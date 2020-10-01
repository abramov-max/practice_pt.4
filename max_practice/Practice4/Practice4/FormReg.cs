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
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (textBoxN.Text == "")
            {
                MessageBox.Show("Введите имя!");
                return;
            }

            if (textBoxSn.Text == "")
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }

            if (textBoxLog.Text == "")
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (textBoxPass.Text == "")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            if (check())
                return;

            Database db = new Database();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `name`, `surname`) VALUES (@log, @pass, @name, @surname)", db.GetConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = textBoxLog.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPass.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxN.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxSn.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");

            db.closeConnection();

            FormAut AutForm = new FormAut();
            this.Hide();
            AutForm.Show();
        }

        public Boolean check()
        {
            Database db = new Database();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @l", db.GetConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = textBoxLog.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return true;
            }
            else
                return false;
        }
    }
    
}
