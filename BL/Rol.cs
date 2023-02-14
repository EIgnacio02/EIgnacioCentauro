using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result= new ML.Result();

            try
            {
                using (DL.EignacioCentauroContext context= new DL.EignacioCentauroContext())
                {
                    var query = context.Rols.FromSqlRaw("RolGetAll").ToList();
                    result.ObjectList = new List<object>();

                    if (query!=null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = obj.IdRol;
                            rol.RolName = obj.RolName;

                            result.ObjectList.Add(rol);
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
