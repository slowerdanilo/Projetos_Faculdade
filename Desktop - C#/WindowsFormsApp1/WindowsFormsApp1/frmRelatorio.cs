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
    public partial class frmRelatorio : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        DateTime d;
        string strSQL; 
        public frmRelatorio()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmQuartos quarto = new frmQuartos();
            this.Hide();
            quarto.Show();
        }

        private void frmRelatorio_Shown(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-SFIFSC4;Initial Catalog=Login;Integrated Security=True");

                strSQL = "SELECT ID AS ORDEM, ID_QUARTO AS NUMERO_QUARTO,HOSPEDE, DATA_ENTRADA AS DATA_DE_ENTRADA, DATA_SAIDA AS DATA_DE_SAIDA FROM HOSPEDES_QUARTO WHERE DATA_SAIDA IS NOT NULL ORDER BY DATA_SAIDA DESC";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                da.Fill(ds);

                dgv1.DataSource = ds.Tables[0];

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

        private void frmRelatorio_Load(object sender, EventArgs e)
        {

        }
    }
}
