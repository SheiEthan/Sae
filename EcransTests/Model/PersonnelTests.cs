using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ecrans.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Ecrans.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NomNull()
        {
            Personnel nomnull = new Personnel(1, "ethan.tillier@gmail.com", "", "Ethan");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PrenomNull()
        {
            Personnel prenomnull = new Personnel(1, "ethan.tillier@gmail.com", "Tillier", "");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void emailnull()
        {
            Personnel prenomnull = new Personnel(1, "", "Tillier", "Ethan");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void emailfausse()
        {
            Personnel prenomnull = new Personnel(1, "ethan.tillier:gmail,ok", "Tillier", "Ethan");
        }

        [TestMethod()]
        public void CreateTest()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into personnel(idpersonnel, emailPersonnel, nomPersonnel, prenomPersonnel) values ('100','ethan.tillier@gmail.com','Tillier','Ethan') ;";
            accesBD.SetData(requete);
            requete = $"select idpersonnel from personnel where emailpersonnel = 'ethan.tillier@gmail.com'";
            accesBD.GetData(requete);
            Assert.AreEqual(100, int.Parse(accesBD.GetData(requete).Rows[0]["idpersonnel"].ToString()));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void ReadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }


    }
}