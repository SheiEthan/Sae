using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecrans.Model

/// <summary>
/// Stocke 4 informations :
/// 3 chaines : l'email,le nom et le prenom
/// 1 entier :  l'id
/// </summary>
{
    public class Personnel : Crud<Personnel>
    {
        /// <summary>
        /// Permet d'instancier un personnel sans rien
        /// </summary>
        public Personnel()
        {
        }
        /// <summary>
        /// Permet d'instancier un personnel 
        /// </summary>

        public Personnel(int idPersonnel, string emailPersonnel, string nomPersonnel, string prenomPersonnel)
        {
            this.IdPersonnel = idPersonnel;
            this.EmailPersonnel = emailPersonnel;
            this.NomPersonnel = nomPersonnel;
            this.PrenomPersonnel = prenomPersonnel;
        }

        public int IdPersonnel { get; set; }
        private string emailPersonnel;
        private string nomPersonnel;
        private string prenomPersonnel;
        public ObservableCollection<Est_Attribue> LesAttributions { get; set; }

        /// <summary>
        /// Obtient ou définit l'email –
        /// L'email doit avoir un @ et finir par un .com,net ou fr
        /// </summary>
        /// <exception cref="ArgumentException">  si l'email n'est pas conforme </exception>
        public string? EmailPersonnel
        {
            get
            {
                return emailPersonnel;
            }

            set
            {
                string regex = @"^[^@\s]+@[^@\s]+\.(com|net|fr)$";
                if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                    throw new ArgumentException("Le mail doit être remplie ou correct");
                emailPersonnel = value;
            }
        }
        /// <summary>
        /// Obtient ou définit le nom –
        /// ne peut pas etre null ou vide
        /// </summary>
        /// <exception cref="ArgumentException">  si le nom est vide ou null </exception>
        public string? NomPersonnel
        {
            get
            {
                return nomPersonnel;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Le nom du personnel doit être remplie !");
                nomPersonnel = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower(); ;
            }
        }
        // <summary>
        /// Obtient ou définit le prenom –
        /// ne peut pas etre null ou vide
        /// </summary>
        /// <exception cref="ArgumentException">  si le prenom est vide ou null </exception>
        public string? PrenomPersonnel
        {
            get
            {
                return prenomPersonnel;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Le prénom du personnel doit être remplie !");
                prenomPersonnel = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower(); ;
            }
        }

        /// <summary>
        /// Permet d'inserer des données dans la table personnel 
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into personnel(emailPersonnel, nomPersonnel, prenomPersonnel) values ('" + this.EmailPersonnel + "','" + this.NomPersonnel + "','" + this.PrenomPersonnel + "') ;";
            accesBD.SetData(requete);
            requete = $"select idpersonnel from personnel where emailpersonnel = '{this.EmailPersonnel}'";
            this.IdPersonnel = int.Parse(accesBD.GetData(requete).Rows[0]["idpersonnel"].ToString());
        }
        /// <summary>
        /// Permet de supprimer des données dans la table personnel 
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "DELETE FROM personnel WHERE idpersonnel='" + this.IdPersonnel + "';";
            accesBD.SetData(requete);
        }
        /// <summary>
        /// regenere des données dans la table personnel 
        /// </summary>
        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idPersonnel, emailPersonnel, nomPersonnel, prenomPersonnel from personnel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel p = new Personnel(int.Parse(row["idPersonnel"].ToString()), (String)row["emailPersonnel"], (String)row["nomPersonnel"], (String)row["prenomPersonnel"]);
                    lesPersonnels.Add(p);
                }
            }
            return lesPersonnels;
        }

        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Permet de mettr eà jour des données dans la table personnel 
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "Update personnel SET nompersonnel='" + this.NomPersonnel + "', prenompersonnel='" + this.PrenomPersonnel + "', emailpersonnel='" + this.EmailPersonnel + "' where idPersonnel='" + this.IdPersonnel + "';";
            accesBD.SetData(requete);
        }
        public override string ToString()
        {
            return this.NomPersonnel + " " + this.PrenomPersonnel;
        }
    }
}