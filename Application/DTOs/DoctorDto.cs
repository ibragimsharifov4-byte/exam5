namespace Application.DTOs;

public class DoctorDto
{
    public string Fullname { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime Hiredat { get; set; }
}
