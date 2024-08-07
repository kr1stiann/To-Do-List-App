using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class toDoApp : Form
    {
        public toDoApp()
        {
            InitializeComponent();
        }
        

        DataTable toDoList = new DataTable();
        bool isEditing = false;

        private void toDoApp_Load(object sender, EventArgs e)
        {
            //Create columns
            
            toDoList.Columns.Add("Title");
            toDoList.Columns.Add("Description");

            // Point our DataGridView to our DataTable
            toDoListView.DataSource = toDoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // Fill text firelds with data from table
            titleTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = titleTextBox.Text;
            }
            else
            {
                toDoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            //Clear fields
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }
    }
}
