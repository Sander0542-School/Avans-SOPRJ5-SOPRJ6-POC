using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BumboPOC.Web.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Afdeling Afdeling { get; set; }
        public double KPU { get; set; }
        public IEnumerable<Calendar> Calendars()
        {
            return Calendar.All().Where(c => c.UserId == Id);
        }
        public IEnumerable<WorkedHours> WorkedHours()
        {
            return Models.WorkedHours.All().Where(c => c.UserId == Id);
        }

        public static User Get(int id)
        {
            return All().Find(wh => wh.Id == id);
        }

        public static List<User> All()
        {
            var jsonFile = Path.Combine(Environment.CurrentDirectory, "Data/JSON/Users.json");
            var jsonString = File.ReadAllText(jsonFile);

            return JsonSerializer.Deserialize<List<User>>(jsonString);
        }
    }

    public enum Afdeling
    {
        Vulploeg,
        Kassa,
        Teamleider
    }
}
