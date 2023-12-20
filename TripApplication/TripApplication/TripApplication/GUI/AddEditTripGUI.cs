using Microsoft.EntityFrameworkCore;
using System.Data;
using TripApplication.DTO;
using TripApplication.Models;

namespace TripApplication.GUI
{
    public partial class AddEditTripGUI : Form
    {
        private TripDTO trip;
        private readonly TripContext context = new TripContext();
        private static List<SlotDTO> slots = new List<SlotDTO>
        {
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
        public AddEditTripGUI()
        {
            InitializeComponent();
            LoadComboBox();
        }
        public AddEditTripGUI(TripDTO trip)
        {
            this.trip = trip;
            InitializeComponent();
            LoadComboBox();
            LoadTripData();
        }

        private void LoadComboBox()
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MM/dd/yyyy";
            dtpDate.Value = DateTime.Now;

            cboSlot.DataSource = slots;
            cboSlot.DisplayMember = "SlotName";
            cboSlot.ValueMember = "SlotId";

            cboLimo.DataSource = context.Limousines.ToList();
            cboLimo.DisplayMember = "Plate";
            cboLimo.ValueMember = "LimousineId";
            cboLimo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboLimo.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboTrip.DataSource = context.Routes.ToList();
            cboTrip.DisplayMember = "RouteName";
            cboTrip.ValueMember = "RouteId";
            cboTrip.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTrip.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.trip == null)
            {
                labelTitle.Text = "ADD NEW TRIP";
                dtpDate.Value = DateTime.Now;
                dtpDate.MinDate = DateTime.Now;
            }



        }

