using ManaSpeedTester.Models;
using System;
using System.IO;

namespace ManaSpeedTester
{
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

        public void SaveServiceSpeed(TestInput input)
        {
            try
            {
                if ((input.finish - input.start).TotalSeconds <= 1)
                    return;
                string docPath = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(docPath, "speed_service_meteer.txt");
                if (!System.IO.File.Exists(filePath))
                    System.IO.File.Create(filePath);
                string line = $"**************************************************************************************************************{Environment.NewLine}";
                line += $"JSON DATA : {Newtonsoft.Json.JsonConvert.SerializeObject(input.data, Newtonsoft.Json.Formatting.None)} {Environment.NewLine}";
                line += $"METHOD : {input.method.ReflectedType.FullName} {Environment.NewLine}";
                line += $"TIME : {DateTime.Now.ToString()} {Environment.NewLine}";
                line += $"DURATION : {(input.finish - input.start).TotalSeconds} sec {Environment.NewLine} {Environment.NewLine}";
                line += $"**************************************************************************************************************{Environment.NewLine}";
                System.IO.File.AppendAllText(filePath, line);
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message);
            }
        }

        public void SaveRepositoySpeed(TestInput input)
        {
            try
            {
                if ((input.finish - input.start).TotalSeconds <= 1)
                    return;
                string docPath = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(docPath, "speed_repository_meteer.txt");
                if (!System.IO.File.Exists(filePath))
                    System.IO.File.Create(filePath);
                string line = $"**************************************************************************************************************{Environment.NewLine}";
                line += $"JSON DATA : {Newtonsoft.Json.JsonConvert.SerializeObject(input.data, Newtonsoft.Json.Formatting.None)} {Environment.NewLine}";
                line += $"METHOD : {input.method.ReflectedType.FullName} {Environment.NewLine}";
                line += $"TIME : {DateTime.Now.ToString()} {Environment.NewLine}";
                line += $"DURATION : {(input.finish - input.start).TotalSeconds} sec {Environment.NewLine} {Environment.NewLine}";
                line += $"**************************************************************************************************************{Environment.NewLine}";
                System.IO.File.AppendAllText(filePath, line);
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message);
            }
        }
    }
}
