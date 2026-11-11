using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IPatientService patientService, ILogger<PatientController> logger) : ControllerBase
{
    private IPatientService _service = patientService;
    private readonly ILogger<PatientController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<PatientDto>>> GetAllPatients()
    {
        _logger.LogInformation("Geting the patients");
        return await _service.GetAllPatients();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<PatientDto>> GetPatient(int id)
    {
        _logger.LogInformation("Get patient by id");
        return await _service.GetPatient(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddPatient(PatientDto patient)
    {
        _logger.LogInformation("Adding the patient");
        return await _service.AddPatient(patient);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeletePatient(int id)
    {
        _logger.LogInformation("Delete the patient");
        return await _service.DeletePatient(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdatePatient(PatientDto patient , int id)
    {
        _logger.LogInformation("Update the patient");
        return await _service.UpdatePatient(patient , id);
    }
}
