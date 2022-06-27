using System;
using SampleApp.Models;

namespace SampleApp.Services
{
    public interface IDoctorService
    {
        Task<IList<Doctor>> GetDoctors();
    }
}

