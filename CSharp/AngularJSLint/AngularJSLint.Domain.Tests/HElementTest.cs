using AngularJSLint.Domain.Tests.Builders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain
{
    [TestFixture]
    public class HElementTest
    {
        [Test]
        public void AngularAttributes_With_One_AngularAttribe_And_One_Without_Should_Return_One_Attribute()
        {
            HElement element = HElementBuilder.Create.Default()
                                                     .WithNormalAttribute()
                                                     .WithAngularAttribute();
            var attributes = element.AngularAttributes();
            Assert.AreEqual(1, attributes.Count());
        }

        [Test]
        public void HasAngularAttribute_With_NgController_Returns_True()
        {
            HElement element = HElementBuilder.Create.Default()
                                                     .WithAngularAttribute();
            Assert.True(element.HasAngularAttribute());
        }

        [Test]
        public void HasAngularAttribute_With_Normal_Attribute_Returns_False()
        {
            HElement element = HElementBuilder.Create.Default()
                                                     .WithNormalAttribute();
            Assert.False(element.HasAngularAttribute());
        }
    }
}
