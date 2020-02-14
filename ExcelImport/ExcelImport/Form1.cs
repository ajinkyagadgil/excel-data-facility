using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExcelImport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImportExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "CSV files (*.csv)|*.csv|Excel Files|*.xls;*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog.FileName;
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            List<string> data1 = new List<string>();
            List<long> lineNo = new List<long>();
            List<TextFieldParser> gg = new List<TextFieldParser>();
            using (TextFieldParser parser = new TextFieldParser(tbFileName.Text))
            {
                parser.TextFieldType = FieldType.Delimited;
                var headerLine = parser.ReadLine();
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if(Convert.ToInt64(fields[14]) > Convert.ToInt64(72))
                    {
                        gg.Add(parser);
                        lineNo.Add(parser.LineNumber);
                        //data1.Add(parser.ReadLine());
                    }
                }
            }


            //var res = File.ReadAllText(tbFileName.Text);
            //var res1 = File.ReadAllLines(tbFileName.Text);

            //var header = res.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Take(1).FirstOrDefault();
            ////var header1 = res1.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Take(1).FirstOrDefault();

            //var fileData = res.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

            //foreach (var data in fileData)
            //{
            //    var data1 = data.Split(',');
            //}



            //var lineCount = File.ReadLines(tbFileName.Text).Count();
            //List<string> test1 = new List<string>();
            //List<long> lineNum = new List<long>();
            //var lineinit = 2;
            //using (TextFieldParser parser = new TextFieldParser(tbFileName.Text))
            //{
            //    var test = parser;
            //    parser.TextFieldType = FieldType.Delimited;
            //    string headerLine = parser.ReadLine();
            //    parser.SetDelimiters(",");
            //    while(lineinit != lineCount)
            //    {

            //        var line = parser.ReadLine();
            //        lineNum.Add(parser.LineNumber);
            //        lineinit++;
            //        var data = parser.ReadFields();

            //        //if(data != null)
            //        //{
            //            if (Convert.ToDecimal(data[14]) > 72)
            //            {
            //                test1.Add(line);
            //            }
            //        //}
            //    }
            //}

            //var lines = File.ReadAllLines(tbFileName.Text).ToList();
            //var headers = lines.First();
            //List<string> test = new List<string>();
            //foreach(var line in lines.Skip(1))
            //{
            //    var columns = line.Split(',');
            //    var availableStock = decimal.Parse(columns[14].Replace("\"", string.Empty), CultureInfo.InvariantCulture);

            //    if(availableStock > 72)
            //    {
            //        test.Add(line);
            //    }
            //}
        }
    }
}

