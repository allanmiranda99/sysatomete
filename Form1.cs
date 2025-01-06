using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; // Biblioteca para usar SQLite

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Caminho do banco de dados (no mesmo diretório do executável)
            string caminhoBanco = "usuarios.db";

            // Verifica se o banco já existe
            if (!System.IO.File.Exists(caminhoBanco))
            {
                // Cria o arquivo do banco de dados
                SQLiteConnection.CreateFile(caminhoBanco);

                // Exibe a mensagem apenas quando o banco é criado pela primeira vez
                MessageBox.Show("Banco de dados criado com sucesso!");
            }

            // Conexão e criação da tabela
            string connectionString = "Data Source=usuarios.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Criação da tabela de usuários
                string sql = @"
            CREATE TABLE IF NOT EXISTS Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Usuario TEXT NOT NULL,
                Senha TEXT NOT NULL
            );

            -- Inserir um usuário padrão
            INSERT INTO Usuarios (Usuario, Senha)
            SELECT 'admin', '1234'
            WHERE NOT EXISTS (SELECT 1 FROM Usuarios);
        ";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }


        private void Login_Click(object sender, EventArgs e)
        {
            // Pegue os valores digitados nos campos de texto
            string usuario = guna2TextBox1.Text; // Atualize caso seus campos tenham outro nome
            string senha = guna2TextBox2.Text;

            // Verifique se os campos não estão vazios
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha os campos de usuário e senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Conexão com o banco de dados
            string connectionString = "Data Source=usuarios.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Comando SQL para verificar se o usuário e senha existem
                string sql = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Senha = @Senha";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    // Adicione os parâmetros para evitar SQL Injection
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Senha", senha);

                    // Execute a consulta
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        // Abra o próximo formulário
                        Form2 form2 = new Form2(); // Supondo que você tenha um Form2 criado
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Login falhou
                        MessageBox.Show("Usuário ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                connection.Close();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Lógica para o campo de texto do usuário (se necessário)
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            // Lógica para o campo de texto da senha (se necessário)
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Verifica se a tecla pressionada é Enter
            {
                Login.PerformClick(); // Aciona o clique do botão de login
                e.SuppressKeyPress = true; // Impede que o som de "beep" ocorra ao pressionar Enter
            }
        }
    }
    
}
