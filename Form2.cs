using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        bool sidebarExpand;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Implementação futura
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Configura a largura inicial da sidebar para o tamanho mínimo
            sidebar.Width = sidebar.MinimumSize.Width;
            sidebarExpand = false;
        }


        private void picToggleMenu_Click(object sender, EventArgs e)
        {
            // Alterna a variável sidebarExpand e inicia o timer para expandir ou minimizar a barra lateral
            sidebarExpand = !sidebarExpand;  // Alterna entre expandir e minimizar
            sidebarTimer.Start();  // Inicia o timer para animação
        }


        private void picToggleMenu_Click_1(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            // Se a barra lateral for expandir, minimizar
            if (sidebarExpand)
            {
                sidebar.Width += 10;  // Aumenta a largura da barra lateral
                                      // Verifica se atingiu o tamanho máximo
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebarExpand = false;  // Muda o estado para minimizar
                    sidebarTimer.Stop();  // Para o timer
                }
            }
            else
            {
                sidebar.Width -= 10;  // Diminui a largura da barra lateral
                                      // Verifica se atingiu o tamanho mínimo
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebarExpand = true;  // Muda o estado para expandir
                    sidebarTimer.Stop();  // Para o timer
                }
            }
        }


        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Instanciar o Form3
            Form3 form3 = new Form3();

            // Mostrar o Form3
            form3.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Instanciar o Form4
            Form4 form4 = new Form4();

            // Mostrar o Form4
            form4.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // Instanciar o FaleConosco
            FaleConosco FaleConosco = new FaleConosco();

            // Mostrar o FaleConosco
            FaleConosco.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            // Instanciar o Download
            Download Download = new Download();

            // Mostrar o Download
            Download.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Exibe uma mensagem perguntando se o usuário tem certeza de que quer sair
            DialogResult result = MessageBox.Show("Você tem certeza que quer sair?", "Confirmar Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica a resposta do usuário
            if (result == DialogResult.Yes)
            {
                Form1 form1 = new Form1();  // Cria uma nova instância do Form1
                form1.Show();  // Exibe o Form1 (tela de login)
                this.Hide();  // Esconde o formulário atual (o formulário que está sendo fechado)
            }
            else
            {
                // Caso o usuário não confirme, não faz nada, o formulário permanece aberto
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // Instanciar o Teste
            Teste Teste = new Teste();

            // Mostrar o Teste
            Teste.Show();
        }
    }
}