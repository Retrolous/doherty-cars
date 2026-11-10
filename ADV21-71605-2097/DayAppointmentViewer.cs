using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Petkunas__Lukas___Doherty_Cars
{


    public partial class DayAppointmentViewer : UserControl
    {
        public DayAppointmentViewer()
        {
            InitializeComponent();
        }

        #region Rendering fields
        // represents the position at which the cursor was when beginning movement i.e. when clicking on a block
        private Point _startingCursorPosition;
        // represents the id of the appointment which has been selected to move
        private int _movingAppointmentID = -1;

        // indicates whether it should be the left or right end of the appointment that should move with the cursor
        private bool _firstHalfMoving = false;

        // stores the last known position of the cursor when executing mouse events
        // allows rendering logic to dynamically update the size of timeblocks as the mouse moves
        private Point _currentCursorPosition;

        // represents the space that the timetable has to render in without appearing cluttered
        private int _workableWidth;
        private int _workableHeight;

        // stores appointment id -> coordinates of the top left and bottom right corners of the rectangle representing each appointment
        // x1, x2, y1, y2
        private Dictionary<int, List<int>> _visibleTimeblockCoordinates = new Dictionary<int, List<int>>();


        // represents the total dimensions of a single hour given the working hours and workable width
        private int _slotWidth;
        private int _slotHeight;

        // represents the empty space horizontally and vertically to prevent the timetable from appearing cluttered
        private const int _horizontalPadding = 60;
        private const int _verticalPadding = 5;
        private const int _fontSize = 15;
        #endregion
        #region Editing fields
        // determines whether clicking on a space will create a new appointment, and whether details for appointments will be loaded on clicking their respective blocks
        public bool InsertMode = false;

        // store the hours that engineers work between so the width of the viewer can be calculated
        // storing it as a tuple like this and then calculating dynamically allows for hours to be changed in the future
        private (int startOfDay, int endOfDay) _dayBounds = (8, 17);

        // the date for which appointments are to be loaded into the timetable
        // set to the current day by default to prevent errors due to uninitialised date
        private DateTime _queryDate = DateTime.Now;

        // stores what is essentially the "initial condition" of each timeblock, before any edits to their dimensions are made
        // contains either the schedules as they were found on the database for existing records
        // or the initial state of a new timeblock
        // this allows for reversal when an invalid action is performed by the user e.g. going out of bounds       
        // stores mechanic id -> their entire schedule
        // dictionary may seem redundant as mechanicscheudle already has mechanic id, but it allows for rapid presence
        // checks when populating MechanicSchedules instead of having to check each existing MechanicSchedule
        private Dictionary<int, MechanicSchedule> _mechanicSchedules = new Dictionary<int, MechanicSchedule>();

        // stores the timeblocks currently displayed on the screen
        // thus, it stores the timeblocks as modified by the user
        private List<MechanicSchedule> _currentDaySchedules = new List<MechanicSchedule>();

        // was needed for scrolling, but no longer needed
        // if scrolling required due to the presence of more mechanics, uncomment this and the appropriate mousescroll event
        // private int stringOffset = 0;

        // id of the appointment which has been selected for editing
        private int _selectedAppointmentID = -1;

        // public property to allow for the calling of an event when the selected appointment is changed
        public int SelectedAppointmentID
        {
            get => _selectedAppointmentID;
            set
            {
                _selectedAppointmentID = value;
                OnValueChanged(EventArgs.Empty);
            }
        }


        // events that the service appointments form can listen to in order to update its fields
        // when a different service appointment is chosen
        public event EventHandler ValueChanged;
        #endregion

        #region Rendering logic
        private void DayAppointments_Load(object sender, EventArgs e)
        {
            // width is the width of the entire available space - padding on each side
            _workableWidth = (pnlDay.Width - 2 * _horizontalPadding);
            // height is the height of the entire available space - padding on each side - space for the labels at the top
            _workableHeight = (pnlDay.Height - 2 * _verticalPadding) - 2 * _fontSize;

            // width of each slot is the working width divided by the number of hours that mechanics work in a day
            _slotWidth = (_workableWidth / (_dayBounds.endOfDay - _dayBounds.startOfDay));


            // height of each slot is a third of the workable height to provide a balance between details and readability
            _slotHeight = (_workableHeight / 3);

            // load schedules from the database
            PopulateSchedules();

            // attach the drawing logic to the panel, and draw the new schedules
            pnlDay.Paint += new PaintEventHandler(DrawAppointments);
            pnlDay.Refresh();

            // remnant from scrolling logic, if more mechanics are added uncomment
            // pnlDay.MouseWheel += new MouseEventHandler(pnlDay_Scroll);


            // set panel to be doublebuffered to prevent jittering when rendering appointments
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlDay, new object[] { true });
        }

        // draw all appointments for the current day
        private void DrawAppointments(object sender, PaintEventArgs e)
        {
            // get the panels graphics object
            var g = e.Graphics;

            // self-explanatory
            DrawTimeLabels(g);
            DrawSlots(g);
            DrawMechanicNameLabels(g);
            DrawTimeblocks(g);
        }

        // draws the labels for each hour in the timetable
        private void DrawTimeLabels(Graphics g)
        {
            // bold bahnschrift size pt 13 font for the labels
            Font TimeFont = new Font(
                new FontFamily("Bahnschrift"),
                _fontSize,
                FontStyle.Bold,
                GraphicsUnit.Pixel
                );

            // #71d7c5 as argb (secondary colour seen throughout the program)
            SolidBrush TimeBrush = new SolidBrush(Color.FromArgb(113, 215, 197));

            // incrementing through each hour that is to be labelled
            for (int i = _dayBounds.startOfDay; i < _dayBounds.endOfDay; i++)
            {
                g.DrawString(
                    // concatenate the current hour in 24 hour format with the minutes ":00" (as appointments will always start at the start of an hour)
                    // for hours that are shorter i.e. 8:00, an extra zero is added at the start to ensure the user understands this is 24-hour format
                    string.Concat(i.ToString(), ":00").PadLeft(5, '0'),
                    TimeFont,
                    TimeBrush,
                    // horizontal padding + zero-indexed position * slotwidth
                    // vertical padding from top
                    // note that the start must be subtracted as we start from the start of the day, not 0
                    new Point(_horizontalPadding + _slotWidth * (i - _dayBounds.startOfDay), _verticalPadding)
                    );
            }
        }

        // draws the empty boxes within which the appointments are to be drawn
        private void DrawSlots(Graphics g)
        {
            // #F2FBF9 as argb
            Pen SlotPen = new Pen(Color.FromArgb(242, 251, 249));
            // for each mechanic
            for (int i = 0; i < _mechanicSchedules.Count; i++)
            {
                // for each time slot
                for (int j = 0; j < (_dayBounds.endOfDay - _dayBounds.startOfDay); j++)
                {
                    // 
                    g.DrawRectangle(SlotPen,
                        new Rectangle(_horizontalPadding + _slotWidth * j, // horizontal padding + all previous slot widths
                        (_verticalPadding + _fontSize + 5) + _slotHeight * i,  // vertical padding + label + all previous slot heights
                        _slotWidth,
                        _slotHeight));
                }
            }
        }

        // draws the mechanics' names beside the rows which display their appointments
        private void DrawMechanicNameLabels(Graphics g)
        {
            // bahnschrift size pt 15 font for the labels
            Font MechanicFont = new Font(new FontFamily("Bahnschrift"), _fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            // #71d7c5 as argb (secondary colour seen throughout the program)
            SolidBrush MechanicBrush = new SolidBrush(Color.FromArgb(113, 215, 197));


            List<string> MechanicNamesOrderedByIndex =
                _mechanicSchedules // all mechanic schedules
                .Values
                .OrderBy((e) => e.Index) // ordered by the indices of their rows
                .Select((e) => e.MechanicName) // select to produce a list of the mechanic names
                .ToList();

            for (int i = 0; i < MechanicNamesOrderedByIndex.Count; i++)
                g.DrawString(MechanicNamesOrderedByIndex[i], // draw the name of the mechanic
                    MechanicFont,
                    MechanicBrush,
                    _horizontalPadding - (2 * _fontSize), // padding between the left edge of the timetable and left side of the panel - 2 * the font size to ensure the label is just to the left of the timetable
                    (_slotHeight / 2) + _slotHeight * i, // half of slotheight + the height of the previous slots. usually adjusts to the centre of the row
                    new StringFormat(StringFormatFlags.DirectionVertical) // render the text vertically
                    );
        }

        // draw each appointment in the timetable as a rectangle
        private void DrawTimeblocks(Graphics g)
        {
            // #71d7c5 as argb
            Brush RectangleBrush = new SolidBrush(Color.FromArgb(113, 215, 197));

            // #2703c1 as argb
            Pen RectangleOutlinePen = new Pen(Color.FromArgb(39, 3, 193), 3);

            // 	#ff9501
            Brush RectangleNewBrush = new SolidBrush(Color.FromArgb(255, 149, 1));

            // 	#f52525
            Pen RectangleNewOutlinePen = new Pen(Color.FromArgb(245, 37, 37), 3);

            // clear the timeblock coordinates from the previous render
            _visibleTimeblockCoordinates.Clear();

            // if this is the first time rendering the timeblocks for that day, populate the schedules for that day first
            if (_currentDaySchedules.Count == 0) _currentDaySchedules = GetDaySchedule();

            // for each schedule in the current day's schedules
            foreach (MechanicSchedule Schedule in _currentDaySchedules)
            {
                // for each timeblock in that schedule
                foreach (Timeblock Timeblock in Schedule.Timeblocks)
                {
                    // the x and y of the timeblock's top-left corner, and its width
                    int x, y, Width;

                    // the rectangle object representing the timeblock graphically
                    Rectangle TimeblockRectangle;

                    // if the current appointment is moving and its graphical representation is to be updated
                    if (Timeblock.AppointmentID == _movingAppointmentID)
                    {
                        // if it's the left half that is to be adjusted
                        if (_firstHalfMoving)
                        {
                            // horizontal padding + the width of the slots before the current appointment - the distance the cursor has moved left
                            x = _horizontalPadding + _slotWidth * (Timeblock.AppointmentStart.Hour - _dayBounds.startOfDay) - (_startingCursorPosition.X - _currentCursorPosition.X);
                            y = (_verticalPadding + _fontSize + 5) + (_slotHeight * Schedule.Index); // vertical padding + font size + slight adjustment to account for border + the height of the slots before the current one
                            Width = _slotWidth * (Timeblock.AppointmentEnd.Hour - Timeblock.AppointmentStart.Hour) + (_startingCursorPosition.X - _currentCursorPosition.X); // slot width * no of hours in appointment + distance cursor has moved left
                            TimeblockRectangle = new Rectangle(x, y, Width, _slotHeight);
                        }
                        else
                        {
                            x = _horizontalPadding + _slotWidth * (Timeblock.AppointmentStart.Hour - _dayBounds.startOfDay); // horizontal padding + the width of the slots before the current appointment
                            y = (_verticalPadding + _fontSize + 5) + (_slotHeight * Schedule.Index); // vertical padding + font size + slight adjustment to account for border + the height of the slots before the current one
                            Width = _slotWidth * (Timeblock.AppointmentEnd.Hour - Timeblock.AppointmentStart.Hour) + (_currentCursorPosition.X - _startingCursorPosition.X);  // slot width * no of hours in appointment + distance cursor has moved right
                            TimeblockRectangle = new Rectangle(x, y, Width, _slotHeight);
                        }
                    }
                    else
                    {
                        // horizontal padding + the width of the slots before the current appointment
                        x = _horizontalPadding + _slotWidth * (Timeblock.AppointmentStart.Hour - _dayBounds.startOfDay);
                        // vertical padding + font size + slight adjustment to account for border + the height of the slots before the current one
                        y = (_verticalPadding + _fontSize + 5) + (_slotHeight * Schedule.Index);
                        // slot width * no of hours in appointment
                        Width = _slotWidth * (Timeblock.AppointmentEnd.Hour - Timeblock.AppointmentStart.Hour);
                        TimeblockRectangle = new Rectangle(x, y, Width, _slotHeight);
                    }

                    // add the rectangle's coordinates to the disctionary
                    _visibleTimeblockCoordinates[Timeblock.AppointmentID] = new List<int> { x, x + Width, y, y + _slotHeight };

                    // if the appointment in question is one that is in the process of being created
                    if (Timeblock.AppointmentID == 0)
                    {
                        g.FillRectangle(RectangleNewBrush, TimeblockRectangle);
                        g.DrawRectangle(RectangleNewOutlinePen, TimeblockRectangle);

                        continue;
                    }

                    // if the appointment is a regular appointment
                    g.FillRectangle(RectangleBrush, TimeblockRectangle);
                    g.DrawRectangle(RectangleOutlinePen, TimeblockRectangle);
                }
            }
        }

        // scrolling logic when more mechanics are displayed than can fit onto the screen
        /* private void pnlDay_Scroll(object sender, MouseEventArgs e)
         {

            *//* scrollFactor =  (e.Delta * SystemInformation.MouseWheelScrollLines / 60);
             stringOffset += scrollFactor;
             foreach(MechanicSchedule schedule in mechanicSchedules.Values)
             {
                 for(int i = 0; i < schedule.Timeblocks.Count; i++)
                 {
                     Rectangle currentRect = schedule.Timeblocks[i].rectangleRepresentation;
                     currentRect.Y = currentRect.Y + scrollFactor;
                     schedule.Timeblocks[i].rectangleRepresentation = currentRect;
                 }

             }

             for (int i = 0; i < calendar.Count; i++)
             {
                 Rectangle currentRect = calendar[i];
                 currentRect.Y = currentRect.Y + scrollFactor;
                 calendar[i] = currentRect;
             }


             pnlDay.Refresh();*//*
         }*/

        #endregion
        #region Editing logic
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        // used to create a timeblock during the "insert mode"
        private void CreateTimeblockBasedOnCursorPosition(Point CursorLocation)
        {
            // calculate which mechanic has been clicked on by reversing the logic used to draw the rows
            int MechanicIndex = (CursorLocation.Y - _verticalPadding - _fontSize - 5) / _slotHeight;

            // find the hour that starts the position that was clicked on, whether it be the start of the current cell or the start or end of the row
            int StartTime = FindLargestTimeLessThanPosition(CursorLocation.X);

            // if outside of the timetable was clicked
            if (StartTime == _dayBounds.endOfDay) StartTime -= 1;

            // initialise the current block to have a length of 1 hour
            int EndTime = StartTime + 1;

            // create this new block with an id of 0 to indicate it is temporary
            // will be stored and manipulated in memory but not in the database
            Timeblock NewTimeblock = new Timeblock(0,
                new DateTime(_queryDate.Year, _queryDate.Month, _queryDate.Day, StartTime, 0, 0),
                 new DateTime(_queryDate.Year, _queryDate.Month, _queryDate.Day, EndTime, 0, 0)
                );


            // get the schedules for the mechanic whose row was selected, and add the new appointment to their schedule
            MechanicSchedule RelevantDaySchedule = _mechanicSchedules.Values
                                            .Where(ms => ms.Index == MechanicIndex)
                                            .FirstOrDefault();

            MechanicSchedule RelevantSchedule = _currentDaySchedules
                                            .Where(ms => ms.Index == MechanicIndex)
                                            .FirstOrDefault();

            if (RelevantDaySchedule != null && RelevantSchedule != null)
            {
                RelevantDaySchedule.Timeblocks.Add(NewTimeblock);
                RelevantSchedule.Timeblocks.Add(NewTimeblock);
            }


            // redraw
            pnlDay.Refresh();
        }

        // activate/deactivate insert mode
        public void SetInsertMode(bool value) => InsertMode = value;

        private void pnlDay_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Location.Y - _verticalPadding - _fontSize - 5) < 0) return;

            // determine the index of the mechanic that was clicked on
            int MechanicIndex = (e.Location.Y - _verticalPadding - _fontSize - 5) / _slotHeight;



            // if there is no such mechanic at that index, return
            if (MechanicIndex >= _currentDaySchedules.Count) return;

            // if the user doesn't have permission to access their colleagues' appointments i.e. it is not their appointment and they do not have "Unrestricted Write" permission, return
            if (_currentDaySchedules[MechanicIndex].MechanicStaffID != CurrentUser.CurrentLoggedInUser.StaffID && CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel() < 2)
            {
                MessageBox.Show("You are not permitted to edit your colleagues' appointments.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            // avoid bugs due to double-clicking
            if (e.Clicks > 1) return;

            // if the user is creating a new appointment
            if (InsertMode)
            {
                // if there is not a temporary timeblock existing in memory
                if (!_visibleTimeblockCoordinates.ContainsKey(0))
                {
                    CreateTimeblockBasedOnCursorPosition(e.Location);

                    // if the time set clashes, just remove and skip
                    if (!IsValidTimeSet(FindLargestTimeLessThanPosition(e.X), 0, false, true))
                    {
                        DeleteAppointment(0);
                        return;
                    }
                }



                // get the coordinates of the temporary block
                // only these will be considered as the "insert mode" ignores existing appointments
                List<int> NewTimeblockCoordinates = _visibleTimeblockCoordinates[0];

                // if the cursor was on the temporary block
                if (
                    NewTimeblockCoordinates[0] < e.Location.X &&
                    e.Location.X < NewTimeblockCoordinates[1] &&
                    e.Location.Y > NewTimeblockCoordinates[2] &&
                    NewTimeblockCoordinates[3] > e.Location.Y
                    )
                {
                    // start moving the temporary block and select it
                    SelectedAppointmentID = _movingAppointmentID = 0;
                    _startingCursorPosition = e.Location;
                    _currentCursorPosition = e.Location;

                    // determine whether the first half was clicked or not by determining whether the cursor was before the halfway point of the appointment
                    if (e.Location.X < (NewTimeblockCoordinates[1] + NewTimeblockCoordinates[0]) / 2) _firstHalfMoving = true;
                    else _firstHalfMoving = false;
                }

                // prevent further evaluation
                return;
            }


            // for each block
            foreach (var kvp in _visibleTimeblockCoordinates)
            {
                // get its coordinates
                List<int> coordinates = kvp.Value;

                // if the cursor was over that block when clicking
                if (
                    coordinates[0] < e.Location.X &&
                    e.Location.X < coordinates[1] &&
                    e.Location.Y > coordinates[2] &&
                    coordinates[3] > e.Location.Y
                    )
                {
                    // select that appointment and start moving it
                    SelectedAppointmentID = _movingAppointmentID = kvp.Key;
                    _startingCursorPosition = e.Location;
                    _currentCursorPosition = e.Location;

                    // determine whether the first half was clicked or not by determining whether the cursor was before the halfway point of the appointment
                    if (e.Location.X < (coordinates[1] + coordinates[0]) / 2) _firstHalfMoving = true;
                    else _firstHalfMoving = false;

                    // prevent further evaluation
                    return;
                }

            }
        }

        private void pnlDay_MouseMove(object sender, MouseEventArgs e)
        {
            // if there is an appointment moving
            if (_movingAppointmentID != -1)
            {
                // update the current cursor position to allow for the determination of the timeblock's new length when comparing to the starting cursor position
                _currentCursorPosition = e.Location;
                pnlDay.Refresh();
            }
        }

        public void DeleteAppointment(int AppointmentID)
        {
            // remove the relevant appointment from the list of timeblocks to prevent further rendering
            _visibleTimeblockCoordinates.Remove(AppointmentID);
            foreach (var schedule in _mechanicSchedules.Values)

            // remove all timeblocks from the schedule with that appointment id
            {
                schedule.Timeblocks.RemoveAll(tb => tb.AppointmentID == AppointmentID);
            }

            foreach (var schedule in _currentDaySchedules)

            // remove all timeblocks from the current day's schedule with that appointment id
            {
                schedule.Timeblocks.RemoveAll(tb => tb.AppointmentID == AppointmentID);
            }


            // rerender
            pnlDay.Refresh();
        }

        private void pnlDay_MouseUp(object sender, MouseEventArgs e)
        {
            // if an appointment has been chosen to move previously
            if (_movingAppointmentID != -1)
            {
                // find the time at which the relevant end of the appointment was dropped closest to
                int Time = FindClosestTime(_firstHalfMoving ? _visibleTimeblockCoordinates[_movingAppointmentID][0] : _visibleTimeblockCoordinates[_movingAppointmentID][1]);

                // and retrieve the timeblock for that appointment
                Timeblock RelevantTimeblock = _mechanicSchedules.Values
                                            .SelectMany(ms => ms.Timeblocks)
                                            .FirstOrDefault(tb => tb.AppointmentID == _movingAppointmentID);

                // if the timeblock was shorter than half an hour when it was dropped (i.e. the end would snap onto the start or vice versa)
                if (_visibleTimeblockCoordinates[_movingAppointmentID][1] - _visibleTimeblockCoordinates[_movingAppointmentID][0] <= _slotWidth * 1 / 2)
                {
                    // output an error message, make no changes, and stop dragging
                    MessageBox.Show("You cannot have an appointment of length 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetDragState();
                    pnlDay.Refresh();
                    return;
                }

                // if the new position would cause conflicts with other appointments or would cause it go out of bounds
                if (!IsValidTimeSet(Time, _movingAppointmentID, !_firstHalfMoving, true))
                {
                    // output an error message, make no changes, and stop dragging
                    MessageBox.Show("New time must not cause the appointment to go beyond the working hours, nor overlap with other appointments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetDragState();
                    pnlDay.Refresh();
                    return;
                }

                // if the validation has been passed
                if (_firstHalfMoving)
                {
                    // update the timeblock with the new time, either modifying the start or the end of the timeblock
                    DateTime RelevantDate = RelevantTimeblock.AppointmentStart;
                    RelevantTimeblock.AppointmentStart = new DateTime(RelevantDate.Year, RelevantDate.Month, RelevantDate.Day, Time, 0, 0);

                    // don't change the selected appointment but trigger the "onchanged" event to ensure that the form displays the most recent start and end times
                    SelectedAppointmentID = SelectedAppointmentID;
                }
                else
                {
                    DateTime RelevantDate = RelevantTimeblock.AppointmentEnd;
                    RelevantTimeblock.AppointmentEnd = new DateTime(RelevantDate.Year, RelevantDate.Month, RelevantDate.Day, Time, 0, 0);
                    SelectedAppointmentID = SelectedAppointmentID;
                }


            }

            // stop dragging and rerender
            ResetDragState();
            pnlDay.Refresh();
        }
        #endregion
        #region Time logic
        // ensure that every appointment in the timetable is valid before attempting to use the "Save New Schedule" functionality
        // as checks will be made to ensure overlaps don't occur in the first place, this will just ensure that sufficient time is provided to complete an appointment
        private List<string> ValidateEntireSchedule()
        {
            // the list that will store an invalid timeblock's appointment id, mechanic name and additional hours required
            List<string> InvalidTimeblockInfo = new List<string>();

            // for each schedule in the timetable
            foreach (MechanicSchedule Schedule in _currentDaySchedules)
            {
                // for each timeblock
                foreach (Timeblock Timeblock in Schedule.Timeblocks)
                {
                    ServiceAppointment SavedAppointment = ServiceAppointment.RetrieveByAppointmentID(Timeblock.AppointmentID);
                    // retrieve the info of the current appointment to be parsed from the database
                    // as "Save New Schedule" is only concerned with times, this will allow for the calculation of required time using the existing information
                    // which only depends on vehicles and services

                    // the time that would be required given the saved vehicle and services
                    int RequiredTime = ServiceAppointment.CalculateTimeRequired(SavedAppointment.ServiceIDsAndRequiredPartIDs, SavedAppointment.VehicleID);

                    // the actual time that has been allocated through user action
                    int AllottedTime = Timeblock.AppointmentEnd.Hour - Timeblock.AppointmentStart.Hour;

                    // if this isn't enough, add the timeblock info to the list
                    if (AllottedTime < RequiredTime) InvalidTimeblockInfo.Add($"{Timeblock.AppointmentID} for {Schedule.MechanicName} - needs {RequiredTime - AllottedTime} more hours");
                }
            }

            // return errors, if any
            return InvalidTimeblockInfo;
        }

        // update the entire timetable with the new times input, ignoring any changes to services, vehicles etc.
        public bool UpdateDaySchedule()
        {
            // check if any timeblocks could not be completed with their provided time
            List<string> InvalidTimeblocks = ValidateEntireSchedule();

            // if any error messages have been provided
            if (InvalidTimeblocks.Count > 0)
            {
                MessageBox.Show("The following timeblocks need amended:\n" + String.Join("\n", InvalidTimeblocks), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // for each schedule
            foreach (MechanicSchedule Schedule in _currentDaySchedules)
            {
                // for each timeblock in that schedule
                foreach (Timeblock Timeblock in Schedule.Timeblocks)
                {
                    // get that appointments info
                    ServiceAppointment SavedAppointment = ServiceAppointment.RetrieveByAppointmentID(Timeblock.AppointmentID);
                    // update that appointment's mechanic and times
                    SavedAppointment.StaffID = Schedule.MechanicStaffID;
                    SavedAppointment.AppointmentStart = Timeblock.AppointmentStart;
                    SavedAppointment.AppointmentEnd = Timeblock.AppointmentEnd;

                    // attempt to save the service appointment with that new time
                    ServiceAppointment.UpdateAppointment(SavedAppointment);
                    // if any errors occur, these will be output each time one occurs in a separate messagebox
                }
            }
            MessageBox.Show("Finished saving.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // success
            return true;
        }

        // set all variables related to dragging to their default values
        private void ResetDragState()
        {
            _movingAppointmentID = -1;
            _firstHalfMoving = false;
            _startingCursorPosition = Point.Empty;
            _currentCursorPosition = Point.Empty;
        }

        public bool AttemptAppointmentMechanicIDChange(int AppointmentID, int NewMechanicID)
        {
            // if the current user does not have "Unrestricted Write" permissions and they are not the mechanic who is going to receive the appointment
            if (Role.RetrieveByRoleID(CurrentUser.CurrentLoggedInUser.RoleID).AuthorisationLevel < 2 && NewMechanicID != CurrentUser.CurrentLoggedInUser.StaffID)
            {
                MessageBox.Show("You can't give your colleague an appointment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // get the coordinates for the appointment
            List<int> RelevantAppointmentCoordinates = _visibleTimeblockCoordinates[AppointmentID];
            // get the schedule of the mechanic who would receive the appointment
            MechanicSchedule NewMechanicIDExistingSchedule = _currentDaySchedules.Where(e => e.MechanicStaffID == NewMechanicID).FirstOrDefault();

            // setting to the same mechanic, conflict not possible as appointment will already be in a valid position
            if (NewMechanicIDExistingSchedule.Timeblocks.Any(e => e.AppointmentID == AppointmentID)) return true;

            foreach (Timeblock Timeblock in NewMechanicIDExistingSchedule.Timeblocks)
            {
                // check for overlap of the timeblocks
                if (RelevantAppointmentCoordinates[0] < _visibleTimeblockCoordinates[Timeblock.AppointmentID][1] && _visibleTimeblockCoordinates[Timeblock.AppointmentID][0] < RelevantAppointmentCoordinates[1])
                {
                    MessageBox.Show("Sorry, this would overlap with an existing appointment belonging to this mechanic.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            // get the id of the mechanic who previously had that appointment
            int OldMechanicID = _currentDaySchedules.Where(e => e.Timeblocks.Any(ex => ex.AppointmentID == AppointmentID)).FirstOrDefault().MechanicStaffID;

            // get the existing timeblock for the appointment that is going to be moved
            Timeblock AppointmentCurrentTimeblock = _currentDaySchedules.Where(e => e.MechanicStaffID == OldMechanicID).FirstOrDefault().Timeblocks.Where(e => e.AppointmentID == AppointmentID).FirstOrDefault();


            // get the schedules of the mechanic who previously owned that appointment, and of the mechanic that will received it
            MechanicSchedule OldCurrentSchedule = _currentDaySchedules
                                            .Where(ms => ms.MechanicStaffID == OldMechanicID)
                                            .FirstOrDefault();

            MechanicSchedule NewCurrentSchedule = _currentDaySchedules
                                            .Where(ms => ms.MechanicStaffID == NewMechanicID)
                                            .FirstOrDefault();

            // swap the appointment in the schedule for the current day
            OldCurrentSchedule.Timeblocks.Remove(AppointmentCurrentTimeblock);
            NewCurrentSchedule.Timeblocks.Add(AppointmentCurrentTimeblock);

            // retrieve the overall schedules
            MechanicSchedule OldSchedule = _mechanicSchedules[OldMechanicID];
            MechanicSchedule NewSchedule = _mechanicSchedules[NewMechanicID];

            // retrieve that same timeblock from the overall schedules
            Timeblock AppointmentTimeblock = _mechanicSchedules[OldMechanicID].Timeblocks.Where(e => e.AppointmentID == AppointmentID).FirstOrDefault();


            // swap the appointment in the overall schedules
            OldSchedule.Timeblocks.Remove(AppointmentTimeblock);
            NewSchedule.Timeblocks.Add(AppointmentTimeblock);

            // rerender
            pnlDay.Refresh();
            return true;
        }

        #endregion
        #region Retrieval logic
        // change the query data by reloading appointment data and filtering by that new date
        public void SetQueryDate(DateTime date)
        {
            _queryDate = date;

            // reload data with the new date
            _mechanicSchedules.Clear();
            _currentDaySchedules.Clear();
            PopulateSchedules();
            pnlDay.Refresh();
        }

        private List<MechanicSchedule> GetDaySchedule()
        {
            // return the mechanic schedules list
            return _mechanicSchedules.Values
               .Select(s => new MechanicSchedule(
                s.MechanicStaffID, // copy over the original mechanic information for that schedule
                s.MechanicName,
                s.Index
            )
               {
                   // but set the timeblocks to be filtered by the currently selected date
                   Timeblocks = s.Timeblocks
                    .Where(tb => tb.AppointmentStart.Date == _queryDate.Date)
                    .ToList()
               })
               .ToList();
        }

        // refresh appointment records by retrieving new appointment data from the database
        public void RefreshRecords()
        {
            // reload appointment data with updated information
            _visibleTimeblockCoordinates.Clear();
            _currentDaySchedules.Clear();
            PopulateSchedules();
            pnlDay.Refresh();
        }

        // fill the schedule dictionary with the latest version of the appointments on the system
        private void PopulateSchedules()
        {
            // clear any old schedules present 
            var keys = _mechanicSchedules.Keys.ToList();

            foreach (var key in keys)
            {
                _mechanicSchedules[key].Timeblocks.Clear();
            }

            // get the latest appointments from the database
            List<ServiceAppointment> AllAppointments = ServiceAppointment.RetrieveAppointments();
            if (AllAppointments == null) { return; }
            foreach (ServiceAppointment Appointment in AllAppointments)
            {
                // if the mechanic has not been processed yet
                if (!_mechanicSchedules.ContainsKey(Appointment.StaffID))
                {
                    _mechanicSchedules.Add(
                        Appointment.StaffID,
                        // staffid, staffname, index based on the number of already existing staff (zero-indexed)
                        new MechanicSchedule(Appointment.StaffID, Staff.RetrieveByStaffID(Appointment.StaffID).Firstname, _mechanicSchedules.Count));
                }

                // add a new timeblock to the mechanics schedule based on that appointment's start and end times
                _mechanicSchedules[Appointment.StaffID]
                    .Timeblocks
                    .Add(new Timeblock(Appointment.AppointmentID, Appointment.AppointmentStart, Appointment.AppointmentEnd));
            }
        }

        // return the schedule which contains the provided appointment id
        private MechanicSchedule ReturnMechanicScheduleInMemory(int ID) => _mechanicSchedules.Values.Where(ms => ms.Timeblocks.Any(tb => tb.AppointmentID == ID)).FirstOrDefault();

        // return the timeblock associated with the provided appointment id
        private Timeblock ReturnTimeblockInMemory(int ID) => _mechanicSchedules.Values.SelectMany(ms => ms.Timeblocks).FirstOrDefault(tb => tb.AppointmentID == ID);

        // return the start of the provided appointment id
        public DateTime GetAppointmentStart(int ID) => ReturnTimeblockInMemory(ID).AppointmentStart;

        // return the end of the provided appointment id
        public DateTime GetAppointmentEnd(int ID) => ReturnTimeblockInMemory(ID).AppointmentEnd;

        // return the mechanic associated with the provided appointment id
        public int GetAppointmentMechanicID(int ID) => ReturnMechanicScheduleInMemory(ID).MechanicStaffID;

        // return a list of all mechanics that have appointments associated with them
        public List<int> ReturnMechanics() => _mechanicSchedules.Keys.ToList();

        // find the hour which is closest to the position provided
        private int FindClosestTime(int X)
        {
            // if the position is before the timetable
            if (X - (_horizontalPadding) < 0) return _dayBounds.startOfDay;

            // if the position is after the timetable
            if (X > (_horizontalPadding + (_slotWidth * (_dayBounds.endOfDay - _dayBounds.startOfDay)))) return _dayBounds.endOfDay;

            // check each hour to find the first one whose slot would be greater than the position provided
            // then check to see whether the position would be closer to that hour or the one before it
            for (int i = _dayBounds.startOfDay; i <= _dayBounds.endOfDay + 1; i++)
            {
                int ComparisonValue = X - (_horizontalPadding + _slotWidth * (i - _dayBounds.startOfDay));

                if (ComparisonValue < 0)
                    return (ComparisonValue < -(_slotWidth * 1 / 2)) ? i - 1 : i;
            }


            // base case if no time was found, but should be impossible as the checks cover all possible ranges (before, in and after the timetable)
            return 0;
        }


        // find the first hour before the position provided
        private int FindLargestTimeLessThanPosition(int X)
        {
            // if the position is before the timetable, return the start of the day
            if (X - (_horizontalPadding) < 0) return _dayBounds.startOfDay;

            // if the position is after, return the end of the day
            if (X > (_horizontalPadding + (_slotWidth * (_dayBounds.endOfDay - _dayBounds.startOfDay)))) return _dayBounds.endOfDay;

            // check each hour to see the first one that is greater than the position, and then return the one before that
            for (int i = _dayBounds.startOfDay; i <= _dayBounds.endOfDay; i++)
            {
                int ComparisonValue = X - (_horizontalPadding + _slotWidth * (i - _dayBounds.startOfDay));

                if (ComparisonValue < 0)
                    return (i - 1);
            }


            // base case if no time was found, but should be impossible as the checks cover all possible ranges (before, in and after the timetable)
            return 0;
        }


        // determine whether the new time provided for the appropriate appointment would be valid
        private bool IsValidTimeSet(int Time, int AppointmentID, bool SetEnd, bool DueToDragging)
        {
            // can't have an appointment out of bounds
            if (Time < _dayBounds.startOfDay || Time > _dayBounds.endOfDay)
                return false;

            // get the original start and end times

            int SavedStartHour = ReturnTimeblockInMemory(AppointmentID).AppointmentStart.Hour;
            int SavedEndHour = ReturnTimeblockInMemory(AppointmentID).AppointmentEnd.Hour;

            // if the new time would be the end of the appointment
            if (SetEnd)
            {
                // if the new end time would be before the current start time
                if (Time < SavedStartHour + 1) return false;
            }
            else
            {
                // if the new start time would be after the current end time
                if (Time > SavedEndHour - 1) return false;
            }

            // offset used when determining the new coordinates of the current appointment
            // if the new time was set using the datetimepicker controls provided, there will have been no change to the position
            // of the timeblocks and instead this must be accommodated for manually
            int Offset;
            if (DueToDragging) Offset = 0;
            else Offset = _slotWidth;

            // get the coordinates of the appropriate timeblock
            List<int> SelectedAppointmentCoordinates = _visibleTimeblockCoordinates[AppointmentID].ToList();

            // adjust the timeblock postions if the time was set using the datetimepickers
            // if dragging, the position is set dynamically so this is not required
            if (SetEnd)
            {
                if (Time < SavedEndHour) SelectedAppointmentCoordinates[1] -= Offset;
                else SelectedAppointmentCoordinates[1] += Offset;
            }
            else
            {
                if (Time < SavedStartHour) SelectedAppointmentCoordinates[0] -= Offset;
                else SelectedAppointmentCoordinates[0] += Offset;
            }

            // get a list of ids for all appointments in the same row as the appointment whose time is to be set
            List<int> RelatedAppointmentIDs =
                _currentDaySchedules
                    .Where(ms => ms.Timeblocks.Any(tb => tb.AppointmentID == AppointmentID))
                    .FirstOrDefault()
                    .Timeblocks
                    .Select(tb => tb.AppointmentID)
                    .ToList();

            // for each set of coordinates stored
            foreach (KeyValuePair<int, List<int>> kvp in _visibleTimeblockCoordinates)
            {
                // if the coordinates are not in the current row or they are of the appointment to be modified
                if (!RelatedAppointmentIDs.Contains(kvp.Key) || kvp.Key == AppointmentID) continue;

                // if there are any overlaps
                if (SelectedAppointmentCoordinates[0] < kvp.Value[1] && kvp.Value[0] < SelectedAppointmentCoordinates[1]) return false;

            }

            // the time would be valid if set
            return true;
        }


        public bool SetAppointmentTime(DateTime DateTime, int AppointmentID, bool SetEnd)
        {
            // check if the time set would be valid
            if (!IsValidTimeSet(DateTime.Hour, AppointmentID, SetEnd, false))
            {
                MessageBox.Show("New time must not cause the appointment to go beyond the working hours, nor overlap with other appointments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // get the relevant timeblock object in memory, adjust its times, and then rerender
            Timeblock RelevantTimeblock = ReturnTimeblockInMemory(AppointmentID);
            if (SetEnd)
            {
                RelevantTimeblock.AppointmentEnd = DateTime;
            }
            else
            {
                RelevantTimeblock.AppointmentStart = DateTime;
            }
            pnlDay.Refresh();
            return true;
        }
        #endregion

        
    }
}
