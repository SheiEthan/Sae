using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecrans.Model
{
    public class Personnel : Crud<Personnel>
    {
        public Personnel()
        {
        }

        public Personnel(int idPersonnel, string emailPersonnel, string nomPersonnel, string prenomPersonnel)
        {
            this.IdPersonnel = idPersonnel;
            this.EmailPersonnel = emailPersonnel;
            this.NomPersonnel = nomPersonnel;
            this.PrenomPersonnel = prenomPersonnel;
        }

        public int IdPersonnel { get; set; }
        public string EmailPersonnel { get; set; }
        public string NomPersonnel { get; set; }
        public string PrenomPersonnel { get; set; }
        public ObservableCollection<Est_Attribue> LesAttributions { get; set; }
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into personnel(emailPersonnel, nomPersonnel, prenomPersonnel) values ('" + this.EmailPersonnel +"','"+this.NomPersonnel+"','"+this.PrenomPersonnel+"') ;";
            accesBD.SetData(requete);
            requete = $"select idpersonnel from personnel where emailpersonnel = '{this.EmailPersonnel}'";
            this.IdPersonnel = int.Parse(accesBD.GetData(requete).Rows[0]["idpersonnel"].ToString());
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "DELETE FROM personnel WHERE idpersonnel='" + this.IdPersonnel + "';";
            accesBD.GetData(requete);
        }

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

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "Update personnel SET nompersonnel='" + this.NomPersonnel + "', prenompersonnel='" + this.PrenomPersonnel + "', emailpersonnel='" + this.EmailPersonnel+"' where idPersonnel='" + this.IdPersonnel + "';";
            accesBD.SetData(requete);
        }
        public override string ToString()
        {
            return this.NomPersonnel + " " + this.PrenomPersonnel;
        }
    }
}
