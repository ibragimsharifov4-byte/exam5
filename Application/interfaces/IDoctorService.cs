using Application.Responses;
using Application.DTOs;


namespace Application.interfaces;

public interface IDoctorService
{
    Task<ApiResponse<List<DoctorDto>>> GetAllDoctors();
    Task<ApiResponse<DoctorDto>> GetDoctor(int id);
    Task<ApiResponse<bool>> AddDoctor(DoctorDto doctor);
    Task<ApiResponse<bool>> UpdateDoctor(DoctorDto doctor , int id);
    Task<ApiResponse<bool>> DeleteDoctor(int id);
}
