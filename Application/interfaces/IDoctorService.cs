using Application.Responses;
using Domain.Models;


namespace Application.interfaces;

public interface IDoctorService
{
    Task<ApiResponse<List<Doctor>>> GetAllDoctors();
    Task<ApiResponse<Doctor>> GetDoctor(int id);
    Task<ApiResponse<bool>> AddDoctor(Doctor doctor);
    Task<ApiResponse<bool>> UpdateDoctor(Doctor doctor , int id);
    Task<ApiResponse<bool>> DeleteDoctor(int id);
}
