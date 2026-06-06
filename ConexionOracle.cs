using Oracle.ManagedDataAccess.Client;

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
            return new OracleConnection(cadena);
        }
    }
}