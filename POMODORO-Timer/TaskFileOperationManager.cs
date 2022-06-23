using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODORO_Timer
{
    public class TaskFileOperationManager : FileOperationManager
    {
        public string ErrorMsg = "";
        public bool Create()
        {
            try
            {
                FileInfo fi = new FileInfo(Settings.Path);
                if (CreateParentDirectory(fi.Directory) == false) return false;
                if (Exists()) return true;
                using (File.Create(Settings.Path)) { /*no function*/};
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
            return true;
        }

        public bool Delete()
        {
            try
            {
                File.Delete(Settings.Path);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
            return true;
        }

        public bool Exists()
        {
            return File.Exists(Settings.Path);
        }

        public bool ReCreate()
        {
            try
            {
                if (Delete())
                    if (Create()) return true;
                    else throw new Exception(ErrorMsg);
                else throw new Exception(ErrorMsg);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
        }

        private bool CreateParentDirectory(DirectoryInfo di)
        {
            if (di.Parent.Exists == false) return CreateParentDirectory(di.Parent);
            if (di.Exists == false) return true;
            try
            {
                Directory.CreateDirectory(di.FullName);
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
