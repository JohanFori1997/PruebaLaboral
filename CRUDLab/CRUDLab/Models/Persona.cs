using System;
using System.Collections.Generic;

#nullable disable

namespace CRUDLab.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
    }
}
