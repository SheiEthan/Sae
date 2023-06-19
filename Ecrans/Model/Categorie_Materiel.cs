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
        public string NomCategorie { get; set; }
        public ObservableCollection<Materiel> Materiels { get; set; }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into categorie_materiel(nomcategorie) values ('"+this.NomCategorie+"') ;";
            accesBD.SetData(requete);
            requete = $"select idcategorie from categorie_materiel where nomcategorie = '{this.NomCategorie}'";
            this.IdCategorie = int.Parse(accesBD.GetData(requete).Rows[0]["idcategorie"].ToString());
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "DELETE FROM categorie_materiel WHERE idcategorie='"+ this.IdCategorie+"';";
            accesBD.SetData(requete);
        }

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
