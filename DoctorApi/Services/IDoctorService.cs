using System;
using DoctorApi.Models;

namespace DoctorApi.Services
{
    public interface IDoctorService
    {
        IList<Doctor> GetDoctors();
    }
}

