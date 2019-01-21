using System;
using System.Collections.Generic;
using System.Text;

namespace HelloInstall
{
    public class InstallInformation
    {
        public int CurrentInstall { get; set; }
        public string InstallSource { get; set; }
        public List<InstallTask> InstallTasks { get; set; }
    }

    public struct InstallTask
    {
        public string Name;
        public string Source;
        public string Path;
    }
}
