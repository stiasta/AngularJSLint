using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Tests
{
    [TestFixture]
    public class AngularJSLintTest
    {
        [Test]
        public void Parse_With_1_Invalid_ControllerAs_Syntax_Should_Return_1_Error()
        {
            var app = new AngularJSLint("<div ng-controller=\"mainController\"></div>", true);

            var result = app.Parse();
            Assert.AreEqual(1, result.Count());
        }
    }
}
