using Oracle.ManagedDataAccess.Client;

namespace NotasOracleWinForms
{
    public class ConexionOracle
    {
        private readonly string cadena =
            "User Id=SYSTEM;" +
            "Password=Tapiero123;" +
            "Data Source=127.0.0.1:1521/orcl;" +
            "Connection Timeout=120;";

        public OracleConnection ObtenerConexion()
        {
            return new OracleConnection(cadena);
        }
    }
}   