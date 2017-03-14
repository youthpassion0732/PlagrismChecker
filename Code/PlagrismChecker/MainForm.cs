using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace PlagrismChecker
{
    public partial class MainForm : Form
    {

        private List<string> _SourceFileContent;
        private ConcurrentBag<CompareResult> _CompareResultBag;
        private ConcurrentBag<CompareResult> _UnMatchResultBag;


        #region properties

        public List<string> SourceFileContent
        {
            get
            {
                if (_SourceFileContent == null)
                    _SourceFileContent = new List<string>();

                return _SourceFileContent;
            }
            set
            {
                _SourceFileContent = value;
            }
        }

        public ConcurrentBag<CompareResult> CompareResultBag
        {
            get
            {
                if (_CompareResultBag == null)
                    _CompareResultBag = new ConcurrentBag<CompareResult>();

                return _CompareResultBag;
            }
            set
            {
                _CompareResultBag = value;
            }
        }

        public ConcurrentBag<CompareResult> UnMatchResultBag
        {
            get
            {
                if (_UnMatchResultBag == null)
                    _UnMatchResultBag = new ConcurrentBag<CompareResult>();

                return _UnMatchResultBag;
            }
            set
            {
                _UnMatchResultBag = value;
            }
        }

        #endregion  


        #region form events

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

                labelPalagrismPer.Visible = false;
                labelPalagrismResult.Visible = false;

                toolTipDelimiter.SetToolTip(textBoxDelimiter, "Type Chracter/Word With Space");

                // bind grid columns
                BindDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fileBrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files|*.txt; *.doc; *.docx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePathtextBox.Text = openFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dirBrowsebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    dirPathtextBox.Text = folderBrowserDialog.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            try
            {

                // reset form values
                ResetFormValues();

                if (string.IsNullOrEmpty(filePathtextBox.Text.Trim()))
                {
                    MessageBox.Show("Compare file is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(dirPathtextBox.Text.Trim()))
                {
                    MessageBox.Show("Compare directory is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // get all files from directory
                    string[] filesList = Directory.GetFiles(dirPathtextBox.Text.Trim(), "*.*", SearchOption.AllDirectories);

                    // prepare splited source file content
                    SourceFileContent = new List<string>();
                    SourceFileContent = PrepareSplitFileContent(filePathtextBox.Text.Trim());

                    // compare directory files content with browsed file content 
                    CompareFiles(filesList);

                    if (CompareResultBag.Count == 0)
                        MessageBox.Show("No Plagiarism found! File is 100% identical.", "Plagiarism Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // populate results into grid
                    dataGridView.DataSource = CompareResultBag.ToList();

                   // set plagiarism result in percentage
                   SetPlagiarismPercentage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = null;
                labelPalagrismResult.Text = "0%";
                textBoxDelimiter.Text = "";
                dirPathtextBox.Text = "";
                filePathtextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region private methods

        // bind grid columns
        private void BindDataGridViewColumns()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = null;

            dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn.DataPropertyName = "matchText";
            dataGridViewTextBoxColumn.Name = "matchText";
            dataGridViewTextBoxColumn.HeaderText = "Match Text";
            dataGridViewTextBoxColumn.ReadOnly = true;
            dataGridViewTextBoxColumn.Visible = true;
            dataGridViewTextBoxColumn.Width = 400;
            dataGridView.Columns.Add(dataGridViewTextBoxColumn);

            dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn.DataPropertyName = "charTracing";
            dataGridViewTextBoxColumn.Name = "charTracing";
            dataGridViewTextBoxColumn.HeaderText = "Character Tracing";
            dataGridViewTextBoxColumn.ReadOnly = true;
            dataGridViewTextBoxColumn.Visible = true;
            dataGridViewTextBoxColumn.Width = 200;
            dataGridView.Columns.Add(dataGridViewTextBoxColumn);

            dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn.DataPropertyName = "filePath";
            dataGridViewTextBoxColumn.Name = "filePath";
            dataGridViewTextBoxColumn.HeaderText = "File Path";
            dataGridViewTextBoxColumn.ReadOnly = true;
            dataGridViewTextBoxColumn.Visible = true;
            dataGridViewTextBoxColumn.Width = 600;
            dataGridView.Columns.Add(dataGridViewTextBoxColumn);

            dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn.DataPropertyName = "filePercentage";
            dataGridViewTextBoxColumn.Name = "filePercentage";
            dataGridViewTextBoxColumn.HeaderText = "Overall Plagiarism in File";
            dataGridViewTextBoxColumn.ReadOnly = true;
            dataGridViewTextBoxColumn.Visible = true;
            dataGridViewTextBoxColumn.Width = 200;
            dataGridView.Columns.Add(dataGridViewTextBoxColumn);
        }

        // prepare splited file content
        private List<string> PrepareSplitFileContent(string filePath)
        {
            try
            {

                int matchingWordsCount = 4;
                int.TryParse(textBoxWordsMatch.Text.Trim(), out matchingWordsCount);

                if (matchingWordsCount == 0)
                    throw new Exception("words match field is not valid.");

                List<string> fileContentList = new List<string>();

                // get file content
                string fileContent = GetFileText(filePath);

                if (!string.IsNullOrEmpty(fileContent))
                {

                    string[] splitContent = fileContent.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                    if (splitContent.Length > 0)
                    {
                        for (int i = 0; i < splitContent.Length - matchingWordsCount + 1; i++)
                        {
                            string wordCombination = GetStringCombination(splitContent, i, matchingWordsCount);

                            if (!string.IsNullOrEmpty(wordCombination.Trim()))
                                fileContentList.Add(wordCombination);
                        }
                    }
                }
                else
                {
                    throw new Exception("file is empty");
                }

                return fileContentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // read the contents of the file
        private string GetFileText(string name)
        {
            try
            {
                string fileContents = String.Empty;

                if (File.Exists(name))
                {
                    if (name.ToLower().Contains(".doc") || name.ToLower().Contains(".docx"))
                    {
                        // read content of office word files
                        Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                        Document document = application.Documents.Open(name);
                        fileContents = document.Content.Text;
                        application.Quit();
                    }
                    else
                    {
                        // read content of txt files
                        fileContents = File.ReadAllText(name);
                    }

                    // removing delimiters from content
                    if (!string.IsNullOrEmpty(fileContents.Trim()))
                    {
                        foreach (string delimiter in textBoxDelimiter.Text.Split(' '))
                        {
                            if (!string.IsNullOrEmpty(delimiter) && fileContents.Contains(delimiter))
                                fileContents = fileContents.Replace(delimiter, "").Trim();
                        }

                        fileContents = Regex.Replace(fileContents, @"\t|\n|\r", " ");
                        if (fileContents.Contains("  ")) fileContents = fileContents.Replace("  ", " ").Trim();
                    }
                }
                else
                {
                    throw new Exception("file not found");
                }

                return fileContents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // create string combinations of browsed file, according to "matchingWordsCount"
        private string GetStringCombination(string[] splitContent, int index, int matchingWordsCount)
        {
            try
            {

                string wordCombination = string.Empty;

                for (int i = 1; i <= matchingWordsCount; i++)
                {
                    wordCombination = wordCombination + " " + splitContent[index];
                    index++;
                }

                return wordCombination.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // compare directory files content with browsed file content
        private void CompareFiles(string[] filesList)
        {
            try
            {

                CompareResultBag = new ConcurrentBag<CompareResult>();
                UnMatchResultBag = new ConcurrentBag<CompareResult>();

                Int32 totalFiles = filesList.Length;
                Parallel.For(0, totalFiles, (i) =>
                {
                    CompareFile(i, filesList);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // compare directory file content with browsed file content
        private void CompareFile(int i, string[] filesList)
        {
            try
            {
                string fileContent = GetFileText(filesList[i]);

                if (!string.IsNullOrEmpty(fileContent.Trim()))
                {
                    foreach (string text in SourceFileContent)
                    {
                        if (fileContent.Replace(" ", "").ToLower().Trim().Contains(text.Replace(" ", "").ToLower().Trim()))
                        {
                            CompareResult compareResult = new CompareResult();
                            compareResult.matchText = text;
                            compareResult.filePath = filesList[i];
                            // set value of chracter tracing
                            compareResult.charTracing = SetCharTracingText(fileContent, text);

                            CompareResultBag.Add(compareResult);
                        }
                        else
                        {
                            // for testing only
                            CompareResult compareResult = new CompareResult();
                            compareResult.matchText = text;
                            compareResult.filePath = filesList[i];
                            UnMatchResultBag.Add(compareResult);
                        }
                    }

                    var fileMatchWords = CompareResultBag.Where(x => x.filePath == filesList[i]);
                    if (fileMatchWords != null && fileMatchWords.ToList().Count > 0)
                    {
                        var compareResultsList = fileMatchWords.GroupBy(item => item.matchText)
                                                         .Select(grp => grp.OrderBy(item => item.matchText).First())
                                                         .ToList();
                        double totalMatchWords = (double)compareResultsList.Count;
                        double fileWordsWithCombination = SourceFileContent.Distinct().ToList().Count;

                        double percentage = Convert.ToDouble(totalMatchWords / fileWordsWithCombination) * 100;
                        fileMatchWords.FirstOrDefault().filePercentage = Math.Round(percentage, 2).ToString() + "%";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // set plagiarism result in percentage
        private void SetPlagiarismPercentage()
        {
            try
            {
                double percentage = 0;

                var sourceFileList = SourceFileContent.Distinct().ToList();
                var compareResultsList = CompareResultBag.GroupBy(item => item.matchText)
                                                         .Select(grp => grp.OrderBy(item => item.matchText).First())
                                                         .ToList();

                if (sourceFileList.Count > 0 && compareResultsList.Count > 0)
                    percentage = Convert.ToDouble((double)compareResultsList.Count / (double)sourceFileList.Count) * 100;

                labelPalagrismPer.Visible = true;
                labelPalagrismResult.Visible = true;

                labelPalagrismResult.Text = Math.Round(percentage, 2).ToString() + "%";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // set value of chracter tracing
        private string SetCharTracingText(string fileContent, string matchText)
        {
            try
            {
                string charTracingText = string.Empty;

                int startIndex = fileContent.Replace(" ", "").ToLower().Trim().IndexOf(matchText.Replace(" ", "").ToLower().Trim());
                int textLength = matchText.Replace(" ", "").ToLower().Trim().Length;
                int endIndex = startIndex + textLength;

                charTracingText = string.Format("From {0} to {1}", startIndex + 1, endIndex);

                return charTracingText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResetFormValues()
        {
            try
            {
                dataGridView.DataSource = null;
                labelPalagrismResult.Text = "0%";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
