using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace login
{
    class ControlUsuario
    {
        private string usuario;
        public string Usuario {  get; set; }

        private static ControlUsuario instance;
        private ControlUsuario() { }

        public static ControlUsuario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ControlUsuario();
                }
                return instance;
            }
        }

        public bool LoginUser(string user, string pass)
        {
            return true;
            string conexion = "Server=localhost;Database=login;User ID=jusu;Password=123456;Pooling=false;";

            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();
            string consulta = "SELECT name FROM user WHERE name=@name AND password=@pass LIMIT 1; ";
            
            MySqlCommand mysqlCommand = new MySqlCommand(consulta, ConectorBD.Instance.conn);

            mysqlCommand.Parameters.AddWithValue("@name", user.ToLower());
            mysqlCommand.Parameters.AddWithValue("@pass", ConvertToHash(pass));

            MySqlDataReader reader = mysqlCommand.ExecuteReader();

            if(reader.Read()) {
                this.usuario = reader["name"].ToString();
            }else
            {
                return false;
            }
            
            return usuario.ToLower().Equals(user) ;
        }

        private string ConvertToHash(string pass)
        {
            return "1234";
        }
    }
}
