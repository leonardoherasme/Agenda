using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CapaEntidad;

namespace CapaEntidad // ----------------------------- ATRIBUTOS DE LA APP.
{
    public class E_Agenda
    {
        private int _idagenda;
        private string _codigoagenda;
        private string _anombre;
        private string _aapellido;
        private string _acedula;
        private string _acorreo;
        private string _adireccion;

        // -----------------------------ENCAPSULAMIENTO DE VARIABLES.
        public int Idagenda { get => _idagenda; set => _idagenda = value; }
        public string Codigoagenda { get => _codigoagenda; set => _codigoagenda = value; }
        public string Anombre { get => _anombre; set => _anombre = value; }
        public string Aapellido { get => _aapellido; set => _aapellido = value; }
        public string Acedula { get => _acedula; set => _acedula = value; }
        public string Acorreo { get => _acorreo; set => _acorreo = value; }
        public string Adireccion { get => _adireccion; set => _adireccion = value; }

    }
}