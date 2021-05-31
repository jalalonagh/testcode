using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class TimeDurationTracker : ITimeDurationTracker
    {
        public void SaveSpeed(DateTime start, DateTime finish, string method, string username)
        {
            try
            {
                if ((finish - start).TotalSeconds <= 1)
                    return;

                string docPath = Directory.GetCurrentDirectory();

                string filePath = Path.Combine(docPath, "speed_o_meteer.txt");

                if (!System.IO.File.Exists(filePath))
                    System.IO.File.Create(filePath);

                string line = Environment.NewLine + $"{username} **** {DateTime.Now.ToString()} **** {method} => {(finish - start).TotalSeconds} sec";

                System.IO.File.AppendAllText(filePath, line);
            }
            catch (Exception Ex)
            {

            }
        }
    }

    public interface ITimeDurationTracker
    {
        void SaveSpeed(DateTime start, DateTime finish, string method, string username);
    }

    public sealed class TimeDurationTrackerSingleton
    {
        TimeDurationTrackerSingleton()
        {
        }
        private static readonly object padlock = new object();
        private static TimeDurationTrackerSingleton instance = null;
        public static TimeDurationTrackerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new TimeDurationTrackerSingleton();
                        }
                    }
                }
                return instance;
            }
        }

        public void SaveSpeed(DateTime start, DateTime finish, string method, string username)
        {
            try
            {
                if ((finish - start).TotalSeconds <= 1)
                    return;

                string docPath = Directory.GetCurrentDirectory();

                string filePath = Path.Combine(docPath, "speed_o_meteer.txt");

                if (!System.IO.File.Exists(filePath))
                    System.IO.File.Create(filePath);

                string line = Environment.NewLine + $"{username} **** {DateTime.Now.ToString()} **** {method} => {(finish - start).TotalSeconds} sec";

                System.IO.File.AppendAllText(filePath, line);
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