        private void CheckLimo(DateTime date, int slot, List<Limousine> listLimo)
        {
            List<Trip> trips = context.Trips.Where(t => t.Date == date && t.Slot == slot).ToList();
            if (trips != null)
            {
                foreach (Trip t in trips)
                {
                    int Id = (int)t.LimousineId;
                    Limousine limo = listLimo.FirstOrDefault(l => l.LimousineId == Id);
                    if (limo != null)
                    {
                        listLimo.Remove(limo);
                    }
                }
            }
            if (trip != null && trip.Slot == slot)
            {
                Limousine lim = context.Limousines.FirstOrDefault(l => l.Plate == trip.LimousinePlate);
                listLimo.Insert(0, lim);
            }

            cboLimo.DataSource = listLimo;
            cboLimo.DisplayMember = "Plate";
            cboLimo.ValueMember = "LimousineId";
            cboLimo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboLimo.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void CheckSlot(int routeId, DateTime date, int limoId, List<SlotDTO> listSlot)
        {
            Trip t = context.Trips.FirstOrDefault(t => t.RouteId == routeId && t.Date == date && t.LimousineId == limoId);
            if (t != null)
            {
                int slot = (int)t.Slot;
                listSlot.RemoveAt(slot);
            }
            cboSlot.DataSource = slots;
            cboSlot.DisplayMember = "SlotName";
            cboSlot.ValueMember = "SlotId";
        }

        private void CalculatePrice(int routeId)
        {
            double price = 0;
            Route route = context.Routes.FirstOrDefault(r => r.RouteId == routeId);
            if (route != null)
            {
                price = (double)(route.Distance * 1);

            }
            numPrice.Value = (Decimal)price;

        }

        private void CalculatePrice(int routeId, int limoId)
        {
            double price = 0;
            Route route = context.Routes.FirstOrDefault(r => r.RouteId == routeId);
            Limousine limo = context.Limousines.Include(l => l.TypeNavigation).FirstOrDefault(l => l.LimousineId == limoId);
            if (route != null)
            {
                price = (double)(route.Distance * (double)limo.TypeNavigation.UnitPrice);

            }
            numPrice.Value = (Decimal)price;

        }

        private double RefreshPrice(int routeId, int limoId)
        {
            double price = 0;
            Route route = context.Routes.FirstOrDefault(r => r.RouteId == routeId);
            Limousine limo = context.Limousines.Include(l => l.TypeNavigation).FirstOrDefault(l => l.LimousineId == limoId);
            if (route != null)
            {
                price = (double)(route.Distance * (double)limo.TypeNavigation.UnitPrice);

            }
            return price;
        }

        //============================================================

        private void LoadTripData()
        {
            dtpDate.Enabled = false;
            dtpDate.Value = DateTime.Parse(trip.Date.ToString());
            cboLimo.SelectedItem = context.Limousines.Where(l => l.Plate == trip.LimousinePlate).FirstOrDefault();
            numPrice.Value = Decimal.Parse(trip.Price + "");
            cboSlot.SelectedValue = (int)trip.Slot;
            cboTrip.SelectedItem = context.Routes.FirstOrDefault(t => t.RouteName == trip.TripName);
            cboTrip.Enabled = false;
        }

        private void cboTrip_Leave(object sender, EventArgs e)
        {
            Route r = context.Routes.FirstOrDefault(r => r.RouteName == cboTrip.Text);
            if (r == null)
            {
                MessageBox.Show("This trip does not exist", "ERROR");
                cboTrip.SelectedIndex = 0;
            }
            else
            {
                CheckLimo(dtpDate.Value, int.Parse(cboSlot.SelectedValue.ToString()), context.Limousines.ToList());
                CalculatePrice(int.Parse(cboTrip.SelectedValue.ToString()), int.Parse(cboLimo.SelectedValue.ToString()));
            }

        }

        private void cboLimo_Leave(object sender, EventArgs e)
        {
            Limousine limo = context.Limousines.FirstOrDefault(l => l.Plate == cboLimo.Text);
            if (limo == null)
            {
                MessageBox.Show("This Limousine does not exist", "ERROR");
                cboLimo.SelectedIndex = 0;
            }
            else
            {
                Limousine selectedLimo = (Limousine)cboLimo.SelectedItem;
                CalculatePrice(int.Parse(cboTrip.SelectedValue.ToString()), int.Parse(cboLimo.SelectedValue.ToString()));
                if (trip != null && selectedLimo.Plate == trip.LimousinePlate)
                {
                    numPrice.Value = (Decimal)trip.Price;
                }
            }
        }

        private void numPrice_Leave(object sender, EventArgs e)
        {
            if (numPrice.Value <= 0 || numPrice.Text.Trim() == "")
            {
                MessageBox.Show("Price must be greater than 0", "ERROR");
                numPrice.Text = RefreshPrice(int.Parse(cboTrip.SelectedValue.ToString()), int.Parse(cboLimo.SelectedValue.ToString())) + "";
            }
        }

        private void dtpDate_Leave(object sender, EventArgs e)
        {
            CheckLimo(dtpDate.Value, int.Parse(cboSlot.SelectedValue.ToString()), context.Limousines.ToList());
        }

        private void cboSlot_Leave(object sender, EventArgs e)
        {
            CheckLimo(dtpDate.Value, int.Parse(cboSlot.SelectedValue.ToString()), context.Limousines.ToList());
        }

        private void cboLimo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrip.SelectedValue != null && cboLimo.SelectedValue != null)
            {
                CalculatePrice(int.Parse(cboTrip.SelectedValue.ToString()), int.Parse(cboLimo.SelectedValue.ToString()));
            }

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDate.Value != null && cboSlot.SelectedValue != null)
            {
                CheckLimo(dtpDate.Value, int.Parse(cboSlot.SelectedValue.ToString()), context.Limousines.ToList());
            }
        }

        private void cboSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtpDate.Value != null && cboSlot.SelectedValue != null && Application.OpenForms["AddEditTripGUI"] != null)
            {
                CheckLimo(dtpDate.Value, int.Parse(cboSlot.SelectedValue.ToString()), context.Limousines.ToList());
            }
            if (cboTrip.SelectedValue != null && cboLimo.SelectedValue != null && Application.OpenForms["AddEditTripGUI"] != null)
            {
                CalculatePrice(int.Parse(cboTrip.SelectedValue.ToString()), int.Parse(cboLimo.SelectedValue.ToString()));
            }
        }

        private void cboTrip_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTrip.SelectedValue != null && cboLimo.SelectedValue != null && Application.OpenForms["AddEditTripGUI"] != null)
            {
                CalculatePrice(int.Parse(cboTrip.SelectedValue.ToString()), int.Parse(cboLimo.SelectedValue.ToString()));
            }
        }

        private void AddEditTripGUI_Load(object sender, EventArgs e)
        {
            if (cboTrip.SelectedValue != null && cboLimo.SelectedValue != null && Application.OpenForms["AddEditTripGUI"] != null)
            {
                CalculatePrice(int.Parse(cboTrip.SelectedValue.ToString()), int.Parse(cboLimo.SelectedValue.ToString()));
                if (trip != null)
                {
                    numPrice.Value = (Decimal)trip.Price;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            if (trip != null)
            {
                TripGUI gui = new TripGUI("admin", "admin");
                gui.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trip == null)
            {
                Trip newTrip = new Trip
                {
                    RouteId = int.Parse(cboTrip.SelectedValue.ToString()),
                    Date = dtpDate.Value,
                    Slot = int.Parse(cboSlot.SelectedValue.ToString()),
                    Price = numPrice.Value,
                    LimousineId = int.Parse(cboLimo.SelectedValue.ToString()),
                    Status = 1,
                    CreateBy = "admin"
                };
                context.Trips.Add(newTrip);
                context.SaveChanges();
                MessageBox.Show("This trip has been added successfully");
                this.Close();
            }
            else
            {
                Trip editTrip = context.Trips.Find(this.trip.TripId);
                if (editTrip != null)
                {
                    editTrip.Slot = int.Parse(cboSlot.SelectedValue.ToString());
                    editTrip.LimousineId = int.Parse(cboLimo.SelectedValue.ToString());
                    editTrip.Price = numPrice.Value;
                    try
                    {
                        context.Trips.Update(editTrip);
                        context.SaveChanges();
                        MessageBox.Show("This trip has been updated successfully");
                        this.Close();
                        TripGUI gui = new TripGUI("admin", "admin");
                        gui.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }
        }
    }
}
