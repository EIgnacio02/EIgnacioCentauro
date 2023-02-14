using System;
using System.Collections.Generic;

namespace DL;

public partial class Gpsdatum
{
    public int IdGps { get; set; }

    public DateTime DateSystem { get; set; }

    public DateTime? DateEvent { get; set; }

    public double? Latitude { get; set; }

    public int? Longitude { get; set; }

    public int? Battery { get; set; }

    public int? Sources { get; set; }

    public int? Tipos { get; set; }
}
