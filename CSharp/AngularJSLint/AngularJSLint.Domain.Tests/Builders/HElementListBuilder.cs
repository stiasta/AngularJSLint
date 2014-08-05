using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain.Tests.Builders
{
    public class HElementListBuilder
    {
        private static HElementList _list;
        public static HElementListBuilder Create
        {
            get
            {
                return new HElementListBuilder();
            }
        }

        public HElementListBuilder Default()
        {
            _list = new HElementList();
            return this;
        }

        public HElementListBuilder With(HElement element)
        {
            _list.Elements.Add(element);
            return this;
        }

        public static implicit operator HElementList(HElementListBuilder b)
        {
            return _list;
        }
    }
}
