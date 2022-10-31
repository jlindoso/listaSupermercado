using BusinessLayer.DAL.Base;
using BusinessLayer.DAL.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {
        public Usuario Adicionar(Usuario usuario)
        {
            using (var con = this.Con)
            {
                con.Open();
                try
                {
                    this.SqlString = "INSERT INTO Usuario(Nome, Senha, Email) values (@nome, @senha, @email)";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("senha", usuario.Senha);
                        cmd.Parameters.AddWithValue("email", usuario.Email);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"300500 Erro não mapeado ao criar Usuario: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
            usuario.Id = Convert.ToInt32(GetLastIdInserted(usuario.Email));
            return usuario;
        }

        public int? GetLastIdInserted(string email)
        {
            int? result = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var sqlString = $"SELECT u.id FROM Usuario u WHERE u.email = '{email}';";
                using (var cmd = new SqlCommand(sqlString, con))
                {
                    try
                    {
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        result = (int?)Convert.ToInt32(dr["id"]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"300400 Erro não mapeado ao criar Usuario: {ex.Message}");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return result;
        }

        public Usuario Editar(int id, Usuario usuario)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                try
                {
                    this.SqlString = "UPDATE usuario SET  " +
                        " nome = @nome, " +
                        " senha = @senha ";
                    if (usuario.Email != null)
                        this.SqlString += " ,email = @email ";
                    this.SqlString += " WHERE id = @id;";

                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {

                        cmd.Parameters.AddWithValue("nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("senha", usuario.Senha);
                        if (usuario.Email != null)
                            cmd.Parameters.AddWithValue("email", usuario.Email);

                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"300500 Erro não mapeado ao criar Usuario: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
            usuario.Id = Convert.ToInt32(GetLastIdInserted(usuario.Email));
            return usuario;
        }

        public void Excluir(int id)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    this.SqlString = "DELETE FROM Usuario WHERE id = @id";
                    using (var cmd = new SqlCommand(SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {

                    throw new Exception("Não foi possivel excluir usuario");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public Usuario? Obter(int id)
        {
            using (var con = this.Con)
            {
                con.Open();
                try
                {
                    this.SqlString = "SELECT id, nome, email, senha FROM Usuario WHERE id = @id;";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        this.Dr = cmd.ExecuteReader();
                        if (Dr.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(Dr["id"].ToString()),
                                Email = Dr["email"].ToString(),
                                Nome = Dr["nome"].ToString(),
                                Senha = Dr["senha"].ToString()
                            };
                        };


                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"300500 Erro não mapeado ao criar Usuario: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }

            return null;
        }


        public Usuario? Login(string email, string senha)
        {
            using (var con = this.Con)
            {
                con.Open();
                try
                {
                    this.SqlString = "SELECT id, nome, email, senha FROM Usuario WHERE email = @email AND senha = @senha;";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("senha", senha);
                        this.Dr = cmd.ExecuteReader();
                        if (Dr.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(Dr["id"].ToString()),
                                Email = Dr["email"].ToString(),
                                Nome = Dr["nome"].ToString(),
                                Senha = Dr["senha"].ToString()
                            };
                        };


                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"300500 Erro não mapeado ao criar Usuario: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }

            return null;
        }



    }
}
