namespace TripApplication.GUI
{
    partial class BookingGUI
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
            bookingDataView = new DataGridView();
            labelnum = new Label();
            btnAdd = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)bookingDataView).BeginInit();
            SuspendLayout();
            // 
            // bookingDataView
            // 
            bookingDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingDataView.Location = new Point(10, 335);
            bookingDataView.Margin = new Padding(3, 2, 3, 2);
            bookingDataView.Name = "bookingDataView";
            bookingDataView.ReadOnly = true;
            bookingDataView.RowHeadersWidth = 51;
            bookingDataView.RowTemplate.Height = 29;
            bookingDataView.Size = new Size(848, 162);
            bookingDataView.TabIndex = 0;
            bookingDataView.CellContentClick += bookingDataView_CellContentClick;
            bookingDataView.DataBindingComplete += bookingDataView_DataBindingComplete;
            // 
            // labelnum
            // 
            labelnum.AutoSize = true;
            labelnum.Location = new Point(10, 318);
            labelnum.Name = "labelnum";
            labelnum.Size = new Size(123, 15);
            labelnum.TabIndex = 1;
            labelnum.Text = "Number of bookings :";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 291);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 25);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add new booking";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(776, 501);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(82, 22);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // BookingGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 525);
            ControlBox = false;
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(labelnum);
            Controls.Add(bookingDataView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BookingGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookingGUI";
            ((System.ComponentModel.ISupportInitialize)bookingDataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView bookingDataView;
        private Label labelnum;
        private Button btnAdd;
        private Button btnBack;
    }
}