using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    
        /// represents a service appointment in the system
        class ServiceAppointment
        {
        #region Private fields
        private int _appointmentID;
        private int _vehicleID;
        private int _staffID;
        private DateTime _appointmentStart;
        private DateTime _appointmentEnd;
        private bool _paid;
        private bool _completed;
        private bool _discounted;

        // <serviceid, <partid, quantity>>
        private Dictionary<int, Dictionary<int, int>> _serviceIDsAndRequiredPartIDs;

        #endregion
        #region Public properties
        public int AppointmentID
            {
                get => _appointmentID;
                set => _appointmentID = value >= 0
                    ? value
                    : throw new ArgumentException("Appointment ID must be zero or positive.");
            }

            public int VehicleID
            {
                get => _vehicleID;
                set => _vehicleID = value >= 0
                    ? value
                    : throw new ArgumentException("Vehicle ID must be greater than zero.");
            }

            public int StaffID
            {
                get => _staffID;
                set => _staffID = value >= 0
                    ? value
                    : throw new ArgumentException("Staff ID must be greater than zero.");
            }

            public DateTime AppointmentStart
            {
                get => _appointmentStart;
                set => _appointmentStart = value;
            }

            public DateTime AppointmentEnd
            {
                get => _appointmentEnd;
                set => _appointmentEnd = value > AppointmentStart
                    ? value
                    : throw new ArgumentException("Appointment end must be after appointment start.");
            }

            public bool Paid
            {
                get => _paid;
                set => _paid = value;
            }

            public bool Completed
            {
                get => _completed;
                set => _completed = value;
            }

        public bool Discounted
        {
            get => _discounted;
            set => _discounted = value;
        }

        public Dictionary<int, Dictionary<int, int>> ServiceIDsAndRequiredPartIDs 
        {
            get => _serviceIDsAndRequiredPartIDs; 
            private set => _serviceIDsAndRequiredPartIDs = value; 
        }

        #endregion
        #region Constructors
        public ServiceAppointment() { }

        public ServiceAppointment(
        int appointmentID,
        int vehicleID,
        int staffID,
        DateTime appointmentStart,
        DateTime appointmentEnd,
        bool paid,
        bool completed,
        bool discounted,
        Dictionary<int, Dictionary<int, int>> serviceIDsAndRequiredPartIDs)
        {
            AppointmentID = appointmentID;
            VehicleID = vehicleID;
            StaffID = staffID;
            AppointmentStart = appointmentStart;
            AppointmentEnd = appointmentEnd;
            Paid = paid;
            Completed = completed;
            Discounted = discounted;
            ServiceIDsAndRequiredPartIDs = serviceIDsAndRequiredPartIDs;
        }
        #endregion

        #region Validation
        // ensure the details input would for a valid appointment
        public static List<string> ValidateAppointment(int VehicleID, int StaffID, DateTime Start, DateTime End)
        {
            List<string> Errors = new List<string>();

            if (VehicleID <= 0)
                Errors.Add("Vehicle ID must be greater than zero.");

            if (StaffID <= 0)
                Errors.Add("Staff ID must be greater than zero.");

            if (End <= Start)
                Errors.Add("Appointment end must be after appointment start.");

            if (Start.Date != End.Date)
                Errors.Add("Appointments must start and finish on the same day");

            return Errors;
        }
        #endregion
        #region Create

        // add a new appointment into the database
        public static string AddAppointment(ServiceAppointment NewAppointment)
        {
            try
            {
                // stores the id of the appointment that was inserted into the ServiceAppointments table
                int LastInsertedId;
                string AppointmentQuery = @"
                    INSERT INTO ServiceAppointments
                    (VehicleID, StaffID, AppointmentStart, AppointmentEnd, Paid, Completed, Discounted)
                    VALUES
                    (@VehicleID, @StaffID, @AppointmentStart, @AppointmentEnd, @Paid, @Completed, @Discounted);

                    SELECT SCOPE_IDENTITY();";

                string AppointmentServicesQuery = @"
                    INSERT INTO ServiceAppointmentsServices
                    (AppointmentID, ServiceID)
                    VALUES
                    (@AppointmentID, @ServiceID);";

                string AppointmentServicesPartsQuery = @"
                    INSERT INTO ServiceAppointmentsServicesParts
                    (AppointmentID, ServiceID, PartID, Quantity)
                    VALUES
                    (@AppointmentID, @ServiceID, @PartID, @Quantity);"; ;

                // update the parts table to reflect the parts that have been used up in the new appointment
                string PartsQuery = "UPDATE Parts SET Quantity = Quantity - @Amount WHERE PartID = @PartID";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(AppointmentQuery, Connection))
                {
                    cmd.Parameters.AddWithValue("@VehicleID", NewAppointment.VehicleID);
                    cmd.Parameters.AddWithValue("@StaffID", NewAppointment.StaffID);
                    cmd.Parameters.AddWithValue("@AppointmentStart", NewAppointment.AppointmentStart);
                    cmd.Parameters.AddWithValue("@AppointmentEnd", NewAppointment.AppointmentEnd);
                    cmd.Parameters.AddWithValue("@Paid", NewAppointment.Paid);
                    cmd.Parameters.AddWithValue("@Completed", NewAppointment.Completed);
                    cmd.Parameters.AddWithValue("@Discounted", NewAppointment.Discounted);

                    Connection.Open();
                    LastInsertedId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (var Connection = DBConnect.ConnectionToDB())
                {
                    Connection.Open();

                    using (var serviceCmd = new SqlCommand(AppointmentServicesQuery, Connection))
                    using (var partCmd = new SqlCommand(AppointmentServicesPartsQuery, Connection))
                    {
                        serviceCmd.Parameters.Add("@AppointmentID", SqlDbType.Int);
                        serviceCmd.Parameters.Add("@ServiceID", SqlDbType.Int);

                        partCmd.Parameters.Add("@AppointmentID", SqlDbType.Int);
                        partCmd.Parameters.Add("@ServiceID", SqlDbType.Int);
                        partCmd.Parameters.Add("@PartID", SqlDbType.Int);
                        partCmd.Parameters.Add("@Quantity", SqlDbType.Int);


                        foreach (var service in NewAppointment.ServiceIDsAndRequiredPartIDs)
                        {
                            serviceCmd.Parameters["@AppointmentID"].Value = LastInsertedId;
                            serviceCmd.Parameters["@ServiceID"].Value = service.Key;
                            serviceCmd.ExecuteNonQuery();

                            foreach (var part in service.Value)
                            {
                                partCmd.Parameters["@AppointmentID"].Value = LastInsertedId;
                                partCmd.Parameters["@ServiceID"].Value = service.Key;
                                partCmd.Parameters["@PartID"].Value = part.Key;
                                partCmd.Parameters["@Quantity"].Value = part.Value;

                                partCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    using (var cmd = new SqlCommand(PartsQuery, Connection))
                    {
                        // go from <service <part, quantity>> to <part, quantity> to <part, quantites> to <part, total quantity> 
                        Dictionary<int, int> newServicePartsAndQuantities = NewAppointment.ServiceIDsAndRequiredPartIDs.Values.SelectMany(d => d)
                                                                                    .GroupBy(kvp => kvp.Key)
                                                                                    .ToDictionary(
                                                                                            g => g.Key,
                                                                                            g => g.Sum(kvp => kvp.Value)
                                                                                    );


                        cmd.Parameters.Add("@PartID", SqlDbType.Int);
                        cmd.Parameters.Add("@Amount", SqlDbType.Int);

                        foreach (KeyValuePair<int, int> kvp in newServicePartsAndQuantities)
                        {
                            cmd.Parameters["@PartID"].Value = kvp.Key;
                            cmd.Parameters["@Amount"].Value = kvp.Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return "Error when adding appointment: " + e.Message;
            }
        }
        #endregion
        #region Retrieve
        // retrieve all appointments in the database
        public static List<ServiceAppointment> RetrieveAppointments()
        {
            List<ServiceAppointment> Result = new List<ServiceAppointment>();

            try
            {
               
                using (var Connection = DBConnect.ConnectionToDB())
                using (var AppointmentAdapter = new SqlDataAdapter(
                    "SELECT * FROM ServiceAppointments WHERE DateDeleted IS NULL",
                    Connection))
                using (var AppointmentServicesPartsAdapter = new SqlDataAdapter(
                    "SELECT * FROM ServiceAppointmentsServicesParts WHERE DateDeleted IS NULL",
                    Connection))
                using (var AppointmentServicesAdapter = new SqlDataAdapter(
                "SELECT * FROM ServiceAppointmentsServices WHERE DateDeleted IS NULL",
                     Connection))
                {
                    // fetch all service appointments and their parts
                    DataTable DataServicePartsResult = new DataTable();
                    DataTable DataServicesResult = new DataTable();
                    DataTable DataResult = new DataTable();
                    AppointmentServicesPartsAdapter.Fill(DataServicePartsResult);
                    AppointmentAdapter.Fill(DataResult);
                    AppointmentServicesAdapter.Fill(DataServicesResult);

                    // create a new service appointment for each row in the table
                    foreach (DataRow row in DataResult.Rows)
                        Result.Add(FromDataRow(row));

                    foreach (DataRow row in DataServicesResult.Rows)
                    {
                        // get the appointment that relationship belongs to
                        ServiceAppointment CurrentAppointment =
                            Result
                            .Where((e) => e.AppointmentID == (int)row["AppointmentID"])
                            .FirstOrDefault();

                        // if that appointment exists
                        if (CurrentAppointment != null)
                        {
                            // add the service as a key, then the part -> quantity dictionary as a value

                            if (!CurrentAppointment.ServiceIDsAndRequiredPartIDs.ContainsKey((int)row["ServiceID"]))
                                CurrentAppointment.ServiceIDsAndRequiredPartIDs.Add((int)row["ServiceID"], new Dictionary<int, int>());
                        }
                    }

                    // for each appointment-service-part relationship
                    foreach (DataRow row in DataServicePartsResult.Rows)
                    {
                        // get the appointment that relationship belongs to
                        ServiceAppointment CurrentAppointment = 
                            Result
                            .Where((e) => e.AppointmentID == (int)row["AppointmentID"])
                            .FirstOrDefault();    

                        // if that appointment exists
                        if(CurrentAppointment != null)
                        {
                            // add the service as a key, then the part -> quantity dictionary as a value

                            if (!CurrentAppointment.ServiceIDsAndRequiredPartIDs.ContainsKey((int)row["ServiceID"]))
                                CurrentAppointment.ServiceIDsAndRequiredPartIDs.Add((int)row["ServiceID"], new Dictionary<int, int>());

                            CurrentAppointment.ServiceIDsAndRequiredPartIDs[(int)row["ServiceID"]].Add((int)row["PartID"], (int)row["Quantity"]);
                        }
                    }
                }

                

                return Result;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error retrieving appointments: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static ServiceAppointment RetrieveByAppointmentID(int id)
        {
            ServiceAppointment SelectedAppointment;
            try
            {
                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM ServiceAppointments WHERE AppointmentID = @AppointmentID",
                    Connection))
                using (var AppointmentServicePartsAdapter = new SqlDataAdapter(
                "SELECT * FROM ServiceAppointmentsServicesParts WHERE AppointmentID = @AppointmentID",
                Connection))
                using (var AppointmentServicesAdapter = new SqlDataAdapter(
                "SELECT * FROM ServiceAppointmentsServices WHERE AppointmentID = @AppointmentID",
                Connection))
                {
                    {
                        DataTable DataResult = new DataTable();
                        DataTable DataServicePartsResult = new DataTable();
                        DataTable DataServicesResult = new DataTable();
                        Adapter.SelectCommand.Parameters.AddWithValue("@AppointmentID", id);
                        AppointmentServicePartsAdapter.SelectCommand.Parameters.AddWithValue("@AppointmentID", id);
                        AppointmentServicesAdapter.SelectCommand.Parameters.AddWithValue("@AppointmentID", id);
                        Adapter.Fill(DataResult);

                        // retrieve the appointment information, including parts, given the id
                        AppointmentServicePartsAdapter.Fill(DataServicePartsResult);

                        AppointmentServicesAdapter.Fill(DataServicesResult);
                        // if no appointment was found, return null
                        if (DataResult.Rows.Count <= 0) return null;


                        // parse the appointment
                        SelectedAppointment = FromDataRow(DataResult.Rows[0]);

                        if (DataServicesResult.Rows.Count > 0)
                        {
                            foreach (DataRow row in DataServicesResult.Rows)
                            {
                                if (!SelectedAppointment.ServiceIDsAndRequiredPartIDs.ContainsKey((int)row["ServiceID"]))
                                    SelectedAppointment.ServiceIDsAndRequiredPartIDs.Add((int)row["ServiceID"], new Dictionary<int, int>());
                            }
                        }

                        // if there are parts required for the appointment, add them into the dictionary
                        if (DataServicePartsResult.Rows.Count > 0)
                        {
                            foreach (DataRow row in DataServicePartsResult.Rows)
                            {
                                if (!SelectedAppointment.ServiceIDsAndRequiredPartIDs.ContainsKey((int)row["ServiceID"]))
                                    SelectedAppointment.ServiceIDsAndRequiredPartIDs.Add((int)row["ServiceID"], new Dictionary<int, int>());

                                SelectedAppointment.ServiceIDsAndRequiredPartIDs[(int)row["ServiceID"]].Add((int)row["PartID"], (int)row["Quantity"]);
                            }
                        }
                    }
                }

                return SelectedAppointment;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error retrieving appointment: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion
        #region Delete
        // delete an appointment and all satellite data given its id
        public static string DeleteAppointment(int id)
        {
            try
            {
                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE ServiceAppointments
                        SET DateDeleted = GETDATE()
                        WHERE AppointmentID = @AppointmentID;

                        UPDATE ServiceAppointmentsServices
                        SET DateDeleted = GETDATE()
                        WHERE AppointmentID = @AppointmentID

                        UPDATE ServiceAppointmentsServicesParts
                        SET DateDeleted = GETDATE()
                        WHERE AppointmentID = @AppointmentID";

                    cmd.Parameters.AddWithValue("@AppointmentID", id);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
            }
            catch(Exception ex)
            {
                return "Appointment delete unsuccessful. Please contact the administrator: " + ex.Message;
            }
        }
        #endregion
        #region Mapping
        // parse a service appointment given its row in ServiceAppointments
        public static ServiceAppointment FromDataRow(DataRow row)
        {
            return new ServiceAppointment(
                (int)row["AppointmentID"],
                (int)row["VehicleID"],
                (int)row["StaffID"],
                (DateTime)row["AppointmentStart"],
                (DateTime)row["AppointmentEnd"],
                (bool)row["Paid"],
                (bool)row["Completed"],
                (bool)row["Discounted"],
                new Dictionary<int, Dictionary<int, int>>()
            );
        }

        // calculate the time that would be required to complete the current appointment
        public static int CalculateTimeRequired(Dictionary<int, Dictionary<int, int>> ServicesAndParts, int VehicleID)
        {
            decimal RunningTotal = 0;


            // for each service, add on that service's length
            foreach(int ServiceID in ServicesAndParts.Keys)
            {
                RunningTotal += Service.RetrieveByServiceID(ServiceID).DurationHours;
            }

            // then get the serviced vehicle's multiplier, and multiply the total by it
            int VehicleTypeID = Vehicle.RetrieveByVehicleID(VehicleID).VehicleTypeID;
            decimal VehicleTypeComplexity = VehicleType.RetrieveByVehicleTypeID(VehicleTypeID).Complexity;

            // round up to ensure you do not underestimate
            return (int)Math.Ceiling(RunningTotal * VehicleTypeComplexity);
        }


        // calculate how much an appointment would cost given its services and parts
        public static decimal CalculateCost(Dictionary<int, Dictionary<int, int>> ServicesAndParts)
        {
            decimal RunningTotal = 0;
            foreach (var kvp in ServicesAndParts)
            {
                // add on the service's cost
                RunningTotal += Service.RetrieveByServiceID(kvp.Key).Price;

                foreach(int partID in kvp.Value.Keys)
                {
                    // add on each part's cost
                    RunningTotal += Part.RetrieveByPartID(partID).SellPrice * ServicesAndParts[kvp.Key][partID];
                }
            }

            return RunningTotal;
        }

        // update an appointment in the database with new information
        // each appointment will be deleted and the updated appointment inserted to take its place to circumvent the complexity of modifying the existing data
        public static void UpdateAppointment(ServiceAppointment Appointment)
        {
            {
                ServiceAppointment OldAppointment = RetrieveByAppointmentID(Appointment.AppointmentID);
                string ServiceAppointmentsQuery = "UPDATE ServiceAppointments SET VehicleID = @VehicleID , StaffID = @StaffID , AppointmentStart = @AppointmentStart , AppointmentEnd = @AppointmentEnd , Paid = @Paid , Completed = @Completed , Discounted = @Discounted  WHERE AppointmentID = @AppointmentID;";
                string ServiceAppointmentsServicesDeleteQuery = "DELETE FROM ServiceAppointmentsServices WHERE AppointmentID = @AppointmentID";
                string ServiceAppointmentsServicesAddQuery = "INSERT INTO ServiceAppointmentsServices(AppointmentID, ServiceID) VALUES (@AppointmentID, @ServiceID)";
                string ServiceAppointmentsServicesPartsDeleteQuery = "DELETE FROM ServiceAppointmentsServicesParts WHERE AppointmentID = @AppointmentID";
                string ServiceAppointmentsServicesPartsAddQuery = "INSERT INTO ServiceAppointmentsServicesParts(AppointmentID, ServiceID, PartID, Quantity) VALUES (@AppointmentID, @ServiceID, @PartID, @Quantity)";
                string PartsQuery = "UPDATE Parts SET Quantity = Quantity - @Amount WHERE PartID = @PartID";
                try
                {
                    using (var Connection = DBConnect.ConnectionToDB())
                    {
                        Connection.Open();
                        using (var cmd = new SqlCommand(ServiceAppointmentsQuery, Connection))
                        {
                            cmd.Parameters.AddWithValue("@AppointmentID", Appointment.AppointmentID);
                            cmd.Parameters.AddWithValue("@VehicleID", Appointment.VehicleID);
                            cmd.Parameters.AddWithValue("@StaffID", Appointment.StaffID);
                            cmd.Parameters.AddWithValue("@AppointmentStart", Appointment.AppointmentStart);
                            cmd.Parameters.AddWithValue("@AppointmentEnd", Appointment.AppointmentEnd);
                            cmd.Parameters.AddWithValue("@Paid", Appointment.Paid);
                            cmd.Parameters.AddWithValue("@Completed", Appointment.Completed);
                            cmd.Parameters.AddWithValue("@Discounted", Appointment.Discounted);
                            cmd.ExecuteNonQuery();

                           
                        }

                        using (var cmd = new SqlCommand(ServiceAppointmentsServicesPartsDeleteQuery, Connection))
                        {
                            cmd.Parameters.AddWithValue("@AppointmentID", Appointment.AppointmentID);
                            cmd.ExecuteNonQuery();

                            
                        }

                        using (var cmd = new SqlCommand(ServiceAppointmentsServicesDeleteQuery, Connection))
                        {
                            cmd.Parameters.AddWithValue("@AppointmentID", Appointment.AppointmentID);
                            cmd.ExecuteNonQuery();

                           
                        }

                        using (var cmd = new SqlCommand(ServiceAppointmentsServicesAddQuery, Connection))
                        {
                            cmd.Parameters.AddWithValue("@AppointmentID", Appointment.AppointmentID);
                            cmd.Parameters.Add("@ServiceID", SqlDbType.Int);

                            foreach (int serviceID in Appointment.ServiceIDsAndRequiredPartIDs.Keys)
                            {
                                cmd.Parameters["@ServiceID"].Value = serviceID;
                                cmd.ExecuteNonQuery();
                            }

                            
                        }

                        

                        using (var cmd = new SqlCommand(ServiceAppointmentsServicesPartsAddQuery, Connection))
                        {
                            cmd.Parameters.AddWithValue("@AppointmentID", Appointment.AppointmentID);
                            cmd.Parameters.Add("@ServiceID", SqlDbType.Int);
                            cmd.Parameters.Add("@PartID", SqlDbType.Int);
                            cmd.Parameters.Add("@Quantity", SqlDbType.Int);

                            foreach (KeyValuePair<int, Dictionary<int, int>> serviceAndParts in Appointment.ServiceIDsAndRequiredPartIDs)
                            {
                                cmd.Parameters["@ServiceID"].Value = serviceAndParts.Key;

                                foreach(KeyValuePair<int, int> partsAndQuantity in serviceAndParts.Value)
                                {
                                    cmd.Parameters["@PartID"].Value = partsAndQuantity.Key;
                                    cmd.Parameters["@Quantity"].Value = partsAndQuantity.Value;
                                    cmd.ExecuteNonQuery();
                                }                             
                            }                          
                        }

                        // take into account the parts that are taken out of inventory
                        using (var cmd = new SqlCommand(PartsQuery, Connection))
                        {
                            Dictionary<int, int> OldServicePartsAndQuantities = OldAppointment.ServiceIDsAndRequiredPartIDs.Values.SelectMany(d => d)
                                                                                        .GroupBy(kvp => kvp.Key)
                                                                                        .ToDictionary(
                                                                                                g => g.Key,
                                                                                                g => g.Sum(kvp => kvp.Value)
                                                                                        );

                            Dictionary<int, int> NewServicePartsAndQuantities = Appointment.ServiceIDsAndRequiredPartIDs.Values.SelectMany(d => d)
                                                                                        .GroupBy(kvp => kvp.Key)
                                                                                        .ToDictionary(
                                                                                                g => g.Key,
                                                                                                g => g.Sum(kvp => kvp.Value)
                                                                                        );

                            
                            cmd.Parameters.Add("@PartID", SqlDbType.Int);
                            cmd.Parameters.Add("@Amount", SqlDbType.Int);

                            foreach (KeyValuePair<int, int> kvp in NewServicePartsAndQuantities)
                            {
                                cmd.Parameters["@PartID"].Value = kvp.Key;
                                // new parts have been added i.e. all must be taken out of the inventory
                                if (!OldServicePartsAndQuantities.ContainsKey(kvp.Key)){
                                    cmd.Parameters["@Amount"].Value = kvp.Value;
                                    cmd.ExecuteNonQuery();
                                } else // parts already existed in the appointment - update the parts table with the difference in the quantities
                                {
                                    cmd.Parameters["@Amount"].Value = kvp.Value - OldServicePartsAndQuantities[kvp.Key];
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // add the old parts that are not used in the new appointment parts list back into the table
                            foreach(KeyValuePair<int, int> kvp in OldServicePartsAndQuantities)
                            {
                                cmd.Parameters["@PartID"].Value = kvp.Key;
                                if (!NewServicePartsAndQuantities.ContainsKey(kvp.Key))
                                {
                                    cmd.Parameters["@Amount"].Value = -kvp.Value;
                                    cmd.ExecuteNonQuery();
                                }
                            }

                        }

                       
                    }
                }
                catch (Exception e)
                {                
                    MessageBox.Show("Save unsuccessful. Please contact the administrator with the follinwg message:\n" + e.Message);
                }

            }
        }
    }
        #endregion
    }
    

