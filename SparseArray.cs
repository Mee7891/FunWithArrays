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

        T defVal;

        SortedList<int, SortedList<int, T>> rows;

        public SparseArray(int _rowN, int _colN)
        {
            if (_rowN <= 0 || _colN <= 0) throw new Exception("Unacceptable array dimensions");

            rowN = _rowN;
            colN = _colN;

            rows = new SortedList<int, SortedList<int, T>>(rowN);

            defVal = default(T);
        }

        public SparseArray(int _rowN, int _colN, T _defVal)
        {
            if (_rowN <= 0 || _colN <= 0) throw new Exception("Unacceptable array dimensions");

            rowN = _rowN;
            colN = _colN;

            rows = new SortedList<int, SortedList<int, T>>(rowN);

            defVal = _defVal;
        }

        SortedList<int, T> GetRow(int i)
        {
            if (!ProveRowIndex(i)) throw new Exception("Unacceptable row index");

            if(rows.ContainsKey(i))
                return rows[i];
            return null;
        }

        bool ProveRowIndex(int i)
        {
            if (i < 0 || i >= rowN) return false;
            return true;
        }

        bool ProveColunmIndex(int j)
        {
            if (j < 0 || j >= colN) return false;
            return true;
        }
    }
}
