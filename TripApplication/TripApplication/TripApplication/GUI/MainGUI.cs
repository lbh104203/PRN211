using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripApplication.GUI
{
    public partial class MainGUI : Form
    {
        private string role;
        private string username;

        public MainGUI(string role, string username)
        {
            this.role = role;
            this.username = username;
            InitializeComponent();
            labelHello.Text = $"Hello, {username}";
            logoutadminToolStripMenuItem.Text = $"Logout ({username})";
            checkButton();
        }

        private void checkButton()
        {
            if (this.role == "admin")
            {
            }
            else if (this.role == "staff")
            {
                btnLimousine.Visible = false;
                btnRoute.Visible = false;
                btnTrip.Text = "Bookings";
            }
        }

        private void logoutadminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginGUI loginGUI = new LoginGUI();
            loginGUI.Show();
            this.role = "";
            this.Close();
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            RouteGUI routeGUI = new RouteGUI();
            routeGUI.Show();
            this.Close();
        }

        private void btnLimousine_Click(object sender, EventArgs e)
        {
            LimousineGUI lim = new LimousineGUI();
            lim.Show();
            this.Close();
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            TripGUI trip = new TripGUI(this.role, this.username);
            trip.Show();
            this.Close();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {

        }
    }
}
