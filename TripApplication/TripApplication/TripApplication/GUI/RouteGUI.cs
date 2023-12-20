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
    public partial class RouteGUI : Form
    {
        private readonly TripContext context = new TripContext();
        public RouteGUI()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadRouteData();
        }

        private void LoadComboBoxData()
        {
            numDistance.Value = 0;
            List<Location> listLocation = context.Locations.ToList();

            Location chooseDefault = new Location
            {
                LocationCode = "0",
                LocationName = "Select Location"
            };
            listLocation.Insert(0, chooseDefault);

            cboFrom.DataSource = new List<Location>(listLocation);
            cboFrom.DisplayMember = "LocationName";
            cboFrom.ValueMember = "LocationCode";

            cboTo.DataSource = new List<Location>(listLocation);
            cboTo.DisplayMember = "LocationName";
            cboTo.ValueMember = "LocationCode";

            cboFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboFrom.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboTo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void AddAdminRouteButton()
        {
            routeDataView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
        }
        private void RefreshRouteDataView()
        {
            routeDataView.Columns.Clear();
            routeDataView.DataSource = null;
        }

        private void LoadRouteData()
        {
            RefreshRouteDataView();
            List<RouteDTO> listRouteDTO = (from route in context.Routes.Include(r => r.RouteFromNavigation).Include(r => r.RouteToNavigation)
                                           select new RouteDTO
                                           {
                                               RouteId = route.RouteId,
                                               RouteName = route.RouteName,
                                               RouteFrom = route.RouteFromNavigation.LocationName,
                                               RouteTo = route.RouteToNavigation.LocationName,
                                               Distance = route.Distance
                                           }
                                           ).ToList();
            routeDataView.DataSource = listRouteDTO;
            AddAdminRouteButton();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            UnableUpdate();
            Location from = (Location)cboFrom.SelectedItem;
            Location to = (Location)cboTo.SelectedItem;
            if (from.LocationCode == "0" && to.LocationCode == "0")
            {
                LoadRouteData();
            }
            else
            {
                List<RouteDTO> listRouteDTO = (from route in context.Routes.Include(r => r.RouteFromNavigation).Include(r => r.RouteToNavigation)
                                               select new RouteDTO
                                               {
                                                   RouteId = route.RouteId,
                                                   RouteName = route.RouteName,
                                                   RouteFrom = route.RouteFromNavigation.LocationName,
                                                   RouteTo = route.RouteToNavigation.LocationName,
                                                   Distance = route.Distance
                                               }
                                           ).ToList();
                if (from.LocationCode != "0" && to.LocationCode == "0")
                {
                    listRouteDTO = listRouteDTO.Where(r => r.RouteFrom == from.LocationName).ToList();
                }
                else if (from.LocationCode == "0" && to.LocationCode != "0")
                {
                    listRouteDTO = listRouteDTO.Where(r => r.RouteTo == to.LocationName).ToList();
                }
                else 
                {
                    listRouteDTO = listRouteDTO.Where(r => r.RouteFrom == from.LocationName && r.RouteTo == to.LocationName).ToList();
                }

                RefreshRouteDataView();
                routeDataView.DataSource = listRouteDTO;
                AddAdminRouteButton();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textId.Text != string.Empty)
            {
                Route route = context.Routes.Find(int.Parse(textId.Text));
                UpdateRoute(route);
            }
            else
            {
                Location from = (Location)cboFrom.SelectedItem;
                Location to = (Location)cboTo.SelectedItem;
                List<Route> routes = context.Routes.Where(r => r.RouteFrom == from.LocationCode && r.RouteTo == to.LocationCode).ToList();

                if (from.LocationCode == "0" || to.LocationCode == "0")
                {
                    MessageBox.Show("You are required to choose a valid starting and ending location for the route !!", "ERROR");
                }
                else if (cboFrom.SelectedItem == cboTo.SelectedItem)
                {
                    MessageBox.Show("You are required to choose DIFFERENT starting and ending locations for the route !!", "ERROR");
                }
                else
                {
                    if ((double)numDistance.Value <= 0)
                    {
                        MessageBox.Show("Distance must be greater than 0 (km)");
                    }
                    else if (routes.Count == 0)
                    {
                        Route route = new Route
                        {
                            RouteFrom = from.LocationCode,
                            RouteTo = to.LocationCode,
                            RouteName = $"{from.LocationName} - {to.LocationName}",
                            Distance = (double)numDistance.Value

                        };
                        context.Routes.Add(route);
                        context.SaveChanges();
                        MessageBox.Show("This route has been added successfully !!");
                        LoadRouteData();
                    }
                    else
                    {
                        MessageBox.Show("This route already exists !!", "ERROR");
                    }
                }
            }
        }

        private void UpdateRoute(Route route)
        {
            Location from = (Location)cboFrom.SelectedItem;
            Location to = (Location)cboTo.SelectedItem;
            List<Route> routes = context.Routes.Where(r => r.RouteFrom == from.LocationCode && r.RouteTo == to.LocationCode).ToList();
            if (route.RouteFrom == from.LocationCode && route.RouteTo == to.LocationCode)
            {
                MessageBox.Show("This route has been updated successfully !!");
            }
            else if (cboFrom.SelectedItem == cboTo.SelectedItem)
            {
                MessageBox.Show("You are required to choose DIFFERENT starting and ending locations for the route !!", "ERROR");
            }
            else if (routes.Count != 0)
            {
                MessageBox.Show("This route already exists !!", "ERROR");
            }
            else
            {
                route.RouteFrom = cboFrom.SelectedValue.ToString();
                route.RouteTo = cboTo.SelectedValue.ToString();
                route.RouteName = $"{from.LocationName} - {to.LocationName}";
                route.Distance = (double)numDistance.Value;

                context.Routes.Update(route);
                context.SaveChanges();
                MessageBox.Show("This route has been updated successfully !!");
                LoadRouteData();
            }
        }

        private void routeDataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            routeDataView.ReadOnly = true;
            labelAll.Text = $"All our routes: {routeDataView.Rows.Count.ToString()}";
        }

        // click button delete
        private void routeDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (routeDataView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (routeDataView.Columns[e.ColumnIndex].HeaderText == "Delete")
                    {
                        int id = Convert.ToInt32(routeDataView.Rows[e.RowIndex].Cells["RouteId"].Value);
                        if (MessageBox.Show("Do you want to delete this route?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DeleteRoute(id);
                            LoadRouteData();
                        }
                    }
                }
            }
        }

        private void DeleteRoute(int routeId)
        {
            Route route = context.Routes.Find(routeId);
            context.Routes.Remove(route);
            context.SaveChanges();
            MessageBox.Show("Deleted successfully !!");
        }


        // click cell
        private void routeDataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UnableUpdate();
            DataGridViewRow row = routeDataView.Rows[e.RowIndex];
            textId.Text = row.Cells["RouteId"].Value.ToString();
            cboFrom.SelectedItem = context.Locations.FirstOrDefault(l => l.LocationName == row.Cells["RouteFrom"].Value.ToString());
            cboTo.SelectedItem = context.Locations.FirstOrDefault(l => l.LocationName == row.Cells["RouteTo"].Value.ToString());
            numDistance.Value = Decimal.Parse(row.Cells["Distance"].Value.ToString());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EnableAdd();
            LoadRouteData();
            textId.Text = String.Empty;
            cboFrom.SelectedIndex = 0;
            cboTo.SelectedIndex = 0;
            numDistance.Value = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainGUI mainGUI = new MainGUI("admin", "admin");
            mainGUI.Show();
            this.Close();
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

        private void numDistance_Leave(object sender, EventArgs e)
        {
            if (numDistance.Value <= 0)
            {
                MessageBox.Show("Distance must be greater than 0 !!", "ERROR");
                numDistance.Value = 0;
            }
        }

        private void UnableUpdate()
        {
            btnAdd.Enabled = false;
            cboFrom.Enabled = false;
            cboTo.Enabled = false;
            numDistance.Enabled = false;
        }
        private void EnableAdd()
        {
            btnAdd.Enabled = !false;
            cboFrom.Enabled = !false;
            cboTo.Enabled = !false;
            numDistance.Enabled = !false;
        }
    }
}
