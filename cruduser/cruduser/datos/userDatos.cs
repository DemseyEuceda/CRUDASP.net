using System.Data.SqlClient;
using System.Data;
using cruduser.Models;


namespace cruduser.datos
{
    public class userDatos
    {

        public List<UsuarioModel> listar()
        {
            var lista = new List<UsuarioModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new UsuarioModel() {
                            id = Convert.ToInt32(reader["id"]), 
                            nombre = reader["nombre"].ToString(),
                            direccion = reader["direccion"].ToString(), 
                            correo  =reader["correo"].ToString(),
                            apodo = reader["apodo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }


        public UsuarioModel obtenerUsuario(int id)
        {
            var usuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_get_user", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        usuario.id = Convert.ToInt32(reader["id"]);
                        usuario.nombre = reader["nombre"].ToString();
                        usuario.direccion = reader["direccion"].ToString();
                        usuario.correo = reader["correo"].ToString();
                        usuario.apodo = reader["apodo"].ToString();
                        
                    }
                }
            }
            return usuario;
        }

        public bool crear (UsuarioModel usuario)
        {
            bool resp;
            try
            {
                //var usuario = new UsuarioModel();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_crear_usuario", conexion);
                    cmd.Parameters.AddWithValue("nombre", usuario.nombre);
                    cmd.Parameters.AddWithValue("direccion", usuario.direccion);
                    cmd.Parameters.AddWithValue("correo", usuario.correo);
                    cmd.Parameters.AddWithValue("apodo", usuario.apodo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resp = true;

            }catch (Exception ex)
            {   
                string error = ex.Message;
                resp = false;
            }

            return resp;
        }

        public bool editar(UsuarioModel usuario)
        {
            bool resp;
            try
            {
                //var usuario = new UsuarioModel();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_usuario", conexion);
                    cmd.Parameters.AddWithValue("id", usuario.id);
                    cmd.Parameters.AddWithValue("nombre", usuario.nombre);
                    cmd.Parameters.AddWithValue("direccion", usuario.direccion);
                    cmd.Parameters.AddWithValue("correo", usuario.correo);
                    cmd.Parameters.AddWithValue("apodo", usuario.apodo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resp = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                resp = false;
            }

            return resp;
        }



        public bool eliminar(int id)
        {
            bool resp;
            try
            {
                //var usuario = new UsuarioModel();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete_usuario", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resp = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                resp = false;
            }

            return resp;
        }


    }
}
