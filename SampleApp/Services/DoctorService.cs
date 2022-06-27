using Newtonsoft.Json;
using SampleApp.Models;

namespace SampleApp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IHttpClientFactory clientFactory;

        public DoctorService(IHttpClientFactory httpClientFactory)
        {
            this.clientFactory = httpClientFactory;
        }

        public async Task<IList<Doctor>> GetDoctors()
        {
            var doctors = new List<Doctor>();
            
            var client = this.clientFactory.CreateClient("DoctorClient");

            var response = await client.GetAsync("Doctor");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                doctors = JsonConvert.DeserializeObject<List<Doctor>>(apiResponse);
            }

            if (doctors == null)
                return new List<Doctor>();

            return doctors;
        }
    }
}

