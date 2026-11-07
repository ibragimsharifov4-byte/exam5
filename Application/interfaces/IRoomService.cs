using Application.Responses;
using Domain.Models;

namespace Application.interfaces;

public interface IRoomService
{
    Task<ApiResponse<List<Room>>> GetAllRooms();
    Task<ApiResponse<Room>> GetRoom(int id);
    Task<ApiResponse<bool>> AddRoom(Room room);
    Task<ApiResponse<bool>> UpdateRoom(Room room , int id);
    Task<ApiResponse<bool>> DeleteRoom(int id);
}
