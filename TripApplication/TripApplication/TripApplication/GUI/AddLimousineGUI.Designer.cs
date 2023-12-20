namespace TripApplication.GUI
{
    partial class AddLimousineGUI
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
            label6 = new Label();
            textName = new TextBox();
            textPlate = new TextBox();
            numRow = new NumericUpDown();
            numCol = new NumericUpDown();
            cboType = new ComboBox();
            btnAdd = new Button();
            btnBack = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)numRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCol).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(234, 21);
            label1.Name = "label1";
            label1.Size = new Size(268, 32);
            label1.TabIndex = 0;
            label1.Text = "ADD NEW LIMOUSINE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 112);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 0;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(397, 114);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 7;
            label3.Text = "Plate: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(107, 156);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 3;
            label4.Text = "Number Rows:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(354, 160);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 4;
            label5.Text = "Number Cols:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(259, 233);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 5;
            label6.Text = "Type";
            // 
            // textName
            // 
            textName.Location = new Point(204, 110);
            textName.Margin = new Padding(3, 2, 3, 2);
            textName.Name = "textName";
            textName.Size = new Size(110, 23);
            textName.TabIndex = 1;
            // 
            // textPlate
            // 
            textPlate.Location = new Point(445, 110);
            textPlate.Margin = new Padding(3, 2, 3, 2);
            textPlate.Name = "textPlate";
            textPlate.Size = new Size(110, 23);
            textPlate.TabIndex = 7;
            // 
            // numRow
            // 
            numRow.Location = new Point(204, 152);
            numRow.Margin = new Padding(3, 2, 3, 2);
            numRow.Name = "numRow";
            numRow.Size = new Size(57, 23);
            numRow.TabIndex = 8;
            numRow.Leave += numRow_Leave;
            // 
            // numCol
            // 
            numCol.Location = new Point(445, 156);
            numCol.Margin = new Padding(3, 2, 3, 2);
            numCol.Name = "numCol";
            numCol.Size = new Size(57, 23);
            numCol.TabIndex = 9;
            numCol.Leave += numCol_Leave;
            // 
            // cboType
            // 
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(311, 231);
            cboType.Margin = new Padding(3, 2, 3, 2);
            cboType.Name = "cboType";
            cboType.Size = new Size(133, 23);
            cboType.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(225, 316);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(82, 22);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(409, 316);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(82, 22);
            btnBack.TabIndex = 12;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.AppWorkspace;
            label7.Location = new Point(560, 112);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 13;
            label7.Text = "10A-12345";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(198, 177);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 14;
            label8.Text = "*( 5 -> 10 )";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.ControlDarkDark;
            label9.Location = new Point(439, 181);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 15;
            label9.Text = "*( 2 -> 3 )";
            // 
            // AddLimousineGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 406);
            ControlBox = false;
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(cboType);
            Controls.Add(numCol);
            Controls.Add(numRow);
            Controls.Add(textPlate);
            Controls.Add(textName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddLimousineGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddLimousineGUI";
            ((System.ComponentModel.ISupportInitialize)numRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCol).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textName;
        private TextBox textPlate;
        private NumericUpDown numRow;
        private NumericUpDown numCol;
        private ComboBox cboType;
        private Button btnAdd;
        private Button btnBack;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}