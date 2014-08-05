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
    public class HAttributeTest
    {
        [Test]
        public void IsAngularAttribute_With_NgController_Should_Return_True()
        {
            HAttribute attribute = HAttributeBuilder.Create.AngularAttribute();
            Assert.True(attribute.IsAngularAttribute());
        }

        [Test]
        public void IsAngularAttribute_With_Id_Should_Return_False()
        {
            HAttribute attribute = HAttributeBuilder.Create.NormalAttribute();
            Assert.False(attribute.IsAngularAttribute());
        }

        [Test]
        public void IsLint_Where_NgController_Is_ControllerAs_Returns_True()
        {
            HAttribute attribute = HAttributeBuilder.Create.AngularAttribute();
            Assert.True(attribute.IsLint());
        }

        [Test]
        public void IsLint_Where_Ng_Controller_IsNot_ControllerAs_Returns_False()
        {
            HAttribute attribute = HAttributeBuilder.Create.AngularAttribute()
                                                                .WithInvalidControllerAs();
            Assert.False(attribute.IsLint());
        }

        [Test]
        public void LintErrors_With_No_Errors_Returns_Empty_List()
        {
            HAttribute attribute = HAttributeBuilder.Create.AngularAttribute();
            Assert.AreEqual(0, attribute.LintErrors().Count);
        }

        [Test]
        public void LintErrors_With_NgController_Without_ControllerAs_Returns_1_Error()
        {
            HAttribute attribute = HAttributeBuilder.Create.AngularAttribute()
                                                           .WithInvalidControllerAs();
            Assert.AreEqual(1, attribute.LintErrors().Count);
        }
    }
}
