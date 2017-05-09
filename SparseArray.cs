using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeeArraysClasses
{
    public class SparseArray<T>
    {
        int rowN;
        int colN;

        SortedList<int, SortedList<int, T>> rows;

        public SparseArray(int _rowN, int _colN)
        {
            if (_rowN <= 0 || _colN <= 0) throw new Exception("Unacceptable array dimensions");

            rowN = _rowN;
            colN = _colN;

            rows = new SortedList<int, SortedList<int, T>>(rowN);
        }



    }
}
