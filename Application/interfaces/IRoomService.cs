using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface IRoomService
{
    Task<ApiResponse<List<RoomDto>>> GetAllRooms();
    Task<ApiResponse<RoomDto>> GetRoom(int id);
    Task<ApiResponse<bool>> AddRoom(RoomDto room);
    Task<ApiResponse<bool>> UpdateRoom(RoomDto room , int id);
    Task<ApiResponse<bool>> DeleteRoom(int id);
}
