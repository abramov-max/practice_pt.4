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
    public partial class FormUpp : Form
    {

        private List<Row> data = new List<Row>();
        public FormUpp()
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

        private void FormUpp_Shown(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlCommand command = new MySqlCommand("INSERT INTO `info` (`name`, `surname`, `diagnoz`, `priem`) VALUES (@nam, @sur, @dia, @pri)", db.GetConnection());

            command.Parameters.Add("@nam", MySqlDbType.VarChar).Value = textName.Text;
            command.Parameters.Add("@sur", MySqlDbType.VarChar).Value = textSurname.Text;
            command.Parameters.Add("@dia", MySqlDbType.VarChar).Value = textDiagnoz.Text;
            command.Parameters.Add("@pri", MySqlDbType.VarChar).Value = textPriem.Text;
            
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Строка была добавлена");
            else
                MessageBox.Show("Строка не была добавлена");

            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("DELETE FROM `info` WHERE `id` = @i", db.GetConnection());
            command.Parameters.Add("@i", MySqlDbType.VarChar).Value = textDel.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            MessageBox.Show("Строка была удалена!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить все данные?", " ",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Database db = new Database();
                MySqlCommand command = new MySqlCommand("TRUNCATE TABLE `info`", db.GetConnection());

                try
                {
                    db.openConnection();

                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные удалены", "Внимание");
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data.Clear();

            Database manager = new Database();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `info`", manager.GetConnection());
            MySqlDataReader reader;

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

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
                {
                    AddDataGrid(data[i]);
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            finally
            {
                manager.closeConnection();
            }
        }
    }
}
