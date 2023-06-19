using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecrans.Model;

namespace Ecrans.Model
{
    /// <summary>
    /// Stocke 2 informations :
    /// 1 chaines : le nom de la catégorie
    /// 1 entier : l'identifiant de la catégorie
    /// </summary>
    public class Categorie_Materiel : Crud<Categorie_Materiel>
    {
        public Categorie_Materiel()
        {
        }

        public Categorie_Materiel(int idCategorie, string nomCategorie)
        {
            this.IdCategorie = idCategorie;
            this.NomCategorie = nomCategorie;
        }

        public int IdCategorie { get; set; }
        private string nomCategorie;
        public ObservableCollection<Materiel> Materiels { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de la catégorie –
        /// Le nom de la catégorie ne doit pas être nul / vide
        /// </summary>
        /// <exception cref="ArgumentNullException"> Envoyée si le nom de la catégorie est nul / vide </exception>
        public string? NomCategorie
        {
            get
            {
                return nomCategorie;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Erreur, le nom de la catégorie ne peut pas être vide !");
                nomCategorie = value;
            }
        }

        /// <summary>
        /// Crée une catégorie de materiel dans la base de donnée
        /// </summary>
        
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into categorie_materiel(nomcategorie) values ('"+this.NomCategorie+"') ;";
            accesBD.SetData(requete);
            requete = $"select idcategorie from categorie_materiel where nomcategorie = '{this.NomCategorie}'";
            this.IdCategorie = int.Parse(accesBD.GetData(requete).Rows[0]["idcategorie"].ToString());
        }

        /// <summary>
        /// Supprime une catégorie de materiel dans la base de donnée
        /// </summary>
        
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "DELETE FROM categorie_materiel WHERE idcategorie='"+ this.IdCategorie+"';";
            accesBD.GetData(requete);
        }

        /// <summary>
        /// Regénère une catégorie de materiel dans la base de donnée
        /// </summary>
        
        public ObservableCollection<Categorie_Materiel> FindAll()
        {
            ObservableCollection<Categorie_Materiel> lesCategoriesMateriels = new ObservableCollection<Categorie_Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idCategorie, nomCategorie from categorie_materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie_Materiel cm = new Categorie_Materiel(int.Parse(row["idCategorie"].ToString()), (String)row["nomCategorie"]);
                    lesCategoriesMateriels.Add(cm);
                }
            }
            return lesCategoriesMateriels;
        }

        public ObservableCollection<Categorie_Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour une catégorie de materiel dans la base de donnée
        /// </summary>
        
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "Update categorie_materiel SET nomCategorie='" + this.NomCategorie + "' where idCategorie='"+this.IdCategorie+"';";
            accesBD.SetData(requete);
        }

        public override string ToString()
        {
            return this.NomCategorie;
        }
    }
}
