using Oracle.ManagedDataAccess.Client;

namespace NotasOracleWinForms
{
    public class ConexionOracle
    {
        private string cadena =
            "User Id=SYSTEM;" + 
            "Password=Tapiero123;" +
            "Data Source=localhost:1521/orcl";  

        public OracleConnection ObtenerConexion()
        {
            return new OracleConnection(cadena);
        }
    }   
}
