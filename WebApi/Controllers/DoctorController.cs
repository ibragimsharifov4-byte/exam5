using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController(IDoctorService doctorService) : ControllerBase
{
    private IDoctorService _service = doctorService;

    [HttpGet]
    public async Task<ApiResponse<List<DoctorDto>>> GetAllDoctors()
    {
        return await _service.GetAllDoctors();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<DoctorDto>> GetDoctor(int id)
    {
        return await _service.GetDoctor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDoctor(DoctorDto doctor)
    {
        return await _service.AddDoctor(doctor);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteDoctor(int id)
    {
        return await _service.DeleteDoctor(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateDoctor(DoctorDto doctor , int id)
    {
        return await _service.UpdateDoctor(doctor , id);
    }
}
