using HospitalManagement.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Abstraction
{
    public interface IPatientRepository
    {
        public IEnumerable<Patient> GetPatient();

        public int AddPatient(Patient patient);

        public int UpdatePatient(Patient patient);

        public int DeletePatient(int id);

        public Patient GetByIdPatient(int id);
    }
}
