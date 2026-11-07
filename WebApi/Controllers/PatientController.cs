using Application.interfaces;
using Domain.Models;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    private IPatientService _service = patientService;
    
    [HttpGet]
    public async Task<ApiResponse<List<Patient>>> GetAllPatients()
    {
        return await _service.GetAllPatients();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<Patient>> GetPatient(int id)
    {
        return await _service.GetPatient(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddPatient(Patient patient)
    {
        return await _service.AddPatient(patient);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeletePatient(int id)
    {
        return await _service.DeletePatient(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdatePatient(Patient patient , int id)
    {
        return await _service.UpdatePatient(patient , id);
    }
}
