using System;

namespace RocketApi.Models
{
  public class Lead
  {
    public long Id { get; set; }
    public string full_name { get; set; }
    public string company_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string project_name { get; set; }
    public string project_description { get; set; }
    public string department_in_charge_of_the_elevators { get; set; }
    public string message { get; set; }
    public DateTime? updated_at { get; set; }
    public DateTime? date_of_creation { get; set; }
    // public long customer_id { get; set; }

  }
}
