using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IPatientService
{
    Task<ApiResponse<List<Patient>>> GetAllPatients();
    Task<ApiResponse<Patient>> GetPatient(int id);
    Task<ApiResponse<bool>> AddPatient(Patient patient);
    Task<ApiResponse<bool>> UpdatePatient(Patient patient , int id);
    Task<ApiResponse<bool>> DeletePatient(int id);
}
