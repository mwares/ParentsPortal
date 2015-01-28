using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataCreater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Go_Click(object sender, RoutedEventArgs e)
        {
            //                var query = ParseObject.GetQuery("Person");                
            //var query = from person in ParseObject.GetQuery("Person")
            //            where person.Get<string>("objectId") == "S4CpcJ8Yyu"
            //            select person;
//
            //IEnumerable<ParseObject> Parent = await query.FindAsync();


            ParseObject parent = new ParseObject("Person");
            parent["Forename"] = "Mark";
            parent["Surname"] = "Wares";
            parent["PersonTypeId"] = 1;

            ParseObject child1 = new ParseObject("Person");
            child1["Forename"] = "Chloe";
            child1["Surname"] = "Wares";
            child1["PersonTypeId"] = 2;
            await child1.SaveAsync();

            ParseObject child2 = new ParseObject("Person");
            child2["Forename"] = "Chloe";
            child2["Surname"] = "Wares";
            child2["PersonTypeId"] = 2;
            await child2.SaveAsync();

            ParseRelation<ParseObject> relation = parent.GetRelation<ParseObject>("PersonLink");
            relation.Add(child1);
            relation.Add(child2);

            await parent.SaveAsync();





            //    List<Person> children = new List<Person>();
            //    foreach (var parseObject in results)
            //    {
            //        Person p = await GetPersonFromParseObject(parseObject);
            //        children.Add(p);                
            //    }


            //// Create the post
            //var myPost = new ParseObject("Post")
            //{
            //    { "title", "I'm Hungry" },
            //    { "content", "Where should we go for lunch?" }    
            //};

            //// Create the comment
            //var myComment = new ParseObject("Comment")
            //{
            //    { "content", "Let's do Sushirrito." }
            //};

            //// Add a relation between the Post and Comment
            //myComment["parent"] = myPost;

            //// This will save both myPost and myComment
            //await myComment.SaveAsync();
            //You can also link objects using just their ObjectIds like so:

            //myComment["parent"] = ParseObject.CreateWithoutData("Post", "1zEcyElZ80");
        }

        private async void GetKids_Click(object sender, RoutedEventArgs e)
        {
            var query = from person in ParseObject.GetQuery("Person")
                        where person.Get<string>("objectId") == "WolywqVi87"
                        select person;

            ParseObject obj = await query.FirstAsync();
            
            ParseRelation<ParseObject> relation = obj.GetRelation<ParseObject>("PersonLink");

            //var kidsQuery = relation.Query;
            IEnumerable<ParseObject> ParseLearners = await relation.Query.FindAsync();

            
        }
    }
}
