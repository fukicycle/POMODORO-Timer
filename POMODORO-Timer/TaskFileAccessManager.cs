using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODORO_Timer
{
    public class TaskFileAccessManager : FileAccessManager
    {
        private string Path = System.IO.Path.Combine(Environment.CurrentDirectory, "Repository", "Task", "task.txt");
        public string ErrorMsg = "";
        public bool Load(out string contents)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path, Encoding.UTF8))
                {
                    contents = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                contents = "";
                ErrorMsg = ex.Message;
                return false;
            }
            return true;
        }

        public bool Write(string contents)
        {
            try
            {
                File.WriteAllText(Path, contents, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
            return true;
        }
    }
}
