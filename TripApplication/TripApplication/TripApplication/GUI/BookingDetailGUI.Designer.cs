namespace TripApplication.GUI
{
    partial class BookingDetailGUI
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
            textCustomer = new TextBox();
            textPhone = new TextBox();
            textPrice = new TextBox();
            textStaff = new TextBox();
            textSeat = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textCustomer
            // 
            textCustomer.Location = new Point(299, 304);
            textCustomer.Margin = new Padding(3, 2, 3, 2);
            textCustomer.Name = "textCustomer";
            textCustomer.ReadOnly = true;
            textCustomer.Size = new Size(110, 23);
            textCustomer.TabIndex = 0;
            // 
            // textPhone
            // 
            textPhone.Location = new Point(500, 304);
            textPhone.Margin = new Padding(3, 2, 3, 2);
            textPhone.Name = "textPhone";
            textPhone.ReadOnly = true;
            textPhone.Size = new Size(110, 23);
            textPhone.TabIndex = 1;
            // 
            // textPrice
            // 
            textPrice.Location = new Point(500, 346);
            textPrice.Margin = new Padding(3, 2, 3, 2);
            textPrice.Name = "textPrice";
            textPrice.ReadOnly = true;
            textPrice.Size = new Size(110, 23);
            textPrice.TabIndex = 2;
            // 
            // textStaff
            // 
            textStaff.Location = new Point(403, 383);
            textStaff.Margin = new Padding(3, 2, 3, 2);
            textStaff.Name = "textStaff";
            textStaff.ReadOnly = true;
            textStaff.Size = new Size(110, 23);
            textStaff.TabIndex = 3;
            // 
            // textSeat
            // 
            textSeat.Location = new Point(299, 344);
            textSeat.Margin = new Padding(3, 2, 3, 2);
            textSeat.Name = "textSeat";
            textSeat.ReadOnly = true;
            textSeat.Size = new Size(110, 23);
            textSeat.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(226, 308);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 5;
            label1.Text = "Customer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(441, 308);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 6;
            label2.Text = "Phone: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(449, 349);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 7;
            label3.Text = "Price: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(330, 386);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 8;
            label4.Text = "Created by:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 349);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 9;
            label5.Text = "Seats:";
            // 
            // button1
            // 
            button1.Location = new Point(391, 420);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BookingDetailGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 446);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textSeat);
            Controls.Add(textStaff);
            Controls.Add(textPrice);
            Controls.Add(textPhone);
            Controls.Add(textCustomer);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BookingDetailGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookingDetailGUI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textCustomer;
        private TextBox textPhone;
        private TextBox textPrice;
        private TextBox textStaff;
        private TextBox textSeat;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}