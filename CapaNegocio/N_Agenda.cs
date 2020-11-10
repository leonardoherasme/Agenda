using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Runtime.Remoting;

namespace CapaNegocio
{
    public class N_Agenda
    {
        D_Agenda objDato = new D_Agenda();
        public List<E_Agenda> ListarAgenda(string buscar)
        {
            return objDato.ListarAgenda(buscar);
        }
        public void InsertandoAgenda(E_Agenda _Agenda)
        {
            objDato.InsertarAgenda(_Agenda);
        }
        public void EditandoAgenda(E_Agenda _Agenda)
        {
            objDato.EditarAgenda(_Agenda);
        }
        public void EliminarAgenda(E_Agenda _Agenda)
        {
            objDato.EliminarAgenda(_Agenda);
        }
    }
}