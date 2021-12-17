using System;

namespace RocketApi.Models
{
    public class interventions
    { 
        public long id { get; set; }

        public long author_id { get; set; }
        public long customer_id { get; set; }
        public long? employee_id { get; set; }
        public long building_id { get; set; }
        public long battery_id { get; set; }
        public long? column_id { get; set; }
        public long? elevator_id { get; set; }
        public DateTime? started_at { get; set; }
        public DateTime? ended_at { get; set; }
        public string result { get; set; }
        public string report { get; set; }
        public string status { get; set; }
    }
}