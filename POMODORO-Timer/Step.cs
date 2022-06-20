using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODORO_Timer
{
    public class Step
    {
#if DEBUG
        public const int FIRST = 1;
        public const int SECOND = 1;
        public const int THIRD = 1;
        public const int FOURTH = 1;
        public const int BREAK = 2;
        public const int LONG_BREAK = 3;
#else
        public const int FIRST = 25;
        public const int SECOND = 25;
        public const int THIRD = 25;
        public const int FOURTH = 25;
        public const int BREAK = 5;
        public const int LONG_BREAK = 15;
#endif
    }
}
