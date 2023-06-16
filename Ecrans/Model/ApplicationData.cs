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
        }
    }
}
