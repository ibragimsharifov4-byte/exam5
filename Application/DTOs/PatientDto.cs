namespace Application.DTOs;

public class PatientDto
{
    public string Fullname { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreateDat { get; set; } = DateTime.Now;
}
