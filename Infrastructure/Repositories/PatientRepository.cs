using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class PatientRepository(Database database) : IPatientRepository
{
    private Database _database = database;

    public async Task<bool> AddPatient(Patient patient)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = 
        "insert into patients (fullname, phone, birthdate, isactive, createdat) values (@fullname, @phone, @birthdate, @isactive, @createdat)";
        var res = await connection.ExecuteAsync(query , patient);
        return res>0;
    }

    public async Task<bool> DeletePatient(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from patients where id = @id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<List<Patient>> GetAllPatients()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from patients";
        var res = await connection.QueryAsync<Patient>(query);
        return res.ToList();
    }

    public async Task<Patient> GetPatient(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from patients where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<Patient>(query, new {id});
        return res!;
    }

    public async Task<bool> UpdatePatient(Patient patient , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update patients set fullname = @fullname, phone = @phone, birthdate = @birthdate, isactive = @isactive, createdat = @createdat where id = @id";
        var res = await connection.ExecuteAsync(query, new{id , patient.Fullname , patient.Phone , patient.BirthDate , patient.IsActive , patient.CreateDat});
        return res > 0;
    }

}
