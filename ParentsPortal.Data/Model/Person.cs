using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentsPortal.Data.Helpers;


namespace ParentsPortal.Data.Model
{
    public class Person : ObservableObject
    {
        public string PersonId { get; set; }

        //public string Forename { get; set; }

        private string forename;

        public string Forename
        {
            get { return forename; }
            set { forename = value; }
        }
        

        public string Surname { get; set; }

        public string FullName
        {
            get { return this.Forename + " " + this.Surname; }
        }

        public string PersonLinkId { get; set; }

        public string PersonTypeId { get; set; }
    }
}
