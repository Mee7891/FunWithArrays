using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class ArrayNonZB2DTo1D<T> : IEnumerable where T : struct
    {
        int minI;
        int minJ;
        int rowLength;

        T[] arr;

        public ArrayNonZB2DTo1D(int minI, int maxI, int minJ, int maxJ)
        {
            if (maxI < minI) Utils.Swap<int>(ref maxI, ref minI);
            if (maxJ < minJ) Utils.Swap<int>(ref maxJ, ref minJ);

            this.minI = minI; this.minJ = minJ;

            rowLength    = maxJ - minJ + 1;

            arr = new T[rowLength*(maxI - minI + 1)];  //columnLength = maxI - minI + 1;
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
                {
                    int index = (i - minI) * rowLength + (j - minJ);
                    return arr[index];
                }
                catch
                { throw new Exception("Попытка доступа по неверному индексу"); }
            }
            set
            {
                try
                {
                    int index = (i - minI) * rowLength + (j - minJ);
                    arr[index] = value;
                }
                catch
                { throw new Exception("Попытка доступа по неверному индексу"); }
            }
        }
    }
}
