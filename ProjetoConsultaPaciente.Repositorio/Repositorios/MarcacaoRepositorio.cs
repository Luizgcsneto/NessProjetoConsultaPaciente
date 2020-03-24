using ProjetoConsultaPaciente.Dominio.Contratos;
using ProjetoConsultaPaciente.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoConsultaPaciente.Repositorio.Repositorios
{
    public class MarcacaoRepositorio : BaseRepositorio<Marcacao>, IPacienteRepositorio
    {
        string connectionString = @"Data Source=DESKTOP-NLQLOUN\express;initial catalog=iconsulta;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public void Adicionar(Dominio.Entidade.Marcacao entity)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Paciente entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Marcacao marcacao)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"UPDATE [dbo].[Marcacao]
                                   SET 
                                       DataMarcacao = @DataMarcacao
                                      ,Disponivel = @Disponivel
                                      ,Horario = @Horario
                                      ,Paciente_Id = @Paciente_Id
                                      ,Hospital_Id = @Hospital_Id
                                 WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", marcacao.Id);
                cmd.Parameters.AddWithValue("@DataMarcacao", marcacao.DataMarcacao);
                cmd.Parameters.AddWithValue("@Disponivel", marcacao.Disponivel);
                cmd.Parameters.AddWithValue("@Horario", marcacao.Horario);
                cmd.Parameters.AddWithValue("@Paciente_Id", marcacao.PacienteId);
                cmd.Parameters.AddWithValue("@Hospital_Id", marcacao.HospitalId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

       

        public void Atualizar(Paciente entity)
        {
            throw new NotImplementedException();
        }

        public Marcacao Buscar(Guid Id)
        {
            Marcacao marcacao = new Marcacao();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Marcacao WHERE Id= " + "@Id";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    marcacao.Id = new Guid(rdr["Id"].ToString());
                    marcacao.Horario = TimeSpan.Parse(rdr["Horario"].ToString());
                    marcacao.DataMarcacao = DateTime.Parse(rdr["DataMarcacao"].ToString());
                    marcacao.Disponivel = Convert.ToBoolean(rdr["Disponivel"].ToString());
                    marcacao.HospitalId = new Guid(rdr["Hospital_Id"].ToString());
                    marcacao.PacienteId = new Guid(rdr["Paciente_Id"].ToString());

                }
            }
            return marcacao;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Marcacao marcacao)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Marcacao where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", marcacao.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Inserir(Marcacao marcacao)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"INSERT INTO dbo.Marcacao
                                                               (Id,Hospital_Id,DataMarcacao,Disponivel,Horario,Paciente_Id)
                                                         VALUES
                                                                (@Id,@Hospital_Id,@DataMarcacao,@Disponivel,@Horario,@Paciente_Id)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", marcacao.Id);
                cmd.Parameters.AddWithValue("@DataMarcacao", marcacao.DataMarcacao);
                cmd.Parameters.AddWithValue("@Disponivel", marcacao.Disponivel);
                cmd.Parameters.AddWithValue("@Horario", marcacao.Horario);
                cmd.Parameters.AddWithValue("@Paciente_Id", marcacao.PacienteId);
                cmd.Parameters.AddWithValue("@Hospital_Id", marcacao.HospitalId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ICollection<Marcacao> Listar()
        {
            List<Marcacao> lstfuncionario = new List<Marcacao>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Marcacao", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Marcacao marcacao = new Marcacao();
                    marcacao.Id = new Guid(rdr["Id"].ToString());
                    marcacao.DataMarcacao = DateTime.Parse(rdr["DataMarcacao"].ToString());
                    marcacao.Disponivel = Convert.ToBoolean(rdr["Disponivel"].ToString());
                    marcacao.Horario = TimeSpan.Parse(rdr["Horario"].ToString());
                    marcacao.HospitalId = new Guid(rdr["Hospital_Id"].ToString());

                    if (!String.IsNullOrEmpty(rdr["Paciente_Id"].ToString()))
                    {
                        marcacao.PacienteId = new Guid(rdr["Paciente_Id"].ToString());
                    }

                    lstfuncionario.Add(marcacao);
                }
                con.Close();
            }
            return lstfuncionario;
        }

        public ICollection<Marcacao> ListarPorHospital(Guid hospitalId)
        {
            List<Marcacao> lstfuncionario = new List<Marcacao>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Marcacao where disponivel='true' and hospital_id='" + hospitalId + @"'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Marcacao marcacao = new Marcacao();
                    marcacao.Id = new Guid(rdr["Id"].ToString());
                    marcacao.DataMarcacao = DateTime.Parse(rdr["DataMarcacao"].ToString());
                    marcacao.Disponivel = Convert.ToBoolean(rdr["Disponivel"].ToString());
                    marcacao.Horario = TimeSpan.Parse(rdr["Horario"].ToString());
                    marcacao.HospitalId = new Guid(rdr["Hospital_Id"].ToString());

                    if (!String.IsNullOrEmpty(rdr["Paciente_Id"].ToString()))
                    {
                        marcacao.PacienteId = new Guid(rdr["Paciente_Id"].ToString());
                    }

                    lstfuncionario.Add(marcacao);
                }
                con.Close();
            }
            return lstfuncionario;
        }


        public ICollection<Marcacao> ListarPorPaciente(Guid pacienteId)
        {
            List<Marcacao> lstfuncionario = new List<Marcacao>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Marcacao where disponivel='true' and paciente_id='" + pacienteId + @"'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Marcacao marcacao = new Marcacao();
                    marcacao.Id = new Guid(rdr["Id"].ToString());
                    marcacao.DataMarcacao = DateTime.Parse(rdr["DataMarcacao"].ToString());
                    marcacao.Disponivel = Convert.ToBoolean(rdr["Disponivel"].ToString());
                    marcacao.Horario = TimeSpan.Parse(rdr["Horario"].ToString());
                    marcacao.HospitalId = new Guid(rdr["Hospital_Id"].ToString());

                    if (!String.IsNullOrEmpty(rdr["Paciente_Id"].ToString()))
                    {
                        marcacao.PacienteId = new Guid(rdr["Paciente_Id"].ToString());
                    }

                    lstfuncionario.Add(marcacao);
                }
                con.Close();
            }
            return lstfuncionario;
        }

        public Dominio.Entidade.Marcacao ObterPorID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dominio.Entidade.Marcacao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Dominio.Entidade.Marcacao entity)
        {
            throw new NotImplementedException();
        }

        public void Remover(Paciente entity)
        {
            throw new NotImplementedException();
        }

        public Paciente VerificarPaciente(Paciente paciente)
        {
            throw new NotImplementedException();
        }



      

        Paciente IBaseRepositorio<Paciente>.ObterPorID(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Paciente> IBaseRepositorio<Paciente>.ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
