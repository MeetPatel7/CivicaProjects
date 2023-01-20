using HospitalManagement.Business.Abstraction;
using HospitalManagement.Business.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class PatientRepository : IPatientRepository
    {
        string connectionString = "Server=IN-LT-17262\\SQL2019;Database=HospitalDB;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public int AddPatient(Patient patient)
        {
            
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddPatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Age", patient.Age);
                    cmd.Parameters.AddWithValue("@MobileNo", patient.MobileNo);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return 1;
            
            
        }

        public int DeletePatient(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeletePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Patient> GetPatient()
        {
            try
            {
                List<Patient> lstPatient = new List<Patient>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("GetPatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Patient patient = new Patient();

                        patient.Id = Convert.ToInt32(rdr["Id"]);
                        patient.Name = rdr["Name"].ToString();
                        patient.Age = Convert.ToInt32(rdr["Age"]);
                        patient.MobileNo =rdr["MobileNo"].ToString();
                       
                        lstPatient.Add(patient);
                    }
                    con.Close();
                }
                return lstPatient;
            }
            catch
            {
                throw;
            }
        }

        public Patient GetByIdPatient(int id)
        {
            try
            {
                Patient patient = new Patient();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM patient WHERE ID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        patient.Id = Convert.ToInt32(rdr["Id"]);
                        patient.Name = rdr["Name"].ToString();
                        patient.Age = Convert.ToInt32(rdr["Age"]);
                        patient.MobileNo = rdr["MobileNo"].ToString();
                    }
                }
                return patient;
            }
            catch
            {
                throw;
            }
        }

        public int UpdatePatient(Patient patient)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdatePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id ", patient.Id);
                    cmd.Parameters.AddWithValue("@Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Age", patient.Age);
                    cmd.Parameters.AddWithValue("@MobileNo", patient.MobileNo);
       
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
