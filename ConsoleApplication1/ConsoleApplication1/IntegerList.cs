using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _size = 0;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new Exception("Unesen je negativan broj!");
            }
            _internalStorage = new int[initialSize];
        }

        public void Add(int item)
        {
            if (_size + 1 > _internalStorage.Length)
            {
                int[] pom = _internalStorage;
                _internalStorage = new int[pom.Length * 2];
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

            _internalStorage[index] = 0;
            for (int i = index + 1; i < _size; i++)
            {
                _internalStorage[i - 1] = _internalStorage[i];

            }

            _size--;
            _internalStorage[_size] = 0;
            return true;

        }

        public bool Remove(int item)
        {
            int index1 = 0;
            foreach ( int num in _internalStorage)
            {
                if (num == item)
                {
                    return RemoveAt(index1);
                }
                index1++;
            }

            return false;
        }

        public int GetElement(int index)
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

        public int IndexOf(int item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item == _internalStorage[i])
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

        public bool Contains(int item)
        {
            for ( int i = 0; i < _size; i++)
            {
                if (item == _internalStorage[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1); // [1]
            listOfIntegers.Add(2); // [1 ,2]
            listOfIntegers.Add(3); // [1 ,2 ,3]
            listOfIntegers.Add(4); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5); //[2 ,3 ,4]
            Console.WriteLine(listOfIntegers.Count); // 3
            Console.WriteLine(listOfIntegers.Remove(100)); // false
            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false
            listOfIntegers.Clear(); // []
            Console.WriteLine(listOfIntegers.Count); // 0
            Console.Read();
        }

        static void Main(string[] args)
        {
            IIntegerList list = new IntegerList(5);
            ListExample(list);
        }
    }
}
