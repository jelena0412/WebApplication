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
    public class ReceptRepository
    {
        public List<Recept> GetAllRecepti()
        {
            List<Recept> listaRecepata = new List<Recept>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM Recepti";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Recept recept = new Recept();
                    recept.Id = dataReader.GetInt32(0);
                    recept.Naziv = dataReader.GetString(1);
                    recept.Opis = dataReader.GetString(2);
                    recept.Komentar = dataReader.GetString(3);
                    recept.Ocena = dataReader.GetInt32(4);
                    recept.Id_korisnika = dataReader.GetInt32(5);

                    listaRecepata.Add(recept);
                }
            }

            return listaRecepata;
        }


        public int InsertRecept(Recept recept)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Recepti (naziv, opis, komentar, ocena, id_korisnika) " +
                                   "OUTPUT INSERTED.Id " +
                                 "VALUES (@naziv, @opis, @komentar, @ocena, @id_korisnika)";

                sqlCommand.Parameters.AddWithValue("@naziv", recept.Naziv);
                sqlCommand.Parameters.AddWithValue("@opis", recept.Opis);
                sqlCommand.Parameters.AddWithValue("@komentar", recept.Komentar);
                sqlCommand.Parameters.AddWithValue("@ocena", recept.Ocena);
                sqlCommand.Parameters.AddWithValue("@id_korisnika", recept.Id_korisnika);

                sqlConnection.Open();
                int insertedID = (int)sqlCommand.ExecuteScalar();
                return insertedID;
            }
        }
        public bool UnesiReceptSaSastojcimaStavkama(Recept recept, List<Sastojak> sastojci, List<Stavka> stavke)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string queryRecept = "INSERT INTO Recepti (Naziv, Opis, Komentar, Ocena, Id_korisnika) " +
                                         "VALUES (@Naziv, @Opis, @Komentar, @Ocena, @Id_korisnika); SELECT SCOPE_IDENTITY();";

                    SqlCommand commandRecept = new SqlCommand(queryRecept, connection, transaction);
                    commandRecept.Parameters.AddWithValue("@Naziv", recept.Naziv);
                    commandRecept.Parameters.AddWithValue("@Opis", recept.Opis);
                    commandRecept.Parameters.AddWithValue("@Komentar", recept.Komentar);
                    commandRecept.Parameters.AddWithValue("@Ocena", recept.Ocena);
                    commandRecept.Parameters.AddWithValue("@Id_korisnika", recept.Id_korisnika);

                    int idRecepta = Convert.ToInt32(commandRecept.ExecuteScalar());

                    for (int i = 0; i < sastojci.Count; i++)
                    {
                        Sastojak sastojak = sastojci[i];
                        string querySastojak = "INSERT INTO Sastojci (naziv_sastojka, mera) VALUES (@NazivSastojka, @Mera); SELECT SCOPE_IDENTITY();";
                        SqlCommand commandSastojak = new SqlCommand(querySastojak, connection, transaction);
                        commandSastojak.Parameters.AddWithValue("@NazivSastojka", sastojak.naziv_sastojka);
                        commandSastojak.Parameters.AddWithValue("@Mera", sastojak.mera);

                        int idSastojka = Convert.ToInt32(commandSastojak.ExecuteScalar());

                        Stavka stavka = stavke[i];
                        string queryStavka = "INSERT INTO Stavke (kolicina, id_recepta, id_sastojka) VALUES (@Kolicina, @IdRecepta, @IdSastojka)";
                        SqlCommand commandStavka = new SqlCommand(queryStavka, connection, transaction);
                        commandStavka.Parameters.AddWithValue("@Kolicina", stavka.kolicina);
                        commandStavka.Parameters.AddWithValue("@IdRecepta", idRecepta);
                        commandStavka.Parameters.AddWithValue("@IdSastojka", idSastojka);

                        commandStavka.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    Console.WriteLine("Greška prilikom unosa recepta: " + ex.Message);
                    return false;
                }
            }
        }

        public int UpdateRecept(Recept recept)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Recepti SET naziv=@naziv, opis=@opis, " +
                                         "komentar=@komentar, ocena=@ocena, id_korisnika=@id_korisnika " +
                                         "WHERE id=@id";

                sqlCommand.Parameters.AddWithValue("@id", recept.Id);
                sqlCommand.Parameters.AddWithValue("@naziv", recept.Naziv);
                sqlCommand.Parameters.AddWithValue("@opis", recept.Opis);
                sqlCommand.Parameters.AddWithValue("@komentar", recept.Komentar);
                sqlCommand.Parameters.AddWithValue("@ocena", recept.Ocena);
                sqlCommand.Parameters.AddWithValue("@id_korisnika", recept.Id_korisnika);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

       
        public List<Recept> GetReceptByNaziv(string naziv)
        {
            List<Recept> recepti = new List<Recept>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Recepti WHERE Naziv = @Naziv";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Naziv", naziv);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recept recept = new Recept();
                            recept.Id = Convert.ToInt32(reader["Id"]);
                            recept.Naziv = reader["Naziv"].ToString();
                            recepti.Add(recept);
                        }
                    }
                }
            }
            return recepti;
        }


    }
}
