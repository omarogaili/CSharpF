using System.Reflection;

namespace LinqAndExtensions
{
    internal class Roster
    {
        public List<Student> Students { get; private set; }

        public Roster()
        {
            var dataFile = Path.Combine(new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .Parent.Parent.Parent.Parent
                .FullName,
                "StudentData.json");
            var data = File.ReadAllText(dataFile);
            Students = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(data);
        }
    }
}
