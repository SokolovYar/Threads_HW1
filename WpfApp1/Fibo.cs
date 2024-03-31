using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Fibo
    {
        public int Number { get; private set; }
        public int PrevNumber { get; private set; }
        public int MaxRange { get; }

        public Fibo(int start, int end)
        {
            if (start < 0 || end < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Меньше 2");
            }

            Number = start;
            PrevNumber = 0;
            MaxRange = end;
        }

        public int Next()
        {
            int temp = Number + PrevNumber;
                // Если следующее простое число не найдено, то возвращается -1
                if (temp > MaxRange) return -1;
            PrevNumber = Number;
            Number = temp;
            return Number;
        }
    }
}
