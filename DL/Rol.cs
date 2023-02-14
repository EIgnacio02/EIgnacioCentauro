using System;
using System.Collections.Generic;

namespace DL;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? RolName { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
