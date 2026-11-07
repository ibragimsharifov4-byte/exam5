using Domain.interfaces;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private  IRoomRepository _repository = roomRepository;
    public async Task<ApiResponse<bool>> AddRoom(Room room)
    {
        var res = await _repository.AddRoom(room);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteRoom(int id)
    {
        var res = await _repository.DeleteRoom(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not deleted(" , false);
    }

    public async Task<ApiResponse<List<Room>>> GetAllRooms()
    {
        var res = await _repository.GetAllRooms();
        return new ApiResponse<List<Room>>(HttpStatusCode.OK , "List of rooms" , res);
    }

    public async Task<ApiResponse<Room>> GetRoom(int id)
    {
        var res = await _repository.GetRoom(id);
        return res != null
        ? new ApiResponse<Room>(HttpStatusCode.OK , "Room found" , res)
        : new ApiResponse<Room>(HttpStatusCode.NotFound , "Room not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateRoom(Room room , int id)
    {
        var res = await _repository.UpdateRoom(room , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not updated(" , false);
    }

}
