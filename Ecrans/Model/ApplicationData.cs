using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecrans.Model
{
    public class ApplicationData
    {
        public ObservableCollection<Est_Attribue> Est_Attribues { get; set; }
        public ObservableCollection<Categorie_Materiel> Categorie_Materiels { get; set; }
        public ObservableCollection<Materiel> Materiels { get; set; }
        public ObservableCollection<Personnel> Personnels { get; set; }
        public ApplicationData()
        {
            Est_Attribue e = new Est_Attribue();
            Est_Attribues = e.FindAll();

            Categorie_Materiel cm = new Categorie_Materiel();
            Categorie_Materiels = cm.FindAll();

            Materiel m = new Materiel();
            Materiels = m.FindAll();

            Personnel p = new Personnel();
            Personnels = p.FindAll();

            foreach (Materiel unMate in Materiels.ToList())
            {
                unMate.UneCategorie = Categorie_Materiels.ToList().Find(c => c.IdCategorie == unMate.FK_IdCategorie);
            }

            foreach (Categorie_Materiel uneCate in Categorie_Materiels.ToList())
            {
                uneCate.Materiels = new ObservableCollection<Materiel>(Materiels.ToList().FindAll(m => m.FK_IdCategorie == uneCate.IdCategorie));
            }

            // liason attribue a materiel
            foreach (Est_Attribue uneAttribu in Est_Attribues.ToList())
            {
                uneAttribu.UnMateriel = Materiels.ToList().Find(m => m.IdMateriel == uneAttribu.FK_IdMateriel);
            }

            foreach (Materiel unMate in Materiels.ToList())
            {
                unMate.LesAttributions = new ObservableCollection<Est_Attribue>(Est_Attribues.ToList().FindAll(a => a.FK_IdMateriel == unMate.IdMateriel));
            }

            // liason attribue a personnel
            foreach (Est_Attribue uneAttribu in Est_Attribues.ToList())
            {
                uneAttribu.UnPersonnel = Personnels.ToList().Find(p => p.IdPersonnel == uneAttribu.FK_IdPersonnel);
            }

            foreach (Personnel unPerso in Personnels.ToList())
            {
                unPerso.LesAttributions = new ObservableCollection<Est_Attribue>(Est_Attribues.ToList().FindAll(a => a.FK_IdPersonnel == unPerso.IdPersonnel));
            }
        }


    }
}
