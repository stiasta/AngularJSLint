using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain.Repository
{
    public class HtmlReader
    {
        private readonly string text;
        private readonly HtmlDocument htmlDocument;
        public HtmlReader(string text)
        {
            this.text = text;
            this.htmlDocument = new HtmlDocument();
            this.htmlDocument.LoadHtml(this.text);
        }

        public HElementList GetNodes(string withAttribute)
        {
            var navigator = htmlDocument.CreateNavigator();
            var nodes = navigator.Select(string.Format("//*[{0}]", withAttribute));

            var list = new HElementList();
            do
            {
                var node = (nodes.Current as HtmlNodeNavigator).CurrentNode.FirstChild;
                list.Elements.Add(new HElement()
                {
                    Element = node.Name,
                    Linenumber = node.Line,
                    Column = node.LinePosition,
                    Attributes = node.Attributes.Select(x => new HAttribute()
                    {
                        Name = x.Name,
                        Value = x.Value,
                        LineNumber = x.Line,
                        ColumnNumber = x.LinePosition
                    }).ToList()
                });
            } while (nodes.MoveNext());

            return list;
        }
    }
}
