using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface IPatientService
{
    Task<ApiResponse<List<PatientDto>>> GetAllPatients();
    Task<ApiResponse<PatientDto>> GetPatient(int id);
    Task<ApiResponse<bool>> AddPatient(PatientDto patient);
    Task<ApiResponse<bool>> UpdatePatient(PatientDto patient , int id);
    Task<ApiResponse<bool>> DeletePatient(int id);
}
