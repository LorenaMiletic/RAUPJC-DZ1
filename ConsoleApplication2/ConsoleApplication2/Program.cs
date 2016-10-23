using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _size = 0;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new Exception("Unesen je negativan broj!");
            }
            _internalStorage = new X[initialSize];
        }

        public void Add(X item)
        {
            if (_size + 1 > _internalStorage.Length)
            {
                X[] pom = _internalStorage;
                _internalStorage = new X[pom.Length * 2];
                Array.Copy(pom, _internalStorage, pom.Length);
            }

            _internalStorage[_size] = item;
            _size++;

        }

        public bool RemoveAt(int index)
        {
            if (index >= _size || index < 0)
            {
                return false;
            }

            _internalStorage[index] = default(X);
            for (int i = index + 1; i < _size; i++)
            {
                _internalStorage[i - 1] = _internalStorage[i];

            }

            _size--;
            _internalStorage[_size] = default(X);
            return true;

        }

        public bool Remove(X item)
        {
            int index1 = 0;
            foreach (X num in _internalStorage)
            {
                if (num.Equals(item))
                {
                    return RemoveAt(index1);
                }
                index1++;
            }

            return false;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index < _size)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index je izvan intervala!");
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count
        {
            get
            {
                return _size;
            }

        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _size);
            _size = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
