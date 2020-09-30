
using NetCore.BE;
using NetCore.BE.Transporte.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace NetCoreDAO
{
    public class AutoDAO
    {
        public List<AutoBE> getallAutos(string placa, int marca, string modelo, string cnn)
        {
            List<AutoBE> lista = new List<AutoBE>();
            try
            {
                using (SqlConnection objConection = new SqlConnection(cnn))
                {
                    using (SqlCommand objCommand = new SqlCommand("Pa_getbyfilters_auto", objConection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.Add(new SqlParameter("@pi_placa", SqlDbType.VarChar, 50) { Value = placa });
                        objCommand.Parameters.Add(new SqlParameter("@pi_marca", SqlDbType.Int) { Value = marca});
                        objCommand.Parameters.Add(new SqlParameter("@pi_modelo", SqlDbType.VarChar, 150) { Value = modelo });
                        objCommand.Connection.Open();
                        using (IDataReader dr = objCommand.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AutoBE u = new AutoBE();
                                u.Id = dr.GetInt32(dr.GetOrdinal("IdAuto"));
                                u.Placa = dr.GetString(dr.GetOrdinal("Placa"));
                                u.Marca = new MarcaBE() { Nombre = dr.GetString(dr.GetOrdinal("Marca")) };
                                u.Modelo = dr.GetString(dr.GetOrdinal("Modelo"));
                                u.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
                                u.FechaCreacion = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"));
                                lista.Add(u);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Guardar(AutoRequest autoInfo, string cnn)
        {
            bool ok = false;
            try
            {
                using (SqlConnection objConection = new SqlConnection(cnn))
                {
                    using (SqlCommand objCommand = new SqlCommand("Pa_insert_auto", objConection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.Add(new SqlParameter("@pi_placa", SqlDbType.VarChar, 50) { Value = autoInfo.Placa });
                        objCommand.Parameters.Add(new SqlParameter("@pi_marca", SqlDbType.Int) { Value = autoInfo.Marca });
                        objCommand.Parameters.Add(new SqlParameter("@pi_modelo", SqlDbType.VarChar, 150) { Value = autoInfo.Modelo });
                        objCommand.Parameters.Add(new SqlParameter("@pi_descripcion", SqlDbType.VarChar, 150) { Value = autoInfo.Descripcion });
                        objCommand.Connection.Open();

                        objCommand.ExecuteNonQuery();

                        ok = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ok;
        }
    }
}
