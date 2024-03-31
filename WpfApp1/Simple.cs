using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1
{
    internal class SimpleNumber
    {
        public int Number {  get; private set; }
        public int MaxRange { get; set; }

        public SimpleNumber(int start, int end)
        {
            if (start <= 1) throw new ArgumentOutOfRangeException(nameof(start), "Меньше или равно 1");
            Number = start;
            MaxRange = end;
        }

        public bool Next()
        {
           int temp = Number;
           while (++temp <= MaxRange)
            {
                if (isPrime(temp))
                {
                    Number = temp;
                    return true;
                }
            }
           return false;
        }

        private bool isPrime(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
