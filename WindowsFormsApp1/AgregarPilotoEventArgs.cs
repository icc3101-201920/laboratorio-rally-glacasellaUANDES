using ModelosRally;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasRally
{
    public class AgregarPilotoEventArgs : EventArgs
    {
        
        public Persona persona { get; set; }
    }
}
