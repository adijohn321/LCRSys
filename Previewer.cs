using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCRSys
{
    public partial class Previewer : Form
    {
        public Previewer()
        {
            InitializeComponent();
        }

        public Previewer(string[] data, string[] x, string form)
        {
            this.data = data;
            this.x = x;



            tmpFile = Environment.CurrentDirectory + "/templates/"+form+".pdf";
            filelocation = Environment.CurrentDirectory + "/templates/" + form + ".docx";

            switch (form)
            {
                case "Form97page1":
                    start = 0;
                    startx = 0;
                    break;
                case "Form97page2":
                    start = 73;
                    startx = 6;
                    break;
                case "Form102page1":
                    start = 0;
                    startx = 0;
                    break;
                case "Form102page2":
                    start = 62;
                    startx = 5;
                    break;
                case "Form103page1":
                    start = 0;
                    startx = 0;
                    break;
                case "Form103page2":
                    start = 61;
                    startx = 15;
                    break;
                default:
                    break;
            }
            InitializeComponent();
        }

      


        string[] data;
        string[] x;

        Microsoft.Office.Interop.Word.Application app;
        Microsoft.Office.Interop.Word.Document doc;
        object objMissing = Missing.Value;
        object tmpFile;
        object filelocation;
        int start = 0;
        int startx = 0;

        private void Previewer_Load(object sender, EventArgs e)
        {

            try
            {
                app = new Microsoft.Office.Interop.Word.Application();
                doc = app.Documents.Open(ref filelocation, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing);



                //find and replace here
                for (int a = 0; a < data.Length; a++) {
                    findAndReplace("[data"+(a+start)+"]",data[a]);
                }
                for (int b = 0; b<x.Length;b++) {
                    findAndReplace("[x"+(b+startx)+"]",x[b]);
                }
               
                






                doc.ExportAsFixedFormat(tmpFile.ToString(), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                this.PDFviewer.src = tmpFile.ToString();
                this.PDFviewer.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                doc.Close(WdSaveOptions.wdDoNotSaveChanges, WdOriginalFormat.wdOriginalDocumentFormat, false);
                app.Quit(WdSaveOptions.wdDoNotSaveChanges);
            }

        }
        private void findAndReplace(object find, object replaceWith)
        {
            this.app.Selection.Find.Execute(ref find, true, true, false, false, false, true, false, 1, ref replaceWith, 2, false, false, false, false);
        }

        void form97() {
            
        }

    }
}
