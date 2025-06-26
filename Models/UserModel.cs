namespace MVVM.Models
{
    internal class UserModel
    {
        private int _id;
        private string _nombre;
        private string _apellidos;
        private string _email;
        private string _password;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                }
            }
        }

        public string Apellidos
        {
            get => _apellidos;
            set
            {
                if (_apellidos != value)
                {
                    _apellidos = value;
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                }
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }
    }
}
