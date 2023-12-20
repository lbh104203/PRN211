using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripApplication.Models;

namespace TripApplication.GUI
{
    public partial class AddLimousineGUI : Form
    {
        private readonly TripContext context = new TripContext();
        private static string regexPattern = @"^[0-9]{2}[A-Z]{1}-[0-9]{4,5}$";

        public AddLimousineGUI()
        {
            InitializeComponent();
            LoadComboType();
        }

        private void LoadComboType()
        {
            cboType.DataSource = context.LimousineTypes.ToList();
            cboType.SelectedIndex = 0;
            cboType.DisplayMember = "Type";
            cboType.ValueMember = "Id";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Limousine lim = context.Limousines.Where(l => l.Plate == textPlate.Text).FirstOrDefault();
            if (lim != null)
            {
                MessageBox.Show("This car is alreadt exists !!", "ERROR");
            }
            else if (lim == null && textName.TextLength > 0
                && Regex.IsMatch(textPlate.Text, regexPattern)
                && (int)numRow.Value > 0 && (int)numCol.Value > 0)
            {
                Limousine limToAdd = new Limousine
                {
                    Name = textName.Text,
                    Plate = textPlate.Text,
                    NumberCols = (int)numCol.Value,
                    NumberRows = (int)numRow.Value,
                    Type = int.Parse(cboType.SelectedValue.ToString())
                };
                context.Limousines.Add(limToAdd);
                context.SaveChanges();
                MessageBox.Show("Added Successfully !!");
                this.Close();
            }
            else if (!Regex.IsMatch(textPlate.Text, regexPattern))
            {
                MessageBox.Show("Invalid format of Plate, check the example !", "ERROR");
            }
            else
            {
                MessageBox.Show("Please check again Name must not empty, Plate must be same format with example" +
                    ", Number Row and Col must be > 0", "ERROR");
            }
        }

        private void numRow_Leave(object sender, EventArgs e)
        {
            if (numRow.Value < 5)
            {
                MessageBox.Show("The number of seats row must be between 5 to 10");
                numRow.Value = 5;
            }
            if (numRow.Value > 10)
            {
                MessageBox.Show("The number of seats row must be between 5 to 10");
                numRow.Value = 10;
            }
        }

        private void numCol_Leave(object sender, EventArgs e)
        {
            if (numCol.Value < 2)
            {
                MessageBox.Show("The number of seats row must be between 2 to 3");
                numCol.Value = 2;
            }
            if (numCol.Value > 3)
            {
                MessageBox.Show("The number of seats row must be between 2 to 3");
                numCol.Value = 3;
            }
        }
    }
}
