using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsPortal.Data.Model
{
    public interface IParentsPortalService
    {
        Task<IList<Person>> GetChildren(Person parent);
    }
}
