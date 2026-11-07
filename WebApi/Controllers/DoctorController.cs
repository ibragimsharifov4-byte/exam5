using Application.interfaces;
using Domain.Models;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController(IDoctorService doctorService) : ControllerBase
{
    private IDoctorService _service = doctorService;

    [HttpGet]
    public async Task<ApiResponse<List<Doctor>>> GetAllDoctors()
    {
        return await _service.GetAllDoctors();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<Doctor>> GetDoctor(int id)
    {
        return await _service.GetDoctor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDoctor(Doctor doctor)
    {
        return await _service.AddDoctor(doctor);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteDoctor(int id)
    {
        return await _service.DeleteDoctor(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateDoctor(Doctor doctor , int id)
    {
        return await _service.UpdateDoctor(doctor , id);
    }
}
