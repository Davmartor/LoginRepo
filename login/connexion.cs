using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace login
{
    class ConectorBD
    {
        public MySqlConnection conn;

        private static ConectorBD instance;

        private ConectorBD() { }
        
        public static ConectorBD Instance
        {
            get
            {

            if (instance == null)
                instance = new ConectorBD();
                return instance;
            }
        }

        public void Conectar()
        {
            string conexion = "Server=localhost;Database=combates;User ID=jusu;Password=123456;Pooling=false;";

            this.conn = new MySqlConnection(conexion);

            this.conn.Open();
        }

        public void CloseConnection()
        {
            this.conn.Close();
        }

    }
}
