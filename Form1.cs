using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace NotasOracleWinForms
{
    public partial class Form1 : Form
    {
        private readonly ConexionOracle conexion =
            new ConexionOracle();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VerificarConexionAsync();
        }

        private async Task VerificarConexionAsync()
        {
            try
            {
                bool conectado = await Task.Run(() =>
                    conexion.ProbarConexion());

                if (conectado)
                {
                    MessageBox.Show(
                        "Conexión Oracle establecida correctamente.",
                        "Oracle",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "No fue posible conectar con Oracle.",
                        "Oracle",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                decimal n1 = decimal.Parse(txtNota1.Text);
                decimal n2 = decimal.Parse(txtNota2.Text);
                decimal n3 = decimal.Parse(txtNota3.Text);
                decimal n4 = decimal.Parse(txtNota4.Text);
                decimal n5 = decimal.Parse(txtNota5.Text);

                decimal suma = n1 + n2 + n3 + n4 + n5;
                decimal promedio = suma / 5;

                txtSuma.Text = suma.ToString("0.00");
                txtPromedio.Text = promedio.ToString("0.00");
            }
            catch
            {
                MessageBox.Show(
                    "Ingrese valores numéricos válidos en las notas.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del alumno.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (LimiteAlumnos())
            {
                MessageBox.Show(
                    "Ya se registraron los 87 alumnos.",
                    "Límite alcanzado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    using OracleConnection cn =
                        conexion.ObtenerConexion();

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
                    VALUES
                    (
                        :nombre,
                        :n1,
                        :n2,
                        :n3,
                        :n4,
                        :n5,
                        :suma,
                        :promedio
                    )";

                    using OracleCommand cmd =
                        new OracleCommand(sql, cn);

                    cmd.Parameters.Add(":nombre",
                        txtNombre.Text.Trim());

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
                });

                MessageBox.Show(
                    "Alumno guardado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnLimpiar_Click(null, null);
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    $"Oracle Error\n\n" +
                    $"Código: {ex.Number}\n" +
                    $"Mensaje: {ex.Message}",
                    "Oracle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Error General",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await Task.Run(() =>
                {
                    using OracleConnection cn =
                        conexion.ObtenerConexion();

                    cn.Open();

                    string sql =
                        "SELECT * FROM ALUMNOS_NOTAS_J ORDER BY ID";

                    OracleDataAdapter da =
                        new OracleDataAdapter(sql, cn);

                    DataTable tabla = new DataTable();

                    da.Fill(tabla);

                    return tabla;
                });

                dgvDatos.DataSource = dt;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    $"Oracle Error\n\n" +
                    $"Código: {ex.Number}\n" +
                    $"Mensaje: {ex.Message}",
                    "Oracle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Error General",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            try
            {
                using OracleConnection cn =
                    conexion.ObtenerConexion();

                cn.Open();

                string sql =
                    "SELECT COUNT(*) FROM ALUMNOS_NOTAS_J";

                using OracleCommand cmd =
                    new OracleCommand(sql, cn);

                int cantidad =
                    Convert.ToInt32(
                        cmd.ExecuteScalar());

                return cantidad >= 87;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    $"Oracle Error\n\n" +
                    $"Código: {ex.Number}\n" +
                    $"Mensaje: {ex.Message}",
                    "Oracle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Error General",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}
