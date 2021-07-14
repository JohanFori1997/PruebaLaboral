using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDLab.Models.Request
{
    public class PersonaRequest
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string email { get; set; }
    }
}
