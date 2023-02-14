namespace ML
{
    public class Usuario
    {

        public int IdUsers { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Passwords { get; set; }
        public int Parent { get; set; }
        public int Status { get; set; }

        public List<object> UsuarioList { get; set; }

        public ML.Rol Rol { get; set; }

    }
}