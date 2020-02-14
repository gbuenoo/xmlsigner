using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLSigner
{
    public class XMLHandler
    {
        public XmlDocument XMLImport(string xmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(xmlPath);

            return xmlDoc;
        }

        public XmlDocument XMLSign(XmlDocument xml, RSA rsaKey)
        {

            var signedXML = new SignedXml(xml);
            signedXML.SigningKey = rsaKey;

            Reference reference = new Reference();
            reference.Uri = "";

            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            signedXML.AddReference(reference);

            signedXML.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXML.GetXml();

            xml.DocumentElement.AppendChild(xml.ImportNode(xmlDigitalSignature, true));

            return xml;
        }

        public void XMLExport(XmlDocument xml, string path)
        {
            xml.Save(path);
        }
    }
}
