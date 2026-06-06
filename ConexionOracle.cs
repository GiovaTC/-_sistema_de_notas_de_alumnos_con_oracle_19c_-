using Oracle.ManagedDataAccess.Client;
using System;

namespace NotasOracleWinForms
{
    public class ConexionOracle
    {
        private readonly string cadena =
            "User Id=SYSTEM;" +
            "Password=Tapiero123;" +
            "Data Source=localhost:1521/orcl;" +
            "Connection Timeout=60;";

        public OracleConnection ObtenerConexion()
        {
            OracleConnection conexion =
                new OracleConnection(cadena);

            try
            {
                conexion.Open();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al conectar con Oracle: " +
                    ex.Message);
            }

            return conexion;
        }
    }
}