namespace fbLauncher
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bwWorkLoop = new System.ComponentModel.BackgroundWorker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRunningCount = new System.Windows.Forms.Label();
            this.cbDoWork = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStartedSummary = new System.Windows.Forms.Label();
            this.lbKills = new System.Windows.Forms.Label();
            this.bwKoriaviyKostil = new System.ComponentModel.BackgroundWorker();
            this.tbMaxCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(598, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(598, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bwWorkLoop
            // 
            this.bwWorkLoop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwWorkLoop_DoWork);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(476, 537);
            this.dataGridView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Активно:";
            // 
            // lbRunningCount
            // 
            this.lbRunningCount.AutoSize = true;
            this.lbRunningCount.Location = new System.Drawing.Point(649, 64);
            this.lbRunningCount.Name = "lbRunningCount";
            this.lbRunningCount.Size = new System.Drawing.Size(13, 13);
            this.lbRunningCount.TabIndex = 4;
            this.lbRunningCount.Text = "0";
            // 
            // cbDoWork
            // 
            this.cbDoWork.AutoSize = true;
            this.cbDoWork.Location = new System.Drawing.Point(524, 42);
            this.cbDoWork.Name = "cbDoWork";
            this.cbDoWork.Size = new System.Drawing.Size(97, 17);
            this.cbDoWork.TabIndex = 5;
            this.cbDoWork.Text = "Активировать";
            this.cbDoWork.UseVisualStyleBackColor = true;
            this.cbDoWork.CheckedChanged += new System.EventHandler(this.cbDoWork_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(521, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Всего запусков";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Закрыто по таймауту";
            // 
            // lbStartedSummary
            // 
            this.lbStartedSummary.AutoSize = true;
            this.lbStartedSummary.Location = new System.Drawing.Point(649, 82);
            this.lbStartedSummary.Name = "lbStartedSummary";
            this.lbStartedSummary.Size = new System.Drawing.Size(13, 13);
            this.lbStartedSummary.TabIndex = 8;
            this.lbStartedSummary.Text = "0";
            // 
            // lbKills
            // 
            this.lbKills.AutoSize = true;
            this.lbKills.Location = new System.Drawing.Point(649, 100);
            this.lbKills.Name = "lbKills";
            this.lbKills.Size = new System.Drawing.Size(13, 13);
            this.lbKills.TabIndex = 9;
            this.lbKills.Text = "0";
            // 
            // bwKoriaviyKostil
            // 
            this.bwKoriaviyKostil.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwKoriaviyKostil_DoWork);
            // 
            // tbMaxCount
            // 
            this.tbMaxCount.Location = new System.Drawing.Point(627, 39);
            this.tbMaxCount.Name = "tbMaxCount";
            this.tbMaxCount.Size = new System.Drawing.Size(46, 20);
            this.tbMaxCount.TabIndex = 10;
            this.tbMaxCount.Text = "3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 561);
            this.Controls.Add(this.tbMaxCount);
            this.Controls.Add(this.lbKills);
            this.Controls.Add(this.lbStartedSummary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDoWork);
            this.Controls.Add(this.lbRunningCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker bwWorkLoop;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRunningCount;
        private System.Windows.Forms.CheckBox cbDoWork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStartedSummary;
        private System.Windows.Forms.Label lbKills;
        private System.ComponentModel.BackgroundWorker bwKoriaviyKostil;
        private System.Windows.Forms.TextBox tbMaxCount;
    }
}

