namespace WindowsFormsApplication1
{
    partial class WinMonitorConfig
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
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnUninstallService = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnApplyConfig = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComputerID = new System.Windows.Forms.TextBox();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCompanyID = new System.Windows.Forms.TextBox();
            this.btnStartRunner = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStopRunner = new System.Windows.Forms.Button();
            this.bkgdRunner = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(12, 49);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(111, 23);
            this.btnStartService.TabIndex = 0;
            this.btnStartService.Text = "Start Service";
            this.btnStartService.UseVisualStyleBackColor = true;
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(130, 50);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(111, 23);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "Stop Service";
            this.btnStopService.UseVisualStyleBackColor = true;
            // 
            // btnUninstallService
            // 
            this.btnUninstallService.Location = new System.Drawing.Point(248, 50);
            this.btnUninstallService.Name = "btnUninstallService";
            this.btnUninstallService.Size = new System.Drawing.Size(134, 23);
            this.btnUninstallService.TabIndex = 2;
            this.btnUninstallService.Text = "Uninstall Service";
            this.btnUninstallService.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Install Service";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnApplyConfig
            // 
            this.btnApplyConfig.Location = new System.Drawing.Point(248, 177);
            this.btnApplyConfig.Name = "btnApplyConfig";
            this.btnApplyConfig.Size = new System.Drawing.Size(149, 23);
            this.btnApplyConfig.TabIndex = 4;
            this.btnApplyConfig.Text = "Apply Configuration";
            this.btnApplyConfig.UseVisualStyleBackColor = true;
            this.btnApplyConfig.Click += new System.EventHandler(this.btnApplyConfig_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(130, 93);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(375, 22);
            this.txtURL.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "URL:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Computer ID:";
            // 
            // txtComputerID
            // 
            this.txtComputerID.Location = new System.Drawing.Point(130, 152);
            this.txtComputerID.Name = "txtComputerID";
            this.txtComputerID.Size = new System.Drawing.Size(111, 22);
            this.txtComputerID.TabIndex = 8;
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Location = new System.Drawing.Point(130, 122);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(375, 22);
            this.txtAPIKey.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "API Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Company ID:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.Location = new System.Drawing.Point(130, 180);
            this.txtCompanyID.Name = "txtCompanyID";
            this.txtCompanyID.Size = new System.Drawing.Size(111, 22);
            this.txtCompanyID.TabIndex = 12;
            // 
            // btnStartRunner
            // 
            this.btnStartRunner.Location = new System.Drawing.Point(13, 13);
            this.btnStartRunner.Name = "btnStartRunner";
            this.btnStartRunner.Size = new System.Drawing.Size(110, 23);
            this.btnStartRunner.TabIndex = 13;
            this.btnStartRunner.Text = "Start Runner";
            this.btnStartRunner.UseVisualStyleBackColor = true;
            this.btnStartRunner.Click += new System.EventHandler(this.btnStartRunner_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(403, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnStopRunner
            // 
            this.btnStopRunner.Location = new System.Drawing.Point(131, 13);
            this.btnStopRunner.Name = "btnStopRunner";
            this.btnStopRunner.Size = new System.Drawing.Size(110, 23);
            this.btnStopRunner.TabIndex = 15;
            this.btnStopRunner.Text = "Stop Runner";
            this.btnStopRunner.UseVisualStyleBackColor = true;
            this.btnStopRunner.Click += new System.EventHandler(this.btnStopRunner_Click);
            // 
            // bkgdRunner
            // 
            this.bkgdRunner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgdRunner_DoWork);
            // 
            // WinMonitorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 279);
            this.Controls.Add(this.btnStopRunner);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartRunner);
            this.Controls.Add(this.txtCompanyID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAPIKey);
            this.Controls.Add(this.txtComputerID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnApplyConfig);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUninstallService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Name = "WinMonitorConfig";
            this.Text = "Win-Monitor Configuration";
            this.Load += new System.EventHandler(this.WinMonitorConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnUninstallService;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnApplyConfig;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComputerID;
        private System.Windows.Forms.TextBox txtAPIKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCompanyID;
        private System.Windows.Forms.Button btnStartRunner;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStopRunner;
        private System.ComponentModel.BackgroundWorker bkgdRunner;
    }
}

