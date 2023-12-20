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
    public partial class TripGUI : Form
    {
        private readonly TripContext context = new TripContext();
        private string role;
        private string username;
        private static List<SlotDTO> slots = new List<SlotDTO>
        {
            new SlotDTO
            {
                SlotId = 0,
                SlotName = "All",
            },
            new SlotDTO
            {
                SlotId = 1,
                SlotName = "Day - 09:00:00 AM"
            },
            new SlotDTO
            {
                SlotId = 2,
                SlotName = "Night - 21:00:00 PM"
            }
        };
        public TripGUI()
        {
            InitializeComponent();
            LoadTripData();
            LoadComboBox();
        }

        public TripGUI(string role)
        {
            this.role = role;
            InitializeComponent();
            LoadTripData();
            LoadComboBox();
        }

        public TripGUI(string role, string username)
        {
            this.role = role;
            this.username = username;
            InitializeComponent();
            LoadTripData();
            LoadComboBox();
            EnableButton();
        }

        private void EnableButton()
        {
            if (this.role == "admin")
            {
                btnAddNew.Visible = true;
            }
            else if (this.role == "staff")
            {
                btnAddNew.Visible = false;
            }
        }

        private void LoadTripData()
        {
            List<TripDTO> listTrip = (
                from trip in context.Trips.Include(t => t.Route).Include(t => t.Limousine).ToList()
                select new TripDTO
                {
                    TripId = trip.TripId,
                    TripName = trip.Route.RouteName,
                    TripFrom = trip.Route.RouteFrom,
                    TripTo = trip.Route.RouteTo,
                    Date = trip.Date,
                    Slot = trip.Slot,
                    Price = trip.Price,
                    LimousinePlate = trip.Limousine.Plate,
                    LimousineType = trip.Limousine.Type == 1 ? "NORMAL" : "VIP",
                    Status = trip.Status,
                }
                )
                .OrderByDescending(t => t.Date)
                .ToList();
            if (this.role == "admin")
            {
                tripDataView.DataSource = listTrip;
            }
            else if (this.role == "staff")
            {
                tripDataView.DataSource = listTrip.Where(t => t.Date >= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) && (t.Status == 1 || t.Status == 2))
                    .OrderBy(t => t.Date)
                    .ToList();
            }
            HideColumns();
            AddColumns();
        }

        private List<TripDTO> GetListTripDTO()
        {
            List<TripDTO> listTrip = (
                from trip in context.Trips.Include(t => t.Route).Include(t => t.Limousine).ToList()
                select new TripDTO
                {
                    TripId = trip.TripId,
                    TripName = trip.Route.RouteName,
                    TripFrom = trip.Route.RouteFrom,
                    TripTo = trip.Route.RouteTo,
                    Date = trip.Date,
                    Slot = trip.Slot,
                    Price = trip.Price,
                    LimousinePlate = trip.Limousine.Plate,
                    LimousineType = trip.Limousine.Type == 1 ? "NORMAL" : "VIP",
                    Status = trip.Status,
                }
                )
                .OrderByDescending(t => t.Date)
                .ToList();
            return listTrip;
        }

        private void RefreshTripDataView()
        {
            tripDataView.Columns.Clear();
            tripDataView.DataSource = null;
        }


        private void HideColumns()
        {
            tripDataView.Columns["TripFrom"].Visible = false;
            tripDataView.Columns["TripTo"].Visible = false;
            tripDataView.Columns["TripId"].Visible = false;
            tripDataView.Columns["Status"].Visible = false;
        }

        private void AddColumns()
        {
            tripDataView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Bookings",
                Text = "Bookings",
                UseColumnTextForButtonValue = true
            });
            if (this.role == "admin")
            {
                tripDataView.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                });
                tripDataView.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                });
            }
            else if (this.role == "staff")
            {
                tripDataView.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Started",
                    Text = "Started",
                    UseColumnTextForButtonValue = true
                });
            }
        }


        private void LoadComboBox()
        {
            if (this.role == "admin")
            {
                checkSeat.Visible = false;
            }
            else if (this.role == "staff")
            {
                checkSeat.Visible = true;
            }
            List<Location> listLocation = context.Locations.ToList();

            cboFrom.DataSource = new List<Location>(listLocation);
            cboFrom.DisplayMember = "LocationName";
            cboFrom.ValueMember = "LocationCode";
            cboFrom.SelectedIndex = 0;
            cboFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboFrom.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboTo.DataSource = new List<Location>(listLocation);
            cboTo.DisplayMember = "LocationName";
            cboTo.ValueMember = "LocationCode";
            cboTo.SelectedIndex = 1;
            cboTo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTo.AutoCompleteSource = AutoCompleteSource.ListItems;


            cboSlot.DataSource = slots;
            cboSlot.DisplayMember = "SlotName";
            cboSlot.ValueMember = "SlotId";
            cboSlot.SelectedIndex = 0;

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MM/dd/yyyy";
            dtpDate.Value = DateTime.Now;

            radioAll.Checked = true;
        }

        private void tripDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            labelNum.Text = $"The number of trips:  {tripDataView.Rows.Count}";
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            //checkSeat.Visible = true;
            Location from = (Location)cboFrom.SelectedItem;
            Location to = (Location)cboTo.SelectedItem;

            List<TripDTO> listTrip = GetListTripDTO();
            listTrip = listTrip.Where(t => t.TripFrom == from.LocationCode && t.TripTo == to.LocationCode
            && t.Date == DateTime.Parse(dtpDate.Value.ToString("MM/dd/yyyy")))
                .ToList();
            if (this.role == "staff")
            {
                listTrip = listTrip.Where(t => t.Date >= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")) && (t.Status == 1 || t.Status == 2))
                    .OrderBy(t => t.Date)
                    .ToList();
            }

            if ((int)cboSlot.SelectedValue == 0)
            {

            }
            else
            {
                listTrip = listTrip.Where(t => t.Slot == (int)cboSlot.SelectedValue).ToList();
            }

            if (GetTypeChoosen() == "ALL")
            {

            }
            else
            {
                listTrip = listTrip.Where(t => t.LimousineType == GetTypeChoosen()).ToList();
            }

            RefreshTripDataView();
            tripDataView.DataSource = listTrip;
            HideColumns();
            AddColumns();

        }

        private string GetTypeChoosen()
        {
            if (radioNormal.Checked) return "NORMAL";
            if (radioVip.Checked) return "VIP";

            return "ALL";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            RefreshTripDataView();
            LoadTripData();
            //checkSeat.Visible = false;
            checkSeat.Checked = false;
        }

        private void tripDataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = tripDataView.Rows[e.RowIndex];
            cboFrom.SelectedItem = context.Locations.Where(l => l.LocationCode == row.Cells["TripFrom"].Value).FirstOrDefault();
            cboTo.SelectedItem = context.Locations.Where(l => l.LocationCode == row.Cells["TripTo"].Value).FirstOrDefault();
            cboSlot.SelectedIndex = int.Parse(row.Cells["Slot"].Value.ToString());
            dtpDate.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
            radioNormal.Checked = radioNormal.Text == row.Cells["LimousineType"].Value.ToString();
            radioVip.Checked = radioVip.Text == row.Cells["LimousineType"].Value.ToString();
        }

        private void checkSeat_CheckedChanged(object sender, EventArgs e)
        {
            List<TripDTO> routes = (List<TripDTO>)tripDataView.DataSource;
            List<TripDTO> temp = new List<TripDTO>();
            if (checkSeat.Checked)
            {
                temp = (List<TripDTO>)routes.Where(r => r.Status == 1).ToList();
                tripDataView.DataSource = temp;
            }
            else
            {
                btnShowAll_Click(sender, e);
            }

        }

        private void tripDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (tripDataView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (tripDataView.Columns[e.ColumnIndex].HeaderText == "Edit")
                    {
                        int Id = int.Parse(tripDataView.Rows[e.RowIndex].Cells["TripId"].Value.ToString());
                        TripDTO trip = GetListTripDTO().Where(t => t.TripId == Id).FirstOrDefault();
                        AddEditTripGUI t = new AddEditTripGUI(trip);
                        this.Close();
                        t.Show();


                    }
                    else if (tripDataView.Columns[e.ColumnIndex].HeaderText == "Delete")
                    {
                        int Id = int.Parse(tripDataView.Rows[e.RowIndex].Cells["TripId"].Value.ToString());
                        Trip removeTrip = context.Trips.Find(Id);
                        if (removeTrip != null && MessageBox.Show("Do you want to delete this trip ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            context.Trips.Remove(removeTrip);
                            context.SaveChanges();
                            MessageBox.Show("Deleted successfully");
                            RefreshTripDataView();
                            LoadTripData();
                        }
                    }
                    else if (tripDataView.Columns[e.ColumnIndex].HeaderText == "Bookings")
                    {
                        int Id = Convert.ToInt32(tripDataView.Rows[e.RowIndex].Cells["TripId"].Value);
                        BookingGUI gui = new BookingGUI(this.role, this.username, Id);
                        this.Close();
                        gui.Show();
                    }
                    else if (tripDataView.Columns[e.ColumnIndex].HeaderText == "Started")
                    {
                        int Id = Convert.ToInt32(tripDataView.Rows[e.RowIndex].Cells["TripId"].Value);
                        Trip t = context.Trips.Find(Id);
                        if (t.Date == DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")))
                        {
                            if (MessageBox.Show("This trip has been started ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                t.Status = 3;
                                context.Trips.Update(t);
                                context.SaveChanges();
                                RefreshTripDataView();
                                LoadTripData();
                            }
                        }

                    }
                }
            }
        }

        private void cboFrom_Leave(object sender, EventArgs e)
        {
            string inputValue = cboFrom.Text;
            Location matchingLocation = context.Locations.FirstOrDefault(l => l.LocationName == inputValue);
            if (matchingLocation == null)
            {
                MessageBox.Show("Please choose the valid Location !!", "ERROR");
                cboFrom.SelectedIndex = 0;
            }
        }

        private void cboTo_Leave(object sender, EventArgs e)
        {
            string inputValue = cboTo.Text;
            Location matchingLocation = context.Locations.FirstOrDefault(l => l.LocationName == inputValue);
            if (matchingLocation == null)
            {
                MessageBox.Show("Please choose the valid Location !!", "ERROR");
                cboTo.SelectedIndex = 0;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddEditTripGUI trip = new AddEditTripGUI();
            trip.ShowDialog();
            RefreshTripDataView();
            LoadTripData();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainGUI main = new MainGUI(this.role, this.username);
            main.Show();
            this.Close();
        }

    }
}
