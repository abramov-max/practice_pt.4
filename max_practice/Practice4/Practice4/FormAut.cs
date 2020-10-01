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
    public partial class FormAut : Form
    {
        public FormAut()
        {
            InitializeComponent();
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {
            String login = textBoxLog.Text;
            String password = textBoxPass.Text;

            Database db = new Database();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @log AND `password` = @pass", db.GetConnection());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Вы вошли в ваш аккаунт");
                FormPac Pacform = new FormPac();
                this.Hide();
                Pacform.Show();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }
    }
}
