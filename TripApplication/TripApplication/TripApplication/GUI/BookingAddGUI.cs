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
    public partial class BookingAddGUI : Form
    {
        private readonly TripContext context = new TripContext();
        private string username;
        private string role;
        private string seatStatus;
        private Trip ChoosenTrip;
        private int row;
        private int col;
        private int count = 0;
        public BookingAddGUI()
        {
            InitializeComponent();
        }

        public BookingAddGUI(Trip trip, string username, string role)
        {
            this.ChoosenTrip = trip;
            this.role = role;
            this.username = username;
            InitializeComponent();
            SetDefaultSeatStatus();
            LoadSeats();

        }


        private void LoadSeats()
        {
            textCreated.Text = this.username;
            List<int> listChoosenSeat = GetListSeatsChoosen(GetAllSeatStatus(this.ChoosenTrip.TripId), this.row, this.col);
            RefreshSeatsView(this.row, this.col);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Name = $"{i * col + j}";
                    checkBox.Checked = false;
                    checkBox.Text = $"{i * col + j + 1}";
                    checkBox.Size = new Size(50, 20);
                    checkBox.Checked = false;

                    // Đặt vị trí checkbox
                    int x = 350 + j * 65; // Khoảng cách giữa các checkbox theo trục X
                    int y = 20 + i * 25; // Khoảng cách giữa các checkbox theo trục Y   
                    checkBox.Location = new Point(x, y);
                    if (listChoosenSeat.Contains(i * col + j))
                    {
                        checkBox.Checked = true;
                        checkBox.Enabled = false;
                    }
                    else
                    {
                        checkBox.CheckedChanged += CheckBox_CheckedChanged;
                    }

                    // Thêm checkbox vào form
                    this.Controls.Add(checkBox);
                }
            }

        }

        private void SetDefaultSeatStatus()
        {
            GetRowCol(this.ChoosenTrip.TripId);
            textAmount.Text = "0";
            for (int i = 0; i < this.row * this.col; i++)
            {
                seatStatus += "0";
            }

        }

        //========================================================================================================

        private void CheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int index = Convert.ToInt32(checkbox.Name);
            if (checkbox.Checked)
            {
                count++;
                textAmount.Text = calAmount(this.ChoosenTrip, this.count).ToString();
                UpdateChooseSeat(true, index);
            }
            else
            {
                count--;
                textAmount.Text = calAmount(this.ChoosenTrip, this.count).ToString();
                UpdateChooseSeat(false, index);
            }
        }

        private void UpdateChooseSeat(bool isChecked, int index)
        {
            char[] each = seatStatus.ToCharArray();
            string temp = "";
            if (isChecked)
            {
                each[index] = '1';
            }
            else
            {
                each[index] = '0';
            }
            foreach (char c in each)
            {
                temp += c;
            }
            this.seatStatus = temp;
        }

        private double calAmount(Trip trip, int count)
        {
            return (double)trip.Price * count;
        }

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
            foreach (Booking book in context.Bookings.Where(b => b.TripId == this.ChoosenTrip.TripId).ToList())
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string regex = "^[0]{1}[0-9]{9}$";
            double amount = Convert.ToDouble(textAmount.Text);

            if (amount > 0)
            {
                if(Regex.IsMatch(textPhone.Text, regex))
                {
                    Booking booking = new Booking
                    {
                        TripId = this.ChoosenTrip.TripId,
                        Customer = textCustomer.Text,
                        Phone = textPhone.Text,
                        SeatsStatus = this.seatStatus,
                        Amount = (Decimal)amount,
                        CreatedBy = this.username
                    };

                    context.Bookings.Add(booking);
                    context.SaveChanges();
                    MessageBox.Show("Added Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Phone");
                    textPhone.Text = String.Empty;
                }

            }
            else
            {
                if (MessageBox.Show("You didn't choose Seats, Do you want to cancel ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textPhone_Leave(object sender, EventArgs e)
        {
            string regex = "^[0]{1}[0-9]{9}$";
            if(!Regex.IsMatch(textPhone.Text, regex))
            {
                MessageBox.Show("Invalid Phone");
                textPhone.Text = String.Empty;
            }
        }
    }
}
