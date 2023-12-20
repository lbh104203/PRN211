namespace TripApplication.GUI
{
    partial class LimousineGUI
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
            groupBox1 = new GroupBox();
            label8 = new Label();
            label2 = new Label();
            btnDelete = new Button();
            numCol = new NumericUpDown();
            numRow = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            btnRefresh = new Button();
            btnSave = new Button();
            textId = new TextBox();
            textName = new TextBox();
            label3 = new Label();
            textPlate = new TextBox();
            label1 = new Label();
            limoDataView = new DataGridView();
            labelNum = new Label();
            btnBack = new Button();
            label4 = new Label();
            textFilter = new TextBox();
            label7 = new Label();
            btnAdd = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)limoDataView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(numCol);
            groupBox1.Controls.Add(numRow);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(textId);
            groupBox1.Controls.Add(textName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textPlate);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(796, 184);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Limousine Info";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(644, 95);
            label8.Name = "label8";
            label8.Size = new Size(77, 20);
            label8.TabIndex = 16;
            label8.Text = "* ( 2 -> 3 )";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(644, 52);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 8;
            label2.Text = "*( 5 -> 10 )";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(437, 149);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // numCol
            // 
            numCol.Location = new Point(529, 91);
            numCol.Name = "numCol";
            numCol.Size = new Size(82, 27);
            numCol.TabIndex = 14;
            numCol.Leave += numCol_Leave;
            // 
            // numRow
            // 
            numRow.Location = new Point(529, 51);
            numRow.Name = "numRow";
            numRow.Size = new Size(82, 27);
            numRow.TabIndex = 13;
            numRow.Leave += numRow_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(413, 93);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 12;
            label6.Text = "Number Cols:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(406, 52);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 11;
            label5.Text = "Number Rows:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(321, 149);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(192, 149);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // textId
            // 
            textId.Location = new Point(291, 151);
            textId.Name = "textId";
            textId.Size = new Size(23, 27);
            textId.TabIndex = 4;
            textId.Visible = false;
            // 
            // textName
            // 
            textName.Location = new Point(177, 91);
            textName.Name = "textName";
            textName.Size = new Size(149, 27);
            textName.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 52);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Plate:";
            // 
            // textPlate
            // 
            textPlate.Location = new Point(177, 45);
            textPlate.Name = "textPlate";
            textPlate.ReadOnly = true;
            textPlate.Size = new Size(149, 27);
            textPlate.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 93);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // limoDataView
            // 
            limoDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            limoDataView.Location = new Point(11, 307);
            limoDataView.Name = "limoDataView";
            limoDataView.ReadOnly = true;
            limoDataView.RowHeadersWidth = 51;
            limoDataView.RowTemplate.Height = 29;
            limoDataView.Size = new Size(797, 391);
            limoDataView.TabIndex = 3;
            limoDataView.CellClick += limoDataView_CellClick;
            limoDataView.DataBindingComplete += limoDataView_DataBindingComplete;
            // 
            // labelNum
            // 
            labelNum.AutoSize = true;
            labelNum.Location = new Point(11, 284);
            labelNum.Name = "labelNum";
            labelNum.Size = new Size(219, 20);
            labelNum.TabIndex = 2;
            labelNum.Text = "Total number of our Limousine: ";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(714, 704);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(171, 20);
            label4.Name = "label4";
            label4.Size = new Size(120, 38);
            label4.TabIndex = 4;
            label4.Text = "Search: ";
            // 
            // textFilter
            // 
            textFilter.Location = new Point(306, 28);
            textFilter.Name = "textFilter";
            textFilter.Size = new Size(149, 27);
            textFilter.TabIndex = 1;
            textFilter.TextChanged += textFilter_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(470, 35);
            label7.Name = "label7";
            label7.Size = new Size(106, 20);
            label7.TabIndex = 6;
            label7.Text = "(Name / Plate)";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 248);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(219, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add a new limousine";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // LimousineGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 745);
            ControlBox = false;
            Controls.Add(btnAdd);
            Controls.Add(label7);
            Controls.Add(textFilter);
            Controls.Add(label4);
            Controls.Add(btnBack);
            Controls.Add(labelNum);
            Controls.Add(limoDataView);
            Controls.Add(groupBox1);
            Name = "LimousineGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LimousineGUI";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCol).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)limoDataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private DataGridView limoDataView;
        private TextBox textPlate;
        private Label labelNum;
        private TextBox textId;
        private TextBox textName;
        private Label label3;
        private Button btnSave;
        private Button btnBack;
        private Button btnRefresh;
        private Label label4;
        private TextBox textFilter;
        private TextBox textCol;
        private TextBox textRow;
        private Label label6;
        private Label label5;
        private Label label7;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numCol;
        private NumericUpDown numRow;
        private Button btnDelete;
        private Button btnAdd;
        private Label label8;
        private Label label2;
    }
}