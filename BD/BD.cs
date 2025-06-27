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
            ObservableCollection<UserModel> lstResult = new ObservableCollection<UserModel>();
            string query = "SELECT * FROM usuarios";
            using (MySqlConnection cn = new MySqlConnection(Conexion))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
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
                reader.Close();
                cn.Close();
            }
            return lstResult;
        }
        internal void Add(UserModel user)
        {
            string query = "INSERT INTO usuarios VALUES (@id, @name, @lastname, @email, @password);";
            using (MySqlConnection cn = new MySqlConnection(Conexion))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@name", user.Nombre);
                cmd.Parameters.AddWithValue("@lastname", user.Apellidos);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        internal void Delete(UserModel user)
        {
            string query = "DELETE FROM usuarios WHERE IDUSER = @id";
            using (MySqlConnection cn = new MySqlConnection(Conexion))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
  
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        internal void Edit(UserModel user)
        {
            string query = "UPDATE usuarios SET NOMBRE = @name, APELLIDOS = @lastname, EMAIL = @email, CONTRASENA = @password WHERE IDUSER = @id";
            using (MySqlConnection cn = new MySqlConnection(Conexion))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@name", user.Nombre);
                cmd.Parameters.AddWithValue("@lastname", user.Apellidos);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
