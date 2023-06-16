using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecrans.Model
{
    public class Est_Attribue : Crud<Est_Attribue>
    {
        public int FK_IdPersonnel { get; set; }
        public int FK_IdMateriel { get; set; }
        public DateTime DateAttribution { get; set; }
        public string CommentaireAttribution { get; set; }
        public Materiel UnMateriel { get; set; }
        public Personnel UnPersonnel { get; set; }
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
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
