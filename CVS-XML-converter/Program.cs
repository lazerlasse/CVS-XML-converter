using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVS_XML_converter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

//        XmlTextWriter writer = new XmlTextWriter("users.xml", Encoding.UTF8);

//        writer.WriteStartDocument();
//            writer.WriteStartElement("users");

//            using (CsvReader reader = new CsvReader("users.csv"))
//            {
//                reader.ReadHeaders();

//                while (reader.ReadRecord())
//                {
//                    writer.WriteStartElement("user");

//                    writer.WriteElementString("user_id", reader["user_id"]);
//                    writer.WriteElementString("first_name", reader["first_name"]);
//                    writer.WriteElementString("last_name", reader["last_name"]);

//                    writer.WriteEndElement();
//                }

//    reader.Close();
//            }

//writer.WriteEndElement();
//            writer.WriteEndDocument();
//            writer.Close();
    }
}
