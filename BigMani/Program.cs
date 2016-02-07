using BigMani.Core;
using BigMani.Core.Modules;
using BigMani.Core.UI;
using BigMani.Data_Layer;
using BigMani.Interfaces;
using BigMani.Models;

namespace BigMani
{

    public class Program
    {
        public static void Main()
        {
            var db = new ConditionerData();
            var engine = new Engine(new ConsoleUserInterface(), new Controller(new ConsoleUserInterface(), db, new RegisterModule(db),
                new TestingModule(db), new SearchingModule(db), new ValidityModule(), new StatusModule(db)));
            engine.Run();
        }
    }
}
