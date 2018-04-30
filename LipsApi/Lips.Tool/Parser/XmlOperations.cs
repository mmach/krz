using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Lips.Tool.Parser
{
    public class XsltOperations
    {
        // Methods
        public static string ReturnFilledHtml(string xml, string xslt)
        {
            XmlReader input = XmlReader.Create(new StringReader(xml));
            XslCompiledTransform transform = new XslCompiledTransform();
            XslCompiledTransform transform2 = new XslCompiledTransform();
            XmlReader stylesheet = XmlReader.Create(new StringReader(xslt));
            using (StringWriter writer = new StringWriter())
            {
                using (XmlWriter writer2 = XmlWriter.Create(writer))
                {
                    transform2.Load(stylesheet);
                    transform2.Transform(input, writer2);
                    writer2.Close();
                }
                return writer.ToString();
            }
        }
    }

 

}
