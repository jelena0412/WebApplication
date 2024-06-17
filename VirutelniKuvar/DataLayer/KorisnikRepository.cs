using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class KorisnikRepository
    {
        private readonly string connectionString;

        public KorisnikRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public virtual List<Korisnik> GetAllUsers()
        {
            List<Korisnik> listaKorisnika = new List<Korisnik>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM Korisnici";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Korisnik korisnik = new Korisnik();

                    korisnik.id = dataReader.GetInt32(0);
                    korisnik.ime = dataReader.GetString(1);
                    korisnik.prezime = dataReader.GetString(2);
                    korisnik.korisnicko_ime = dataReader.GetString(3);
                    korisnik.mejl = dataReader.GetString(4);
                    korisnik.broj_telefona = dataReader.GetString(5);
                    korisnik.lozinka = dataReader.GetString(6);

                    listaKorisnika.Add(korisnik);
                }
            }

            return listaKorisnika;
        }
        public int InsertUser(Korisnik korisnik)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Korisnici (ime, prezime, korisnicko_ime, mejl, broj_telefona, lozinka) " +
                                        "VALUES (@ime, @prezime, @korisnicko_ime, @mejl, @broj_telefona, @lozinka)";

                sqlCommand.Parameters.AddWithValue("@ime", korisnik.ime);
                sqlCommand.Parameters.AddWithValue("@prezime", korisnik.prezime);
                sqlCommand.Parameters.AddWithValue("@korisnicko_ime", korisnik.korisnicko_ime);
                sqlCommand.Parameters.AddWithValue("@mejl", korisnik.mejl);
                sqlCommand.Parameters.AddWithValue("@broj_telefona", korisnik.broj_telefona);
                sqlCommand.Parameters.AddWithValue("@lozinka", korisnik.lozinka);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateUser(Korisnik korisnik)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Korisnici SET ime=@ime, prezime=@prezime, " +
                                         "korisnicko_ime=@korisnicko_ime, mejl=@mejl, broj_telefona=@broj_telefona, lozinka=@lozinka " +
                                         "WHERE id=@id";

                sqlCommand.Parameters.AddWithValue("@id", korisnik.id);
                sqlCommand.Parameters.AddWithValue("@ime", korisnik.ime);
                sqlCommand.Parameters.AddWithValue("@prezime", korisnik.prezime);
                sqlCommand.Parameters.AddWithValue("@korisnicko_ime", korisnik.korisnicko_ime);
                sqlCommand.Parameters.AddWithValue("@mejl", korisnik.mejl);
                sqlCommand.Parameters.AddWithValue("@broj_telefona", korisnik.broj_telefona);
                sqlCommand.Parameters.AddWithValue("@lozinka", korisnik.lozinka);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public bool ProveriKorisnika(string korisnickoIme, string lozinka)
        {
            bool korisnikPostoji = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string query = "SELECT COUNT(*) FROM Korisnici WHERE korisnicko_ime = @KorisnickoIme AND lozinka = @Lozinka";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KorisnickoIme", korisnickoIme);
                    command.Parameters.AddWithValue("@Lozinka", lozinka);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        Console.WriteLine("Broj pronađenih korisnika: " + count);
                        if (count > 0)
                        {
                            korisnikPostoji = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Greška prilikom provere korisnika: " + ex.Message);
                    }
                }
            }

            return korisnikPostoji;
        }

        public int DeleteUser(int korisnikId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Korisnici WHERE id=@id";

                sqlCommand.Parameters.AddWithValue("@id", korisnikId);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
