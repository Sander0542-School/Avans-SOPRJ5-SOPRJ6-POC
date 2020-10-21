﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BumboPOC.Web.Data.Models
{
    public class WorkedHours
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        [JsonConverter(typeof(JsonTimeSpanConverter))]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan StartTime { get; set; }

        [JsonConverter(typeof(JsonTimeSpanConverter))]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan EndTime { get; set; }

        public TimeSpan Duration()
        {
            return EndTime.Subtract(StartTime);
        }

        public static WorkedHours Get(int id)
        {
            return All().Find(wh => wh.Id == id);
        }

        public static List<WorkedHours> All()
        {
            var jsonFile = Path.Combine(Environment.CurrentDirectory, "Data/JSON/WorkedHours.json");
            var jsonString = File.ReadAllText(jsonFile);

            return JsonSerializer.Deserialize<List<WorkedHours>>(jsonString);
        }
    }
}
