using System.ComponentModel;

namespace SampleApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;
    }
}

