using Domain.Models;

namespace Domain.interfaces;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllPatients();
    Task<Patient> GetPatient(int id);
    Task<bool> AddPatient(Patient patient);
    Task<bool> UpdatePatient(Patient patient , int id);
    Task<bool> DeletePatient(int id);
}
