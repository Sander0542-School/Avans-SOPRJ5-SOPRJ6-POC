using Bogus;
using BumboPOC.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BumboPOC.Web.Data
{
    public class Faker
    {
        public static void UpdateData(int count)
        {
            var users = new List<User>();
            var calendars = new List<Calendar>();
            var workedHours = new List<WorkedHours>();

            var faker = new Bogus.Faker("nl");
            var random = new Random();

            int workedHoursCount = 0;

            for (int i = 0; i < count; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = faker.Name.FullName(),
                    Afdeling = faker.PickRandom<Afdeling>(),
                    KPU = random.Next(500, 1300) / 100
                });

                for (int j = 1; j <= 28; j++)
                {
                    if (random.Next(4) == 0)
                    {
                        var date = new DateTime(2020, 1, j);
                        var startTime = new TimeSpan(random.Next(7, 17), 0, 0);
                        var endTime = startTime.Add(new TimeSpan(0, 15 * random.Next(12, 24), 0));

                        calendars.Add(new Calendar
                        {
                            Id = ++workedHoursCount,
                            UserId = i,
                            Date = date,
                            StartTime = startTime,
                            EndTime = endTime
                        });

                        workedHours.Add(new WorkedHours
                        {
                            Id = workedHoursCount,
                            UserId = i,
                            Date = date,
                            StartTime = startTime,
                            EndTime = endTime.Add(new TimeSpan(0, 0, random.Next(0, 4) * 15, 0))
                        });
                    }
                }
            }

            var usersString = JsonSerializer.Serialize(users);
            var calendarString = JsonSerializer.Serialize(calendars);
            var workedHoursString = JsonSerializer.Serialize(workedHours);

            var dataFolder = Path.Combine(Environment.CurrentDirectory, "Data/JSON");

            File.WriteAllText(Path.Combine(dataFolder, "Users.json"), usersString);
            File.WriteAllText(Path.Combine(dataFolder, "Calendar.json"), calendarString);
            File.WriteAllText(Path.Combine(dataFolder, "WorkedHours.json"), workedHoursString);
        }
    }
}
