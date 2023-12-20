using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripApplication.DTO;
using TripApplication.Models;

namespace TripApplication.GUI
{
    public partial class LimousineGUI : Form
    {
        private readonly TripContext context = new TripContext();
        public LimousineGUI()
        {
            InitializeComponent();
            LoadLimousineDataView();
        }

        private void LoadLimousineDataView()
        {
            List<LimousineDTO> listLimo = (
                from lim in context.Limousines.Include(l => l.TypeNavigation)
                select new LimousineDTO
                {
                    LimousineId = lim.LimousineId,
                    Name = lim.Name,
                    NumberRows = lim.NumberRows,
                    NumberCols = lim.NumberCols,
                    Plate = lim.Plate,
                    Type = lim.TypeNavigation.Type
                }
                ).ToList();

            limoDataView.DataSource = listLimo;
        }


        private void limoDataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = limoDataView.Rows[e.RowIndex];

            textId.Text = row.Cells["LimousineId"].Value.ToString();
            textName.Text = row.Cells["Name"].Value.ToString();
            textPlate.Text = row.Cells["Plate"].Value.ToString();
            numRow.Value = int.Parse(row.Cells["NumberRows"].Value.ToString());
            numCol.Value = int.Parse(row.Cells["NumberCols"].Value.ToString());

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (textId.TextLength > 0)
            {
                int id = int.Parse(textId.Text);
                if (numCol.Value > 0 && numRow.Value > 0 && textName.TextLength > 0)
                {
                    Limousine lim = context.Limousines.Find(id);
                    if (lim != null)
                    {
                        lim.Name = textName.Text;
                        lim.NumberRows = (int)numRow.Value;
                        lim.NumberCols = (int)numCol.Value;
                        lim.Plate = textPlate.Text;
                        context.Limousines.Update(lim);
                        context.SaveChanges();
                        MessageBox.Show("Updated Successfully !");
                        RefreshLimoData();
                        textFilter.Text = textFilter.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Please check again Name must not empty, Number Row and Col must be > 0");
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textId.Text = String.Empty;
            textName.Text = String.Empty;
            textPlate.Text = String.Empty;
            textFilter.Text = String.Empty;
            numRow.Value = 0;
            numCol.Value = 0;
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            List<LimousineDTO> listBySearch = (
                from lim in context.Limousines.Include(l => l.TypeNavigation)
                where lim.Plate.ToLower().Contains(textFilter.Text.ToLower()) ||
                lim.Name.ToLower().Contains(textFilter.Text.ToLower())
                select new LimousineDTO
                {
                    LimousineId = lim.LimousineId,
                    Name = lim.Name,
                    NumberRows = lim.NumberRows,
                    NumberCols = lim.NumberCols,
                    Plate = lim.Plate,
                    Type = lim.TypeNavigation.Type
                }
                )
                .ToList();
            limoDataView.DataSource = listBySearch;
        }

        private void RefreshLimoData()
        {
            limoDataView.DataSource = null;
            limoDataView.Columns.Clear();
            LoadLimousineDataView();
        }

        private void limoDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            labelNum.Text = $"Total number of our Limousine: {limoDataView.Rows.Count}";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textId.TextLength > 0)
            {
                int id = int.Parse(textId.Text);
                if (id > 0)
                {
                    Limousine lim = context.Limousines.Find(id);
                    if (MessageBox.Show("Do you want to DELETE this Limousine ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        context.Limousines.Remove(lim);
                        context.SaveChanges();
                        MessageBox.Show("Deleted Successfully");
                        RefreshLimoData();
                        textFilter.Text = textFilter.Text;

                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainGUI main = new MainGUI("admin", "admin");
            main.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddLimousineGUI add = new AddLimousineGUI();
            add.ShowDialog();
            RefreshLimoData();
            textFilter.Text = textFilter.Text;
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
