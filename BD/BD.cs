using MVVM.Models;
using System.Collections.ObjectModel;
using MySqlConnector;

namespace MVVM.BD
{
    internal class BD
    {
        private readonly string _conexion;

        public string Conexion => _conexion;

        public BD()
        {
            _conexion = "Server=localhost;Database=BDUSERS;User ID=root;Password=Nico19205_;";
        }

        internal ObservableCollection<UserModel> Get()
        {
            var lstResult = new ObservableCollection<UserModel>();
            string query = "SELECT * FROM usuarios";

            using (var cn = new MySqlConnection(Conexion))
            {
                cn.Open();
                using (var cmd = new MySqlCommand(query, cn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstResult.Add(new UserModel()
                            {
                                Id = reader.GetInt32("IDUSER"),
                                Nombre = reader.GetString("NOMBRE"),
                                Apellidos = reader.GetString("APELLIDOS"),
                                Email = reader.GetString("EMAIL"),
                                Password = reader.GetString("CONTRASENA")
                            });
                        }
                    }
                }
            }

            return lstResult;
        }
    }
}
