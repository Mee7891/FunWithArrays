using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Array2DNonZB<T>:IEnumerable where T: struct
    {
        int minI;
        int minJ;

        T[,] arr;

        public Array2DNonZB(int minI, int maxI, int minJ, int maxJ)
        {
            if (maxI < minI) Utils.Swap<int>(ref maxI, ref minI);
            if (maxJ < minJ) Utils.Swap<int>(ref maxJ, ref minJ);

            this.minI = minI; this.minJ = minJ;

            arr = new T[maxI - minI + 1, maxJ - minJ + 1];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        public T this[int i, int j]
        {
            get
            {
                try
                { return arr[i - minI, j - minJ]; }
                catch
                { throw new Exception("Попытка доступа по неверному индексу"); }
            }
            set
            {
                try
                { arr[i - minI, j - minJ] = value; }
                catch
                { throw new Exception("Попытка доступа по неверному индексу"); }
            }
        }
    }
}
