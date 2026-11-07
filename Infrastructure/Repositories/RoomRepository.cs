using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class RoomRepository(Database database) : IRoomRepository
{
    private Database _database = database;
    public async Task<bool> AddRoom(Room room)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "insert into rooms (name , isactive) values (@name , @isactive)";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }   

    public async Task<bool> DeleteRoom(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from rooms where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<List<Room>> GetAllRooms()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from rooms";
        var res = await connection.QueryAsync<Room>(query);
        return res.ToList();
    }

    public async Task<Room> GetRoom(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from rooms where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<Room>(query, new { id });
        return res!;
    }

    public async Task<bool> UpdateRoom(Room room , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update rooms set name = @name, isactive = @isactive where id = @id";
        var res = await connection.ExecuteAsync(query, new{id , room.Name , room.IsActive});
        return res > 0;
    }

}
