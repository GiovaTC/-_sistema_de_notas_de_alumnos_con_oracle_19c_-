using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace NotasOracleWinForms
{
    public class ConexionOracle
    {
        private readonly string cadenaConexion =
            "User Id=SYSTEM;" +
            "Password=Tapiero123;" +
            "Data Source=(DESCRIPTION=" +
            "(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))" +
            "(CONNECT_DATA=(SERVICE_NAME=ORCL)));" +
            "Connection Timeout=30;" +
            "Pooling=false;";

        public OracleConnection ObtenerConexion()
        {
            try
            {
                OracleConnection conexion =
                    new OracleConnection(cadenaConexion);

                return conexion;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    $"Error Oracle:\n\n{ex.Message}",
                    "Oracle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error General:\n\n{ex.Message}",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                throw;
            }
        }

        public bool ProbarConexion()
        {
            try
            {
                using (OracleConnection cn =
                       new OracleConnection(cadenaConexion))
                {
                    cn.Open();
                    cn.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string ObtenerEstadoConexion()
        {
            try
            {
                using (OracleConnection cn =
                       new OracleConnection(cadenaConexion))
                {
                    cn.Open();

                    string estado =
                        $"Conectado correctamente.\n" +
                        $"Servidor: {cn.DataSource}\n" +
                        $"Versión: {cn.ServerVersion}";

                    cn.Close();

                    return estado;
                }
            }
            catch (OracleException ex)
            {
                return $"Oracle Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}   