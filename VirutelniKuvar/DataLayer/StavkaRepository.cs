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
    public class StavkeRepository
    {
        public List<Stavka> GetAllStavka()
        {
            List<Stavka> listaStavki = new List<Stavka>();

           
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM Stavke";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Stavka stavka = new Stavka();
                    stavka.Id = dataReader.GetInt32(0);
                    stavka.kolicina = dataReader.GetString(1);
                    stavka.id_recepta = dataReader.GetInt32(2);
                    stavka.id_sastojka = dataReader.GetInt32(3);

                    listaStavki.Add(stavka);
                }
            }

            return listaStavki;
        }

        public int InsertStavke(Stavka stavka)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Stavke (kolicina,id_recepta, id_sastojka) " +
                                         "VALUES (@kolicina,@id_recepta, @id_sastojka)";

                sqlCommand.Parameters.AddWithValue("@kolicina", stavka.kolicina);
                sqlCommand.Parameters.AddWithValue("@id_recepta ", stavka.id_recepta);
                sqlCommand.Parameters.AddWithValue("@id_sastojka ", stavka.id_sastojka);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateStavke(Stavka stavka)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "UPDATE Stavke SET kolicina=@kolicina, id_recepta=@id_recepta, id_sastojka=@id_sastojka " +
                                         "WHERE Id=@Id";

                sqlCommand.Parameters.AddWithValue("@Id", stavka.Id);
                sqlCommand.Parameters.AddWithValue("@kolicina", stavka.kolicina);
                sqlCommand.Parameters.AddWithValue("@id_recepta", stavka.id_recepta);
                sqlCommand.Parameters.AddWithValue("@id_sastojka", stavka.id_sastojka);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
