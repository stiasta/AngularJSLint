using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain
{
    public class HElementList : IEnumerable<HElement>
    {
        private List<HElement> _elements;
        public List<HElement> Elements
        {
            get
            {
                if (_elements == null)
                {
                    _elements = new List<HElement>();
                }

                return _elements;
            }
        }

        public IEnumerable<HElement> AngularElements()
        {
            return Elements.Where(element => element.HasAngularAttribute());
        }

        public IEnumerable<Error> LintErrors()
        {
            return Elements.Where(element => element.HasAngularAttribute())
                           .SelectMany(element => element.LintErrors());
        }

        public IEnumerator<HElement> GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Elements.GetEnumerator();
        }
    }
}
