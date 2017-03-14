namespace PlagrismChecker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.filePathtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dirPathtextBox = new System.Windows.Forms.TextBox();
            this.dirBrowsebutton = new System.Windows.Forms.Button();
            this.compareButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.fileBrowseButton = new System.Windows.Forms.Button();
            this.labelPalagrismPer = new System.Windows.Forms.Label();
            this.labelPalagrismResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWordsMatch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDelimiter = new System.Windows.Forms.TextBox();
            this.toolTipDelimiter = new System.Windows.Forms.ToolTip(this.components);
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // filePathtextBox
            // 
            this.filePathtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathtextBox.Location = new System.Drawing.Point(147, 23);
            this.filePathtextBox.Name = "filePathtextBox";
            this.filePathtextBox.ReadOnly = true;
            this.filePathtextBox.Size = new System.Drawing.Size(441, 20);
            this.filePathtextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File to compare";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Directory to compare";
            // 
            // dirPathtextBox
            // 
            this.dirPathtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirPathtextBox.Location = new System.Drawing.Point(147, 60);
            this.dirPathtextBox.Name = "dirPathtextBox";
            this.dirPathtextBox.ReadOnly = true;
            this.dirPathtextBox.Size = new System.Drawing.Size(441, 20);
            this.dirPathtextBox.TabIndex = 4;
            // 
            // dirBrowsebutton
            // 
            this.dirBrowsebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dirBrowsebutton.Location = new System.Drawing.Point(594, 57);
            this.dirBrowsebutton.Name = "dirBrowsebutton";
            this.dirBrowsebutton.Size = new System.Drawing.Size(102, 23);
            this.dirBrowsebutton.TabIndex = 3;
            this.dirBrowsebutton.Text = "Browse Directory";
            this.dirBrowsebutton.UseVisualStyleBackColor = true;
            this.dirBrowsebutton.Click += new System.EventHandler(this.dirBrowsebutton_Click);
            // 
            // compareButton
            // 
            this.compareButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compareButton.Location = new System.Drawing.Point(486, 161);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(102, 32);
            this.compareButton.TabIndex = 6;
            this.compareButton.Text = "Compare File";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 224);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(689, 300);
            this.dataGridView.TabIndex = 7;
            // 
            // fileBrowseButton
            // 
            this.fileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBrowseButton.Location = new System.Drawing.Point(594, 20);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(102, 23);
            this.fileBrowseButton.TabIndex = 9;
            this.fileBrowseButton.Text = "Browse File";
            this.fileBrowseButton.UseVisualStyleBackColor = true;
            this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
            // 
            // labelPalagrismPer
            // 
            this.labelPalagrismPer.AutoSize = true;
            this.labelPalagrismPer.Location = new System.Drawing.Point(11, 195);
            this.labelPalagrismPer.Name = "labelPalagrismPer";
            this.labelPalagrismPer.Size = new System.Drawing.Size(61, 13);
            this.labelPalagrismPer.TabIndex = 10;
            this.labelPalagrismPer.Text = "Palagrism =";
            // 
            // labelPalagrismResult
            // 
            this.labelPalagrismResult.AutoSize = true;
            this.labelPalagrismResult.Location = new System.Drawing.Point(70, 195);
            this.labelPalagrismResult.Name = "labelPalagrismResult";
            this.labelPalagrismResult.Size = new System.Drawing.Size(13, 13);
            this.labelPalagrismResult.TabIndex = 11;
            this.labelPalagrismResult.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "N Gram (Words To Match)";
            // 
            // textBoxWordsMatch
            // 
            this.textBoxWordsMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWordsMatch.Location = new System.Drawing.Point(147, 95);
            this.textBoxWordsMatch.Name = "textBoxWordsMatch";
            this.textBoxWordsMatch.Size = new System.Drawing.Size(541, 20);
            this.textBoxWordsMatch.TabIndex = 12;
            this.textBoxWordsMatch.Text = "4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Characters To Ignore";
            // 
            // textBoxDelimiter
            // 
            this.textBoxDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDelimiter.Location = new System.Drawing.Point(147, 125);
            this.textBoxDelimiter.Name = "textBoxDelimiter";
            this.textBoxDelimiter.Size = new System.Drawing.Size(541, 20);
            this.textBoxDelimiter.TabIndex = 14;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(594, 161);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(94, 32);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 536);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDelimiter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxWordsMatch);
            this.Controls.Add(this.labelPalagrismResult);
            this.Controls.Add(this.labelPalagrismPer);
            this.Controls.Add(this.fileBrowseButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dirPathtextBox);
            this.Controls.Add(this.dirBrowsebutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePathtextBox);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox filePathtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dirPathtextBox;
        private System.Windows.Forms.Button dirBrowsebutton;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button fileBrowseButton;
        private System.Windows.Forms.Label labelPalagrismPer;
        private System.Windows.Forms.Label labelPalagrismResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWordsMatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDelimiter;
        private System.Windows.Forms.ToolTip toolTipDelimiter;
        private System.Windows.Forms.Button buttonClear;
    }
}

