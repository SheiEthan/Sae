using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ecrans.Model;

namespace Ecrans.Model
{
    /// <summary>
    /// Stocke 5 informations :
    /// 3 chaines : nom,la reference et le code barre
    /// 1 entier :  l'id et la clé etrangere 
    /// </summary>
    public class Materiel : Crud<Materiel>
    {
        public int IdMateriel { get; set; }
        public int FK_IdCategorie { get; set; }
        private string nomMateriel;
        private string referenceConstructeurMateriel;
        private string codeBarreInventaire;
        public Categorie_Materiel UneCategorie { get; set; }
        public ObservableCollection<Est_Attribue> LesAttributions { get; set; }
        // <summary>
        /// Obtient ou définit le nom –
        /// ne peut pas etre null ou vide
        /// </summary>
        /// <exception cref="ArgumentException">  si le nom est vide ou null </exception>
        public string? NomMateriel
        {
            get
            {
                return nomMateriel;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Erreur, le nom du matériel doit être inscrit !");
                nomMateriel = value;
            }
        }
        // <summary>
        /// Obtient ou définit la reference  –
        /// ne peut pas etre null ou vide
        /// </summary>
        /// <exception cref="ArgumentException">  si la reference est vide ou null </exception>
        public string? ReferenceConstructeurMateriel
        {
            get
            {
                return referenceConstructeurMateriel;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Erreur, la référence matériel doit être inscrit !");
                referenceConstructeurMateriel = value;
            }
        }
        // <summary>
        /// Obtient ou définit le code baree –
        /// ne peut pas etre null ou vide
        /// </summary>
        /// <exception cref="ArgumentException">  si le code barre est vide ou null </exception>
        public string? CodeBarreInventaire
        {
            get
            {
                return codeBarreInventaire;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Erreur, le code barre doit être inscrit !");
                codeBarreInventaire = value;
            }
        }
        /// <summary>
        /// Permet d'instancier un materiel sans rien
        /// </summary>
        public Materiel()
        {
        }
        /// <summary>
        /// Permet d'instancier un materiel 
        /// </summary>
        public Materiel(int idMateriel, int fK_IdCategorie, string nomMateriel, string referenceConstructeurMateriel, string codeBarreInventaire)
        {
            this.IdMateriel = idMateriel;
            this.FK_IdCategorie = fK_IdCategorie;
            this.NomMateriel = nomMateriel;
            this.ReferenceConstructeurMateriel = referenceConstructeurMateriel;
            this.CodeBarreInventaire = codeBarreInventaire;
        }
        /// <summary>
        /// Permet d'inserer des données dans la table materiel 
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into materiel(nommateriel, referenceconstructeurmateriel,codebarreinventaire,idcategorie)  values ('" + this.NomMateriel + "','" + this.ReferenceConstructeurMateriel + "','" + this.CodeBarreInventaire + "','" + this.UneCategorie.IdCategorie + "');";
            accesBD.SetData(requete);
            requete = $"select idmateriel from materiel where referenceconstructeurmateriel = '{this.ReferenceConstructeurMateriel}'";
            this.IdMateriel = int.Parse(accesBD.GetData(requete).Rows[0]["idmateriel"].ToString());
        }
        /// <summary>
        /// Permet de supprimmer des données dans la table materiel
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "DELETE FROM materiel WHERE idmateriel='" + this.IdMateriel + "'";
            accesBD.GetData(requete);
        }
        /// <summary>
        /// Permet de generer les données de la table materiel
        /// </summary>
        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idMateriel, idCategorie, nomMateriel, referenceConstructeurMateriel, codeBarreInventaire from materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["idMateriel"].ToString()), int.Parse(row["idCategorie"].ToString()), (String)row["nomMateriel"], (String)row["referenceConstructeurMateriel"], (String)row["codeBarreInventaire"]);
                    lesMateriels.Add(m);
                }
            }
            return lesMateriels;
        }

        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Permet de modifier des données dans la table materiel
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Update materiel SET nommateriel='{this.NomMateriel}', idcategorie =" + this.UneCategorie.IdCategorie + ", codebarreinventaire ='" + this.CodeBarreInventaire + "', referenceconstructeurmateriel ='" + this.ReferenceConstructeurMateriel + "' " + "where idmateriel=" + this.IdMateriel + "";
            MessageBox.Show(requete);
            accesBD.SetData(requete);
        }
        public override string ToString()
        {
            return this.NomMateriel;
        }
    }
}