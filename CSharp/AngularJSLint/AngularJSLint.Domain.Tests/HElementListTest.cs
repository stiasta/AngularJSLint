using AngularJSLint.Domain.Tests.Builders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain.Tests
{
    [TestFixture]
    public class HElementListTest
    {
        [Test]
        public void AngularElements_With_One_Elemenent_With_Angular_Attribute_And_One_Without_Returns_One_Element()
        {
            HElementList list = HElementListBuilder.Create.Default()
                                                          .With(HElementBuilder.Create.Default()
                                                                                      .WithAngularAttribute())
                                                          .With(HElementBuilder.Create.Default()
                                                                                      .WithNormalAttribute());
            Assert.AreEqual(1, list.AngularElements().Count());
        }

        [Test]
        public void LintErrors_With_One_Error_Returns_1_Element()
        {
            HElementList list = HElementListBuilder.Create.Default()
                                                                 .With(HElementBuilder.Create.Default()
                                                                                             .WithInvalidAngularAttribute());
            Assert.AreEqual(1, list.LintErrors().Count());
        }
    }
}
