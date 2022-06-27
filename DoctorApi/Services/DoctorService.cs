using System;
using DoctorApi.Data;
using DoctorApi.Models;

namespace DoctorApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorContext _context;

        public DoctorService(DoctorContext doctorContext)
        {
            this._context = doctorContext;
        }

        public IList<Doctor> GetDoctors()
        {

            return this._context.Doctor.ToList();
        }
    }
}

