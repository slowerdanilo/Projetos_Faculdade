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
    public partial class frmQuartos : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        string strSQL, botao;
        int c, d;
        public static string hospedeSelecionado;

        public frmQuartos()
        {
            InitializeComponent();
        }

        public void btnDisponiveis_Click(object sender, EventArgs e)
        {
            liberarQuartoToolStripMenuItem.Enabled = false;
            reservarQuartoToolStripMenuItem.Enabled = true;
            botao = "Disponiveis";
            try
            {
                //c = 0 para referenciar que estamos buscando os quartos disponíveis
                SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                strSQL = "SELECT  NOME_QUARTO AS NOME_QUARTO, ID AS NUMERO_QUARTO, QUANTIDADE_COMODOS, VALOR, RESERVADO FROM QUARTO WHERE RESERVADO = 'Livre' ORDER BY VALOR";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                da.Fill(ds);

                dg2.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //conexao.Close();
                conexao = null;
            }
        }

        private void dg2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM HOSPEDES_QUARTO WHERE DATA_SAIDA IS NULL AND ID_QUARTO = '" + dg2.CurrentRow.Cells[1].Value.ToString() + "'";
            SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");
            Conexao.Open(); //Abrir conexão

            SqlDataAdapter dp = new SqlDataAdapter(query, Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Quarto já reservado. Por favor, escolha outro.");
            }
            else
            {
                const string mensagem = "Tem certeza que deseja reservar esse quarto?";
                const string caption = "Reservar quarto";
                var result = MessageBox.Show(mensagem, caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                        strSQL = "UPDATE QUARTO SET RESERVADO = 'Ocupado' WHERE ID = @ID";

                        comando = new SqlCommand(strSQL, conexao);

                        comando.Parameters.AddWithValue("@id", dg2.CurrentRow.Cells[1].Value.ToString());

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
                    try
                    {

                        SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                        strSQL = "INSERT INTO HOSPEDES_QUARTO (ID_QUARTO, HOSPEDE, DATA_ENTRADA) VALUES (@ID_QUARTO, @HOSPEDE, @DATA_ENTRADA)";

                        comando = new SqlCommand(strSQL, conexao);

                        comando.Parameters.AddWithValue("@ID_QUARTO", dg2.CurrentRow.Cells[1].Value.ToString());
                        comando.Parameters.AddWithValue("@HOSPEDE", hospedeSelecionado);
                        comando.Parameters.AddWithValue("@DATA_ENTRADA", DateTime.Now);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conexao = null;
                        comando = null;
                    }
                    MessageBox.Show("Quarto reservado com sucesso!");
                    btnDisponiveis_Click(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Primeiro clique no botão Disponíveis.");
                }
            }
        }

        private void frmQuartos_Shown(object sender, EventArgs e)
        {

        }

        private void dg2_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void dg2_CellClick(object sender, DataGridViewCellEventArgs e)
        {            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            liberarQuartoToolStripMenuItem.Enabled = true;
            reservarQuartoToolStripMenuItem.Enabled = false;
            botao = "Reservados";
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                strSQL = "SELECT B.ID AS ORDEM, A.ID AS NUMERO_QUARTO, B.HOSPEDE, A.NOME_QUARTO AS NOME_QUARTO, A.QUANTIDADE_COMODOS, A.VALOR, A.RESERVADO FROM QUARTO AS A INNER JOIN HOSPEDES_QUARTO AS B ON A.ID = B.ID_QUARTO WHERE RESERVADO = 'Ocupado' AND B.DATA_SAIDA IS NULL ORDER BY VALOR";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                da.Fill(ds);

                dg2.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //conexao.Close();
                conexao = null;
            }
        }

        private void dg2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (tentativa1 == 1)
            // {
            //if (tentativa == 1)
            //if (dt2.Rows.Count > 0)
            {
                //atualização dos dados
                const string mensagem = "Tem certeza que deseja liberar esse quarto?";
                const string caption = "Liberar quarto";
                var result = MessageBox.Show(mensagem, caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                        strSQL = "UPDATE HOSPEDES_QUARTO SET DATA_SAIDA = GETDATE() WHERE ID = " + dg2.CurrentRow.Cells[0].Value.ToString();
                        comando = new SqlCommand(strSQL, conexao);
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

                    }
                    try
                    {
                        SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                        strSQL = "UPDATE QUARTO SET RESERVADO = 'Livre' WHERE ID = " + dg2.CurrentRow.Cells[1].Value.ToString();
                        comando = new SqlCommand(strSQL, conexao);
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

                    }
                    MessageBox.Show("Quarto liberado com sucesso!");
                    button2.Visible = false;
                    btnDisponiveis_Click(this, new EventArgs());
                    //dg2_CellFormatting(this,new DataGridViewCellFormattingEventArgs();
                }
                // }
            }
        }




        private void dg2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void reservarQuartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---
            if (frmReservarQuarto.HospedeEntrada == null || frmReservarQuarto.HospedeEntrada == "")
            {
                MessageBox.Show("Primeiro clique na linha que deseja alterar.");
            }
            else
            {
                frmReservarQuarto reserva = new frmReservarQuarto();
                reserva.Show();
            }
        }

        private void liberarQuartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---            
            if (frmLiberarQuarto.nomeQuarto == null || frmLiberarQuarto.nomeQuarto == "")
            {
                MessageBox.Show("Primeiro clique na linha que deseja alterar.");
            }
            else
            {
                frmLiberarQuarto liberar = new frmLiberarQuarto();
                liberar.Show();
            }

        }

        private void dg2_Click(object sender, EventArgs e)
        {
            if (botao == "Reservados")
            {
                frmLiberarQuarto.nomeQuarto = dg2.CurrentRow.Cells[3].Value.ToString();
                frmLiberarQuarto.Id1 = dg2.CurrentRow.Cells[1].Value.ToString();                           
            }
            if (botao == "Disponiveis")
            {
                frmReservarQuarto.HospedeEntrada = dg2.CurrentRow.Cells[2].Value.ToString();
                frmReservarQuarto.idQuarto       = dg2.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatorio relatorio = new frmRelatorio();
            this.Hide();
            relatorio.Show();
        }
    }

}