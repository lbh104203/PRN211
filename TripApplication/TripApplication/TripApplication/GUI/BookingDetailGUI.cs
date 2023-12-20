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
    public partial class BookingDetailGUI : Form
    {
        private readonly TripContext context = new TripContext();
        private List<int> customerSeats = new List<int>();
        private int row;
        private int col;
        private Booking booking;
        public BookingDetailGUI(Booking booking)
        {
            this.booking = booking;
            InitializeComponent();
            LoadSeatStatus();
            LoadBookingInfo();
        }

        private void LoadSeatStatus()
        {
            GetRowCol((int)this.booking.TripId);
            string seatStatus = this.booking.SeatsStatus;
            char[] eachSeat = seatStatus.ToCharArray();
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Name = $"checkbox_{i}_{j}";
                    checkBox.Checked = false;
                    checkBox.Text = $"{i * col + j + 1}";
                    checkBox.Size = new Size(50, 20);
                    if (eachSeat[i * this.col + j] == '1')
                    {
                        checkBox.Checked = true;
                        customerSeats.Add(i * col + j + 1);
                    }
                    // Đặt vị trí checkbox
                    int x = 350 + j * 65; // Khoảng cách giữa các checkbox theo trục X
                    int y = 25 + i * 25; // Khoảng cách giữa các checkbox theo trục Y
                    checkBox.Location = new Point(x, y);
                    // Thêm checkbox vào form
                    checkBox.Enabled = false;
                    this.Controls.Add(checkBox);

                }
            }
        }

        private void LoadBookingInfo()
        {
            string seat = "";
            for (int i = 0; i < this.customerSeats.Count; i++)
            {

                if (i == this.customerSeats.Count - 1)
                {
                    seat += $"{customerSeats[i]}";
                }
                else
                {
                    seat += $"{customerSeats[i]}- ";
                }
            }
            textSeat.Text = seat;
            textCustomer.Text = booking.Customer;
            textPhone.Text = booking.Phone;
            textPrice.Text = booking.Amount.ToString();
            textStaff.Text = booking.CreatedBy;
        }

        //==========================================================================================

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
