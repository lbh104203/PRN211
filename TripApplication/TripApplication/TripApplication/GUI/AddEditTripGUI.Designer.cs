namespace TripApplication.GUI
{
    partial class AddEditTripGUI
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtpDate = new DateTimePicker();
            cboLimo = new ComboBox();
            cboSlot = new ComboBox();
            numPrice = new NumericUpDown();
            button1 = new Button();
            btnBack = new Button();
            labelTitle = new Label();
            cboTrip = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 113);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "Trip: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(253, 167);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "Date: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(255, 215);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 3;
            label3.Text = "Slot:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(249, 312);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 4;
            label4.Text = "Price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(220, 263);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 5;
            label5.Text = "Limousine:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(311, 161);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(174, 23);
            dtpDate.TabIndex = 1;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dtpDate.Leave += dtpDate_Leave;
            // 
            // cboLimo
            // 
            cboLimo.FormattingEnabled = true;
            cboLimo.Location = new Point(311, 260);
            cboLimo.Name = "cboLimo";
            cboLimo.Size = new Size(174, 23);
            cboLimo.TabIndex = 7;
            cboLimo.SelectedValueChanged += cboLimo_SelectedIndexChanged;
            cboLimo.Leave += cboLimo_Leave;
            // 
            // cboSlot
            // 
            cboSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSlot.FormattingEnabled = true;
            cboSlot.Location = new Point(311, 212);
            cboSlot.Name = "cboSlot";
            cboSlot.Size = new Size(174, 23);
            cboSlot.TabIndex = 8;
            cboSlot.SelectedIndexChanged += cboSlot_SelectedIndexChanged;
            cboSlot.Leave += cboSlot_Leave;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(311, 310);
            numPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(174, 23);
            numPrice.TabIndex = 1;
            numPrice.Leave += numPrice_Leave;
            // 
            // button1
            // 
            button1.Location = new Point(311, 396);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(410, 396);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 3;
            btnBack.Text = "Cancel";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = SystemColors.ActiveCaption;
            labelTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Location = new Point(290, 23);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(201, 37);
            labelTitle.TabIndex = 12;
            labelTitle.Text = "EDIT THE TRIP";
            // 
            // cboTrip
            // 
            cboTrip.FormattingEnabled = true;
            cboTrip.Location = new Point(311, 110);
            cboTrip.Name = "cboTrip";
            cboTrip.Size = new Size(174, 23);
            cboTrip.TabIndex = 2;
            cboTrip.SelectedValueChanged += cboTrip_SelectedValueChanged;
            cboTrip.Leave += cboTrip_Leave;
            // 
            // AddEditTripGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(cboTrip);
            Controls.Add(labelTitle);
            Controls.Add(btnBack);
            Controls.Add(button1);
            Controls.Add(numPrice);
            Controls.Add(cboSlot);
            Controls.Add(cboLimo);
            Controls.Add(dtpDate);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddEditTripGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddEditTripGUI";
            Load += AddEditTripGUI_Load;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpDate;
        private ComboBox cboLimo;
        private ComboBox cboSlot;
        private NumericUpDown numPrice;
        private Button button1;
        private Button btnBack;
        private Label labelTitle;
        private ComboBox cboTrip;
    }
}