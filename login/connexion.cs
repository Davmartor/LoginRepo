using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

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

        public Dictionary<string, string> rellenarBoxeadores()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            string consulta = @"SELECT id_boxeador,name_boxeador 
                                FROM combates.boxeadores; ";
            this.Conectar();

            MySqlCommand command = new MySqlCommand(consulta, this.conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                d.Add(
                    reader["name_boxeador"].ToString(),
                    reader["id_boxeador"].ToString()
                    );
            }

            return d;

        }

        public void CloseConnection()
        {
            this.conn.Close();
        }

        public IEnumerable getDefaulView()
        {

            this.Conectar();

            string query = @"SELECT nombre,id_combats as combates,id_victories as victorias, id_ko as ko,best_assault, best_time, rival  
                            FROM clasificacion_boxeadores";

            MySqlCommand commando = new MySqlCommand(query, ConectorBD.Instance.conn);

            MySqlDataAdapter myAdapter = new MySqlDataAdapter(commando);
            
            DataTable dTable = new DataTable();

            myAdapter.Fill(dTable);

            this.CloseConnection();

            return dTable.DefaultView;

        }

    }
}
