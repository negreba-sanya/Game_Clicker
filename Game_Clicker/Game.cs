using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Clicker
{
    public partial class Game : Form
    {
        public int balance;
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;

        public Game()
        {
            InitializeComponent();                        
            balance = Convert.ToInt32(label_balance.Text);
            Balance();            
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Table]", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Table");
                dataGridView1.DataSource = dataSet.Tables["Table"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables["Table"].Clear();
                sqlDataAdapter.Fill(dataSet, "Table");
                dataGridView1.DataSource = dataSet.Tables["Table"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // метод обновления и проверки баланса

        public void Balance() 
        {
            label_balance.Text = Convert.ToString(balance);
                
            if(balance >= 1000)
            {
                picture_news.Enabled = true;
                button_news.Visible = true;
                news_price.Visible = true;
                news_price_progress.Visible = true;
                progress_news_big.Visible = true;
            }

            if (balance >= 10000)
            {
                picture_car.Enabled = true;
                button_car.Visible = true;
                car_price.Visible = true;
                car_price_progress.Visible = true;
                progress_car_big.Visible = true;
            }
            if (balance >= 100000)
            {
                picture_pizza.Enabled = true;
                button_pizza.Visible = true;
                pizza_price.Visible = true;
                pizza_price_progress.Visible = true;
                progress_pizza_big.Visible = true;
            }
            if (balance >= 1000000)
            {
                picture_ponchik.Enabled = true;
                button_ponchik.Visible = true;
                ponchik_price.Visible = true;
                ponchik_price_progress.Visible = true;
                progress_ponchik_big.Visible = true;
            }
        }

        // иконки преметов

        private void picture_limon_Click(object sender, EventArgs e)
        {
            progress_limon_small.Value += 10;

            for (int i = 0; i < 10; i++)
            {
                progress_limon_big.Value += 10;
                Thread.Sleep(80);
            }

            balance += Convert.ToInt32(limon_price_progress.Text);
            progress_limon_big.Value = 0;

            if (progress_limon_small.Value == 100)
            {
                progress_limon_small.Value = 0;
                limon_price_progress.Text = Convert.ToString(Convert.ToInt32(limon_price_progress.Text) + 10);
            }
            Balance();
        }

        private void picture_news_Click(object sender, EventArgs e)
        {
            progress_news_small.Value += 5;

            for (int i = 0; i < 10; i++)
            {
                progress_news_big.Value += 10;
                Thread.Sleep(100);
            }

            balance += Convert.ToInt32(news_price_progress.Text);
            progress_news_big.Value = 0;

            if (progress_news_small.Value == 100)
            {
                progress_news_small.Value = 0;
                news_price_progress.Text = Convert.ToString(Convert.ToInt32(news_price_progress.Text) + 10);
            }
            Balance();
        }

        private void picture_car_Click(object sender, EventArgs e)
        {
            progress_car_small.Value += 5;

            for (int i = 0; i < 10; i++)
            {
                progress_car_big.Value += 10;
                Thread.Sleep(100);
            }

            balance += Convert.ToInt32(car_price_progress.Text);
            progress_car_big.Value = 0;

            if (progress_car_small.Value == 100)
            {
                progress_car_small.Value = 0;
                car_price_progress.Text = Convert.ToString(Convert.ToInt32(car_price_progress.Text) + 10);
            }
            Balance();
        }

        private void picture_pizza_Click(object sender, EventArgs e)
        {
            progress_pizza_small.Value += 5;

            for (int i = 0; i < 10; i++)
            {
                progress_pizza_big.Value += 10;
                Thread.Sleep(100);
            }

            balance += Convert.ToInt32(pizza_price_progress.Text);
            progress_pizza_big.Value = 0;

            if (progress_pizza_small.Value == 100)
            {
                progress_pizza_small.Value = 0;
                pizza_price_progress.Text = Convert.ToString(Convert.ToInt32(pizza_price_progress.Text) + 10);
            }
            Balance();
        }

        private void picture_ponchik_Click(object sender, EventArgs e)
        {
            progress_ponchik_small.Value += 5;

            for (int i = 0; i < 10; i++)
            {
                progress_ponchik_big.Value += 10;
                Thread.Sleep(100);
            }

            balance += Convert.ToInt32(ponchik_price_progress.Text);
            progress_ponchik_big.Value = 0;

            if (progress_ponchik_small.Value == 100)
            {
                progress_ponchik_small.Value = 0;
                ponchik_price_progress.Text = Convert.ToString(Convert.ToInt32(ponchik_price_progress.Text) + 10);
            }
            Balance();
        }

        // кнопки покупки

        private void button_limon_Click(object sender, EventArgs e)
        {
            balance -= Convert.ToInt32(limon_price.Text);
            limon_price_progress.Text = Convert.ToString(Convert.ToInt32(limon_price_progress.Text) + 2);
            Balance();
        }

        private void button_news_Click(object sender, EventArgs e)
        {
            balance -= Convert.ToInt32(news_price.Text);
            news_price_progress.Text = Convert.ToString(Convert.ToInt32(news_price_progress.Text) + 15);
            Balance();
        }

        private void button_car_Click(object sender, EventArgs e)
        {
            balance -= Convert.ToInt32(car_price.Text);
            car_price_progress.Text = Convert.ToString(Convert.ToInt32(car_price_progress.Text) + 65);
            Balance();
        }

        private void button_pizza_Click(object sender, EventArgs e)
        {
            balance -= Convert.ToInt32(pizza_price.Text);
            pizza_price_progress.Text = Convert.ToString(Convert.ToInt32(pizza_price_progress.Text) + 150);
            Balance();
        }

        private void button_ponchik_Click(object sender, EventArgs e)
        {
            balance -= Convert.ToInt32(ponchik_price.Text);
            ponchik_price_progress.Text = Convert.ToString(Convert.ToInt32(ponchik_price_progress.Text) + 1005);
            Balance();
        }

        private void button_leave_account_Click(object sender, EventArgs e)
        {

        }

        private void button_exit_game_Click(object sender, EventArgs e)
        {

        }

        private void button_upgrade_Click(object sender, EventArgs e)
        {

        }

        private void button_table_rec_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.databaseDataSet.Table);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;

            if(progressBar1.Value == 100)
            {                
                pictureBox1.Visible = false;
                progressBar1.Visible = false;
                timer1.Enabled = false;
            }
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            label_sing_in.Text = "Регистрация аккаунта";
            button_sing_in.Text = "Регистрация";
            button_forgot_password.Visible = false;
            button_register.Visible = false;

        }

        private void button_sing_in_Click(object sender, EventArgs e)
        {
            switch (button_sing_in.Text)
            {
                case "Регистрация":
                    SqlCommand command = new SqlCommand("INSERT INTO [Table] (User_Name, Password, Balance, Limon, Limon - auto, News, News - auto, Car, Car - auto, Pizza, Pizza - auto, Ponchik, Ponchik - auto)VALUES(@User_Name, @Password, @Balance, @Limon, @Limon - auto, @News, @News - auto, @Car, @Car - auto, @Pizza, @Pizza - auto, @Ponchik, @Ponchik - auto)", sqlConnection);
                    command.Parameters.AddWithValue("User_Name", TextBox_login.Text);
                    command.Parameters.AddWithValue("Password", TextBox_password.Text);

                    break;

                case "Войти":

                    break;
            }
        }
    }
}
