using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    class Logging
    {

        // enum containing the types of logs currently accessible
        public enum LogType
        {
            LoginAttempt,
            Login,
            Access,
            Create,
            Update,
            Delete
        };


        // additionalInfo represents any information that cannot be accessed from within the class
        // this will include usernames, deleted/updated logs, etc.
        // the contents of this additionalInfo must be manually defined depending on the LogType
        public static void WriteLog(LogType LogType, string AdditionalInfo)
        {

            // attempt to create a message based on the logtype provided, and the additionalinfo
            string Message;
            try
            {
                switch (LogType)
                {
                    case (LogType.LoginAttempt):
                        Message = "User " + AdditionalInfo + " had an unsuccessful login attempt [1]";
                        break;
                    case (LogType.Login):
                        Message = "User " + CurrentUser.CurrentLoggedInUser.Username + " logged in [2]";
                        break;
                    case (LogType.Access):
                        Message = "User " + CurrentUser.CurrentLoggedInUser.Username + " accessed the " + AdditionalInfo + " form [3]";
                        break;
                    case (LogType.Create):
                        Message = "User " + CurrentUser.CurrentLoggedInUser.Username + " added a new " + AdditionalInfo + " [4]";
                        break;
                    case (LogType.Update):
                        Message = "User " + CurrentUser.CurrentLoggedInUser.Username + " modified " + AdditionalInfo + " [5]";
                        break;
                    case (LogType.Delete):
                        Message = "User " + CurrentUser.CurrentLoggedInUser.Username + " deleted " + AdditionalInfo + " [6]";
                        break;
                    default:
                        Message = "Unknown log type";
                        break;
                }


            }
            catch (Exception ex)
            {
                Message = "Error when attempting to save the log: " + ex.Message;
            }

            // root of the project
            string SolutionRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // folder containing the logs file
            string MiscPath = Path.Combine(
                SolutionRoot,
                "misc"
            );

            // attempt to create the directory if it doesn't exist
            Directory.CreateDirectory(MiscPath);

            // the path of the file to which logs will be stored
            string FilePath = Path.Combine(MiscPath, "logs.txt");

            // append the new message
            using (var fs = new FileStream(FilePath, FileMode.Append))
            using (var sw = new StreamWriter(fs))
            {
                sw.WriteLine($"[{DateTime.Now.ToString("G")}] - {Message}");
            }
        }

        // processes all logs stored on the system for display in the logs form, filtered by logtype and username
        public static List<ListViewItem> RetrieveLogsAsListViewItems(DateTime Date, LogType? LogType, string Username)
        {
            List<ListViewItem> ListViewItems = new List<ListViewItem>();

            string SolutionRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string MiscPath = Path.Combine(SolutionRoot, "misc");
            Directory.CreateDirectory(MiscPath);

            string FilePath = Path.Combine(MiscPath, "logs.txt");

            // if there are no logs, output nothing
            if (!File.Exists(FilePath))
                return ListViewItems;


            // all of the logs in the file
            string[] Lines = File.ReadAllLines(FilePath);

            foreach (var Line in Lines)
            {
                try
                {
                    // if filtering by username, and username does not appear in the position where it is expected, ignore
                    if (Username != null)
                    {
                        int firstUserOccurrence = Line.IndexOf(Username);
                        if (firstUserOccurrence == -1 || firstUserOccurrence != Line.IndexOf("User ") + 5) continue;
                    }

                    // if the log isn't formatted properly
                    int firstBracket = Line.IndexOf('[');
                    int secondBracket = Line.IndexOf(']');
                    if (firstBracket < 0 || secondBracket < firstBracket)
                        continue; 

                    // get the date stored in the log
                    string DateStr = Line.Substring(firstBracket + 1, secondBracket - firstBracket - 1);
                    if (!DateTime.TryParse(DateStr, out DateTime LogDate))
                        continue;

                    if (LogDate.Date != Date.Date)
                        continue;

                    // if the date isn't valid or it doesn't match, ignore

                    int lastBracket = Line.LastIndexOf('[');
                    int endBracket = Line.LastIndexOf(']');
                    int CategoryNumber = -1;

                    // if there is a category number, parse it
                    if (lastBracket >= 0 && endBracket > lastBracket)
                    {
                        string numStr = Line.Substring(lastBracket + 1, endBracket - lastBracket - 1);
                        int.TryParse(numStr, out CategoryNumber);
                    }

                    LogType logType;
                    // get the logtype based on the number in the log
                    switch (CategoryNumber)
                    {
                        case 1: logType = Logging.LogType.LoginAttempt; break;
                        case 2: logType = Logging.LogType.Login; break;
                        case 3: logType = Logging.LogType.Access; break;
                        case 4: logType = Logging.LogType.Create; break;
                        case 5: logType = Logging.LogType.Update; break;
                        case 6: logType = Logging.LogType.Delete; break;
                        default: continue;
                    }

                    // if there was a logtype to filter by and it doesn't match
                    if (LogType.HasValue && logType != LogType.Value)
                        continue;

                    

                    // trim the category number off
                    string Message = Line;
                    if (lastBracket > secondBracket)
                        Message = Message.Substring(0, Message.Length - 3).Trim();

                    // add the listviewitem
                    var item = new ListViewItem
                    {
                        Text = Message
                    };

                    ListViewItems.Add(item);
                }
                catch
                {
                    // skip malformed lines
                    continue;
                }
            }

            ListViewItems.Reverse(); // newest first
            return ListViewItems;

        }
    }
}