using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private IPatientRepository _repository = patientRepository;
    public async Task<ApiResponse<bool>> AddPatient(PatientDto patient)
    {
        var model = new Patient
        {
            Fullname = patient.Fullname,
            Phone = patient.Phone,
            BirthDate = patient.BirthDate,
            IsActive = patient.IsActive,
            CreateDat = patient.CreateDat
        };
        var res = await _repository.AddPatient(model);
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

    public async Task<ApiResponse<List<PatientDto>>> GetAllPatients()
    {
        var res = await _repository.GetAllPatients();
        var patients = res.Select(x => new PatientDto
        {
            Fullname = x.Fullname,
            Phone = x.Phone,
            BirthDate = x.BirthDate,
            IsActive = x.IsActive,
            CreateDat = x.CreateDat
        }).ToList();
        return new ApiResponse<List<PatientDto>>(HttpStatusCode.OK , "List of patients" , patients);
    }

    public async Task<ApiResponse<PatientDto>> GetPatient(int id)
    {
        var res = await _repository.GetPatient(id);
        return res != null
        ? new ApiResponse<PatientDto>(HttpStatusCode.OK , "Patient found" , new PatientDto
        {
            Fullname = res.Fullname,
            Phone = res.Phone,
            BirthDate = res.BirthDate,
            IsActive = res.IsActive,
            CreateDat = res.CreateDat
        })
        : new ApiResponse<PatientDto>(HttpStatusCode.NotFound , "Patient not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdatePatient(PatientDto patient , int id)
    {
        var model = new Patient
        {
            Fullname = patient.Fullname,
            Phone = patient.Phone,
            BirthDate = patient.BirthDate,
            IsActive = patient.IsActive,
            CreateDat = patient.CreateDat
        };
        var res = await _repository.UpdatePatient(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not updated(" , false);
    }

}
