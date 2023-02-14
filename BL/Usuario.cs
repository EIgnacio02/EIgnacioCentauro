using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioCentauroContext context= new DL.EignacioCentauroContext())
                {
                    usuario.Name = (usuario.Name == null) ? "" : usuario.Name;
                    usuario.LastName = (usuario.LastName == null) ? "" : usuario.LastName;
                    usuario.SurName = (usuario.SurName == null) ? "" : usuario.SurName;
                    usuario.Email = (usuario.Email == null) ? "" : usuario.Email;

                    var query = context.Users.FromSqlRaw($"UsersGetAll '{usuario.Name}','{usuario.LastName}','{usuario.SurName}','{usuario.Email}'").ToList();
                    result.ObjectList = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuarioObj= new ML.Usuario();

                            usuarioObj.IdUsers = obj.IdUsers;
                            usuarioObj.Rol = new ML.Rol();
                            usuarioObj.Rol.IdRol = (int)obj.IdRol;
                            usuarioObj.Rol.RolName = obj.RolName;
                            usuarioObj.Name = obj.Nombre;
                            usuarioObj.LastName = obj.LastName;
                            usuarioObj.SurName = obj.SurName;
                            usuarioObj.Email = obj.Email;
                            usuarioObj.UserName = obj.UserName;
                            usuarioObj.Passwords = obj.Passwords;
                            usuarioObj.Parent = (int)obj.Parent;
                            usuarioObj.Status = obj.Stauts;

                            result.ObjectList.Add(usuarioObj);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}