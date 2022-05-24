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
    public partial class frmReservarQuarto : Form
    {
        //---
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        DateTime d;
        string strSQL;
        //---

        public static string idQuarto, HospedeEntrada;
        public frmReservarQuarto()
        {
            InitializeComponent();
        }

        private void frmReservarQuarto_Shown(object sender, EventArgs e)
        {
            lblHospede.Text = frmQuartos.hospedeSelecionado;
            lblIdQuarto.Text = idQuarto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //---
            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");
            conexao.Open(); //Abrir conexão
            string query = "SELECT * FROM QUARTO WHERE RESERVADO = 'Ocupado' AND ID = " + lblIdQuarto.Text;
            SqlDataAdapter dp = new SqlDataAdapter(query, conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt.Rows.Count == 0)
            {

                try
                {
                    SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");
                    strSQL = "UPDATE QUARTO SET RESERVADO = 'Ocupado' WHERE ID = " + lblIdQuarto.Text;
                    comando = new SqlCommand(strSQL, Conexao);

                    Conexao.Open();
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
                //MessageBox.Show("Teste com sucesso!");

                //-------------------------------------------------------------

                //inserir dados
                try
                {

                    SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                    strSQL = "INSERT INTO HOSPEDES_QUARTO (ID_QUARTO, HOSPEDE, DATA_ENTRADA) VALUES ('" + lblIdQuarto.Text + "','" + lblHospede.Text + "','" + DateTime.Now + "')";

                    comando = new SqlCommand(strSQL, Conexao);



                    Conexao.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //conexao.Close();
                    MessageBox.Show("Reserva cadastrada com sucesso!");

                    conexao = null;
                    comando = null;
                }
            }
            else
            {
                MessageBox.Show("Quarto já reservado. Vá até o menu principal e clique no botão disponíveis.");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        //==


        private void frmReservarQuarto_Load(object sender, EventArgs e)
        {

        }
    }

}
