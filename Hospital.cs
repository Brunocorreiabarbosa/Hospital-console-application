using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Hospital
    {
        public List<Paciente> Pacientes { get; set; }
        public List<Medico> Medicos { get; set; }

        public Hospital()
        {
            Pacientes = new List<Paciente>();
            Medicos = new List<Medico>();
        }
    }
}
