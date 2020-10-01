using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice4
{
    public partial class FormPac : Form
    {
        public FormPac()
        {
            InitializeComponent();
        }

        private void HeaderOfTheTable()
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 50;
            column1.Name = "id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Имя";
            column2.Width = 100;
            column2.Name = "name";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Фамилия";
            column3.Width = 100;
            column3.Name = "surname";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Диагноз";
            column4.Width = 100;
            column4.Name = "diagnoz";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Приём";
            column5.Width = 100;
            column5.Name = "priem";
            column5.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = false;
        }

        private void AddDataGrid(Row row)
        {
            dataGridView1.Rows.Add(row.id, row.name, row.surname, row.diagnoz, row.priem);
        }

        private void FormPac_Shown(object sender, EventArgs e)
        {
            HeaderOfTheTable();
            dataGridView1.Columns[0].ReadOnly = true;

            List<Row> data = new List<Row>();

            Database manager = new Database();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `info` ", manager.GetConnection());
            MySqlDataReader reader;

            try
            {
                manager.openConnection();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Row row = new Row(reader["id"], reader["name"], reader["surname"], reader["diagnoz"], reader["priem"]);
                    data.Add(row);
                }

                for (int i = 0; i < data.Count; i++)
                    AddDataGrid(data[i]);
            }
            finally
            {
                manager.closeConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUpp Uppform = new FormUpp();
            this.Hide();
            Uppform.Show();
        }
    }
}
    

