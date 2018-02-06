using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterators
{
    internal class CompanyNew : IEnumerable<string>
    {
        private readonly List<string> _workers = new List<string>();

        public CompanyNew(params string[] workers)
        {
            foreach (var worker in workers)
            {
                _workers.Add(worker);
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            // Implement GetEnumerator in CompanyNew using a C# iterator
            foreach (var worker in _workers)
            {
                yield return worker;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
