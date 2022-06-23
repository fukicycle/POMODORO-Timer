using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODORO_Timer
{
    public class Tasks
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        public Nullable<TimeSpan> Achievement { get; set; }
    }
}
