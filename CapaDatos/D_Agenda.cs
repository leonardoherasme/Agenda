using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;


namespace CapaDatos
{
    public class D_Agenda
    {
        // ----------------------------- Habilitando la conexion a la base de datos
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List <E_Agenda> ListarAgenda(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCANDOAGENDA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_Agenda> Listar = new List<E_Agenda>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Agenda
                {
                    Idagenda = LeerFilas.GetInt32(0),
                    Codigoagenda = LeerFilas.GetString(1),
                    Anombre = LeerFilas.GetString(2),
                    Aapellido = LeerFilas.GetString(3),
                    Acedula = LeerFilas.GetString(4),
                    Acorreo = LeerFilas.GetString(5),
                    Adireccion = LeerFilas.GetString(6)
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        } // -----------------------------BUSCAR

        public void InsertarAgenda (E_Agenda _Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTANDOAGENDA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ANOMBRE", _Agenda.Anombre);
            cmd.Parameters.AddWithValue("@AAPELLIDO", _Agenda.Aapellido);
            cmd.Parameters.AddWithValue("@ACEDULA", _Agenda.Acedula);
            cmd.Parameters.AddWithValue("@ACORREO", _Agenda.Acorreo);
            cmd.Parameters.AddWithValue("@ADIRECCION", _Agenda.Adireccion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }// -----------------------------INSERTAR

        public void EditarAgenda(E_Agenda _Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITANDOCONTACTO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDAGENDA", _Agenda.Idagenda);
            cmd.Parameters.AddWithValue("@ANOMBRE", _Agenda.Anombre);
            cmd.Parameters.AddWithValue("@AAPELLIDO", _Agenda.Aapellido);
            cmd.Parameters.AddWithValue("@ACEDULA", _Agenda.Acedula);
            cmd.Parameters.AddWithValue("@ACORREO", _Agenda.Acorreo);
            cmd.Parameters.AddWithValue("@ADIRECCION", _Agenda.Adireccion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }// -----------------------------EDITAR

        public void EliminarAgenda(E_Agenda _Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINANDOCONTACTO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDCAGENDA", _Agenda.Idagenda);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }// -----------------------------ELIMINAR
    }

}