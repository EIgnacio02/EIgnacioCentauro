using System;
using System.Collections.Generic;

namespace DL;

public partial class User
{
    public int IdUsers { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? LastName { get; set; }

    public string? SurName { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Passwords { get; set; } = null!;

    public int? Parent { get; set; }

    public int Stauts { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public string RolName { get; set; }

}
