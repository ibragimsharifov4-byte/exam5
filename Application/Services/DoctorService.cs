using Domain.interfaces;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    private IDoctorRepository _repository = doctorRepository;
    public async Task<ApiResponse<bool>> AddDoctor(Doctor doctor)
    {
        var res = await _repository.AddDoctor(doctor);
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

    public async Task<ApiResponse<List<Doctor>>> GetAllDoctors()
    {
        var res = await _repository.GetAllDoctors();
        return new ApiResponse<List<Doctor>>(HttpStatusCode.OK , "List of doctors" , res);
    }

    public async Task<ApiResponse<Doctor>> GetDoctor(int id)
    {
        var res = await _repository.GetDoctor(id);
        return res != null
        ? new ApiResponse<Doctor>(HttpStatusCode.OK , "Doctor found" , res)
        : new ApiResponse<Doctor>(HttpStatusCode.NotFound , "Doctor not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateDoctor(Doctor doctor , int id)
    {
        var res = await _repository.UpdateDoctor(doctor , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not updated(" , false);
    }

}
