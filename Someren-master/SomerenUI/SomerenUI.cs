using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {
                // hide all other panels
                pnlStudents.Hide();
                pnlRoomPanel.Hide();

                // show dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlRoomPanel.Hide();

                // show students
                pnlStudents.Show();

                try
                {
                    // fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService(); 
                    List<Student> studentList = studService.GetStudents(); 

                    // clear the listview before filling it again
                    listViewStudents.Clear();

                    foreach (Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.Name);
                        listViewStudents.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }

            try
            {
                //(VOID aanmaken voor hide panels?)
                if (panelName == "Rooms")
                {
                    // hide all other panels
                    pnlDashboard.Hide();
                    imgDashboard.Hide();
                    pnlStudents.Hide();

                    // show rooms
                    pnlRoomPanel.Show();

                    try
                    {
                        //AANPASSEN EN METHODES AANMAKEN. 
                        // fill the rooms listview within the rooms panel with a list of rooms
                        RoomService roomService = new RoomService();
                        List<Room> roomList = roomService.GetRooms();

                        // clear the listview before filling it again
                        listViewRoom.Clear();


                        listViewRoom.View = View.Details;
                        listViewRoom.Columns.Add("Number", 120);
                        listViewRoom.Columns.Add("Capacity", 120);
                        listViewRoom.Columns.Add("Type", 120);
                    
                        foreach (Room room in roomList)
                        {
                            ListViewItem li = new ListViewItem(room.Number.ToString());
                            li.SubItems.Add(room.Capacity.ToString());
                            li.SubItems.Add(room.Type);
                            listViewRoom.Items.Add(li);
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Listview could not be loaded properly." + e.Message);
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Panel could not be loaded properly." + e.Message);
            }            
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imgDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // within this method I want to show what happens when 'Rooms' is clicked
            showPanel("Rooms");
        }


        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listViewRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
