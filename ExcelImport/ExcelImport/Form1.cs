using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
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
                Filter = "CSV files (*.csv)|*.csv",
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
            var timeStamp = GetTimestamp(DateTime.Now);
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Output\";
            var filePath = folderPath + timeStamp + ".csv";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            List<string> data = new List<string>();
            using (TextFieldParser parser = new TextFieldParser(tbFileName.Text))
            {
                parser.TextFieldType = FieldType.Delimited;
                var headerLine = parser.ReadLine();
                data.Add(headerLine);
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields =  parser.ReadFields();
                    if (Convert.ToInt64(fields[14]) > Convert.ToInt64(72))
                    {
                        var line = "\"" + string.Join("\",\"", fields) + "\"";
                        data.Add(line);
                    }
                }
            }

            using (var file = File.CreateText(filePath))
            {
                foreach (var item in data)
                {
                    file.WriteLine(item);
                }
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }
    }
}