using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecrans.Model
{
    public class Est_Attribue : Crud<Est_Attribue>
    {
        public int FK_IdPersonnel { get; set; }
        public int FK_IdMateriel { get; set; }
        public DateTime DateAttribution { get; set; }
        private string commentaireAttribution;
        private Materiel unMateriel;
        private Personnel unPersonnel;

        public string? CommentaireAttribution
        {
            get
            {
                return commentaireAttribution;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Erreur, le commentaire de l'attribution doit être inscrit !");
                commentaireAttribution = value;
            }
        }

        public Materiel UnMateriel
        {
            get
            {
                return unMateriel;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException("Erreur, un materiel doit être selectionné !");
                unMateriel = value;
            }
        }

        public Personnel UnPersonnel
        {
            get
            {
                return unPersonnel;
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException("Erreur, un personnel doit être selectionné !");
                unPersonnel = value;
            }
        }

        public Est_Attribue()
        {
        }
        public Est_Attribue(int fK_IdPersonnel, int fK_IdMateriel, DateTime dateAttribution, string commentaireAttribution)
        {
            this.FK_IdPersonnel = fK_IdMateriel;
            this.FK_IdMateriel = fK_IdMateriel;
            this.DateAttribution = dateAttribution;
            this.CommentaireAttribution = commentaireAttribution;
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into est_attribue(idpersonnel, idmateriel, dateattribution, commentaireattribution)  values ('" + this.UnPersonnel.IdPersonnel + "','" + this.UnMateriel.IdMateriel + "','" + this.DateAttribution + "','" + this.CommentaireAttribution + "');";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = " delete from est_attribue where idmateriel= "+this.UnMateriel.IdMateriel+" and dateattribution ='"+this.DateAttribution+"' and idpersonnel="+this.UnPersonnel.IdPersonnel;
            accesBD.GetData(requete);
        }

        public ObservableCollection<Est_Attribue> FindAll()
        {
            ObservableCollection<Est_Attribue> Est_Attribues = new ObservableCollection<Est_Attribue>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idPersonnel, idMateriel, dateAttribution, commentaireAttribution from est_attribue ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Est_Attribue e = new Est_Attribue(int.Parse(row["idPersonnel"].ToString()), int.Parse(row["idMateriel"].ToString()), (DateTime)row["dateAttribution"], (String)row["commentaireAttribution"]);
                    Est_Attribues.Add(e);
                }
            }
            return Est_Attribues;
        }

        public ObservableCollection<Est_Attribue> FindBySelection(string criteres)
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
            String requete = "update est_attribue set idpersonnel="+this.UnPersonnel.IdPersonnel+", idmateriel ="+this.UnMateriel.IdMateriel+", dateattribution ='"+this.DateAttribution+"', commentaireattribution ='"+this.CommentaireAttribution+"' where idmateriel= "+this.UnMateriel.IdMateriel+" and dateattribution ='"+this.DateAttribution+"' and idpersonnel="+this.UnPersonnel.IdPersonnel;
            accesBD.SetData(requete);
        }
    }
}
