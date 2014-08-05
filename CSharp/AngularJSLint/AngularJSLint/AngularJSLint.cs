using AngularJSLint.Domain;
using AngularJSLint.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint
{
    public class AngularJSLint
    {
        private readonly HtmlReader htmlReader;
        private readonly string text;
        private readonly bool isHtml;

        public AngularJSLint(string text, bool isHtml)
        {
            this.text = text;
            this.isHtml = isHtml;
            this.htmlReader = new HtmlReader(text);
        }

        public IEnumerable<Error> Parse()
        {
            var nodes = htmlReader.GetNodes("ng-controller");
            return nodes.LintErrors();
        }
    }
}
