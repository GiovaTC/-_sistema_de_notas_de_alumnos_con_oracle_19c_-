using Oracle.ManagedDataAccess.Client;

namespace NotasOracleWinForms
{
    public class ConexionOracle
    {
        private readonly string cadena =
            @"Data Source=
            (DESCRIPTION=
                (ADDRESS=
                    (PROTOCOL=TCP)
                    (HOST=127.0.0.1)
                    (PORT=1521)
                )
                (CONNECT_DATA=
                    (SERVER=DEDICATED)
                    (SERVICE_NAME=orcl)
                )
            );
            User Id=SYSTEM;
            Password=Tapiero123;
            Connection Timeout=10;
            Validate Connection=true;
            Pooling=false;";

        public OracleConnection ObtenerConexion()
        {
            return new OracleConnection(cadena);
        }
    }
}   