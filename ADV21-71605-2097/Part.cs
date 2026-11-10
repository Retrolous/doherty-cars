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
    class Part
    {
        #region Private fields
        private int _partID;
        private string _name;
        private decimal _buyPrice;
        private decimal _sellPrice;
        private int _quantity;
        #endregion
        #region Public properties
        public int PartID
        {
            get => _partID;
            set => _partID = value >= 0
                ? value
                : throw new ArgumentException("Part ID must be zero or positive.");
        }

        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : throw new ArgumentException("Part name cannot be empty.");
        }

        public decimal BuyPrice
        {
            get => _buyPrice;
            set => _buyPrice = value >= 0
                ? value
                : throw new ArgumentException("Buy price cannot be negative.");
        }

        public decimal SellPrice
        {
            get => _sellPrice;
            set => _sellPrice = value >= 0
                ? value
                : throw new ArgumentException("Sell price cannot be negative.");
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value >= 0
                ? value
                : throw new ArgumentException("Quantity cannot be negative.");
        }
        #endregion
        #region Constructors
        public Part() { }

        public Part(int PartID, string Name, decimal BuyPrice, decimal SellPrice, int Quantity)
        {
            this.PartID = PartID;
            this.Name = Name;
            this.BuyPrice = BuyPrice;
            this.SellPrice = SellPrice;
            this.Quantity = Quantity;
        }
        #endregion

        #region Validation

        // basic validation to ensure that the details provided would form a valid part
        public static List<string> ValidatePart(
            int PartID,
            string Name,
            decimal BuyPrice,
            decimal SellPrice,
            int Quantity)
        {
            List<string> Errors = new List<string>();

            if (PartID < 0)
                Errors.Add("Part ID must be zero or positive.");

            if (string.IsNullOrWhiteSpace(Name))
                Errors.Add("Part name cannot be empty.");

            if (Name.Length > 50)
                Errors.Add("Part name cannot be longer than 50 characters.");

            if (BuyPrice < 0)
                Errors.Add("Buy price cannot be negative.");

            if (SellPrice < 0)
                Errors.Add("Sell price cannot be negative.");

            if (Quantity < 0)
                Errors.Add("Quantity cannot be negative.");

            return Errors;
        }
        #endregion
        #region Create
        // add a new part into the parts table
        public static string AddPart(Part NewPart)
        {
            try
            {
                string Query = @"
                    INSERT INTO Parts (Name, BuyPrice, SellPrice, Quantity)
                    VALUES (@Name, @BuyPrice, @SellPrice, @Quantity)";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Name", NewPart.Name);
                    cmd.Parameters.AddWithValue("@BuyPrice", NewPart.BuyPrice);
                    cmd.Parameters.AddWithValue("@SellPrice", NewPart.SellPrice);
                    cmd.Parameters.AddWithValue("@Quantity", NewPart.Quantity);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null;
            }
            catch (Exception ex)
            {
                return "Error adding part:\n- " + ex.Message;
            }
        }
        #endregion
        #region Update
        // update an existing record with new details
        public static string SavePart(Part ExistingPart)
        {
            try
            {
                string Query = @"
            UPDATE Parts
            SET Name = @Name,
                BuyPrice = @BuyPrice,
                SellPrice = @SellPrice,
                Quantity = @Quantity
            WHERE PartID = @PartID";

                using (var Connection = DBConnect.ConnectionToDB())
                using (var cmd = new SqlCommand(Query, Connection))
                {
                    cmd.Parameters.AddWithValue("@PartID", ExistingPart.PartID);
                    cmd.Parameters.AddWithValue("@Name", ExistingPart.Name);
                    cmd.Parameters.AddWithValue("@BuyPrice", ExistingPart.BuyPrice);
                    cmd.Parameters.AddWithValue("@SellPrice", ExistingPart.SellPrice);
                    cmd.Parameters.AddWithValue("@Quantity", ExistingPart.Quantity);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                }

                return null; // success
            }
            catch (Exception ex)
            {
                return "Error updating part record: " + ex.Message;
            }
        }
        #endregion
        #region Retrieve
        // gets all parts from the parts table
        public static List<Part> RetrieveParts()
        {
            List<Part> Results = new List<Part>();

            try
            {
                DataTable Table = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Parts WHERE DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.Fill(Table);
                }

                foreach (DataRow row in Table.Rows)
                    Results.Add(FromDataRow(row));

                return Results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving parts:\n- " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // gets a part given its id
        public static Part RetrieveByPartID(int id)
        {
            try
            {
               
                DataTable Table = new DataTable();

                using (var Connection = DBConnect.ConnectionToDB())
                using (var Adapter = new SqlDataAdapter(
                    "SELECT * FROM Parts WHERE PartID = @PartID AND DateDeleted IS NULL",
                    Connection))
                {
                    Adapter.SelectCommand.Parameters.AddWithValue("@PartID", id);
                    Adapter.Fill(Table);
                }

                // if there is a part with that id
                return Table.Rows.Count > 0 ? FromDataRow(Table.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving part:\n- " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion     
        #region Delete
        public static string DeletePart(int id)
        {
            try
            {
                using (var connection = DBConnect.ConnectionToDB())
                using (var cmd = connection.CreateCommand())
                {
                    // raises an error if there is any appointment that uses that part
                    cmd.CommandText = @"
                        IF EXISTS (
                        SELECT 1
                        FROM ServiceAppointmentsServicesParts 
                        WHERE PartID = @PartID
                        AND DateDeleted IS NULL
                        )
                        BEGIN
                            RAISERROR('Part is used in service appointments and cannot be deleted.', 16, 1);
                            RETURN;
                        END

                        
                        UPDATE Parts
                        SET DateDeleted = GETDATE()
                        WHERE PartID = @PartID
                        AND DateDeleted IS NULL;";

                    cmd.Parameters.AddWithValue("@PartID", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
            }
            catch(Exception ex)
            {
                return "Part delete unsuccessful:\n- " + ex.Message;
            }
        }
        #endregion
        #region Mapping
        // parses a part given its row representation in the table
        public static Part FromDataRow(DataRow row)
        {
            return new Part(
                (int)row["PartID"],
                row["Name"].ToString(),
                (decimal)row["BuyPrice"],
                (decimal)row["SellPrice"],
                (int)row["Quantity"]
            );
        }
        #endregion
        #region Search
        // returns a list of parts that match the given criteria
        public static List<Part> GetPartsByField(string SearchTerm, string SearchType, string Field)
        {
            List<Part> results = new List<Part>();

            try
            {
                DataTable table = new DataTable();

                using (var connection = DBConnect.ConnectionToDB())
                using (var adapter = new SqlDataAdapter(
                    // modify the query based on the search type
                    $"SELECT * FROM Parts WHERE {Field} {(SearchType == "Exact" ? "=" : "LIKE")} @Value AND DateDeleted IS NULL",
                    connection))
                {
                    if (SearchType == "Exact")
                        adapter.SelectCommand.Parameters.AddWithValue("@Value", SearchTerm);
                    else
                        adapter.SelectCommand.Parameters.AddWithValue("@Value", "%" + SearchTerm + "%");

                    adapter.Fill(table);
                }

                foreach (DataRow row in table.Rows)
                    results.Add(FromDataRow(row));

                return results;
            }
            catch
            {
                return new List<Part>();
            }
        }
        #endregion
    }
}
