using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripApplication.Models;

namespace TripApplication.GUI
{
    public partial class BookingGUI : Form
    {
        private string role;
        private string username;
        private int tripId;
        private int row;
        private int col;
        private int count = 0;

        private readonly TripContext context = new TripContext();
        public BookingGUI()
        {
            InitializeComponent();
        }
        public BookingGUI(string role, string username, int tripId)
        {
            this.role = role;
            this.username = username;
            this.tripId = tripId;
            InitializeComponent();
            LoadBookingDataView();
            checkButton();
        }

        private void checkButton()
        {
            if (this.role == "admin")
            {
                btnAdd.Visible = false;
                bookingDataView.Columns["Delete"].Visible = false;
            }
        }

        private void LoadSeats()
        {
            GetRowCol(this.tripId);
            List<int> listChoosenSeat = GetListSeatsChoosen(GetAllSeatStatus(this.tripId), this.row, this.col);
            RefreshSeatsView(this.row, this.col);
            this.count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Name = $"checkbox_{i}_{j}";
                    checkBox.Checked = false;
                    checkBox.Text = $"{i * col + j + 1}";
                    checkBox.Size = new Size(50, 20);
                    checkBox.Checked = false;
                    if (listChoosenSeat.Contains(i * col + j))
                    {
                        count++;
                        checkBox.Checked = true;
                    }
                    // Đặt vị trí checkbox
                    int x = 350 + j * 65; // Khoảng cách giữa các checkbox theo trục X
                    int y = 20 + i * 25; // Khoảng cách giữa các checkbox theo trục Y   
                    checkBox.Location = new Point(x, y);

                    // Thêm checkbox vào form
                    checkBox.Enabled = false;
                    this.Controls.Add(checkBox);
                }
            }

        }

        private void LoadBookingDataView()
        {
            LoadSeats();
            bookingDataView.Columns.Clear();
            bookingDataView.DataSource = context.Bookings.Where(b => b.TripId == this.tripId).ToList();

            // Hide Booking Id, Show Id
            bookingDataView.Columns["BookingId"].Visible = false;
            bookingDataView.Columns["TripId"].Visible = false;
            bookingDataView.Columns["SeatsStatus"].Visible = false;
            bookingDataView.Columns["CreatedByNavigation"].Visible = false;
            bookingDataView.Columns["Trip"].Visible = false;
            // add button detail, delete
            bookingDataView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true,
            });
            bookingDataView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
            });
        }

        //=========================================================================================

        private void GetRowCol(int tripId)
        {
            Trip trip = context.Trips.Find(tripId);
            if (trip != null)
            {
                Limousine limo = context.Limousines.Find(trip.LimousineId);
                if (limo != null)
                {
                    this.row = (int)limo.NumberRows;
                    this.col = (int)limo.NumberCols;
                }
            }
        }


        private List<int> GetListSeatsChoosen(List<string> listSeat, int rows, int cols)
        {
            List<int> listChoosenSeat = new List<int>();
            listChoosenSeat.Clear();
            foreach (string s in listSeat)
            {
                char[] c = s.ToCharArray();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (c[i * cols + j] == '1')
                        {
                            listChoosenSeat.Add(i * cols + j);
                        }
                    }
                }
            }
            return listChoosenSeat;
        }

        private List<string> GetAllSeatStatus(int tripId)
        {
            List<string> listStatus = new List<string>();
            foreach (Booking book in context.Bookings.Where(b => b.TripId == this.tripId).ToList())
            {
                listStatus.Add(book.SeatsStatus);
            }
            return listStatus;
        }

        private void RefreshSeatsView(int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    CheckBox checkbox = this.Controls.Find($"checkbox_{i}_{j}", true).FirstOrDefault() as CheckBox;
                    if (checkbox != null) this.Controls.Remove(checkbox);
                }

            }
        }

        private void bookingDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (bookingDataView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (bookingDataView.Columns[e.ColumnIndex].HeaderText == "Detail")
                    {
                        int Id = Convert.ToInt32(bookingDataView.Rows[e.RowIndex].Cells["BookingId"].Value);
                        Booking book = context.Bookings.Find(Id);
                        BookingDetailGUI gui = new BookingDetailGUI(book);
                        gui.ShowDialog();

                    }
                    else if (bookingDataView.Columns[e.ColumnIndex].HeaderText == "Delete")
                    {
                        int Id = Convert.ToInt32(bookingDataView.Rows[e.RowIndex].Cells["BookingId"].Value);
                        Booking book = context.Bookings.Find(Id);
                        if (book != null && MessageBox.Show("Do you want to delete this Booking ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            context.Bookings.Remove(book);
                            context.SaveChanges();
                            MessageBox.Show("Deleted Successfully");
                            LoadBookingDataView();
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Trip trip = context.Trips.Find(this.tripId);
            if (trip != null)
            {
                BookingAddGUI gui = new BookingAddGUI(trip, this.username, this.role);
                gui.ShowDialog();
                LoadBookingDataView();
                checkButton();
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            TripGUI trip = new TripGUI(this.role, this.username);
            trip.Show();
        }

        private void bookingDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            labelnum.Text = $"Number of bookings: {bookingDataView.Rows.Count}";
            if (this.count == this.row * this.col)
            {
                Trip trip = context.Trips.Find(this.tripId);
                trip.Status = 2;
                context.Trips.Update(trip);
                context.SaveChanges();
                if (this.role == "staff") btnAdd.Visible = false;
            }
            else
            {
                Trip trip = context.Trips.Find(this.tripId);
                trip.Status = 1;
                context.Trips.Update(trip);
                context.SaveChanges();
                if(this.role == "staff") btnAdd.Visible = true;
            }
        }
    }
}
