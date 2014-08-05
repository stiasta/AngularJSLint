using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain.Tests.Builders
{
    public class HElementBuilder
    {
        private static HElement element;

        public static HElementBuilder Create
        {
            get
            {
                return new HElementBuilder();
            }
        }

        public HElementBuilder Default()
        {
            element = new HElement()
            {
                Column = 1,
                Linenumber = 1,
                Element = "div"
            };

            return this;
        }

        public HElementBuilder WithNormalAttribute()
        {
            element.Attributes.Add(new HAttribute()
            {
                Name = "id",
                Value = "divText"
            });

            return this;
        }

        public HElementBuilder WithAngularAttribute()
        {
            element.Attributes.Add(new HAttribute()
            {
                Name = "ng-controller",
                Value = "storeController"
            });

            return this;
        }

        public HElementBuilder WithInvalidAngularAttribute()
        {
            element.Attributes.Add(HAttributeBuilder.Create.AngularAttribute()
                                                           .WithInvalidControllerAs());
            return this;
        }

        public static implicit operator HElement(HElementBuilder b)
        {
            return element;
        }
    }
}
