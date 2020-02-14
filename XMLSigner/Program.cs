using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XMLSigner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var xmlPath = "..//..//XML//nfTeste.xml";
                var xmlOutputPath = "..//..//XML//output//xmlAssinado.xml";
                XMLHandler handler = new XMLHandler();

                var xml = handler.XMLImport(xmlPath);

                var rsa = new RSACryptoServiceProvider();

                Console.WriteLine("\nArquivo XML importado, realizando a assinatura...");
                var signedXml = handler.XMLSign(xml, rsa);

                Console.WriteLine("\nArquivo XML assinado e salvo em >> " + xmlOutputPath.ToString());
                handler.XMLExport(signedXml, xmlOutputPath);

            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um problema ao executar o processo.");
                Console.WriteLine("\nError:" + e.Message);

            }
            finally
            {
                Console.WriteLine("\n\nPressione qualquer tecla para sair... ");
                Console.ReadKey();
            }
        }
    }
}
