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

        public string FullName
        {
            get { return string.Format("Dr. {0} {1}", this.FirstName, this.LastName); }
        }

        [DisplayName("Specialty")]
        public string Specialty
        {
            get { return "Family Practice"; }
        }

        [DisplayName("Accepting New Patients?")]
        public string IsAcceptingNewPatients
        {
            get { return "Yes"; }
        }

        [DisplayName("Phone Number")]
        public string PhoneNumber
        {
            get { return "(555)867-5309"; }
        }
    }
}

