using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace NotasOracleWinForms
{
    public partial class Form1 : Form
    {
        ConexionOracle conexion = new ConexionOracle();
        public Form1()
        {
            InitializeComponent();
        }

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (LimiteAlumnos())
            {
                MessageBox.Show(
                    "Ya se registraron los 87 alumnos! ");
                return;
            }   

            try
            {
                using (OracleConnection cn =
                    conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                    INSERT INTO ALUMNOS_NOTAS_J 
                    (
                        NOMBRE, 
                        NOTA1, 
                        NOTA2, 
                        NOTA3, 
                        NOTA4, 
                        NOTA5, 
                        SUMA, 
                        PROMEDIO
                    ) 
                    VALUES (
                            :nombre, 
                            :n1, 
                            :n2, 
                            :n3, 
                            :n4, 
                            :n5, 
                            :suma, 
                            :promedio
                    )";

                    OracleCommand cmd =
                        new OracleCommand(sql, cn);

                    cmd.Parameters.Add(":nombre",
                        txtNombre.Text);

                    cmd.Parameters.Add(":n1",
                        decimal.Parse(txtNota1.Text));

                    cmd.Parameters.Add(":n2",
                        decimal.Parse(txtNota2.Text));

                    cmd.Parameters.Add(":n3",
                        decimal.Parse(txtNota3.Text));

                    cmd.Parameters.Add(":n4",
                        decimal.Parse(txtNota4.Text));

                    cmd.Parameters.Add(":n5",
                        decimal.Parse(txtNota5.Text));

                    cmd.Parameters.Add(":suma",
                        decimal.Parse(txtSuma.Text));

                    cmd.Parameters.Add(":promedio",
                        decimal.Parse(txtPromedio.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Alumno guardado correctamente! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection cn =
                       conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql =
                        "SELECT * FROM ALUMNOS_NOTAS_J";

                    OracleDataAdapter da =
                        new OracleDataAdapter(sql, cn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();

            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtNota4.Clear();
            txtNota5.Clear();

            txtSuma.Clear();
            txtPromedio.Clear();

            txtNombre.Focus();
        }

        private bool LimiteAlumnos()
        {
            using (OracleConnection cn =
                   conexion.ObtenerConexion())
            {
                cn.Open();

                string sql =
                    "SELECT COUNT(*) FROM ALUMNOS_NOTAS_J";

                OracleCommand cmd =
                    new OracleCommand(sql, cn);

                int cantidad =
                    Convert.ToInt32(cmd.ExecuteScalar());

                return cantidad >= 87;
            }
        }
    }
}
