using NetCore.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NetCoreDAO
{
    public class MarcaDAO
    {
        public List<MarcaBE> getall(string cnn)
        {
            List<MarcaBE> lista = new List<MarcaBE>();
            try
            {
                using (SqlConnection objConection = new SqlConnection(cnn))
                {
                    using (SqlCommand objCommand = new SqlCommand("Pa_getall_marcas", objConection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;                       
                        objCommand.Connection.Open();
                        using (IDataReader dr = objCommand.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                MarcaBE u = new MarcaBE();
                                u.Id = dr.GetInt32(dr.GetOrdinal("id"));
                                u.Nombre = dr.GetString(dr.GetOrdinal("Marca"));
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
    }
}
