using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODORO_Timer
{
    public static class Settings
    {
        public static readonly string Path = System.IO.Path.Combine(Environment.CurrentDirectory, "Repository", "Task", "task.txt");

    }
}
