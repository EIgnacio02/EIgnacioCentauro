using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Usuario usuario= new ML.Usuario();
            usuario.Rol = new ML.Rol();
            ML.Result result = BL.Usuario.GetAll(usuario);
            ML.Result resultRol = BL.Rol.GetAll();


            if (result.Correct)
            {
                usuario.UsuarioList = result.ObjectList;
                usuario.Rol.RolList = resultRol.ObjectList;
                return View(usuario);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult GetAll(ML.Usuario usuario)
        {
            usuario.Rol = new ML.Rol();
            ML.Result result = BL.Usuario.GetAll(usuario);
            ML.Result resultRol = BL.Rol.GetAll();


            if (result.Correct)
            {
                usuario.UsuarioList = result.ObjectList;
                usuario.Rol.RolList = resultRol.ObjectList;
                return View(usuario);
            }
            else
            {
                return View();
            }

        }
    }
}
