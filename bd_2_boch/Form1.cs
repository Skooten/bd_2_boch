using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bd_2_boch
{
    public partial class Form1 : Form
    {
        Class1 database = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string querystring = "INSERT INTO register (login_user, password_user) VALUES (@login, @password)";

            using (SqlCommand command = new SqlCommand(querystring, database.GetConnection()))
            {
                // Параметризованный запрос
                command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;

                try
                {
                    // Открытие соединения
                    database.openConnection();

                    // Выполнение запроса
                    int rowsAffected = command.ExecuteNonQuery();

                    // Проверка, был ли добавлен аккаунт
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                        Form2 frm_login = new Form2(); // Открытие формы
                        this.Hide();
                        frm_login.ShowDialog(); // Показываем форму как диалог
                        this.Show(); // Показываем текущую форму после закрытия диалога
                    }
                    else
                    {
                        MessageBox.Show("Аккаунт не создан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Закрытие соединения
                    database.closeConnection();
                }
            }
        }
    }
}