using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration; 
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SastojakRepository
    {
        public List<Sastojak> GetAllSastojci()
        {
            List<Sastojak> listaSastojaka = new List<Sastojak>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM Sastojci";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Sastojak sastojak = new Sastojak();
                    sastojak.Id = dataReader.GetInt32(0);
                    sastojak.naziv_sastojka = dataReader.GetString(1);
                    sastojak.mera = dataReader.GetString(2);

                    listaSastojaka.Add(sastojak);
                }
            }

            return listaSastojaka;
        }

        public int InsertSastojak(Sastojak sastojak)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Sastojci (naziv_sastojka, mera) " +
                                 "OUTPUT INSERTED.id " + // Dodajte razmak pre VALUES
                                 "VALUES (@naziv_sastojka, @mera)";

                sqlCommand.Parameters.AddWithValue("@naziv_sastojka", sastojak.naziv_sastojka);
                sqlCommand.Parameters.AddWithValue("@mera", sastojak.mera);

                sqlConnection.Open();
                int insertedId = (int)sqlCommand.ExecuteScalar();
                return insertedId;
            }
        }


        public int UpdateSastojak(Sastojak sastojak)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Sastojci SET naziv_sastojka=@naziv_sastojka, mera=@mera " +
                                         " WHERE id=@id";

                sqlCommand.Parameters.AddWithValue("@Id", sastojak.Id);
                sqlCommand.Parameters.AddWithValue("@naziv_sastojka", sastojak.naziv_sastojka);
                sqlCommand.Parameters.AddWithValue("@mera", sastojak.mera);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public string GetNazivSastojkaById(int idSastojka)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string query = "SELECT Naziv FROM Sastojak WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idSastojka);

                string nazivSastojka = (string)cmd.ExecuteScalar();

                sqlConnection.Close();

                return nazivSastojka;
            }
        }

       
    }
}
