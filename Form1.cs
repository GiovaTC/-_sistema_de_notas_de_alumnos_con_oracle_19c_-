namespace NotasOracleWinForms
{
    public partial class Form1 : Form
    {
        ConexionOracle conexion = new ConexionOracle();
        public Form1()
        {
            InitializeComponent();
        }
        /*
        private void Form1_Load(object sender, EventArgs e)
        {

        }*/

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal n1 = decimal.Parse(txtNota1.Text);
            decimal n2 = decimal.Parse(txtNota2.Text);
            decimal n3 = decimal.Parse(txtNota3.Text);
            decimal n4 = decimal.Parse(txtNota4.Text);
            decimal n5 = decimal.Parse(txtNota5.Text);

            decimal suma = n1 + n2 + n3 + n4 + n5;

            decimal promedio = suma / 5;

            txtSuma.Text = suma.ToString();
            txtPromedio.Text = promedio.ToString("0.00");
        }
        /*
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }*/
    }
}
