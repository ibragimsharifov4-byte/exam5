using Domain.Models;

namespace Domain.interfaces;

public interface IRoomRepository
{
    Task<List<Room>> GetAllRooms();
    Task<Room> GetRoom(int id);
    Task<bool> AddRoom(Room room);
    Task<bool> UpdateRoom(Room room , int id);
    Task<bool> DeleteRoom(int id);
}
