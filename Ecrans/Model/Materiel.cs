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
    public class Materiel : Crud<Materiel>
    {
        public int IdMateriel { get; set; }
        public int FK_IdCategorie { get; set; }
        private string nomMateriel;
        private string referenceConstructeurMateriel;
        private string codeBarreInventaire;
        public Categorie_Materiel UneCategorie { get; set; }
        public ObservableCollection<Est_Attribue> LesAttributions { get; set; }

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

        public Materiel()
        {
        }

        public Materiel(int idMateriel, int fK_IdCategorie, string nomMateriel, string referenceConstructeurMateriel, string codeBarreInventaire)
        {
            this.IdMateriel = idMateriel;
            this.FK_IdCategorie = fK_IdCategorie;
            this.NomMateriel = nomMateriel;
            this.ReferenceConstructeurMateriel = referenceConstructeurMateriel;
            this.CodeBarreInventaire = codeBarreInventaire;
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into materiel(nommateriel, referenceconstructeurmateriel,codebarreinventaire,idcategorie)  values ('" + this.NomMateriel + "','" + this.ReferenceConstructeurMateriel + "','" + this.CodeBarreInventaire + "','" + this.UneCategorie.IdCategorie + "');";
            accesBD.SetData(requete);
            requete = $"select idmateriel from materiel where referenceconstructeurmateriel = '{this.ReferenceConstructeurMateriel}'";
            this.IdMateriel = int.Parse(accesBD.GetData(requete).Rows[0]["idmateriel"].ToString());
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "DELETE FROM materiel WHERE idmateriel='" + this.IdMateriel + "'";
            accesBD.GetData(requete);
        }

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
