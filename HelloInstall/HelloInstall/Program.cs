using System;
using System.IO;
using Newtonsoft.Json;

namespace HelloInstall
{
    public class Program
    {
        static void Main(string[] args)
        {
            var currentConfig = JsonConvert.DeserializeObject<InstallInformation>(File.ReadAllText("C:\\hw - install - info.json"));

            string contents;
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString(currentConfig.InstallSource);

            var webConfig = JsonConvert.DeserializeObject<InstallInformation>(contents);

            if (webConfig.CurrentInstall > currentConfig.CurrentInstall)
                Console.WriteLine("Old install!");
            else
                Console.WriteLine("Current install!");


            Console.WriteLine("Hello World!");
        }

        public static void CreateFile()
        {
            var test = new InstallInformation();
            test.CurrentInstall = 1;
            test.InstallSource = "http://github.com/blablalba";
            var task = new InstallTask();
            task.Name = "Test";
            task.Source = "http://github.com/blablalba";
            task.Path = "C:\\Users\\Default\\Documents";
            test.InstallTasks = new System.Collections.Generic.List<InstallTask>() { task };

            string json = JsonConvert.SerializeObject(test, Formatting.Indented);
            using (var writer = System.IO.File.CreateText("C:\\hw-install-info.json"))
            {
                writer.WriteLine(json);
                writer.Close();
            }
        }
    }
}
