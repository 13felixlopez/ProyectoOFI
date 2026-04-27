using System.IO;
using System.Xml;

namespace ProyectoOFI.Logica
{
    public class Desencryptacion
    {
        static private AES aes = new AES();
        static public string CnString;
        static string dbcnString;
        static public string appPwdUnique = "OFi_23/24S!stemaSeguimientoCafé";
        //public static object checkServer()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("ConnectionString.xml");
        //    XmlElement root = doc.DocumentElement;
        //    dbcnString = root.Attributes[0].Value;
        //    CnString = (aes.Decrypt(dbcnString, appPwdUnique, int.Parse("256")));
        //    return CnString;
        //}
        public static object checkServer()
        {
            string filePath = "ConnectionString.xml";

            // Verificar si el archivo existe
            if (!File.Exists(filePath))
            {
                // Crear el archivo con el contenido especificado si no existe
                CreateXmlFile(filePath);
            }

            // Cargar y procesar el archivo XML existente
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement root = doc.DocumentElement;
            string dbcnString = root.Attributes["DBcnString"].Value;
            string CnString = aes.Decrypt(dbcnString, appPwdUnique, int.Parse("256"));
            return CnString;
        }
        private static void CreateXmlFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();

            // Crear la declaración XML
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            // Crear el elemento raíz
            XmlElement databaseElement = doc.CreateElement(string.Empty, "database", string.Empty);
            doc.AppendChild(databaseElement);

            // Agregar el atributo DBcnString
            XmlAttribute dbcnStringAttribute = doc.CreateAttribute("DBcnString");
            dbcnStringAttribute.Value = "Hola";
            databaseElement.Attributes.Append(dbcnStringAttribute);

            // Guardar el archivo
            doc.Save(filePath);
        }
    }
}
