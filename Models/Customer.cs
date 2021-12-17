using System;
using System.Collections.Generic;

namespace RocketApi.Models
{
    public class Customer
    {
        public long id { get; set; }
        public long user_id { get; set; }
        public DateTime? customer_creation_date { get; set; }
        public string company_name { get; set; }
        public string company_contact_phone { get; set; }
        public string email_of_the_company_contact { get; set; }
        public string full_name_of_the_company_contact { get; set; }
        public string company_headquarters_address { get; set; }
        public string full_name_of_service_technical_authority { get; set; }
        


    }
}
