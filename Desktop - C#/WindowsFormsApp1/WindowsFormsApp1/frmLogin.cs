using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        //Referência da conexão
        SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");
        public frmLogin()
        {
            InitializeComponent();
            txtUser.Select();
        }

        //Verificação de Textbox vazia
        void verificar()
        {
            if (txtUser.Text == "" && txtPass.Text == "")
            {
                MessageBox.Show("Preencha os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Select();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


 
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        //botão login
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void BtnCadastro_Click(object sender, EventArgs e)
        {
            frmCadastro cadastro = new frmCadastro();
            this.Hide();
            cadastro.Show();
        }

        //botão sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");
                Conexao.Open(); //Abrir conexão
                string query = "SELECT * FROM Usuario WHERE Username = '" + txtUser.Text + "' AND Password = '" + txtPass.Text + "'";
                SqlDataAdapter dp = new SqlDataAdapter(query, Conexao);
                DataTable dt = new DataTable();
                dp.Fill(dt);

                try
                {
                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Login efetuado com sucesso!");
                        FrmPrincipal principal = new FrmPrincipal();
                        this.Hide();
                        principal.Show();
                    }
                    else
                    {

                        MessageBox.Show("Usuário ou Senha inválido");
                        txtUser.SelectAll(); //foca no textBox
                        txtUser.Focus();
                    }
                }
                catch
                {
                    //nada
                }
                Conexao.Close(); //Fechar conexão          
            }
        }
    }
}
