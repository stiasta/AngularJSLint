using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain.Tests.Builders
{
    public class HAttributeBuilder
    {
        private static HAttribute attribute;
        public static HAttributeBuilder Create
        {
            get
            {
                return new HAttributeBuilder();
            }
        }

        public HAttributeBuilder AngularAttribute()
        {
            attribute = new HAttribute()
            {
                Name = HAttribute._NgController,
                Value = "storeController as store"
            };

            return this;
        }

        public HAttribute NormalAttribute()
        {
            attribute = new HAttribute();
            attribute.Name = "id";
            attribute.Value = "identifier";
            return this;
        }

        public HAttribute WithInvalidControllerAs()
        {
            attribute.Value = "storeController";
            return this;
        }

        public static implicit operator HAttribute(HAttributeBuilder b)
        {
            return attribute;
        }
    }
}
