using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class DoctorRepository(Database database) : IDoctorRepository
{
    public async Task<bool> AddDoctor(Doctor doctor)
    {
        using var connection = database.Connection();
        connection.Open();
        var query = "insert into doctors (fullname , speciality, isactive , hiredate) values (@fullname , @speciality , @isactive , @hiredate)";
        var res = await connection.ExecuteAsync(query, doctor);
        return res > 0;
    }

    public async Task<bool> DeleteDoctor(int id)
    {
        using var connection = database.Connection();
        connection.Open();
        var query = "delete from doctors where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        using var connection = database.Connection();
        connection.Open();
        var query = "select * from doctors";
        var doctors = await connection.QueryAsync<Doctor>(query);
        return doctors.ToList();
    }

    public async Task<Doctor> GetDoctor(int id)
    {
        using var connection = database.Connection();
        connection.Open();
        var query = "select * from doctors where id = @id";
        var doctor = await connection.QueryFirstOrDefaultAsync<Doctor>(query, new { id });
        return doctor!;
    }

    public async Task<bool> UpdateDoctor(Doctor doctor , int id)
    {
        using var connection = database.Connection();
        connection.Open();
        var query = "update doctors set fullname = @fullname, speciality = @speciality, isactive = @isactive, hiredate = @hiredate where id = @id";
        var res = await connection.ExecuteAsync(query, new{id , doctor.Fullname , doctor.Specialty , doctor.IsActive , doctor.Hiredat});
        return res > 0;
    }

}
