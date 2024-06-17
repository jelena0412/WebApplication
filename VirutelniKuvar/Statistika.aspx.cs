using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace VirutelniKuvar
{
    public partial class Statistika : Page
    {
        protected int GetBrojRegistrovanihKorisnika()
        {
            int brojKorisnika = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Korisnici";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    brojKorisnika = (int)command.ExecuteScalar();
                }
            }

            return brojKorisnika;
        }

        protected double GetProsecnaOcenaRecepata()
        {
            double prosecnaOcena = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT AVG(Ocena) FROM Recepti";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        prosecnaOcena = Convert.ToDouble(result);
                    }
                }
            }

            return prosecnaOcena;
        }

        protected List<string> GetNajpopularnijiRecepti()
        {
            List<string> recepti = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT TOP 5 Naziv FROM Recepti GROUP BY Naziv ORDER BY max(Ocena) DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            recepti.Add(reader["Naziv"].ToString());
                        }
                    }
                }
            }

            return recepti;
        }
    }
}
