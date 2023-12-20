namespace TripApplication.GUI
{
    partial class MainGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            btnRoute = new Button();
            btnLimousine = new Button();
            label1 = new Label();
            labelHello = new Label();
            menuStrip1 = new MenuStrip();
            logoutadminToolStripMenuItem = new ToolStripMenuItem();
            btnTrip = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRoute
            // 
            btnRoute.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnRoute.Location = new Point(150, 312);
            btnRoute.Margin = new Padding(3, 4, 3, 4);
            btnRoute.Name = "btnRoute";
            btnRoute.Size = new Size(161, 112);
            btnRoute.TabIndex = 0;
            btnRoute.Text = "Manage Route";
            btnRoute.UseVisualStyleBackColor = true;
            btnRoute.Click += btnRoute_Click;
            // 
            // btnLimousine
            // 
            btnLimousine.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnLimousine.Location = new Point(616, 309);
            btnLimousine.Margin = new Padding(3, 4, 3, 4);
            btnLimousine.Name = "btnLimousine";
            btnLimousine.Size = new Size(166, 117);
            btnLimousine.TabIndex = 2;
            btnLimousine.Text = "Manage Limousine";
            btnLimousine.UseVisualStyleBackColor = true;
            btnLimousine.Click += btnLimousine_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(85, 68);
            label1.Name = "label1";
            label1.Size = new Size(760, 67);
            label1.TabIndex = 3;
            label1.Text = "WELCOME TO TRIP APPLICATION";
            // 
            // labelHello
            // 
            labelHello.AutoSize = true;
            labelHello.BackColor = SystemColors.InactiveCaption;
            labelHello.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelHello.Location = new Point(366, 178);
            labelHello.Name = "labelHello";
            labelHello.Size = new Size(207, 46);
            labelHello.TabIndex = 4;
            labelHello.Text = "Hello, admin";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { logoutadminToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(949, 45);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // logoutadminToolStripMenuItem
            // 
            logoutadminToolStripMenuItem.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            logoutadminToolStripMenuItem.Name = "logoutadminToolStripMenuItem";
            logoutadminToolStripMenuItem.Size = new Size(108, 39);
            logoutadminToolStripMenuItem.Text = "Logout";
            logoutadminToolStripMenuItem.Click += logoutadminToolStripMenuItem_Click;
            // 
            // btnTrip
            // 
            btnTrip.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnTrip.Location = new Point(382, 312);
            btnTrip.Margin = new Padding(3, 4, 3, 4);
            btnTrip.Name = "btnTrip";
            btnTrip.Size = new Size(161, 112);
            btnTrip.TabIndex = 6;
            btnTrip.Text = "Manage Trip";
            btnTrip.UseVisualStyleBackColor = true;
            btnTrip.Click += btnTrip_Click;
            // 
            // MainGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(949, 600);
            ControlBox = false;
            Controls.Add(btnTrip);
            Controls.Add(labelHello);
            Controls.Add(label1);
            Controls.Add(btnLimousine);
            Controls.Add(btnRoute);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainGUI";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRoute;
        private Button btnLimousine;
        private Label label1;
        private Label labelHello;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem logoutadminToolStripMenuItem;
        private Button btnTrip;
    }
}