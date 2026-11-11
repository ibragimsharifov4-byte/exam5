using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    private IDoctorRepository _repository = doctorRepository;
    public async Task<ApiResponse<bool>> AddDoctor(DoctorDto doctor)
    {
        var model = new Doctor
        {
            Fullname = doctor.Fullname,
            Specialty = doctor.Specialty,
            IsActive = doctor.IsActive,
            Hiredat = doctor.Hiredat
        };
        var res = await _repository.AddDoctor(model);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteDoctor(int id)
    {
        var res = await _repository.DeleteDoctor(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not deleted(" , false);
    }

    public async Task<ApiResponse<List<DoctorDto>>> GetAllDoctors()
    {
        var res = await _repository.GetAllDoctors();
        var doctors = res.Select(x => new DoctorDto
        {
            Fullname = x.Fullname,
            Specialty = x.Specialty,
            IsActive = x.IsActive,
            Hiredat = x.Hiredat
        }).ToList();
        return new ApiResponse<List<DoctorDto>>(HttpStatusCode.OK , "List of doctors" , doctors);
    }

    public async Task<ApiResponse<DoctorDto>> GetDoctor(int id)
    {
        var res = await _repository.GetDoctor(id);
        return res != null
        ? new ApiResponse<DoctorDto>(HttpStatusCode.OK , "Doctor found" , new DoctorDto
        {
            Fullname = res.Fullname,
            Specialty = res.Specialty,
            IsActive = res.IsActive,
            Hiredat = res.Hiredat
        })
        : new ApiResponse<DoctorDto>(HttpStatusCode.NotFound , "Doctor not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateDoctor(DoctorDto doctor , int id)
    {
        var model = new Doctor
        {
            Fullname = doctor.Fullname,
            Specialty = doctor.Specialty,
            IsActive = doctor.IsActive,
            Hiredat = doctor.Hiredat
        };
        var res = await _repository.UpdateDoctor(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not updated(" , false);
    }

}
