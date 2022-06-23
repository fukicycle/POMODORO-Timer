using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODORO_Timer
{
    public interface FileOperationManager
    {
        bool Exists();
        bool Create();
        bool Delete();
        bool ReCreate();
    }
}
