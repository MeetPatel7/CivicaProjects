using HospitalManagement.Business.Abstraction;
using HospitalManagement.Business.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Client.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientRepository _Repository; 
        public PatientController(IPatientRepository repository)
        {
            _Repository = repository; 
        }

        [HttpGet]

        public IEnumerable<Patient> Index() 
        {
            return _Repository.GetPatient();
        }

        [HttpPost]

        public int Create([FromBody] Patient Patient)
        {
            return _Repository.AddPatient(Patient); 
        }

        [HttpGet]

        public Patient Details(int id) 
        {
            return _Repository.GetByIdPatient(id);
        }
        [HttpPut]

        public int Edit([FromBody] Patient Patient) 
        { 
            return _Repository.UpdatePatient(Patient); 
        }

        [HttpDelete]

        public int Delete(int id) 
        {
            return _Repository.DeletePatient(id); 
        }


    }
}
