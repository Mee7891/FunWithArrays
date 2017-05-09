using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class ArrayNonZBND<T> : IEnumerable where T : struct
    {
        int[] iMins;
        int[] sliceSizes;

        T[] arr;

        public ArrayNonZBND(int[] lowerBounds, int[] upperBounds)
        {
            if (lowerBounds.Length != upperBounds.Length)
                throw new Exception("Количество верхних и нижних границ не совпадает!");

            iMins = new int[lowerBounds.Length];
            sliceSizes = new int[lowerBounds.Length];

            int sliceSize = 1;
            for (int i = lowerBounds.Length; --i >= 0;)
            {
                if (lowerBounds[i] > upperBounds[i]) Utils.Swap(ref lowerBounds[i], ref upperBounds[i]);

                sliceSizes[i] = sliceSize;
                iMins[i] = lowerBounds[i];
                sliceSize *= upperBounds[i] - lowerBounds[i] + 1;
            }

            arr = new T[sliceSize];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        public T this[int[] indexes]
        {
            get
            {
                try
                {
                    int index = 0;
                    for (int i = iMins.Length; --i >= 0;)
                        index += (indexes[i] - iMins[i]) * sliceSizes[i];

                    return arr[index];
                }
                catch
                { throw new Exception("Попытка доступа по неверному индексу"); }
            }
            set
            {
                try
                {
                    int index = 0;
                    for (int i = iMins.Length; --i >= 0;)
                        index += (indexes[i] - iMins[i]) * sliceSizes[i];

                    arr[index] = value;
                }
                catch
                { throw new Exception("Попытка доступа по неверному индексу"); }
            }
        }
    }
            
}
