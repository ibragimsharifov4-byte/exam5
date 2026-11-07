using Domain.interfaces;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private IPatientRepository _repository = patientRepository;
    public async Task<ApiResponse<bool>> AddPatient(Patient patient)
    {
        var res = await _repository.AddPatient(patient);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeletePatient(int id)
    {
        var res = await _repository.DeletePatient(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not deleted(" , false);
    }

    public async Task<ApiResponse<List<Patient>>> GetAllPatients()
    {
        var res = await _repository.GetAllPatients();
        return new ApiResponse<List<Patient>>(HttpStatusCode.OK , "List of patients" , res);
    }

    public async Task<ApiResponse<Patient>> GetPatient(int id)
    {
        var res = await _repository.GetPatient(id);
        return res != null
        ? new ApiResponse<Patient>(HttpStatusCode.OK , "Patient found" , res)
        : new ApiResponse<Patient>(HttpStatusCode.NotFound , "Patient not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdatePatient(Patient patient , int id)
    {
        var res = await _repository.UpdatePatient(patient , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not updated(" , false);
    }

}
