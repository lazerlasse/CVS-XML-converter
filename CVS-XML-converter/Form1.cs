using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CVS_XML_converter
{

    public partial class Form1 : Form
    {
        List<string> listFiles = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        public void btnOpen_Click(object sender, EventArgs e)
        {
            listFiles.Clear();
            listView.Items.Clear();
            using (FolderBrowserDialog fdb = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fdb.SelectedPath;
                    foreach (string item in Directory.GetFiles(fdb.SelectedPath))
                    {
                        imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                        FileInfo fi = new FileInfo(item);
                        listFiles.Add(fi.FullName);
                        listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                    }

                }



            }
        }

        private void btnXml_Click(object sender, EventArgs e)
        {

            //Metode til at gemme indstillingerne i en xml fil.
           
        }
        public void SaveSettings()
        {
            //Indlæser og starter XML writeren.
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(txtPath.Text);       //Dette åbner writer og skriver filen.
            writer.WriteStartDocument();                                    //Starter dokumentet.
            writer.WriteComment("test");    //Opretter kommentar i filen.
            writer.WriteStartElement("BULK");
            writer.WriteStartElement("REGISTRER");
            writer.WriteStartElement("MEDARBEJDER-SIGNATUR");

            writer.WriteStartElement("NAVN");
            foreach (string Navn in listFiles)
            {
                writer.WriteElementString("NAVN", Navn);
            }
            writer.WriteEndElement();

        
            writer.WriteStartElement("EMAIL");
            foreach (string Email in listFiles)
            {
                writer.WriteElementString("EMAIL", Email);
            }
            writer.WriteEndElement();

            writer.WriteStartElement("ADRESSE-LINJER");
            writer.WriteStartElement("ADRESSE-LINJE");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("POST-NR");
            writer.WriteEndElement();

            writer.WriteStartElement("BY");
            writer.WriteEndElement();

            writer.WriteStartElement("SIGNATUR-TYPE");
            writer.WriteStartElement("NOEGLEFIL-STRAKSUDSTEDT");
            writer.WriteStartElement("EMAIL-I-CERTIFIKAT-LDAP-REGISTRERING");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();


            //Lukker dokumentet og writeren.
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();


            writer.Flush();
            writer.Close();


        }
    }
}
