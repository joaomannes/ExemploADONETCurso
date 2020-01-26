using ExemploADONETCurso.DAL.Util;
using ExemploADONETCurso.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploADONETCurso.DAL
{
    public class ClienteDAL
    {

        public Cliente Buscar(int id)
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                string sql = "select Id, Nome, DataNascimento from cliente where id = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                if(reader.Read())
                {
                    Cliente c = new Cliente();
                    c.Id = (int) reader["Id"];
                    c.Nome = (string)reader["Nome"];
                    c.DataNascimento = (DateTime)reader["DataNascimento"];
                    return c;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Cliente> Buscar()
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                List<Cliente> clientes = new List<Cliente>();

                string sql = "select Id, Nome, DataNascimento from cliente";
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente c = new Cliente();
                    c.Id = (int)reader["Id"];
                    c.Nome = (string)reader["Nome"];
                    c.DataNascimento = (DateTime)reader["DataNascimento"];
                    clientes.Add(c);
                }

                return clientes;
            }
        }

        public void Inserir(Cliente c)
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {

                string sql = "insert into cliente values (@nome, @datanascimento)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@nome", c.Nome);
                command.Parameters.AddWithValue("@datanascimento", c.DataNascimento);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(Cliente c)
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {

                string sql = "update cliente set Nome = @nome, DataNascimento = @datanascimento where Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@nome", c.Nome);
                command.Parameters.AddWithValue("@datanascimento", c.DataNascimento);
                command.Parameters.AddWithValue("@id", c.Id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Excluir(Cliente c)
        {
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {

                string sql = "delete from cliente where Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", c.Id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
