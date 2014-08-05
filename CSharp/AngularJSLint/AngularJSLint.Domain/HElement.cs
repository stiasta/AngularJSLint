using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngularJSLint.Domain
{
    public class HElement
    {
        public int Linenumber { get; set; }
        public int Column { get; set; }
        public string Element { get; set; }

        private List<HAttribute> _attributes;
        public List<HAttribute> Attributes 
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new List<HAttribute>();
                }

                return _attributes;
            }

            set
            {
                _attributes = value;
            }
        }

        public IEnumerable<HAttribute> AngularAttributes()
        {
            return Attributes.Where(attribute => attribute.IsAngularAttribute());
        }

        public bool HasAngularAttribute()
        {
            return AngularAttributes().Count() > 0;
        }

        public IEnumerable<Error> LintErrors()
        {
            return AngularAttributes().SelectMany(attribute => attribute.LintErrors());
        }
    }
}
