namespace LAD08PackagingV1
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
            this.txtProdOrderNumber = new System.Windows.Forms.TextBox();
            this.btnIndividualLabel = new System.Windows.Forms.Button();
            this.btnGroupingLabel = new System.Windows.Forms.Button();
            this.btnWeighing = new System.Windows.Forms.Button();
            this.btnPlc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEan13 = new System.Windows.Forms.TextBox();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTargetQuantity = new System.Windows.Forms.TextBox();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblRemoveBox = new System.Windows.Forms.Label();
            this.lblLowLimit = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHighLimit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWeighing = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblGroupSize = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.gp44 = new System.Windows.Forms.GroupBox();
            this.docGroupPrev = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chbPlcIndicator = new System.Windows.Forms.CheckBox();
            this.btnResetCurrentCycle = new System.Windows.Forms.Button();
            this.btnBarcodeReader = new System.Windows.Forms.Button();
            this.btnWorkOrder = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblBarcodeState = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInputEntry = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.lblReject = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.docIndiPrev = new System.Windows.Forms.PictureBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timerReadInput = new System.Windows.Forms.Timer(this.components);
            this.timerPrintDelay = new System.Windows.Forms.Timer(this.components);
            this.tmrBlink = new System.Windows.Forms.Timer(this.components);
            this.lblBuild = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gp44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docGroupPrev)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docIndiPrev)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProdOrderNumber
            // 
            this.txtProdOrderNumber.BackColor = System.Drawing.Color.White;
            this.txtProdOrderNumber.Location = new System.Drawing.Point(149, 31);
            this.txtProdOrderNumber.Name = "txtProdOrderNumber";
            this.txtProdOrderNumber.Size = new System.Drawing.Size(214, 22);
            this.txtProdOrderNumber.TabIndex = 1;
            // 
            // btnIndividualLabel
            // 
            this.btnIndividualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndividualLabel.Location = new System.Drawing.Point(410, 19);
            this.btnIndividualLabel.Name = "btnIndividualLabel";
            this.btnIndividualLabel.Size = new System.Drawing.Size(81, 63);
            this.btnIndividualLabel.TabIndex = 3;
            this.btnIndividualLabel.Text = "Individual Label";
            this.btnIndividualLabel.UseVisualStyleBackColor = true;
            this.btnIndividualLabel.Click += new System.EventHandler(this.btnIndividualLabel_Click);
            // 
            // btnGroupingLabel
            // 
            this.btnGroupingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupingLabel.Location = new System.Drawing.Point(497, 19);
            this.btnGroupingLabel.Name = "btnGroupingLabel";
            this.btnGroupingLabel.Size = new System.Drawing.Size(81, 64);
            this.btnGroupingLabel.TabIndex = 3;
            this.btnGroupingLabel.Text = "Grouping Label";
            this.btnGroupingLabel.UseVisualStyleBackColor = true;
            this.btnGroupingLabel.Click += new System.EventHandler(this.btnGroupingLabel_Click);
            // 
            // btnWeighing
            // 
            this.btnWeighing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeighing.Location = new System.Drawing.Point(584, 20);
            this.btnWeighing.Name = "btnWeighing";
            this.btnWeighing.Size = new System.Drawing.Size(81, 63);
            this.btnWeighing.TabIndex = 3;
            this.btnWeighing.Text = "Weighing Station";
            this.btnWeighing.UseVisualStyleBackColor = true;
            this.btnWeighing.Click += new System.EventHandler(this.btnWeighing_Click);
            // 
            // btnPlc
            // 
            this.btnPlc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlc.Location = new System.Drawing.Point(671, 20);
            this.btnPlc.Name = "btnPlc";
            this.btnPlc.Size = new System.Drawing.Size(81, 63);
            this.btnPlc.TabIndex = 3;
            this.btnPlc.Text = "PLC";
            this.btnPlc.UseVisualStyleBackColor = true;
            this.btnPlc.Click += new System.EventHandler(this.btnPlc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEan13);
            this.groupBox1.Controls.Add(this.txtArticle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTargetQuantity);
            this.groupBox1.Controls.Add(this.txtReference);
            this.groupBox1.Controls.Add(this.txtProdOrderNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Work Order";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "EAN13";
            this.label9.Click += new System.EventHandler(this.label5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Article";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Target";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reference";
            // 
            // txtEan13
            // 
            this.txtEan13.BackColor = System.Drawing.Color.White;
            this.txtEan13.Location = new System.Drawing.Point(149, 146);
            this.txtEan13.Name = "txtEan13";
            this.txtEan13.Size = new System.Drawing.Size(214, 22);
            this.txtEan13.TabIndex = 1;
            // 
            // txtArticle
            // 
            this.txtArticle.BackColor = System.Drawing.Color.White;
            this.txtArticle.Location = new System.Drawing.Point(149, 118);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(214, 22);
            this.txtArticle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prod Order Number";
            // 
            // txtTargetQuantity
            // 
            this.txtTargetQuantity.BackColor = System.Drawing.Color.White;
            this.txtTargetQuantity.Location = new System.Drawing.Point(149, 92);
            this.txtTargetQuantity.Name = "txtTargetQuantity";
            this.txtTargetQuantity.Size = new System.Drawing.Size(214, 22);
            this.txtTargetQuantity.TabIndex = 1;
            // 
            // txtReference
            // 
            this.txtReference.BackColor = System.Drawing.Color.White;
            this.txtReference.Location = new System.Drawing.Point(149, 63);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(214, 22);
            this.txtReference.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(410, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 459);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Group Packing";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gp44, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 304F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 438);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblRemoveBox);
            this.groupBox5.Controls.Add(this.lblLowLimit);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.lblHighLimit);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.lblWeighing);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(475, 61);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Weighing";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // lblRemoveBox
            // 
            this.lblRemoveBox.AutoSize = true;
            this.lblRemoveBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoveBox.ForeColor = System.Drawing.Color.Maroon;
            this.lblRemoveBox.Location = new System.Drawing.Point(288, 25);
            this.lblRemoveBox.Name = "lblRemoveBox";
            this.lblRemoveBox.Size = new System.Drawing.Size(184, 25);
            this.lblRemoveBox.TabIndex = 3;
            this.lblRemoveBox.Text = "REMOVE BOX!!!";
            // 
            // lblLowLimit
            // 
            this.lblLowLimit.AutoSize = true;
            this.lblLowLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowLimit.Location = new System.Drawing.Point(228, 43);
            this.lblLowLimit.Name = "lblLowLimit";
            this.lblLowLimit.Size = new System.Drawing.Size(42, 13);
            this.lblLowLimit.TabIndex = 2;
            this.lblLowLimit.Text = "00000";
            this.lblLowLimit.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(181, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "LO Limit";
            this.label7.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblHighLimit
            // 
            this.lblHighLimit.AutoSize = true;
            this.lblHighLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighLimit.Location = new System.Drawing.Point(228, 19);
            this.lblHighLimit.Name = "lblHighLimit";
            this.lblHighLimit.Size = new System.Drawing.Size(42, 13);
            this.lblHighLimit.TabIndex = 2;
            this.lblHighLimit.Text = "00000";
            this.lblHighLimit.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(181, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "HI Limit";
            this.label6.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "grams";
            this.label4.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblWeighing
            // 
            this.lblWeighing.AutoSize = true;
            this.lblWeighing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeighing.Location = new System.Drawing.Point(12, 25);
            this.lblWeighing.Name = "lblWeighing";
            this.lblWeighing.Size = new System.Drawing.Size(97, 25);
            this.lblWeighing.TabIndex = 0;
            this.lblWeighing.Text = "00000.0";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(475, 61);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblGroupSize);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 55);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grouping Size";
            // 
            // lblGroupSize
            // 
            this.lblGroupSize.AutoSize = true;
            this.lblGroupSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupSize.Location = new System.Drawing.Point(70, 19);
            this.lblGroupSize.Name = "lblGroupSize";
            this.lblGroupSize.Size = new System.Drawing.Size(51, 25);
            this.lblGroupSize.TabIndex = 0;
            this.lblGroupSize.Text = "000";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRemaining);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(240, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 55);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remaining";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaining.Location = new System.Drawing.Point(108, 22);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(51, 25);
            this.lblRemaining.TabIndex = 0;
            this.lblRemaining.Text = "000";
            // 
            // gp44
            // 
            this.gp44.Controls.Add(this.docGroupPrev);
            this.gp44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp44.Location = new System.Drawing.Point(3, 137);
            this.gp44.Name = "gp44";
            this.gp44.Size = new System.Drawing.Size(475, 298);
            this.gp44.TabIndex = 1;
            this.gp44.TabStop = false;
            this.gp44.Text = "Label Preview";
            this.gp44.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // docGroupPrev
            // 
            this.docGroupPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docGroupPrev.Location = new System.Drawing.Point(3, 18);
            this.docGroupPrev.Name = "docGroupPrev";
            this.docGroupPrev.Size = new System.Drawing.Size(469, 277);
            this.docGroupPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.docGroupPrev.TabIndex = 0;
            this.docGroupPrev.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox6.Controls.Add(this.chbPlcIndicator);
            this.groupBox6.Controls.Add(this.btnResetCurrentCycle);
            this.groupBox6.Controls.Add(this.btnBarcodeReader);
            this.groupBox6.Controls.Add(this.btnWorkOrder);
            this.groupBox6.Controls.Add(this.btnIndividualLabel);
            this.groupBox6.Controls.Add(this.btnPlc);
            this.groupBox6.Controls.Add(this.btnGroupingLabel);
            this.groupBox6.Controls.Add(this.btnWeighing);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 93);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(906, 96);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            // 
            // chbPlcIndicator
            // 
            this.chbPlcIndicator.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbPlcIndicator.AutoSize = true;
            this.chbPlcIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbPlcIndicator.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPlcIndicator.Location = new System.Drawing.Point(732, 31);
            this.chbPlcIndicator.MinimumSize = new System.Drawing.Size(10, 10);
            this.chbPlcIndicator.Name = "chbPlcIndicator";
            this.chbPlcIndicator.Size = new System.Drawing.Size(10, 10);
            this.chbPlcIndicator.TabIndex = 9;
            this.chbPlcIndicator.Tag = " ";
            this.chbPlcIndicator.UseVisualStyleBackColor = true;
            // 
            // btnResetCurrentCycle
            // 
            this.btnResetCurrentCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCurrentCycle.Location = new System.Drawing.Point(149, 19);
            this.btnResetCurrentCycle.Name = "btnResetCurrentCycle";
            this.btnResetCurrentCycle.Size = new System.Drawing.Size(81, 63);
            this.btnResetCurrentCycle.TabIndex = 0;
            this.btnResetCurrentCycle.Text = "Reset ";
            this.btnResetCurrentCycle.UseVisualStyleBackColor = true;
            this.btnResetCurrentCycle.Click += new System.EventHandler(this.btnResetCurrentCycle_Click);
            // 
            // btnBarcodeReader
            // 
            this.btnBarcodeReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcodeReader.Location = new System.Drawing.Point(323, 19);
            this.btnBarcodeReader.Name = "btnBarcodeReader";
            this.btnBarcodeReader.Size = new System.Drawing.Size(81, 63);
            this.btnBarcodeReader.TabIndex = 0;
            this.btnBarcodeReader.Text = "Barcode Reader";
            this.btnBarcodeReader.UseVisualStyleBackColor = true;
            this.btnBarcodeReader.Click += new System.EventHandler(this.btnBarcodeReader_Click);
            // 
            // btnWorkOrder
            // 
            this.btnWorkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorkOrder.Location = new System.Drawing.Point(236, 19);
            this.btnWorkOrder.Name = "btnWorkOrder";
            this.btnWorkOrder.Size = new System.Drawing.Size(81, 63);
            this.btnWorkOrder.TabIndex = 0;
            this.btnWorkOrder.Text = "Work Order";
            this.btnWorkOrder.UseVisualStyleBackColor = true;
            this.btnWorkOrder.Click += new System.EventHandler(this.btnWorkOrder_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblBarcodeState);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.txtInputEntry);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(410, 117);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(481, 78);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Input Entry";
            // 
            // lblBarcodeState
            // 
            this.lblBarcodeState.AutoSize = true;
            this.lblBarcodeState.Location = new System.Drawing.Point(117, 51);
            this.lblBarcodeState.Name = "lblBarcodeState";
            this.lblBarcodeState.Size = new System.Drawing.Size(30, 16);
            this.lblBarcodeState.TabIndex = 3;
            this.lblBarcodeState.Text = "Idle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Barcode State";
            // 
            // txtInputEntry
            // 
            this.txtInputEntry.Location = new System.Drawing.Point(20, 19);
            this.txtInputEntry.Name = "txtInputEntry";
            this.txtInputEntry.Size = new System.Drawing.Size(438, 22);
            this.txtInputEntry.TabIndex = 0;
            this.txtInputEntry.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtInputEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputEntry_KeyPress);
            this.txtInputEntry.Leave += new System.EventHandler(this.txtInputEntry_Leave);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tableLayoutPanel3);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(3, 190);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(380, 470);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Individual Packing";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox10, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(374, 449);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox11, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox12, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(368, 94);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lblPass);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(178, 88);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Pass";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.Green;
            this.lblPass.Location = new System.Drawing.Point(50, 29);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(74, 37);
            this.lblPass.TabIndex = 0;
            this.lblPass.Text = "000";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.lblReject);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox12.Location = new System.Drawing.Point(187, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(178, 88);
            this.groupBox12.TabIndex = 0;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Reject";
            // 
            // lblReject
            // 
            this.lblReject.AutoSize = true;
            this.lblReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.ForeColor = System.Drawing.Color.Red;
            this.lblReject.Location = new System.Drawing.Point(47, 29);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(74, 37);
            this.lblReject.TabIndex = 0;
            this.lblReject.Text = "000";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.docIndiPrev);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(3, 103);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(368, 343);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Label Preview";
            // 
            // docIndiPrev
            // 
            this.docIndiPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docIndiPrev.Location = new System.Drawing.Point(3, 18);
            this.docIndiPrev.Name = "docIndiPrev";
            this.docIndiPrev.Size = new System.Drawing.Size(362, 322);
            this.docIndiPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.docIndiPrev.TabIndex = 0;
            this.docIndiPrev.TabStop = false;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtInformation);
            this.groupBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(413, 7);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(478, 107);
            this.groupBox13.TabIndex = 7;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Information";
            // 
            // txtInformation
            // 
            this.txtInformation.BackColor = System.Drawing.Color.White;
            this.txtInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformation.Location = new System.Drawing.Point(3, 18);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            this.txtInformation.Size = new System.Drawing.Size(472, 86);
            this.txtInformation.TabIndex = 0;
            this.txtInformation.Text = "ttt";
            this.txtInformation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.groupBox6, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.875F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.125F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 674F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(912, 867);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblBuild);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 84);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LAD08PackagingV1.Properties.Resources.sch;
            this.pictureBox2.Location = new System.Drawing.Point(9, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(181, 78);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(205, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(384, 39);
            this.label10.TabIndex = 0;
            this.label10.Text = "LAD08N Final Packing";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox13);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Controls.Add(this.groupBox9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 669);
            this.panel2.TabIndex = 1;
            // 
            // timerReadInput
            // 
            this.timerReadInput.Interval = 3000;
            this.timerReadInput.Tick += new System.EventHandler(this.timerReadInput_Tick);
            // 
            // timerPrintDelay
            // 
            this.timerPrintDelay.Enabled = true;
            this.timerPrintDelay.Interval = 2000;
            this.timerPrintDelay.Tick += new System.EventHandler(this.timerPrintDelay_Tick);
            // 
            // tmrBlink
            // 
            this.tmrBlink.Enabled = true;
            this.tmrBlink.Interval = 500;
            this.tmrBlink.Tick += new System.EventHandler(this.tmrBlink_Tick);
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.Location = new System.Drawing.Point(609, 54);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(41, 13);
            this.lblBuild.TabIndex = 2;
            this.lblBuild.Text = "label11";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(912, 867);
            this.Controls.Add(this.tableLayoutPanel5);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "LAD8 Packing Software";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gp44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docGroupPrev)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docIndiPrev)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtProdOrderNumber;
        private System.Windows.Forms.Button btnIndividualLabel;
        private System.Windows.Forms.Button btnGroupingLabel;
        private System.Windows.Forms.Button btnWeighing;
        private System.Windows.Forms.Button btnPlc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTargetQuantity;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gp44;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.PictureBox docIndiPrev;
        private System.Windows.Forms.TextBox txtInputEntry;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.Label lblGroupSize;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWeighing;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timerReadInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLowLimit;
        private System.Windows.Forms.Label lblHighLimit;
        private System.Windows.Forms.PictureBox docGroupPrev;
        private System.Windows.Forms.CheckBox chbPlcIndicator;
        private System.Windows.Forms.Button btnWorkOrder;
        private System.Windows.Forms.Button btnResetCurrentCycle;
        private System.Windows.Forms.Timer timerPrintDelay;
        private System.Windows.Forms.Button btnBarcodeReader;
        private System.Windows.Forms.Label lblBarcodeState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRemoveBox;
        private System.Windows.Forms.Timer tmrBlink;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEan13;
        private System.Windows.Forms.Label lblBuild;
    }
}

