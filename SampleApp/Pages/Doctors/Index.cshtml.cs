using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApp.Models;
using SampleApp.Services;

namespace SampleApp.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly IDoctorService doctorService;

        public IndexModel(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public IList<Doctor> Doctors { get;set; } = default!;

        public async Task OnGetAsync()
        {
             this.Doctors = await this.doctorService.GetDoctors();
        }
    }
}
