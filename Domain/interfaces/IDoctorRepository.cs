using Domain.Models;

namespace Domain.interfaces;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllDoctors();
    Task<Doctor> GetDoctor(int id);
    Task<bool> AddDoctor(Doctor doctor);
    Task<bool> UpdateDoctor(Doctor doctor , int id);
    Task<bool> DeleteDoctor(int id);
}
