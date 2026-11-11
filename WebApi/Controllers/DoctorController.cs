using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController(IDoctorService doctorService, ILogger<DoctorController> logger) : ControllerBase
{
    private IDoctorService _service = doctorService;
    private readonly ILogger<DoctorController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<DoctorDto>>> GetAllDoctors()
    {
        _logger.LogInformation("Geting the doctors");
        return await _service.GetAllDoctors();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<DoctorDto>> GetDoctor(int id)
    {
        _logger.LogInformation("Get doctor by id");
        return await _service.GetDoctor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDoctor(DoctorDto doctor)
    {
        _logger.LogInformation("Adding the doctor");
        return await _service.AddDoctor(doctor);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteDoctor(int id)
    {
        _logger.LogInformation("Delete the doctor");
        return await _service.DeleteDoctor(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateDoctor(DoctorDto doctor , int id)
    {
        _logger.LogInformation("Update the doctor");
        return await _service.UpdateDoctor(doctor , id);
    }
}
