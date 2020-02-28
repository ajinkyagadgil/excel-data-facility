using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ExcelImport
{
    public partial class ExcelFacilityForm : Form
    {
        /// <summary>
        /// Nlogger implementation for Logging
        /// </summary>
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ExcelFacilityForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Browse the CSV files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                tbFileName.Text = openFileDialog.FileName;
        }

        /// <summary>
        /// Parse the CSV file and output the output file to folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (tbFileName.Text == string.Empty || tbValue.Text == string.Empty)
                {
                    MessageBox.Show("There are errors in the form");
                    return;
                }
            }

            try
            {
                if (File.Exists(tbFileName.Text))
                {
                    var extension = Path.GetExtension(tbFileName.Text.ToLower());
                    if (extension == ".csv")
                    {
                        var timeStamp = GetTimestamp(DateTime.Now);
                        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Output\";
                        var filePath = folderPath + timeStamp + ".csv";

                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        List<string> data = new List<string>();
                        var value = tbValue.Text != string.Empty ? Convert.ToInt64(tbValue.Text) : 72;
                        using (TextFieldParser parser = new TextFieldParser(tbFileName.Text))
                        {
                            parser.TextFieldType = FieldType.Delimited;
                            var headerLine = parser.ReadLine();
                            data.Add(headerLine);
                            parser.SetDelimiters(",");
                            while (!parser.EndOfData)
                            {
                                string[] fields = parser.ReadFields();
                                if (Convert.ToInt64(fields[14]) < Convert.ToInt64(value))
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
                        OpenFolder(folderPath);
                    }
                    else
                        MessageBox.Show("Please select CSV file");
                }
                else
                    MessageBox.Show("File does not exist in current path");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Something went wrong, please check logs in program data");
            }
        }

        /// <summary>
        /// Get timespamp from current time for naming the output file
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// Opens the folder where file is saved after processing
        /// </summary>
        /// <param name="folderPath"></param>
        private void OpenFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = folderPath,
                        FileName = "explorer.exe"
                    };
                    Process.Start(startInfo);
                }
                else
                    MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Something went wrong while opening folder please check logs");
            }
        }

        /// <summary>
        /// Validation for Value field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbValue.Text == string.Empty)
                errorProviderValue.SetError(tbValue, "Value is required.");
            else
                errorProviderValue.SetError(tbValue, string.Empty);
        }

        /// <summary>
        /// Validation for file path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFileName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbFileName.Text == string.Empty)
                errorProviderValue.SetError(tbFileName, "File is required.");
            else
                errorProviderValue.SetError(tbFileName, string.Empty);
        }
    }
}