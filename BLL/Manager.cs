using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class Manager
    {
        public static List<Contacts> Afficher() {
           return Service.Afficher();
        }

        public static bool VerifierConnexion(string name, string passw) {
            return Service.VerifierConnexion(name, passw);
        }

        public static bool AjouterContact(Contacts contacts) {
            return Service.AjouterContact(contacts);
        }
        public static void Supprimer(String s) {
            Service.Supprimer(s);
        }
        public static void Editer(String s,String t,String b ,bool fav) { 
            Service.Editer(s,t,b,fav);
        }
        public static List<Contacts> Regroupement(int index) {
            return Service.Regroupement_Multicritere(index);
        }
        public static List<Contacts> ChercherContacts(string chaineRecherchee) {
            return Service.ChercherContacts(chaineRecherchee);
            
        }

        //Chercher Contact par prenom
        public static List<Contacts> ChercherContactsParPrenom(string prenom) {
            return Service.ChercherContactsParPrenom(prenom);
            
        }

        //Chercher Contact par nom
        public static List<Contacts> ChercherContactsParNom(string nom) {
            return Service.ChercherContactsParNom(nom);
            
        }
    }
}
