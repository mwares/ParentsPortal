using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsPortal.Data.Model
{
    public class ParentsPortalService : ModelBase, IParentsPortalService
    {
        public async Task<IList<Person>> GetChildren(Person parent)
        {
            try
            {
//                var query = ParseObject.GetQuery("Person");                
                var query = from person in ParseObject.GetQuery("Person")
                            where person.Get<string>("objectId") == "WolywqVi87"
                            select person;
                
                ParseObject parentParseObject = await query.FirstAsync();

                ParseRelation<ParseObject> relation = parentParseObject.GetRelation<ParseObject>("PersonLink");

                IEnumerable<ParseObject> ChildrenParseObject = await relation.Query.FindAsync();
                List<Person> children = new List<Person>();
                foreach (var parseObject in ChildrenParseObject)
                {
                    Person p = await GetPersonFromParseObject(parseObject);
                    children.Add(p);                
                }

                return children;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<Person> GetPersonFromParseObject(ParseObject personParse)
        {
            Person p = new Person();
            try
            {
                p.PersonId = personParse.ObjectId;
                p.Forename = (await GetParseObject(personParse, "String", "Forename")).ToString();
                p.Surname = (await GetParseObject(personParse, "String", "Surname")).ToString();
                //p.DateOfBirth = (DateTime)(await GetParseObject(pupilParse, "DateTime", "DOB"));
                //p.Image = (await GetParseObject(pupilParse, "ParseFile", "Photo") != null) ? pupilParse.Get<ParseFile>("Photo") : await GetDefaultImage();
                //if (p.Image != null)
                //    p.ImageLocation = p.Image.Url;
            }
            catch 
            {

            }

            return p;
        }
    }
}
