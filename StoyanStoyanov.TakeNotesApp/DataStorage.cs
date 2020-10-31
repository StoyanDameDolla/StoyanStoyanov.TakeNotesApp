using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoyanStoyanov.TakeNotesApp
{
    public partial class DataStorage : Form
    {
        DataTable table;
        public DataStorage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Instantiate a new Data table with 2 columns - Title, Messages;
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            //Connecting the Data grid view from the Form with the newly created custom Data Table
            dataGridView1.DataSource = table;

            //Disabling the View mode of the Message column;
            dataGridView1.Columns["Messages"].Visible = false;
            //Adjusting the Width of the Title column -- no grayed out background;
            dataGridView1.Columns["Title"].Width = 270;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textTitle.Clear();
            messageTextbox.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textTitle.Text, messageTextbox.Text);

            //Clearing the boxes after saved message;
            textTitle.Clear();
            messageTextbox.Clear();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //Select a specific row;
            int index = dataGridView1.CurrentCell.RowIndex;
            //If any row has been selected --> index will be 0 or higher;
            if (index > -1)
            {
                //Converting the Title and Message text box data to a String var format;
                textTitle.Text = table.Rows[index].ItemArray[0].ToString();
                messageTextbox.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Pick the index of the currently selected row;
            int index = dataGridView1.CurrentCell.RowIndex;

            //Clearing the rows whenever the Delete button has been clicked;
            table.Rows[index].Delete();
        }
    }
}
