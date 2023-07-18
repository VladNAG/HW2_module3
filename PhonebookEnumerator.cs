using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_module3
{
    internal class PhonebookEnumerator : IEnumerator<IContact>
    {
        private Dictionary<string, List<IContact>> _date;
        private int _position = -1;
        private int _length = 0;
        public PhonebookEnumerator(Dictionary<string, List<IContact>> data)
        {
            _date = data;
            GetLength();
        }

        public IContact Current
        {
            get
            {
                if (_position == -1 && _position >= _length)
                {
                    throw new InvalidOperationException();
                }

                int currentPosition = 0;
                foreach (var item in _date)
                {
                    foreach (var contact in item.Value)
                    {
                        if (_position == currentPosition)
                        {
                            return contact;
                        }

                        currentPosition++;
                    }
                }

                throw new KeyNotFoundException();
            }
        }

        object IEnumerator.Current => Current;
        public bool MoveNext()
        {
            if (_position < _length - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
        }

        private void GetLength()
        {
            foreach (var item in _date)
            {
                foreach (var contact in item.Value)
                {
                    _length++;
                }
            }
        }
    }
}
