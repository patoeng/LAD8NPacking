namespace LAD08PackagingV1
{
    partial class Weighing
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
            this.serialPortWeighing = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbLimits = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnSaveLimits = new System.Windows.Forms.Button();
            this.textLower = new System.Windows.Forms.TextBox();
            this.textNominal = new System.Windows.Forms.TextBox();
            this.textUpper = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOffset = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSerialData = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.btnSavePort = new System.Windows.Forms.Button();
            this.cbbComPort = new System.Windows.Forms.ComboBox();
            this.textStabilization = new System.Windows.Forms.TextBox();
            this.lbIsOpenClosed = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblReference2 = new System.Windows.Forms.Label();
            this.timerStabilization = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbLimits.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPortWeighing
            // 
            this.serialPortWeighing.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortWeighing_DataReceived);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Green;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.04281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.95718F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 333);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 54);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(18, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Weighing Station";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 267);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 269F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(537, 267);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbLimits);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weighing Reading";
            // 
            // gbLimits
            // 
            this.gbLimits.Controls.Add(this.btnRestore);
            this.gbLimits.Controls.Add(this.btnCalculate);
            this.gbLimits.Controls.Add(this.btnSaveLimits);
            this.gbLimits.Controls.Add(this.textLower);
            this.gbLimits.Controls.Add(this.textNominal);
            this.gbLimits.Controls.Add(this.textUpper);
            this.gbLimits.Controls.Add(this.label7);
            this.gbLimits.Controls.Add(this.label6);
            this.gbLimits.Controls.Add(this.label5);
            this.gbLimits.Controls.Add(this.label4);
            this.gbLimits.Controls.Add(this.lblOffset);
            this.gbLimits.Controls.Add(this.lblReference);
            this.gbLimits.Controls.Add(this.label3);
            this.gbLimits.Location = new System.Drawing.Point(19, 80);
            this.gbLimits.Name = "gbLimits";
            this.gbLimits.Size = new System.Drawing.Size(212, 171);
            this.gbLimits.TabIndex = 1;
            this.gbLimits.TabStop = false;
            this.gbLimits.Text = "Limits (per unit, in grams)";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(78, 145);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(64, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(6, 145);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(64, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate  Current";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnSaveLimits
            // 
            this.btnSaveLimits.Location = new System.Drawing.Point(153, 145);
            this.btnSaveLimits.Name = "btnSaveLimits";
            this.btnSaveLimits.Size = new System.Drawing.Size(59, 23);
            this.btnSaveLimits.TabIndex = 2;
            this.btnSaveLimits.Text = "Save";
            this.btnSaveLimits.UseVisualStyleBackColor = true;
            this.btnSaveLimits.Click += new System.EventHandler(this.btnSaveLimits_Click);
            // 
            // textLower
            // 
            this.textLower.Location = new System.Drawing.Point(88, 119);
            this.textLower.Name = "textLower";
            this.textLower.Size = new System.Drawing.Size(100, 20);
            this.textLower.TabIndex = 1;
            // 
            // textNominal
            // 
            this.textNominal.Location = new System.Drawing.Point(88, 94);
            this.textNominal.Name = "textNominal";
            this.textNominal.Size = new System.Drawing.Size(100, 20);
            this.textNominal.TabIndex = 1;
            // 
            // textUpper
            // 
            this.textUpper.Location = new System.Drawing.Point(88, 70);
            this.textUpper.Name = "textUpper";
            this.textUpper.Size = new System.Drawing.Size(100, 20);
            this.textUpper.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Lower Limit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nominal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Upper Limit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Offset";
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(85, 48);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(25, 13);
            this.lblOffset.TabIndex = 0;
            this.lblOffset.Text = "000";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.Location = new System.Drawing.Point(85, 23);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(66, 13);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "Reference";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reference";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblValue);
            this.groupBox2.Location = new System.Drawing.Point(19, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 55);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reading";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "gram(s)";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.ForeColor = System.Drawing.Color.Red;
            this.lblValue.Location = new System.Drawing.Point(27, 14);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(94, 31);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "00000";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lblReference2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(271, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 261);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSerialData);
            this.groupBox5.Controls.Add(this.btnRefresh);
            this.groupBox5.Controls.Add(this.btnOpenClose);
            this.groupBox5.Controls.Add(this.btnSavePort);
            this.groupBox5.Controls.Add(this.cbbComPort);
            this.groupBox5.Controls.Add(this.textStabilization);
            this.groupBox5.Controls.Add(this.lbIsOpenClosed);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(6, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(251, 200);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Com Port";
            // 
            // txtSerialData
            // 
            this.txtSerialData.Location = new System.Drawing.Point(14, 165);
            this.txtSerialData.Name = "txtSerialData";
            this.txtSerialData.Size = new System.Drawing.Size(231, 20);
            this.txtSerialData.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(188, 27);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(89, 64);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btnOpenClose.TabIndex = 2;
            this.btnOpenClose.Text = "Open";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // btnSavePort
            // 
            this.btnSavePort.Location = new System.Drawing.Point(170, 124);
            this.btnSavePort.Name = "btnSavePort";
            this.btnSavePort.Size = new System.Drawing.Size(75, 23);
            this.btnSavePort.TabIndex = 2;
            this.btnSavePort.Text = "Save";
            this.btnSavePort.UseVisualStyleBackColor = true;
            this.btnSavePort.Click += new System.EventHandler(this.btnSavePort_Click);
            // 
            // cbbComPort
            // 
            this.cbbComPort.FormattingEnabled = true;
            this.cbbComPort.Location = new System.Drawing.Point(89, 29);
            this.cbbComPort.Name = "cbbComPort";
            this.cbbComPort.Size = new System.Drawing.Size(93, 21);
            this.cbbComPort.TabIndex = 1;
            // 
            // textStabilization
            // 
            this.textStabilization.Location = new System.Drawing.Point(89, 98);
            this.textStabilization.Name = "textStabilization";
            this.textStabilization.Size = new System.Drawing.Size(156, 20);
            this.textStabilization.TabIndex = 1;
            this.textStabilization.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbIsOpenClosed
            // 
            this.lbIsOpenClosed.AutoSize = true;
            this.lbIsOpenClosed.Location = new System.Drawing.Point(11, 69);
            this.lbIsOpenClosed.Name = "lbIsOpenClosed";
            this.lbIsOpenClosed.Size = new System.Drawing.Size(74, 13);
            this.lbIsOpenClosed.TabIndex = 0;
            this.lbIsOpenClosed.Text = "Com Is Closed";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Com Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Serial Data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Reference";
            // 
            // lblReference2
            // 
            this.lblReference2.AutoSize = true;
            this.lblReference2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference2.Location = new System.Drawing.Point(103, 19);
            this.lblReference2.Name = "lblReference2";
            this.lblReference2.Size = new System.Drawing.Size(66, 13);
            this.lblReference2.TabIndex = 0;
            this.lblReference2.Text = "Reference";
            // 
            // timerStabilization
            // 
            this.timerStabilization.Tick += new System.EventHandler(this.timerStabilization_Tick);
            // 
            // Weighing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 333);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Weighing";
            this.Text = "Weighing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Weighing_FormClosing);
            this.Load += new System.EventHandler(this.Weighing_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbLimits.ResumeLayout(false);
            this.gbLimits.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPortWeighing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.GroupBox gbLimits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox textLower;
        private System.Windows.Forms.TextBox textNominal;
        private System.Windows.Forms.TextBox textUpper;
        private System.Windows.Forms.Button btnSavePort;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lblReference2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbComPort;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.Label lbIsOpenClosed;
        private System.Windows.Forms.Timer timerStabilization;
        private System.Windows.Forms.TextBox textStabilization;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSaveLimits;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtSerialData;
        private System.Windows.Forms.Button btnRefresh;
    }
}