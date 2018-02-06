using System;
using System.Collections;

namespace Iterators
{
    class CompanyOrig : IEnumerable
    {
        private readonly ArrayList _workers = new ArrayList();

        public CompanyOrig(params string[] workers)
        {
            foreach (var worker in workers)
            {
                _workers.Add(worker);
            }
        }

        public IEnumerator GetEnumerator()
        {
            var enumerator = new EmployeeEnumerator {Employees = _workers};
            return enumerator;
        }

        class EmployeeEnumerator : IEnumerator
        {
            int _index = -1;
            public ArrayList Employees { get; set; }

            public object Current
            {
                get { return Employees[_index]; }
            }

            public bool MoveNext()
            {
                _index++;
                return (_index < Employees.Count);
            }

            public void Reset()
            {
                _index = -1;
            }
        }
}
}
