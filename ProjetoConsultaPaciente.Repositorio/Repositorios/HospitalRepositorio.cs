using ProjetoConsultaPaciente.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoConsultaPaciente.Repositorio.Repositorios
{
    public class HospitalRepositorio
    {
        string connectionString = @"Data Source=DESKTOP-NLQLOUN\express;initial catalog=iconsulta;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public void Atualizar(Hospital hospital)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"UPDATE [dbo].[Hospital]
                                   SET 
                                      Nome = @Nome
                                      ,Contato = @Contato                                      
                                      ,Endereco = @Endereco
                                      ,Email = @Email
                                     WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", hospital.Id);
                cmd.Parameters.AddWithValue("@Nome", hospital.Nome);
                cmd.Parameters.AddWithValue("@Contato", hospital.Contato);
                cmd.Parameters.AddWithValue("@Endereco", hospital.Endereco);
                cmd.Parameters.AddWithValue("@Email", hospital.Email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Hospital Buscar(Guid Id)
        {
            Hospital hospital = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Hospital WHERE Id= " + "@Id";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    hospital = new Hospital();
                    hospital.Id = new Guid(rdr["Id"].ToString());
                    hospital.Nome = rdr["Nome"].ToString();
                    hospital.Email = rdr["Email"].ToString();
                    hospital.Endereco = rdr["Endereco"].ToString();
                    hospital.Contato = rdr["Contato"].ToString();
                }

                if (hospital != null)
                {
                    Repositorio.Repositorios.MarcacaoRepositorio repMarcacao = new MarcacaoRepositorio();
                    hospital.Marcacoes = repMarcacao.ListarPorHospital(hospital.Id);
                }


            }
            return hospital;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Hospital hospital)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Hospital where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", hospital.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Inserir(Hospital hospital)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"INSERT INTO dbo.Hospital
                                                               (Id
                                                               ,Nome                                                               
                                                               ,Email
                                                               ,Endereco
                                                               ,Contato)
                                                         VALUES
                                                               (@Id
                                                               ,@Nome
                                                               ,@Email
                                                               ,@Endereco
                                                               ,@Contato
                                                               )";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", hospital.Id);
                cmd.Parameters.AddWithValue("@Nome", hospital.Nome);
                cmd.Parameters.AddWithValue("@Email", hospital.Email);
                cmd.Parameters.AddWithValue("@Endereco", hospital.Endereco);
                cmd.Parameters.AddWithValue("@Contato", hospital.Contato);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ICollection<Hospital> Listar()
        {
            List<Hospital> lstfuncionario = new List<Hospital>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Hospital", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Hospital hospital = new Hospital();
                    hospital.Id = new Guid(rdr["Id"].ToString());
                    hospital.Nome = rdr["Nome"].ToString();
                    hospital.Endereco = rdr["Endereco"].ToString();
                    hospital.Contato = rdr["Contato"].ToString();
                    hospital.Email = rdr["Email"].ToString();

                    lstfuncionario.Add(hospital);
                }
                con.Close();
            }
            return lstfuncionario;
        }
    }
}
