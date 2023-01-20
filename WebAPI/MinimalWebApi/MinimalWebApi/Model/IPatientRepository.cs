using System.Collections.Generic;

namespace MiniDemo.Model
{
    public interface IPatientRepository
    {
        List<Patient> AddPatient(Patient patient);
        List<Patient> GetPatient();
        Patient PutPatient(Patient patient);
        Patient GetPatientById(int id);
    }
}