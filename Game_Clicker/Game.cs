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
        public int id;
        public static int Limonauto = 0;
        public static int Newsauto = 0;
        public static int Carauto = 0;
        public static int Pizzaauto = 0;
        public static int Ponchikauto = 0;

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

            if (Limonauto == 1)
            {
                timer3.Enabled = true;
                button_lim.Enabled = false;
            }
            else
            {
                button_lim.Enabled = true;
            }

            if (Newsauto == 1)
            {
                timer4.Enabled = true;
                button_nw.Enabled = false;
            }
            else
            {
                button_nw.Enabled = true;
            }

            if (Carauto == 1)
            {
                timer5.Enabled = true;
                button_cr.Enabled = false;
            }
            else
            {
                button_cr.Enabled = true;
            }

            if (Pizzaauto == 1)
            {
                timer6.Enabled = true;
                button_pz.Enabled = false;
            }
            else
            {
                button_pz.Enabled = true;
            }

            if (Ponchikauto == 1)
            {
                timer7.Enabled = true;
                button_pch.Enabled = false;
            }
            else
            {
                button_pch.Enabled = true;
            }
        }

        // иконки преметов

        // кнопка с картинкой лимона
        private void picture_limon_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true; 
        }

        // кнопка с картинкой газеты
        private void picture_news_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true;
        }

        // кнопка с картинкой машины
        private void picture_car_Click(object sender, EventArgs e)
        {
            timer5.Enabled = true;
        }

        // кнопка с картинкой пиццы
        private void picture_pizza_Click(object sender, EventArgs e)
        {
            timer6.Enabled = true;
        }

        // кнопка с картинкой пончика
        private void picture_ponchik_Click(object sender, EventArgs e)
        {
            timer7.Enabled = true;
        }


        // кнопки увеличения цены


        // кнопка покупки увеличения цены лимона
        private void button_limon_Click(object sender, EventArgs e)
        {
            if(balance - Convert.ToInt32(limon_price.Text) >= 0)
            {
                balance -= Convert.ToInt32(limon_price.Text);
                limon_price_progress.Text = Convert.ToString(Convert.ToInt32(limon_price_progress.Text) + 2);
                Balance();
            }
                
        }

        // кнопка покупки увеличения цены газеты
        private void button_news_Click(object sender, EventArgs e)
        {
            if (balance - Convert.ToInt32(news_price.Text) >= 0) 
            { 
                balance -= Convert.ToInt32(news_price.Text);
                news_price_progress.Text = Convert.ToString(Convert.ToInt32(news_price_progress.Text) + 15);
                Balance();
            }
        }

        // кнопка покупки увеличения цены машины
        private void button_car_Click(object sender, EventArgs e)
        {
            if (balance - Convert.ToInt32(car_price.Text) >= 0)
            {
                balance -= Convert.ToInt32(car_price.Text);
                car_price_progress.Text = Convert.ToString(Convert.ToInt32(car_price_progress.Text) + 65);
                Balance();
            }
        }

        // кнопка покупки увеличения цены пиццы
        private void button_pizza_Click(object sender, EventArgs e)
        {
            if (balance - Convert.ToInt32(pizza_price.Text) >= 0)
            {
                balance -= Convert.ToInt32(pizza_price.Text);
                pizza_price_progress.Text = Convert.ToString(Convert.ToInt32(pizza_price_progress.Text) + 150);
                Balance();
            }
        }

        // кнопка покупки увеличения цены пончика
        private void button_ponchik_Click(object sender, EventArgs e)
        {
            if (balance - Convert.ToInt32(ponchik_price.Text) >= 0)
            {
                balance -= Convert.ToInt32(ponchik_price.Text);
                ponchik_price_progress.Text = Convert.ToString(Convert.ToInt32(ponchik_price_progress.Text) + 1005);
                Balance();
            }
        }


        // кнопки игровой формы (снизу)


        // кнопка выхода из аккаунта
        private void button_leave_account_Click(object sender, EventArgs e)
        {
            panel_sing_in.Visible = true;
            timer2.Enabled = false;
            progress_limon_small.Value = 0;
            progress_news_small.Value = 0;
            progress_car_small.Value = 0;
            progress_pizza_small.Value = 0;
            progress_ponchik_small.Value = 0;

            picture_car.Enabled = false;
            button_car.Visible = false;
            car_price.Visible = false;
            car_price_progress.Visible = false;
            progress_car_big.Visible = false;

            picture_news.Enabled = false;
            button_news.Visible = false;
            news_price.Visible = false;
            news_price_progress.Visible = false;
            progress_news_big.Visible = false;

            picture_pizza.Enabled = false;
            button_pizza.Visible = false;
            pizza_price.Visible = false;
            pizza_price_progress.Visible = false;
            progress_pizza_big.Visible = false;

            picture_ponchik.Enabled = false;
            button_ponchik.Visible = false;
            ponchik_price.Visible = false;
            ponchik_price_progress.Visible = false;
            progress_ponchik_big.Visible = false;

            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;

            TextBox_login.Text = "";
            TextBox_password.Text = "";
        }

        // кнопка закрытия игры
        private void button_exit_game_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // кнопки игровой формы (сверху)


        // кнопка с улучшениями
        private void button_upgrade_Click(object sender, EventArgs e)
        {
            panel_upgrade.Visible = true;            
        }

        // кнопка с рекордами
        private void button_table_rec_Click(object sender, EventArgs e)
        {
            List<string[]> people = new List<string[]>();

            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                people.Add(new string[] { Convert.ToString(dataGridView1[1, j].Value).Replace(" ", ""), dataGridView1[3, j].Value.ToString() });
            }
            YearComparer yc = new YearComparer();
            people.Sort(yc);
            string result = "";
            for(int i = 1; i < 11; i++)
            {
                foreach (string[] item in people)
                {
                    if (i < 11)
                    {
                        result += i+". "+item[0] + " " + item[1]+"\n";
                        i++;
                    }                    
                }
                i = 11;
            }
            
            Records records = new Records();
            records.Input(result);
            records.Show();
        }

        // сортировка массива рекордов
        class YearComparer : IComparer<string[]>
        {
            public int Compare(string[] o1, string[] o2)
            {
                int a = Convert.ToInt32(o1[1]);
                int b = Convert.ToInt32(o2[1]);

                if (a < b)
                {
                    return 1;
                }
                else if (a > b)
                {
                    return -1;
                }

                return 0;
            }
        }


        // база данных 


        // подключение к базе данных при загрузке формы
        private void Game_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\Desktop\Game_Clicker\Game_Clicker\Database.mdf;Integrated Security=True");
            sqlConnection.Open();
            LoadData();
        }

        // загрузка бд
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

        // перезагрузка бд
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



        // кнопки регистрационного меню


        // кнопка регистрации аккаунта
        private void button_register_Click(object sender, EventArgs e)
        {
            switch (button_register.Text)
            {
                case "Регистрация":
                    label_sing_in.Text = "Регистрация аккаунта";
                    button_sing_in.Text = "Зарегистрироваться";
                    button_register.Text = "Назад";
                    break;
                case "Назад":
                    label_sing_in.Text = "Вход в аккаунт";
                    button_sing_in.Text = "Войти";
                    button_register.Text = "Регистрация";
                    break;
            }
            
        }

        // кнопка входа в аккаунт
        private async void button_sing_in_Click(object sender, EventArgs e)
        {
            if (TextBox_login.Text == "" || TextBox_password.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                switch (button_sing_in.Text)
                {
                    case "Регистрация":
                        bool success = true;
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            if (TextBox_login.Text == Convert.ToString(dataGridView1[1, j].Value).Replace(" ", ""))
                            {
                                success = false;
                            }
                        }
                        if (success == true)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO [Table] (User_Name, Password, Balance, Limon, Limonauto, News, Newsauto, Car, Carauto, Pizza, Pizzaauto, Ponchik, Ponchikauto)VALUES(@User_Name, @Password, @Balance, @Limon, @Limonauto, @News, @Newsauto, @Car, @Carauto, @Pizza, @Pizzaauto, @Ponchik, @Ponchikauto)", sqlConnection);
                            command.Parameters.AddWithValue("User_Name", TextBox_login.Text);
                            command.Parameters.AddWithValue("Password", TextBox_password.Text);
                            command.Parameters.AddWithValue("Balance", 0);
                            command.Parameters.AddWithValue("Limon", 5);
                            command.Parameters.AddWithValue("Limonauto", 0);
                            command.Parameters.AddWithValue("News", 44);
                            command.Parameters.AddWithValue("Newsauto", 0);
                            command.Parameters.AddWithValue("Car", 750);
                            command.Parameters.AddWithValue("Carauto", 0);
                            command.Parameters.AddWithValue("Pizza", 2800);
                            command.Parameters.AddWithValue("Pizzaauto", 0);
                            command.Parameters.AddWithValue("Ponchik", 44500);
                            command.Parameters.AddWithValue("Ponchikauto", 0);
                            await command.ExecuteNonQueryAsync();
                            ReloadData();
                            TextBox_login.Text = "";
                            TextBox_password.Text = "";
                            label_hello.Text = "Регистрация прошла успешно!";
                            label_sing_in.Text = "Вход в аккаунт";
                            button_sing_in.Text = "Войти";
                            button_register.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Этот логин уже занят");
                        }
                        break;

                    case "Войти":
                        bool go = false;
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.RowCount; j++)
                            {
                                if (Convert.ToString(dataGridView1[i, j].Value).Replace(" ", "") == TextBox_login.Text && Convert.ToString(dataGridView1[i + 1, j].Value).Replace(" ", "") == TextBox_password.Text)
                                {
                                    id = Convert.ToInt32(dataGridView1[i - 1, j].Value);
                                    user_name.Text = TextBox_login.Text;
                                    label_balance.Text = Convert.ToString(dataGridView1[i + 2, j].Value).Replace(" ", "");
                                    balance = Convert.ToInt32(label_balance.Text);
                                    limon_price_progress.Text = Convert.ToString(dataGridView1[i + 3, j].Value).Replace(" ", "");
                                    Limonauto = Convert.ToInt32(dataGridView1[i + 4, j].Value);
                                    news_price_progress.Text = Convert.ToString(dataGridView1[i + 5, j].Value).Replace(" ", "");
                                    if (Convert.ToInt32(news_price_progress.Text) != 44)
                                    {
                                        picture_news.Enabled = true;
                                        button_news.Visible = true;
                                        news_price.Visible = true;
                                        news_price_progress.Visible = true;
                                        progress_news_big.Visible = true;
                                    }
                                    Newsauto = Convert.ToInt32(dataGridView1[i + 6, j].Value);
                                    car_price_progress.Text = Convert.ToString(dataGridView1[i + 7, j].Value).Replace(" ", "");
                                    if (Convert.ToInt32(car_price_progress.Text) != 750)
                                    {
                                        picture_car.Enabled = true;
                                        button_car.Visible = true;
                                        car_price.Visible = true;
                                        car_price_progress.Visible = true;
                                        progress_car_big.Visible = true;
                                    }
                                    Carauto = Convert.ToInt32(dataGridView1[i + 8, j].Value);
                                    pizza_price_progress.Text = Convert.ToString(dataGridView1[i + 9, j].Value).Replace(" ", "");
                                    if (Convert.ToInt32(pizza_price_progress.Text) != 2800)
                                    {
                                        picture_pizza.Enabled = true;
                                        button_pizza.Visible = true;
                                        pizza_price.Visible = true;
                                        pizza_price_progress.Visible = true;
                                        progress_pizza_big.Visible = true;
                                    }
                                    Pizzaauto = Convert.ToInt32(dataGridView1[i + 10, j].Value);
                                    ponchik_price_progress.Text = Convert.ToString(dataGridView1[i + 11, j].Value).Replace(" ", "");
                                    if (Convert.ToInt32(ponchik_price_progress.Text) != 44500)
                                    {
                                        picture_ponchik.Enabled = true;
                                        button_ponchik.Visible = true;
                                        ponchik_price.Visible = true;
                                        ponchik_price_progress.Visible = true;
                                        progress_ponchik_big.Visible = true;
                                    }
                                    Ponchikauto = Convert.ToInt32(dataGridView1[i + 12, j].Value);
                                    panel_sing_in.Visible = false;
                                    progress_car_big.Value = 0;
                                    progress_limon_big.Value = 0;
                                    progress_news_big.Value = 0;
                                    progress_pizza_big.Value = 0;
                                    progress_ponchik_big.Value = 0;
                                    progress_car_small.Value = 0;
                                    progress_limon_small.Value = 0;
                                    progress_news_small.Value = 0;
                                    progress_pizza_small.Value = 0;
                                    progress_ponchik_small.Value = 0;
                                    Balance();
                                    timer2.Enabled = true;
                                    go = true;
                                }                                    
                            }
                        }                        
                        label_hello.Text = "Доброго времени суток!";
                        if(go == false)
                        {
                            MessageBox.Show("Неверный логин или пароль");
                        }
                        break;
                }
            }
        }


        // таймеры

        // таймер, отвечающий за загрузку вначале
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

        // таймер, отвечающий за обновление базы раз в секунду
        private async void timer2_Tick(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE [Table] SET Balance=@Balance, Limon=@Limon, Limonauto=@Limonauto, News=@News, Newsauto=@Newsauto, Car=@Car, Carauto=@Carauto, Pizza=@Pizza, Pizzaauto=@Pizzaauto, Ponchik=@Ponchik, Ponchikauto=@Ponchikauto WHERE User_Name=@User_Name", sqlConnection);
            command.Parameters.AddWithValue("@User_Name", user_name.Text);
            command.Parameters.AddWithValue("@Balance", label_balance.Text);
            command.Parameters.AddWithValue("@Limon", limon_price_progress.Text);
            command.Parameters.AddWithValue("@Limonauto", Limonauto);
            command.Parameters.AddWithValue("@News", news_price_progress.Text);
            command.Parameters.AddWithValue("@Newsauto", Newsauto);
            command.Parameters.AddWithValue("@Car", car_price_progress.Text);
            command.Parameters.AddWithValue("@Carauto", Carauto);
            command.Parameters.AddWithValue("@Pizza", pizza_price_progress.Text);
            command.Parameters.AddWithValue("@Pizzaauto", Pizzaauto);
            command.Parameters.AddWithValue("@Ponchik", ponchik_price_progress.Text);
            command.Parameters.AddWithValue("@Ponchikauto", Ponchikauto);
            await command.ExecuteNonQueryAsync();
            ReloadData();
        }

        // таймер - клик на лимон 
        private void timer3_Tick(object sender, EventArgs e)
        {
            progress_limon_big.Value += 10;

            if(progress_limon_big.Value == 100 && Limonauto == 1)
            {
                progress_limon_small.Value += 10;
                balance += Convert.ToInt32(limon_price_progress.Text);
                progress_limon_big.Value = 0;
                Balance();
            }

            if (progress_limon_big.Value == 100 && Limonauto == 0)
            {
                progress_limon_small.Value += 10;
                balance += Convert.ToInt32(limon_price_progress.Text);
                progress_limon_big.Value = 0;
                Balance();
                timer3.Enabled = false;
            }

            if (progress_limon_small.Value == 100)
            {
                progress_limon_small.Value = 0;
                limon_price_progress.Text = Convert.ToString(Convert.ToInt32(limon_price_progress.Text) + 10);
            }
        }

        // таймер - клик на газету 
        private void timer4_Tick(object sender, EventArgs e)
        {
            progress_news_big.Value += 10;

            if (progress_news_big.Value == 100 && Newsauto == 1)
            {
                progress_news_small.Value += 10;
                balance += Convert.ToInt32(news_price_progress.Text);
                progress_news_big.Value = 0;
                Balance();
            }

            if (progress_news_big.Value == 100 && Newsauto == 0)
            {
                progress_news_small.Value += 10;
                balance += Convert.ToInt32(news_price_progress.Text);
                progress_news_big.Value = 0;
                Balance();
                timer4.Enabled = false;
            }

            if (progress_news_small.Value == 100)
            {
                progress_news_small.Value = 0;
                news_price_progress.Text = Convert.ToString(Convert.ToInt32(news_price_progress.Text) + 10);
            }
        }

        // таймер - клик на машину
        private void timer5_Tick(object sender, EventArgs e)
        {
            progress_car_big.Value += 10;

            if (progress_car_big.Value == 100 && Carauto == 1)
            {
                progress_car_small.Value += 10;
                balance += Convert.ToInt32(car_price_progress.Text);
                progress_car_big.Value = 0;
                Balance();
            }

            if (progress_car_big.Value == 100 && Carauto == 0)
            {
                progress_car_small.Value += 10;
                balance += Convert.ToInt32(car_price_progress.Text);
                progress_car_big.Value = 0;
                Balance();
                timer5.Enabled = false;
            }


            if (progress_car_small.Value == 100)
            {
                progress_car_small.Value = 0;
                car_price_progress.Text = Convert.ToString(Convert.ToInt32(pizza_price_progress.Text) + 10);
            }
        }

        // таймер - клик на пиццу
        private void timer6_Tick(object sender, EventArgs e)
        {
            progress_pizza_big.Value += 10;

            if (progress_pizza_big.Value == 100 && Pizzaauto == 1)
            {
                progress_pizza_small.Value += 10;
                balance += Convert.ToInt32(pizza_price_progress.Text);
                progress_pizza_big.Value = 0;
                Balance();
            }

            if (progress_pizza_big.Value == 100 && Pizzaauto == 0)
            {
                progress_pizza_small.Value += 10;
                balance += Convert.ToInt32(pizza_price_progress.Text);
                progress_pizza_big.Value = 0;
                Balance();
                timer6.Enabled = false;
            }

            if (progress_pizza_small.Value == 100)
            {
                progress_pizza_small.Value = 0;
                pizza_price_progress.Text = Convert.ToString(Convert.ToInt32(pizza_price_progress.Text) + 10);
            }
        }

        // таймер - клик на пончик
        private void timer7_Tick(object sender, EventArgs e)
        {
            progress_ponchik_big.Value += 10;

            if (progress_ponchik_big.Value == 100 && Ponchikauto == 1)
            {
                progress_ponchik_small.Value += 10;
                balance += Convert.ToInt32(ponchik_price_progress.Text);
                progress_ponchik_big.Value = 0;
                Balance();
            }

            if (progress_ponchik_big.Value == 100 && Ponchikauto == 0)
            {
                progress_ponchik_small.Value += 10;
                balance += Convert.ToInt32(ponchik_price_progress.Text);
                progress_ponchik_big.Value = 0;
                Balance();
                timer6.Enabled = false;
            }

            if (progress_ponchik_small.Value == 100)
            {
                progress_ponchik_small.Value = 0;
                ponchik_price_progress.Text = Convert.ToString(Convert.ToInt32(ponchik_price_progress.Text) + 10);
            }
        }


        // кнопки поля улучшений

        private void button_lim_Click(object sender, EventArgs e)
        {
            if (balance - 10000 >= 0)
            {
                balance -= 10000;
                Limonauto = 1;
                button_lim.Enabled = false;
                Balance();
            }
            else
            {
                MessageBox.Show("Недостаточно средств");
            }
        }

        private void button_nw_Click(object sender, EventArgs e)
        {
            if (balance - 20000 >= 0)
            {
                balance -= 20000;
                Newsauto = 1;
                button_nw.Enabled = false;
                Balance();
            }
            else
            {
                MessageBox.Show("Недостаточно средств");
            }
        }

        private void button_cr_Click(object sender, EventArgs e)
        {
            if (balance - 50000 >= 0)
            {
                balance -= 50000;
                Carauto = 1;
                button_cr.Enabled = false;
                Balance();
            }
            else
            {
                MessageBox.Show("Недостаточно средств");
            }            
        }

        private void button_pz_Click(object sender, EventArgs e)
        {
            if (balance - 150000 >= 0)
            {
                balance -= 150000;
                Pizzaauto = 1;
                button_pz.Enabled = false;
                Balance();
            }
            else
            {
                MessageBox.Show("Недостаточно средств");
            }
        }

        private void button_pch_Click(object sender, EventArgs e)
        {
            if (balance - 1000000 >= 0)
            {
                balance -= 1000000;
                Ponchikauto = 1;
                button_pch.Enabled = false;
                Balance();
            }
            else
            {
                MessageBox.Show("Недостаточно средств");
            }
        }

        private void button_bck_Click(object sender, EventArgs e)
        {
            panel_upgrade.Visible = false;
        }
    }
}
