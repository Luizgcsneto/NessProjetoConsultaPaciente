using ProjetoConsultaPaciente.Dominio.Contratos;
using ProjetoConsultaPaciente.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoConsultaPaciente.Repositorio.Repositorios
{
    public class PacienteRepositorio : BaseRepositorio<Paciente>, IPacienteRepositorio
    {
        string connectionString = @"Data Source=DESKTOP-NLQLOUN\express;initial catalog=iconsulta;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public void Atualizar(Paciente paciente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"UPDATE [dbo].[Paciente]
                                   SET 
                                      Email = @Email
                                      ,Password = @Password
                                      ,Nome = @Nome
                                      ,SobreNome = @SobreNome
                                      ,EhAdministrador = @EhAdministrador
                                      ,Contato = @Contato
                                 WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", paciente.Id);
                cmd.Parameters.AddWithValue("@Nome", paciente.Nome);
                cmd.Parameters.AddWithValue("@SobreNome", paciente.SobreNome);
                cmd.Parameters.AddWithValue("@Email", paciente.Email);
                cmd.Parameters.AddWithValue("@Password", paciente.Password);
                cmd.Parameters.AddWithValue("@EhAdministrador", paciente.EhAdministrador);
                cmd.Parameters.AddWithValue("@Contato", paciente.Contato);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Paciente Buscar(Guid Id)
        {
            Paciente paciente = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Paciente WHERE Id= " + "@Id";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    paciente = new Paciente();
                    paciente.Id = new Guid(rdr["Id"].ToString());
                    paciente.Nome = rdr["Nome"].ToString();
                    paciente.SobreNome = rdr["SobreNome"].ToString();
                    paciente.Password = rdr["Password"].ToString();
                    paciente.Email = rdr["Email"].ToString();
                    paciente.EhAdministrador = Convert.ToBoolean(rdr["EhAdministrador"].ToString());
                    paciente.Contato = rdr["Contato"].ToString();
                }

                if (paciente != null)
                {
                    Repositorio.Repositorios.MarcacaoRepositorio repMarcacao = new MarcacaoRepositorio();
                    paciente.Marcacoes = repMarcacao.ListarPorPaciente(paciente.Id);
                }

            }
            return paciente;
        }

        public void DesmarcarConsulta(Paciente paciente, Marcacao marcacao)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"UPDATE [dbo].[Marcacao]
                                   SET 
                                      Paciente_Id = null
                                     ,Disponivel = 1
                                 WHERE Id=@Marcacap_Id and Paciente_Id=@Paciente_Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Paciente_Id", paciente.Id);
                cmd.Parameters.AddWithValue("@Marcacap_Id", marcacao.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Paciente paciente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Paciente where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", paciente.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Inserir(Paciente paciente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"INSERT INTO dbo.Paciente
                                                               (Id
                                                               ,Email
                                                               ,Password
                                                               ,Nome
                                                               ,SobreNome
                                                               ,EhAdministrador
                                                               ,Contato)
                                                         VALUES
                                                               (@Id
                                                               ,@Email
                                                               ,@Password
                                                               ,@Nome
                                                               ,@SobreNome
                                                               ,@EhAdministrador
                                                               ,@Contato)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", paciente.Id);
                cmd.Parameters.AddWithValue("@Nome", paciente.Nome);
                cmd.Parameters.AddWithValue("@SobreNome", paciente.SobreNome);
                cmd.Parameters.AddWithValue("@Email", paciente.Email);
                cmd.Parameters.AddWithValue("@Password", paciente.Password);
                cmd.Parameters.AddWithValue("@EhAdministrador", paciente.EhAdministrador);
                cmd.Parameters.AddWithValue("@Contato", paciente.Contato);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ICollection<Paciente> Listar()
        {
            List<Paciente> lstfuncionario = new List<Paciente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Paciente", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.Id = new Guid(rdr["Id"].ToString());
                    paciente.Nome = rdr["Nome"].ToString();
                    paciente.SobreNome = rdr["SobreNome"].ToString();
                    paciente.Password = rdr["Password"].ToString();
                    paciente.Email = rdr["Email"].ToString();
                    paciente.EhAdministrador = Convert.ToBoolean(rdr["EhAdministrador"].ToString());
                    paciente.Contato = rdr["Contato"].ToString();
                    lstfuncionario.Add(paciente);
                }
                con.Close();
            }
            return lstfuncionario;
        }

        public void RealizarMarcacao(Paciente paciente, Marcacao marcacao)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"UPDATE [dbo].[Marcacao]
                                   SET 
                                      Paciente_Id = @Paciente_Id
                                     ,Disponivel = 0
                                 WHERE Id=@Marcacap_Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Paciente_Id", paciente.Id);
                cmd.Parameters.AddWithValue("@Marcacap_Id", marcacao.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Paciente VerificarPaciente(Paciente paciente)
        {
            Paciente PacienteRetorno = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Paciente WHERE Email=@Email and Password=@Password";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Email", paciente.Email);
                cmd.Parameters.AddWithValue("@Password", paciente.Password);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PacienteRetorno = new Paciente();
                    PacienteRetorno.Id = new Guid(rdr["Id"].ToString());
                    PacienteRetorno.Nome = rdr["Nome"].ToString();
                    PacienteRetorno.SobreNome = rdr["SobreNome"].ToString();
                    PacienteRetorno.Password = rdr["Password"].ToString();
                    PacienteRetorno.Email = rdr["Email"].ToString();
                    PacienteRetorno.EhAdministrador = Convert.ToBoolean(rdr["EhAdministrador"].ToString());
                    PacienteRetorno.Contato = rdr["Contato"].ToString();
                }
            }
            return PacienteRetorno;
        }
    }
}
