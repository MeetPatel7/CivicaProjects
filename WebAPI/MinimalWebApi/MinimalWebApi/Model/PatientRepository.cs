using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDemo.Model
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext db;

        public PatientRepository(PatientDbContext db)
        {
            this.db = db;
        }

        public List<Patient> GetPatient() => db.Patient.ToList();

        public Patient PutPatient(Patient patient)
        {
            db.Patient.Update(patient);
            db.SaveChanges();
            return db.Patient.Where(x => x.Id == patient.Id).FirstOrDefault();
        }

        public List<Patient> AddPatient(Patient patient)
        {
            db.Patient.Add(patient);
            db.SaveChanges();
            return db.Patient.ToList();
        }

        public Patient GetPatientById(int Id)
        {
            return db.Patient.Where(x => x.Id == Id).FirstOrDefault();
        }

    }
}
