using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmServiceAppointments : Form
    {
        // indicates whether changing the value of a control is to activate its attached event
        private bool _ignoreChangeEvent = true;

        // the time required for the current appointment
        private int _timeRequired = 0;
        // the cost of the current appointment
        private decimal _cost = 0;

        // indicates whether new appointment are being added, or the current appointments are being modified
        private bool _insertModeEnabled = false;
        // the id of the mechanic carrying out the appointment
        private int _selectedMechanicID = 0;
        public frmServiceAppointments()
        {
            InitializeComponent();
        }

        // the id of the appointment to be edited
        private int _selectedAppointment = -1;
        // the control within which appointments are displayed and selected
        private DayAppointmentViewer _viewer = new DayAppointmentViewer();
        // dictionary of service -> required parts -> quantity
        private Dictionary<int, Dictionary<int, int>> _currentServiceIDsAndPartIDs = new Dictionary<int, Dictionary<int, int>>();

        #region Create
        // attempt to add an appointment to the table
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dtpAppointmentEnd.Value.Hour - dtpAppointmentStart.Value.Hour < _timeRequired)
            {
                MessageBox.Show("It is impossible (or at least very unlikely) the appointment will be completed in the allotted time. Either remove some services, or service a less complex car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // no appointment has been created
            if (_selectedAppointment == -1)
            {
                MessageBox.Show("You must create a timeblock by clicking on the desired time within the schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboVehicleID.SelectedItem == null)
            {
                MessageBox.Show("You must select a vehicle to service!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboMechanicID.SelectedItem == null)
            {
                MessageBox.Show("There must be a mechanic to service a car!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // carry out basic validation to ensure the appointment would form a valid object
            List<string> validationErrors = ServiceAppointment.ValidateAppointment(
               Int32.Parse(((ComboBoxItem)comboVehicleID.SelectedItem).HiddenValue),
               Int32.Parse(((ComboBoxItem)comboMechanicID.SelectedItem).HiddenValue),
               dtpAppointmentStart.Value,
               dtpAppointmentEnd.Value);

            if (validationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", validationErrors), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // create a new appointment object, and attempt to add that to the database
                string addingMessage = ServiceAppointment.AddAppointment(new ServiceAppointment(
                  0,
                  Int32.Parse(((ComboBoxItem)comboVehicleID.SelectedItem).HiddenValue),
                  Int32.Parse(((ComboBoxItem)comboMechanicID.SelectedItem).HiddenValue),
                  dtpAppointmentStart.Value,
                  dtpAppointmentEnd.Value,
                  chkPaid.Checked,
                  chkCompleted.Checked,
                  chkDiscounted.Checked,
                  _currentServiceIDsAndPartIDs));

                if (addingMessage == null)
                {
                    MessageBox.Show("Appointment has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.WriteLog(Logging.LogType.Create, $"appointment ({dtpAppointmentStart.Value.ToLongDateString()})");
                }
                else
                {
                    string messageboxValue = "Appointment was not added:\n" + addingMessage;
                    MessageBox.Show(messageboxValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            LoadFormDefaults(false);
            _viewer.RefreshRecords();
        }
        #endregion
        #region Retrieve
        // validation ADD
        private void PopulateMechanicsList()
        {
            List<int> MechanicIDs = _viewer.ReturnMechanics();

            // if no mechanics could be loaded, prevent any further editing
            if (MechanicIDs.Count == 0)
            {
                MessageBox.Show("No appointments could be loaded for any mechanics. Please manually insert at least one appointment for a mechanic before attempting to load their appointments.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }

            // add each staff member to the combobox
            foreach (int id in MechanicIDs)
            {
                Staff staff = Staff.RetrieveByStaffID(id);
                string roleName = Role.RetrieveByRoleID(staff.RoleID).Name;
                comboMechanicID.Items.Add(new ComboBoxItem($"{staff.StaffID} - {staff.Firstname} {staff.Surname} - {roleName}", Convert.ToString(staff.StaffID)));
                comboMechanicSearch.Items.Add(new ComboBoxItem($"{staff.StaffID} - {staff.Firstname}", Convert.ToString(staff.StaffID)));
            }
        }

        private void PopulateVehiclesList()
        {
            // get all vehicles
            List<Vehicle> Vehicles = Vehicle.RetrieveVehicles();

            if (Vehicles == null || Vehicles.Count == 0)
            {
                MessageBox.Show("No vehicles could be loaded. Please check the vehicles table before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }

            // add each vehicle to the combobox
            foreach (Vehicle vehicle in Vehicles)
            {

                string ownerName = "";
                if (vehicle.CustomerID != null)
                {
                    Customer owner = Customer.RetrieveByCustomerID((int)vehicle.CustomerID);
                    ownerName = $" - {owner.FirstName} {owner.Surname}";
                }

                comboVehicleID.Items.Add(new ComboBoxItem($"{vehicle.VehicleID} - {vehicle.Make} {vehicle.Model}" + ownerName, Convert.ToString(vehicle.VehicleID)));

                comboVehicleSearch.Items.Add(new ComboBoxItem($"{vehicle.VehicleID} - {vehicle.Make} {vehicle.Model}", Convert.ToString(vehicle.VehicleID)));
            }
        }

        private void PopulateServicesList()
        {
            List<Service> Services = Service.RetrieveServices();

            if (Services == null)
            {
                MessageBox.Show("No services could be loaded. Please check the services table before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }

            foreach (Service service in Services)
            {
                chklbServices.Items.Add(new ComboBoxItem($"{service.Name} (£{service.Price})", Convert.ToString(service.ServiceID)));
            }
        }
        private void PopulateAppointmentDetails()
        {

            // if insert mode is enabled, the appointment id in memory will be 0. no services, parts etc. will be present yet so these may be skipped
            if (_insertModeEnabled)
            {
                txtAppointmentID.Text = "0";
                comboMechanicID.SelectedItem = comboMechanicID.Items
               .Cast<ComboBoxItem>()
               .Where(g => Convert.ToInt32(g.HiddenValue) == _viewer.GetAppointmentMechanicID(0))
               .FirstOrDefault();
                _ignoreChangeEvent = true;
                dtpAppointmentStart.Value = _viewer.GetAppointmentStart(0);
                dtpAppointmentEnd.Value = _viewer.GetAppointmentEnd(0);
                _ignoreChangeEvent = false;
                comboVehicleID.SelectedIndex = 0;
                return;
            }

            ServiceAppointment edit = ServiceAppointment.RetrieveByAppointmentID(_selectedAppointment);
            // else, retrieve the details of the appointment as it exists in the database and viewer and populate its details
            if (edit != null)
            {
                txtAppointmentID.Text = edit.AppointmentID.ToString();
                chkPaid.Checked = edit.Paid;
                chkCompleted.Checked = edit.Completed;
                chkDiscounted.Checked = edit.Discounted;
                comboMechanicID.SelectedItem = comboMechanicID.Items
               .Cast<ComboBoxItem>()
               .Where(g => Convert.ToInt32(g.HiddenValue) == _viewer.GetAppointmentMechanicID(edit.AppointmentID))
               .FirstOrDefault();



                // first or default is validation
                comboVehicleID.SelectedItem = comboVehicleID.Items
               .Cast<ComboBoxItem>()
               .Where(g => Convert.ToInt32(g.HiddenValue) == edit.VehicleID)
               .FirstOrDefault();

                _currentServiceIDsAndPartIDs = edit.ServiceIDsAndRequiredPartIDs;

                // ignore change event to ensure changing times does not inappropriately trigger validation
                _ignoreChangeEvent = true;
                dtpAppointmentStart.Value = _viewer.GetAppointmentStart(_selectedAppointment);
                dtpAppointmentEnd.Value = _viewer.GetAppointmentEnd(_selectedAppointment);
                _ignoreChangeEvent = false;

                UpdateServiceParts(); // update the controls with the services, parts, time and cost of the appointment
                UpdateTimeAndCost();


                // ignore change event to ensure that checking the services does not cause the services to be double counted in the treeview, as they've been
                // include via UpdateServiceParts
                _ignoreChangeEvent = true;

                // uncheck all services i.e. reset their state
                for (int i = 0; i < chklbServices.Items.Count; i++)
                {
                    chklbServices.SetItemChecked(i, false);
                }

                // then check each item in the checked list box that represents a service in the appointment
                foreach (int service in edit.ServiceIDsAndRequiredPartIDs.Keys)
                {
                    // set the service to be checked
                    chklbServices.SetItemChecked(
                        chklbServices
                        .Items
                        .IndexOf(chklbServices
                                    .Items
                                    .Cast<ComboBoxItem>()
                                    .Where((e) => Int32.Parse(e.HiddenValue) == service)
                                    .FirstOrDefault())
                        , true);
                }
                _ignoreChangeEvent = false;

                // then add all services to the combobox for adding/removing parts to a service
                comboAppointmentServices.Items.Clear();
                foreach (ComboBoxItem checkeditem in chklbServices.CheckedItems)
                {
                    Service checkedService = Service.RetrieveByServiceID(int.Parse(checkeditem.HiddenValue));

                    comboAppointmentServices.Items.Add(new ComboBoxItem($"{checkedService.Name}", checkeditem.HiddenValue));
                }


            }
        }
        private void PopulatePartsList()
        {
            comboParts.Items.Clear();
            List<Part> Parts = Part.RetrieveParts();

            if (Parts == null)
            {
                MessageBox.Show("No parts could be loaded. Please check the parts table before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockDownForm();
                return;
            }

            foreach (Part part in Parts)
            {
                comboParts.Items.Add(new ComboBoxItem($"{part.Name} - £{part.SellPrice.ToString("0.00")} - {part.Quantity} available", Convert.ToString(part.PartID)));
            }

            comboParts.Text = "";
        }

        private void frmServiceAppointments_Load(object sender, EventArgs e)
        {
            // attach the changing of appointment times in the viewer to the method in this form
            _viewer.ValueChanged += HandleChangedValue;

            // set default values for the search comboboxes
            comboMechanicSearch.Items.Add(new ComboBoxItem("None", null));
            comboMechanicSearch.SelectedIndex = 0;
            comboVehicleSearch.Items.Add(new ComboBoxItem("None", null));
            comboVehicleSearch.SelectedIndex = 0;


            pnlViewer.Controls.Add(_viewer);
            PopulateVehiclesList();
            PopulateServicesList();
            PopulatePartsList();

            // load form defaults, preventing editing
            LoadFormDefaults(false);


            // ensure that the default day is not invalid
            if (dtpAppointmentDate.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                dtpAppointmentDate.Value = dtpAppointmentDate.Value.AddDays(2);
            }
            else if (dtpAppointmentDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                dtpAppointmentDate.Value = dtpAppointmentDate.Value.AddDays(1);
            }

            PopulateMechanicsList();
        }
        #endregion
        #region Update
        // updates the services -> parts list
        // clears all existing nodes
        // then creates a root node with the name of each service
        // then creates a child node for each part, with its name and quantity, under the appropriate root node
        private void UpdateServiceParts()
        {
            tvServiceParts.Nodes.Clear();

            foreach (var kvp in _currentServiceIDsAndPartIDs)
            {
                List<TreeNode> partNodes = new List<TreeNode>();
                foreach (var partIDAndQuantity in kvp.Value)
                {
                    Part relevantPart = Part.RetrieveByPartID(partIDAndQuantity.Key);
                    partNodes.Add(new TreeNode($"{relevantPart.Name} - {partIDAndQuantity.Value}") { Tag = new List<int> { partIDAndQuantity.Key, partIDAndQuantity.Value } });
                }

                TreeNode serviceNode = new TreeNode(Service.RetrieveByServiceID(kvp.Key).Name) { Tag = kvp.Key };
                serviceNode.Nodes.AddRange(partNodes.ToArray());

                tvServiceParts.Nodes.Add(serviceNode);
            }
        }
        private void UpdateTimeAndCost()
        {
            // if there is a vehicle selected, calculate the time using its complexity and the parts and services required
            _timeRequired = (comboVehicleID.SelectedIndex < 0 || ((ComboBoxItem)comboVehicleID.SelectedItem).HiddenValue == null) ? 0 : ServiceAppointment.CalculateTimeRequired(_currentServiceIDsAndPartIDs, int.Parse(((ComboBoxItem)comboVehicleID.SelectedItem).HiddenValue));
            _cost = ServiceAppointment.CalculateCost(_currentServiceIDsAndPartIDs) * (chkDiscounted.Checked ? 0.9m : 1m); // calculate the cost, ensuring the discount is applied
            lblTimeRequiredValue.Text = _timeRequired + " hours";
            lblCostValue.Text = _cost.ToString("C", new CultureInfo("en-GB"));
        }

        private void HandleChangedValue(object sender, EventArgs e)
        {
            _selectedAppointment = _viewer.SelectedAppointmentID;

            if (_selectedAppointment != -1)
            {
                if (_viewer.GetAppointmentMechanicID(_selectedAppointment) != CurrentUser.CurrentLoggedInUser.StaffID && CurrentUser.CurrentLoggedInUser.GetAuthorisationLevel() < 2)
                {
                    toggleEditable(false);
                }
                else
                {
                    toggleEditable(true);
                }
                PopulateAppointmentDetails();
            }
        }

        // save only updated times for the current day, not any details regardign appointments
        private void btnSaveScheduleOnly_Click(object sender, EventArgs e)
        {

            DialogResult newDialog = MessageBox.Show("Are you sure that you want to overwrite changes? This will save ALL changes made to the times of appointments on-screen, but will not save any modified details.", "Save changes", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                // if successful then refresh to ensure that the changes are applied in memory, otherwise allow the user to amend the appointments by keeping them as they are
                // a message will be output indicating the invalid appointments
                bool Success = _viewer.UpdateDaySchedule();
                if (Success) _viewer.RefreshRecords();

                Logging.WriteLog(Logging.LogType.Update, "multiple service appointments occurring on " + dtpAppointmentDate.Value.ToLongDateString());
            }
        }

        // attempt to update an existing appointment in memory
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpAppointmentEnd.Value.Hour - dtpAppointmentStart.Value.Hour < _timeRequired)
            {
                MessageBox.Show("It is impossible (or at least very unlikely) the appointment will be completed in the allotted time. Either remove some services, or service a less complex car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // no appointment has been selected
            if (_selectedAppointment == -1)
            {
                MessageBox.Show("Select an appointment to modify first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validate the appointment to ensure that a valid appointment object could be created
            List<string> ValidationErrors = ServiceAppointment.ValidateAppointment(
                Int32.Parse(((ComboBoxItem)comboVehicleID.SelectedItem).HiddenValue),
                Int32.Parse(((ComboBoxItem)comboMechanicID.SelectedItem).HiddenValue),
                dtpAppointmentStart.Value,
                dtpAppointmentEnd.Value);

            if (ValidationErrors.Any())
            {
                MessageBox.Show("- " + string.Join("\n- ", ValidationErrors), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult newDialog = MessageBox.Show("Are you sure that you want to overwrite changes?", "Save changes", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                try
                {
                    // attempt to save the appointment
                    ServiceAppointment.UpdateAppointment(new ServiceAppointment(
                  Int32.Parse(txtAppointmentID.Text),
                  Int32.Parse(((ComboBoxItem)comboVehicleID.SelectedItem).HiddenValue),
                  Int32.Parse(((ComboBoxItem)comboMechanicID.SelectedItem).HiddenValue),
                  dtpAppointmentStart.Value,
                  dtpAppointmentEnd.Value,
                  chkPaid.Checked,
                  chkCompleted.Checked,
                  chkDiscounted.Checked,
                  _currentServiceIDsAndPartIDs));
                    MessageBox.Show("Save successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _viewer.RefreshRecords();
                }
                catch (Exception ex) { MessageBox.Show("Save unsuccessful:\n - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            else
            {
                return;
            }
            Logging.WriteLog(Logging.LogType.Update, $"appointment {txtAppointmentID.Text} ({dtpAppointmentStart.Value.ToLongDateString()})");
            LoadFormDefaults(false);
        }

        // handles a changed service appointment id in the viewer by populating its details
        #endregion
        #region Delete
        // attempts to delete the selected appointment
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // if insert mode has been selected,
            if (_insertModeEnabled)
            {
                _viewer.DeleteAppointment(0);
                LoadFormDefaults(false);
                return;
            }

            // if no appointment has been selected
            if (_selectedAppointment == -1)
            {
                MessageBox.Show("Select an appointment to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // verify that the user wishes to delete the appointment
            DialogResult newDialog = MessageBox.Show("Are you sure you wish to delete the selected appointment?", "Warning!", MessageBoxButtons.YesNo);
            if (newDialog == DialogResult.Yes)
            {
                // if there is an error message, output it
                _viewer.DeleteAppointment(Convert.ToInt32(txtAppointmentID.Text));
                string message = ServiceAppointment.DeleteAppointment(Convert.ToInt32(txtAppointmentID.Text));
                if (message != null) MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Logging.WriteLog(Logging.LogType.Delete, $"appointment {txtAppointmentID.Text} ({dtpAppointmentStart.Value.ToLongDateString()})");
            }
            else
            {
                return;
            }

            LoadFormDefaults(false);

        }
        #endregion
        #region Search
        // carry out a search based on vehicle and mechanic, outputting a messagebox with relevant appointments
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ServiceAppointment> filteredAppointments;
            List<ServiceAppointment> allAppointments = ServiceAppointment.RetrieveAppointments();
            string selectedStaffID = ((ComboBoxItem)comboMechanicSearch.SelectedItem).HiddenValue;
            string selectedVehicleID = ((ComboBoxItem)comboVehicleSearch.SelectedItem).HiddenValue;

            if (selectedStaffID == null && selectedVehicleID == null)
            {
                MessageBox.Show("You must select something to search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (selectedStaffID == null && selectedVehicleID != null)
            {
                filteredAppointments = allAppointments.Where(ex => ex.VehicleID == int.Parse(selectedVehicleID)).ToList();
            }
            else if (selectedStaffID != null && selectedVehicleID == null)
            {
                filteredAppointments = allAppointments.Where(ex => ex.StaffID == int.Parse(selectedStaffID)).ToList();
            }
            else
            {
                filteredAppointments = allAppointments.Where(ex => ex.StaffID == int.Parse(selectedStaffID) && ex.VehicleID == int.Parse(selectedVehicleID)).ToList();
            }

            if (filteredAppointments.Count == 0)
            {
                MessageBox.Show("No appointments were found with the given criteria.", "Oops!", MessageBoxButtons.OK);
            }
            else
            {
                string message = "";

                foreach (ServiceAppointment appointment in filteredAppointments)
                {
                    message += $"\n{appointment.AppointmentID} - {appointment.AppointmentStart.ToLongDateString()} - {((appointment.Completed) ? "Completed" : "Not Completed")}";
                }

                MessageBox.Show(message, "The following appointments matched your description:", MessageBoxButtons.OK);
            }
        }
        #endregion
        #region Misc
        private void LockDownForm()
        {
            pnlViewer.Controls.Clear();
            toggleEditable(false);
            dtpAppointmentDate.Enabled = false;
            chkInsertMode.Visible = false;

            comboVehicleSearch.Enabled = false;
            comboMechanicSearch.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpServiceAppointments frm = new frmHelpServiceAppointments();
            frm.Show();

        }

        // determines whether it is possible to use the form to edit appointments
        private void toggleEditable(bool state)
        {
            chklbServices.Enabled = state;
            tvServiceParts.Enabled = state;
            btnPartPlus.Enabled = state;
            btnPartMinus.Enabled = state;
            comboAppointmentServices.Enabled = state;
            comboParts.Enabled = state;
            comboMechanicID.Enabled = state;
            comboVehicleID.Enabled = state;
            dtpAppointmentStart.Enabled = state;
            dtpAppointmentEnd.Enabled = state;
            chkPaid.Enabled = state;
            chkDiscounted.Enabled = state;
            chkCompleted.Enabled = state;
            btnAdd.Enabled = state;
            btnSave.Enabled = state;
            btnDelete.Enabled = state;
            btnSaveScheduleOnly.Enabled = state;
        }



        // set the form to its initial state
        private void LoadFormDefaults(bool forInsertMode)
        {
            _ignoreChangeEvent = true;
            tvServiceParts.Nodes.Clear();
            _currentServiceIDsAndPartIDs.Clear();
            for (int i = 0; i < chklbServices.Items.Count; i++)
            {
                chklbServices.SetItemChecked(i, false);
            }

            comboAppointmentServices.Items.Clear();
            txtAppointmentID.Text = "";
            chkPaid.Checked = false;
            chkDiscounted.Checked = false;
            chkCompleted.Checked = false;

            // if the form is not being reset because insertmode has been toggled
            if (!forInsertMode) chkInsertMode.Checked = false;


            _selectedAppointment = -1;
            _viewer.RefreshRecords();
            PopulatePartsList();
            toggleEditable(false);
            _ignoreChangeEvent = false;
            lblTimeRequiredValue.Text = "";
            lblCostValue.Text = "";
        }




        #endregion
        #region Edit
        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            // ensure that the date selected is not the weekend before attempting to load appointments for the relevant date
            if (dtpAppointmentDate.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                MessageBox.Show("We're closed during the weekend!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpAppointmentDate.Value = dtpAppointmentDate.Value.AddDays(2);
            }
            else if (dtpAppointmentDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("We're closed during the weekend!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpAppointmentDate.Value = dtpAppointmentDate.Value.AddDays(1);
            }
            _viewer.SetQueryDate(dtpAppointmentDate.Value);
            LoadFormDefaults(false);
        }

        // if the appointment start time has changed
        private void dtpAppointmentStart_ValueChanged(object sender, EventArgs e)
        {
            // prevent validation due to populating data
            if (_ignoreChangeEvent) return;

            // attempt to set the appointment time in the viewer
            bool result = _viewer.SetAppointmentTime(dtpAppointmentStart.Value, int.Parse(txtAppointmentID.Text), false);

            if (!result)
            {
                // if the time was invalid, reset the time
                _ignoreChangeEvent = true;
                dtpAppointmentStart.Value = _viewer.GetAppointmentStart(int.Parse(txtAppointmentID.Text));
                _ignoreChangeEvent = false;
            }
        }

        // same method as above, but for appointment end time
        private void dtpAppointmentEnd_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreChangeEvent) return;
            bool result = _viewer.SetAppointmentTime(dtpAppointmentEnd.Value, int.Parse(txtAppointmentID.Text), true);

            if (!result)
            {
                _ignoreChangeEvent = true;
                dtpAppointmentEnd.Value = _viewer.GetAppointmentEnd(int.Parse(txtAppointmentID.Text));
                _ignoreChangeEvent = false;
            }
        }

        // prevent the typing in of time
        private void dtpAppointmentEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtpAppointmentStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPartMinus_Click(object sender, EventArgs e)
        {
            if (comboAppointmentServices.SelectedItem == null)
            {
                MessageBox.Show("No service has been chosen to remove a part from.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboParts.SelectedItem == null)
            {
                MessageBox.Show("No part has been chosen to remove from the service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get the id of the part and service
            int relevantServiceID = int.Parse(((ComboBoxItem)comboAppointmentServices.SelectedItem).HiddenValue);
            int relevantPartID = int.Parse(((ComboBoxItem)comboParts.SelectedItem).HiddenValue);

            // prevent removal of nonexistent items
            if (!_currentServiceIDsAndPartIDs[relevantServiceID].ContainsKey(relevantPartID))
            {
                MessageBox.Show("The current service doesn't have any of the selected item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get the nodes for the service and part
            var serviceNode = tvServiceParts.Nodes
                .Cast<TreeNode>()
                .First(n => (int)n.Tag == relevantServiceID);

            var partNode = serviceNode.Nodes
                .Cast<TreeNode>()
                .First(n => ((List<int>)n.Tag)[0] == relevantPartID);

            // remove one part from memory
            _currentServiceIDsAndPartIDs[relevantServiceID][relevantPartID]--;

            // get the updated quantity
            int qty = _currentServiceIDsAndPartIDs[relevantServiceID][relevantPartID];

            // if there is none left, remove from memory and tree
            if (qty == 0)
            {
                _currentServiceIDsAndPartIDs[relevantServiceID].Remove(relevantPartID);
                serviceNode.Nodes.Remove(partNode);
            }
            else
            { // update the text to reflect the new quantity
                partNode.Text = $"{Part.RetrieveByPartID(relevantPartID).Name} - {qty}";
                partNode.Tag = new List<int> { relevantPartID, qty };
            }

            UpdateTimeAndCost();
        }

        private void btnPartPlus_Click(object sender, EventArgs e)
        {

            if (comboAppointmentServices.SelectedItem == null)
            {
                MessageBox.Show("No service has been chosen to add a part to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboParts.SelectedItem == null)
            {
                MessageBox.Show("No part has been chosen to add to a service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // get the id of the part and service
            int relevantServiceID = int.Parse(((ComboBoxItem)comboAppointmentServices.SelectedItem).HiddenValue);
            int relevantPartID = int.Parse(((ComboBoxItem)comboParts.SelectedItem).HiddenValue);
            Part relevantPart = Part.RetrieveByPartID(relevantPartID);
            // if doesn't exist yet, add as an empty part
            if (!_currentServiceIDsAndPartIDs[relevantServiceID].ContainsKey(relevantPartID)) _currentServiceIDsAndPartIDs[relevantServiceID][relevantPartID] = 0;

            int runningTotal = 0;

            foreach (var kvp in _currentServiceIDsAndPartIDs)
            {
                if (kvp.Value.ContainsKey(relevantPartID)) runningTotal += kvp.Value[relevantPartID];
            }
            // if adding would cause it to go over the amount available in inventory
            if (runningTotal + 1 > relevantPart.Quantity)
            {
                MessageBox.Show("You don't have enough of this part in stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get the appropriate nodes
            var serviceNode = tvServiceParts.Nodes
                .Cast<TreeNode>()
                .First(n => (int)n.Tag == relevantServiceID);

            var partNode = serviceNode.Nodes
                .Cast<TreeNode>()
                .FirstOrDefault(n => ((List<int>)n.Tag)[0] == relevantPartID);

            // update quantity in memory
            _currentServiceIDsAndPartIDs[relevantServiceID][relevantPartID]++;

            int qty = _currentServiceIDsAndPartIDs[relevantServiceID][relevantPartID];

            // add a new node with the part name and quantity
            if (partNode != null) serviceNode.Nodes.Remove(partNode);
            serviceNode.Nodes.Add(new TreeNode($"{relevantPart.Name} - {qty}") { Tag = new List<int> { relevantPartID, qty } });

            UpdateTimeAndCost();
        }

        private void chklbServices_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // prevent any changes occurring due to population of fields
            if (_ignoreChangeEvent) return;

            // get the service id that has been checked
            int serviceID = Int32.Parse(((ComboBoxItem)chklbServices.Items[e.Index]).HiddenValue);

            // if the service has been checked
            if (e.NewValue == CheckState.Checked)
            {
                // reflect this change by adding the service to the dictionary, combobox and treelist
                Service newService = Service.RetrieveByServiceID(serviceID);
                _currentServiceIDsAndPartIDs.Add(serviceID, new Dictionary<int, int>());
                tvServiceParts.Nodes.Add(new TreeNode(newService.Name) { Tag = serviceID });
                comboAppointmentServices.Items.Add(new ComboBoxItem($"{newService.Name}", Convert.ToString(serviceID)));
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // otherwise remove from the same dictionary and controls
                _currentServiceIDsAndPartIDs.Remove(serviceID);
                var serviceNode = tvServiceParts.Nodes
                    .Cast<TreeNode>()
                    .First(n => (int)n.Tag == serviceID);
                ComboBoxItem serviceItem = comboAppointmentServices.Items.Cast<ComboBoxItem>().Where((ex) => ex.HiddenValue == Convert.ToString(serviceID)).FirstOrDefault();
                comboAppointmentServices.Items.Remove(serviceItem);
                tvServiceParts.Nodes.Remove(serviceNode);
            }

            UpdateTimeAndCost();
            comboAppointmentServices.SelectedItem = null;
            comboParts.SelectedItem = null;
        }

        // alternate between insertmode
        private void chkInsertMode_CheckedChanged(object sender, EventArgs e)
        {
            LoadFormDefaults(true);


            _insertModeEnabled = chkInsertMode.Checked;

            // toggle the visiblity of the appropriate buttons based on whether insert mode has been toggled
            btnAdd.Visible = _insertModeEnabled;
            btnSave.Visible = btnSaveScheduleOnly.Visible = !_insertModeEnabled;

            _viewer.SetInsertMode(_insertModeEnabled);
        }

        private void comboVehicleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTimeAndCost();
        }

        private void chkDiscounted_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTimeAndCost();
        }

        private void comboMechanicID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // prevent modification of appointments when populating fields
            if (_ignoreChangeEvent) return;

            // attempt to change the mechanic id
            bool result = _viewer.AttemptAppointmentMechanicIDChange(_selectedAppointment, int.Parse(((ComboBoxItem)comboMechanicID.SelectedItem).HiddenValue));
            if (!result)
            {
                _ignoreChangeEvent = true;
                // change it back if invalid
                comboMechanicID.SelectedItem = comboMechanicID.Items.Cast<ComboBoxItem>().Where(ex => int.Parse(ex.HiddenValue) == _selectedMechanicID).FirstOrDefault();
                _ignoreChangeEvent = false;
            }

            _selectedMechanicID = int.Parse(((ComboBoxItem)comboMechanicID.SelectedItem).HiddenValue);
        }
        #endregion











       

      

        
    }
}
