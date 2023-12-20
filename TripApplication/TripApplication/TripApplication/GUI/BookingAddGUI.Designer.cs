namespace TripApplication.GUI
{
    partial class BookingAddGUI
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
            textCustomer = new TextBox();
            textPhone = new TextBox();
            textAmount = new TextBox();
            textCreated = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 385);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Customer: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 429);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Phone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(490, 385);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Amount:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(477, 429);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 3;
            label4.Text = "Created by:";
            // 
            // textCustomer
            // 
            textCustomer.Location = new Point(226, 382);
            textCustomer.Name = "textCustomer";
            textCustomer.Size = new Size(100, 23);
            textCustomer.TabIndex = 4;
            // 
            // textPhone
            // 
            textPhone.Location = new Point(226, 425);
            textPhone.Name = "textPhone";
            textPhone.Size = new Size(100, 23);
            textPhone.TabIndex = 5;
            textPhone.Leave += textPhone_Leave;
            // 
            // textAmount
            // 
            textAmount.Location = new Point(553, 382);
            textAmount.Name = "textAmount";
            textAmount.ReadOnly = true;
            textAmount.Size = new Size(100, 23);
            textAmount.TabIndex = 6;
            // 
            // textCreated
            // 
            textCreated.Location = new Point(553, 425);
            textCreated.Name = "textCreated";
            textCreated.ReadOnly = true;
            textCreated.Size = new Size(100, 23);
            textCreated.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(281, 481);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 28);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(439, 481);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 28);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookingAddGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 525);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(textCreated);
            Controls.Add(textAmount);
            Controls.Add(textPhone);
            Controls.Add(textCustomer);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BookingAddGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookingAddGUI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textCustomer;
        private TextBox textPhone;
        private TextBox textAmount;
        private TextBox textCreated;
        private Button btnAdd;
        private Button btnCancel;
    }
}