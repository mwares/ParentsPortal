using GalaSoft.MvvmLight;
using ParentsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsPortal.Data.ViewModel
{
    public class ParentsPortalViewModel : ViewModelBase
    {
        private readonly IParentsPortalService _parentsPortalService;

        public Person Person
        {
            get;
            private set;
        }

        public ParentsPortalViewModel(IParentsPortalService parentsPortalService, Person person)
        {
            _parentsPortalService = parentsPortalService;
            Person = person;
        }
    }
}
