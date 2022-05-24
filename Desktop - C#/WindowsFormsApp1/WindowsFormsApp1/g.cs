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
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class frmCadastro : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        DateTime d;
        public static string idHospede, result;
        public static int alterar, vRetorno;
        public static string nome;
        public static string sobrenome;
        public static string datanasc;
        public static string sexo;
        public static string rg;
        public static string celular;
        public static string cpf;
        public static string email;
        public static string endereco;
        public static string numero;
        public static string cidade;
        public static string cep;
        public static string uf;
        public static string pais;
        public static string TextoDoBotao;
        string strSQL;

    public frmCadastro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        public void validaBotoes(int vRetorno)
        {
            if (txtNome.Text     == ""
            || txtSobrenome.Text == ""
            || txtCelular.Text   == ""
            || txtCEP.Text       == ""
            || txtCidade.Text    == ""
            || txtEmail.Text     == ""
            || txtEndereco.Text  == ""
            || txtNumero.Text    == ""
            || txtPais.Text      == ""
            || txtRG.Text        == ""
            || txtSexo.Text      == ""
            || txtUF.Text        == ""
            || txtCPF.Text       == "")
            {
                frmCadastro.vRetorno = 1;                
            }
            else
            {
                frmCadastro.vRetorno = 0;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            validaBotoes(vRetorno);
            if (vRetorno == 1)
            {
                MessageBox.Show("Foi detectado campo(s) em braco. Por favor, preencha para continuar.");
            }
            else
            {
                //atualização dos dados
                if (alterar == 1)
                {
                    const string mensagem = "Tem certeza que deseja atualizar os dados?";
                    const string caption = "Atualizar dados";
                    var result = MessageBox.Show(mensagem, caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                            strSQL = "UPDATE HOSPEDE SET nome = @nome, sobrenome = @sobrenome, datanasc = @datanasc, sexo = @sexo, rg = @rg, celular = @celular, cpf = @cpf, email = @email, endereco = @endereco, numero = @numero, cidade = @cidade, cep = @cep, uf = @uf, pais = @pais where id = @id";

                            comando = new SqlCommand(strSQL, conexao);

                            comando.Parameters.AddWithValue("@nome", txtNome.Text);
                            comando.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
                            comando.Parameters.AddWithValue("@datanasc", dateTimePicker1.Text);
                            comando.Parameters.AddWithValue("@sexo", txtSexo.Text);
                            comando.Parameters.AddWithValue("@rg", txtRG.Text);
                            comando.Parameters.AddWithValue("@celular", txtCelular.Text);
                            comando.Parameters.AddWithValue("@cpf", txtCPF.Text);
                            comando.Parameters.AddWithValue("@email", txtEmail.Text);
                            comando.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                            comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                            comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                            comando.Parameters.AddWithValue("@cep", txtCEP.Text);
                            comando.Parameters.AddWithValue("@uf", txtUF.Text);
                            comando.Parameters.AddWithValue("@pais", txtPais.Text);
                            comando.Parameters.AddWithValue("@id", idHospede);

                            conexao.Open();
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            //fechar conexão
                            conexao = null;
                            comando = null;
                        }
                        MessageBox.Show("Registros atualizados com sucesso!");
                        txtNome.Clear();
                        txtSobrenome.Clear();
                        txtCelular.Clear();
                        txtCEP.Clear();
                        txtCidade.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtNumero.Clear();
                        txtPais.Clear();
                        txtRG.Clear();
                        txtSexo.Text = "";
                        txtUF.Clear();
                        txtCPF.Clear();
                        alterar = 0;
                    }
                }
                else
                {
                    const string mensagem = "Tem certeza que cadastrar esse hospede?";
                    const string caption = "Inserção de dados";
                    var result = MessageBox.Show(mensagem, caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //inserir dados
                        try
                        {

                            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                            strSQL = "INSERT INTO Hospede (nome, sobrenome, datanasc, sexo, rg, celular, cpf, email, endereco, numero, cidade, cep, uf, pais, horario_inclusao) VALUES (@nome, @sobrenome, @datanasc, @sexo, @rg, @celular, @cpf, @email, @endereco, @numero, @cidade, @cep, @uf, @pais, getdate())";

                            comando = new SqlCommand(strSQL, conexao);

                            comando.Parameters.AddWithValue("@nome", txtNome.Text);
                            comando.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
                            comando.Parameters.AddWithValue("@datanasc", dateTimePicker1.Text);
                            comando.Parameters.AddWithValue("@sexo", txtSexo.Text);
                            comando.Parameters.AddWithValue("@rg", txtRG.Text);
                            comando.Parameters.AddWithValue("@celular", txtCelular.Text);
                            comando.Parameters.AddWithValue("@cpf", txtCPF.Text);
                            comando.Parameters.AddWithValue("@email", txtEmail.Text);
                            comando.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                            comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                            comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                            comando.Parameters.AddWithValue("@cep", txtCEP.Text);
                            comando.Parameters.AddWithValue("@uf", txtUF.Text);
                            comando.Parameters.AddWithValue("@pais", txtPais.Text);

                            conexao.Open();
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            //conexao.Close();
                            MessageBox.Show("Hospede " + txtNome.Text +" cadastrado com sucesso");
                            txtNome.Clear();
                            txtSobrenome.Clear();
                            txtCelular.Clear();
                            txtCEP.Clear();
                            txtCidade.Clear();
                            txtEmail.Clear();
                            txtEndereco.Clear();
                            txtNumero.Clear();
                            txtPais.Clear();
                            txtRG.Clear();
                            txtSexo.Text = "";
                            txtUF.Clear();
                            txtCPF.Clear();
                            alterar = 0;
                            conexao = null;
                            comando = null;
                        }
                    }
                } 
            }
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            if (alterar == 1)
            {
                //MessageBox.Show("Vamos editar");
                txtNome.Text = nome;
                txtSobrenome.Text = sobrenome;
                txtCelular.Text = celular;
                txtCEP.Text = cep;
                txtCidade.Text = cidade;
                txtEmail.Text = email;
                txtEndereco.Text = endereco;
                txtNumero.Text = numero;
                txtPais.Text = pais;
                txtRG.Text = rg;
                txtSexo.Text = sexo;
                txtUF.Text = uf;
                txtCPF.Text = cpf;
                //dateTimePicker1 = DateTime.Parse(datanasc.ToString("yyyy/MM/dd"));
                dateTimePicker1.Text = Convert.ToDateTime(datanasc).ToString("yyyy-MM-dd HH:mm:ss");                
            }
        }

        private void frmCadastro_Shown(object sender, EventArgs e)
        {
            btnSalvar.Text = TextoDoBotao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtSobrenome.Clear();
            txtCelular.Clear();
            txtCEP.Clear();
            txtCidade.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtPais.Clear();
            txtRG.Clear();
            txtSexo.Text = "";
            txtUF.Clear();
            txtCPF.Clear();
            alterar = 0;
            FrmPrincipal principal = new FrmPrincipal();
            this.Hide();
            principal.Show();
        }

        private void frmCadastro_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
