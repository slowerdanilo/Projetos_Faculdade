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
    public partial class frmLiberarQuarto : Form
    {
        //---
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        DateTime d;
        string strSQL;
        //---

        public static string Id1, Id2, nomeQuarto;
        public frmLiberarQuarto()
        {
            InitializeComponent();
        }

        private void frmLiberarQuarto_Shown(object sender, EventArgs e)
        {
            lblNomeQuarto.Text = nomeQuarto;
            lblNumeroQuarto.Text = Id1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //---
            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");
            conexao.Open(); //Abrir conexão
            string query = "SELECT * FROM QUARTO WHERE RESERVADO = 'Livre' AND ID = " + lblNumeroQuarto.Text;
            SqlDataAdapter dp = new SqlDataAdapter(query, conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                try
                {
                    SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");
                    strSQL = "UPDATE HOSPEDES_QUARTO SET DATA_SAIDA = GETDATE() WHERE ID_QUARTO = " + lblNumeroQuarto.Text;
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
                    conexao = null;
                }
                //MessageBox.Show("Teste com sucesso!");

                //-------------------------------------------------------------


                try
                {

                    SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                    strSQL = "UPDATE QUARTO SET RESERVADO = 'Livre' WHERE ID = " + lblNumeroQuarto.Text;

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
                    //conexao.Close()
                    MessageBox.Show("Quarto liberado com sucesso. Volte para o menu anterior e clique no botão 'Reservados'.");

                    conexao = null;
                    conexao = null;
                }
            }
            else
            {
                MessageBox.Show("Quarto já liberado");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }





        //==


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLiberarQuarto_Load(object sender, EventArgs e)
        {

        }
    }
}
