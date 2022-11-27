
namespace Aircon_Control_Windows
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtOff = new System.Windows.Forms.RadioButton();
            this.rbtOn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtHeaterFanOnly = new System.Windows.Forms.RadioButton();
            this.rbtHeater = new System.Windows.Forms.RadioButton();
            this.rbtCoolerFanOnly = new System.Windows.Forms.RadioButton();
            this.rbtCooler = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeaterFanSpeed = new System.Windows.Forms.TextBox();
            this.txtHeaterTemp = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblPumpStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtCoolerManual = new System.Windows.Forms.RadioButton();
            this.rbtCoolerAuto = new System.Windows.Forms.RadioButton();
            this.txtCoolerSpeed = new System.Windows.Forms.TextBox();
            this.txtCoolerTemp = new System.Windows.Forms.TextBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogon = new System.Windows.Forms.Button();
            this.txtSystemDetails = new System.Windows.Forms.TextBox();
            this.txtSystemRunning = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLogAuthToken = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblTouchCount = new System.Windows.Forms.Label();
            this.lblZoneTemps = new System.Windows.Forms.Label();
            this.btnRefreshInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtOff);
            this.groupBox1.Controls.Add(this.rbtOn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Active:";
            // 
            // rbtOff
            // 
            this.rbtOff.AutoSize = true;
            this.rbtOff.Location = new System.Drawing.Point(6, 42);
            this.rbtOff.Name = "rbtOff";
            this.rbtOff.Size = new System.Drawing.Size(39, 17);
            this.rbtOff.TabIndex = 1;
            this.rbtOff.TabStop = true;
            this.rbtOff.Text = "Off";
            this.rbtOff.UseVisualStyleBackColor = true;
            this.rbtOff.CheckedChanged += new System.EventHandler(this.rbtOff_CheckedChanged);
            // 
            // rbtOn
            // 
            this.rbtOn.AutoSize = true;
            this.rbtOn.Location = new System.Drawing.Point(6, 19);
            this.rbtOn.Name = "rbtOn";
            this.rbtOn.Size = new System.Drawing.Size(39, 17);
            this.rbtOn.TabIndex = 0;
            this.rbtOn.TabStop = true;
            this.rbtOn.Text = "On";
            this.rbtOn.UseVisualStyleBackColor = true;
            this.rbtOn.CheckedChanged += new System.EventHandler(this.rbtOn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtHeaterFanOnly);
            this.groupBox2.Controls.Add(this.rbtHeater);
            this.groupBox2.Controls.Add(this.rbtCoolerFanOnly);
            this.groupBox2.Controls.Add(this.rbtCooler);
            this.groupBox2.Location = new System.Drawing.Point(126, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Mode:";
            // 
            // rbtHeaterFanOnly
            // 
            this.rbtHeaterFanOnly.AutoSize = true;
            this.rbtHeaterFanOnly.Location = new System.Drawing.Point(122, 42);
            this.rbtHeaterFanOnly.Name = "rbtHeaterFanOnly";
            this.rbtHeaterFanOnly.Size = new System.Drawing.Size(108, 17);
            this.rbtHeaterFanOnly.TabIndex = 3;
            this.rbtHeaterFanOnly.TabStop = true;
            this.rbtHeaterFanOnly.Text = "Heater - Fan Only";
            this.rbtHeaterFanOnly.UseVisualStyleBackColor = true;
            this.rbtHeaterFanOnly.CheckedChanged += new System.EventHandler(this.rbtHeaterFanOnly_CheckedChanged);
            // 
            // rbtHeater
            // 
            this.rbtHeater.AutoSize = true;
            this.rbtHeater.Location = new System.Drawing.Point(122, 19);
            this.rbtHeater.Name = "rbtHeater";
            this.rbtHeater.Size = new System.Drawing.Size(57, 17);
            this.rbtHeater.TabIndex = 2;
            this.rbtHeater.TabStop = true;
            this.rbtHeater.Text = "Heater";
            this.rbtHeater.UseVisualStyleBackColor = true;
            this.rbtHeater.CheckedChanged += new System.EventHandler(this.rbtHeater_CheckedChanged);
            // 
            // rbtCoolerFanOnly
            // 
            this.rbtCoolerFanOnly.AutoSize = true;
            this.rbtCoolerFanOnly.Location = new System.Drawing.Point(6, 42);
            this.rbtCoolerFanOnly.Name = "rbtCoolerFanOnly";
            this.rbtCoolerFanOnly.Size = new System.Drawing.Size(106, 17);
            this.rbtCoolerFanOnly.TabIndex = 1;
            this.rbtCoolerFanOnly.TabStop = true;
            this.rbtCoolerFanOnly.Text = "Cooler - Fan Only";
            this.rbtCoolerFanOnly.UseVisualStyleBackColor = true;
            this.rbtCoolerFanOnly.CheckedChanged += new System.EventHandler(this.rbtCoolerFanOnly_CheckedChanged);
            // 
            // rbtCooler
            // 
            this.rbtCooler.AutoSize = true;
            this.rbtCooler.Location = new System.Drawing.Point(6, 19);
            this.rbtCooler.Name = "rbtCooler";
            this.rbtCooler.Size = new System.Drawing.Size(55, 17);
            this.rbtCooler.TabIndex = 0;
            this.rbtCooler.TabStop = true;
            this.rbtCooler.Text = "Cooler";
            this.rbtCooler.UseVisualStyleBackColor = true;
            this.rbtCooler.CheckedChanged += new System.EventHandler(this.rbtCooler_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtHeaterFanSpeed);
            this.groupBox3.Controls.Add(this.txtHeaterTemp);
            this.groupBox3.Location = new System.Drawing.Point(372, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 50);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Heater Config";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Speed (1-10) (Fan Only Mode):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Temp:";
            // 
            // txtHeaterFanSpeed
            // 
            this.txtHeaterFanSpeed.Location = new System.Drawing.Point(273, 18);
            this.txtHeaterFanSpeed.Name = "txtHeaterFanSpeed";
            this.txtHeaterFanSpeed.Size = new System.Drawing.Size(52, 20);
            this.txtHeaterFanSpeed.TabIndex = 6;
            this.txtHeaterFanSpeed.TextChanged += new System.EventHandler(this.txtHeaterFanSpeed_TextChanged);
            // 
            // txtHeaterTemp
            // 
            this.txtHeaterTemp.Location = new System.Drawing.Point(48, 19);
            this.txtHeaterTemp.Name = "txtHeaterTemp";
            this.txtHeaterTemp.Size = new System.Drawing.Size(52, 20);
            this.txtHeaterTemp.TabIndex = 6;
            this.txtHeaterTemp.TextChanged += new System.EventHandler(this.txtHeaterTemp_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblPumpStatus);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.rbtCoolerManual);
            this.groupBox4.Controls.Add(this.rbtCoolerAuto);
            this.groupBox4.Controls.Add(this.txtCoolerSpeed);
            this.groupBox4.Controls.Add(this.txtCoolerTemp);
            this.groupBox4.Location = new System.Drawing.Point(12, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 99);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cooler Config";
            // 
            // lblPumpStatus
            // 
            this.lblPumpStatus.AutoSize = true;
            this.lblPumpStatus.Location = new System.Drawing.Point(10, 71);
            this.lblPumpStatus.Name = "lblPumpStatus";
            this.lblPumpStatus.Size = new System.Drawing.Size(70, 13);
            this.lblPumpStatus.TabIndex = 6;
            this.lblPumpStatus.Text = "Pump Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Speed (1-10):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Temp:";
            // 
            // rbtCoolerManual
            // 
            this.rbtCoolerManual.AutoSize = true;
            this.rbtCoolerManual.Location = new System.Drawing.Point(136, 19);
            this.rbtCoolerManual.Name = "rbtCoolerManual";
            this.rbtCoolerManual.Size = new System.Drawing.Size(124, 17);
            this.rbtCoolerManual.TabIndex = 3;
            this.rbtCoolerManual.TabStop = true;
            this.rbtCoolerManual.Text = "Manual (Fan Speed):";
            this.rbtCoolerManual.UseVisualStyleBackColor = true;
            this.rbtCoolerManual.CheckedChanged += new System.EventHandler(this.rbtCoolerManual_CheckedChanged);
            // 
            // rbtCoolerAuto
            // 
            this.rbtCoolerAuto.AutoSize = true;
            this.rbtCoolerAuto.Location = new System.Drawing.Point(13, 19);
            this.rbtCoolerAuto.Name = "rbtCoolerAuto";
            this.rbtCoolerAuto.Size = new System.Drawing.Size(119, 17);
            this.rbtCoolerAuto.TabIndex = 2;
            this.rbtCoolerAuto.TabStop = true;
            this.rbtCoolerAuto.Text = "Auto (Temperature):";
            this.rbtCoolerAuto.UseVisualStyleBackColor = true;
            this.rbtCoolerAuto.CheckedChanged += new System.EventHandler(this.rbtCoolerAuto_CheckedChanged);
            // 
            // txtCoolerSpeed
            // 
            this.txtCoolerSpeed.Location = new System.Drawing.Point(188, 42);
            this.txtCoolerSpeed.Name = "txtCoolerSpeed";
            this.txtCoolerSpeed.Size = new System.Drawing.Size(52, 20);
            this.txtCoolerSpeed.TabIndex = 1;
            this.txtCoolerSpeed.TextChanged += new System.EventHandler(this.txtCoolerSpeed_TextChanged);
            // 
            // txtCoolerTemp
            // 
            this.txtCoolerTemp.Location = new System.Drawing.Point(57, 42);
            this.txtCoolerTemp.Name = "txtCoolerTemp";
            this.txtCoolerTemp.Size = new System.Drawing.Size(52, 20);
            this.txtCoolerTemp.TabIndex = 0;
            this.txtCoolerTemp.TextChanged += new System.EventHandler(this.txtCoolerTemp_TextChanged);
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Enabled = false;
            this.btnSendCommand.Location = new System.Drawing.Point(732, 155);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(130, 40);
            this.btnSendCommand.TabIndex = 0;
            this.btnSendCommand.Text = "Send Command";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtMAC);
            this.groupBox5.Controls.Add(this.txtUsername);
            this.groupBox5.Controls.Add(this.txtPassword);
            this.groupBox5.Location = new System.Drawing.Point(372, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 78);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seeley Login:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "MAC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // txtMAC
            // 
            this.txtMAC.Location = new System.Drawing.Point(225, 16);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.ReadOnly = true;
            this.txtMAC.Size = new System.Drawing.Size(100, 20);
            this.txtMAC.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(70, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(70, 39);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(732, 17);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(158, 40);
            this.btnLogon.TabIndex = 5;
            this.btnLogon.Text = "Login";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // txtSystemDetails
            // 
            this.txtSystemDetails.Location = new System.Drawing.Point(12, 235);
            this.txtSystemDetails.Multiline = true;
            this.txtSystemDetails.Name = "txtSystemDetails";
            this.txtSystemDetails.Size = new System.Drawing.Size(424, 566);
            this.txtSystemDetails.TabIndex = 6;
            // 
            // txtSystemRunning
            // 
            this.txtSystemRunning.Location = new System.Drawing.Point(442, 235);
            this.txtSystemRunning.Multiline = true;
            this.txtSystemRunning.Name = "txtSystemRunning";
            this.txtSystemRunning.Size = new System.Drawing.Size(692, 566);
            this.txtSystemRunning.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "System Info:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(439, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Running Info:";
            // 
            // btnLogAuthToken
            // 
            this.btnLogAuthToken.Location = new System.Drawing.Point(1004, 155);
            this.btnLogAuthToken.Name = "btnLogAuthToken";
            this.btnLogAuthToken.Size = new System.Drawing.Size(130, 40);
            this.btnLogAuthToken.TabIndex = 10;
            this.btnLogAuthToken.Text = "Log AWS Auth Tokens to File";
            this.btnLogAuthToken.UseVisualStyleBackColor = true;
            this.btnLogAuthToken.Click += new System.EventHandler(this.btnLogAuthTokens_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(868, 155);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 40);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Send Device Refresh Command";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefreshMQTT_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblTouchCount);
            this.groupBox6.Controls.Add(this.lblZoneTemps);
            this.groupBox6.Location = new System.Drawing.Point(372, 152);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(354, 43);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Status:";
            // 
            // lblTouchCount
            // 
            this.lblTouchCount.AutoSize = true;
            this.lblTouchCount.Location = new System.Drawing.Point(241, 15);
            this.lblTouchCount.Name = "lblTouchCount";
            this.lblTouchCount.Size = new System.Drawing.Size(72, 13);
            this.lblTouchCount.TabIndex = 1;
            this.lblTouchCount.Text = "Touch Count:";
            // 
            // lblZoneTemps
            // 
            this.lblZoneTemps.AutoSize = true;
            this.lblZoneTemps.Location = new System.Drawing.Point(8, 17);
            this.lblZoneTemps.Name = "lblZoneTemps";
            this.lblZoneTemps.Size = new System.Drawing.Size(70, 13);
            this.lblZoneTemps.TabIndex = 0;
            this.lblZoneTemps.Text = "Zone Temps:";
            // 
            // btnRefreshInfo
            // 
            this.btnRefreshInfo.Location = new System.Drawing.Point(732, 63);
            this.btnRefreshInfo.Name = "btnRefreshInfo";
            this.btnRefreshInfo.Size = new System.Drawing.Size(158, 40);
            this.btnRefreshInfo.TabIndex = 17;
            this.btnRefreshInfo.Text = "Refresh Info (Web Request)";
            this.btnRefreshInfo.UseVisualStyleBackColor = true;
            this.btnRefreshInfo.Click += new System.EventHandler(this.btnRefreshInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 817);
            this.Controls.Add(this.btnRefreshInfo);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogAuthToken);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSystemRunning);
            this.Controls.Add(this.txtSystemDetails);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Aircon Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtOff;
        private System.Windows.Forms.RadioButton rbtOn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtHeaterFanOnly;
        private System.Windows.Forms.RadioButton rbtHeater;
        private System.Windows.Forms.RadioButton rbtCoolerFanOnly;
        private System.Windows.Forms.RadioButton rbtCooler;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHeaterTemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtCoolerManual;
        private System.Windows.Forms.RadioButton rbtCoolerAuto;
        private System.Windows.Forms.TextBox txtCoolerSpeed;
        private System.Windows.Forms.TextBox txtCoolerTemp;
        private System.Windows.Forms.TextBox txtSystemDetails;
        private System.Windows.Forms.TextBox txtSystemRunning;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHeaterFanSpeed;
        private System.Windows.Forms.Button btnLogAuthToken;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblPumpStatus;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblZoneTemps;
        private System.Windows.Forms.Button btnRefreshInfo;
        private System.Windows.Forms.Label lblTouchCount;
    }
}

