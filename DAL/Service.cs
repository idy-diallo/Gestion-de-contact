using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;
namespace DAL
{
    public class Service
    {
        private static String connectionString =
                @"Data Source=*\SQLEXPRESS;
                Initial Catalog=TPGroup2;
                Integrated Security=True;
                Connect Timeout=5";

        

        public static bool VerifierConnexion(string name, string passw) {
            Service.connectionString = Service.connectionString.Replace("*", Environment.MachineName);
            bool estTrouver = false;
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT *
                      FROM Users
                      WHERE Username = '" + name + "' AND Passwor = '" + passw + "'";

                SqlDataReader res = cmd.ExecuteReader();

                estTrouver = res.Read() ? true : false;
            }


            return estTrouver;
        }

        public static List<Contacts> Afficher() {
            List<Contacts> contact = new List<Contacts>();
            Service.connectionString = Service.connectionString.Replace("*", Environment.MachineName);
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand()) {

                    cmd.CommandText = "select Id,Prenom,Nom,Tel,Favorie from Contacts ";

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Contacts con = new Contacts();
                            con.Id = reader.GetInt32(0);
                            con.Prenom = reader.GetString(1);
                            con.Nom = reader.GetString(2);
                            con.Tel = reader.GetString(3);
                            con.Favorie = reader.GetBoolean(4);
                            contact.Add(con);
                        }
                    }

                }
            }
            return contact;
        }

        public static bool AjouterContact(Contacts contacts) {
            bool estAjouter = false;
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = @"insert into Contacts(Prenom, Nom, Tel, Favorie) values(@prenom, @nom, @tel, @favorie)";

                    cmd.Parameters.AddWithValue("@prenom", contacts.Prenom);
                    cmd.Parameters.AddWithValue("@nom", contacts.Nom);
                    cmd.Parameters.AddWithValue("@tel", contacts.Tel);
                    if (contacts.Favorie != null) {
                        cmd.Parameters.AddWithValue("@favorie", contacts.Favorie);
                    }
                    else {
                        cmd.Parameters.AddWithValue("@favorie", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    estAjouter = true;
                }
            }
            return estAjouter;
        }

        public static void Supprimer(string s) {
            Service.connectionString = Service.connectionString.Replace("*", Environment.MachineName);
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM Contacts WHERE nom = '"+s+"'";

                SqlDataReader res = cmd.ExecuteReader();
            }

        }

        public static void Editer(string s, string t, string b, bool fav) {
            Service.connectionString = Service.connectionString.Replace("*", Environment.MachineName);
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = "update Contacts Set Prenom = '"+t+"',Tel = '"+b+"',Favorie = '"+fav+"' where nom = '"+s+"'";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Contacts> Regroupement_Multicritere(int sortBy) {
            List<Contacts> contact = new List<Contacts>();
            Service.connectionString = Service.connectionString.Replace("*", Environment.MachineName);
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand()) {
                    switch (sortBy) {
                        case 1:
                            cmd.CommandText = @"select Id,Prenom,Nom,Tel,Favorie
                                                            from Contacts
                                                            order by Nom asc";
                            break;
                        
                        case 2:
                            cmd.CommandText = @"select Id,Prenom,Nom,Tel,Favorie
                                                            from Contacts
                                                            where Favorie = 'true'";
                            break;
                        default:
                            break;
                    }



                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Contacts con = new Contacts();
                            con.Id = reader.GetInt32(0);
                            con.Prenom = reader.GetString(1);
                            con.Nom = reader.GetString(2);
                            con.Tel = reader.GetString(3);
                            con.Favorie = reader.GetBoolean(4);
                            contact.Add(con);
                        }
                    }

                }
            }
            return contact;
        }

        public static List<Contacts> ChercherContactsParPrenom(string prenom) {
            List<Contacts> liste = new List<Contacts>();
            /*
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT *
                      FROM Contacts
                      WHERE prenom LIKE '" + prenom + "%'";
                cmd.Parameters.AddWithValue("prenom", prenom);

                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read()) {
                    Contacts contacts = new Contacts();

                    contacts.Id = res.GetInt32(0);
                    contacts.Prenom = res.GetString(1);
                    contacts.Nom = res.GetString(2);
                    contacts.Tel = res.GetString(3);
                    contacts.Favorie = res.IsDBNull(4) ? null : (bool?)res.GetBoolean(4);

                    liste.Add(contacts);
                }
            }*/

            return liste;
        }

        //Méthode pour rechercher un contact par nom
        public static List<Contacts> ChercherContactsParNom(string nom) {
            List<Contacts> liste = new List<Contacts>();
            /*
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT *
                      FROM Contacts
                      WHERE nom LIKE '" + @nom + "%'";
                cmd.Parameters.AddWithValue("nom", nom);

                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read()) {
                    Contacts contacts = new Contacts();

                    contacts.Id = res.GetInt32(0);
                    contacts.Prenom = res.GetString(1);
                    contacts.Nom = res.GetString(2);
                    contacts.Tel = res.GetString(3);
                    contacts.Favorie = res.IsDBNull(4) ? null : (bool?)res.GetBoolean(4);

                    liste.Add(contacts);
                }
            }
            */
            return liste;
        }

        //Méthode pour rechercher un contact sans critère
        public static List<Contacts> ChercherContacts(string chaineRecherchee) {
            List<Contacts> liste = new List<Contacts>();
            /*
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT *
                      FROM Contacts
                      WHERE prenom LIKE '" + @chaineRecherchee + "%' OR nom LIKE '" + @chaineRecherchee + "%'";
                cmd.Parameters.AddWithValue("chaineRecherchee", chaineRecherchee);

                SqlDataReader res = cmd.ExecuteReader(); //  envoyer la requete sur la connexion
                while (res.Read()) { //  parcours des lignes
                    Contacts contacts = new Contacts();

                    contacts.Id = res.GetInt32(0);
                    contacts.Prenom = res.GetString(1);
                    contacts.Nom = res.GetString(2);
                    contacts.Tel = res.IsDBNull(3) ? null : (string)res.GetString(3);
                    contacts.Favorie = res.IsDBNull(4) ? null : (bool?)res.GetBoolean(4);

                    liste.Add(contacts);
                }
            }   //  deconnexion ici*/
            
            return liste;
        }
    }
}
