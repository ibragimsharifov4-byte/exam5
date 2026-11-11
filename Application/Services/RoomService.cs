using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private IRoomRepository _repository = roomRepository;
    public async Task<ApiResponse<bool>> AddRoom(RoomDto room)
    {
        var model = new Room
        {
            Name = room.Name,
            IsActive = room.IsActive
        };
        var res = await _repository.AddRoom(model);
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

    public async Task<ApiResponse<List<RoomDto>>> GetAllRooms()
    {
        var res = await _repository.GetAllRooms();
        var rooms = res.Select(x => new RoomDto
        {
            Name = x.Name,
            IsActive = x.IsActive
        }).ToList();
        return new ApiResponse<List<RoomDto>>(HttpStatusCode.OK , "List of rooms" , rooms);
    }

    public async Task<ApiResponse<RoomDto>> GetRoom(int id)
    {
        var res = await _repository.GetRoom(id);
        return res != null
        ? new ApiResponse<RoomDto>(HttpStatusCode.OK , "Room found" , new RoomDto
        {
            Name = res.Name,
            IsActive = res.IsActive
        })
        : new ApiResponse<RoomDto>(HttpStatusCode.NotFound , "Room not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateRoom(RoomDto room , int id)
    {
        var model = new Room
        {
            Name = room.Name,
            IsActive = room.IsActive
        };
        var res = await _repository.UpdateRoom(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not updated(" , false);
    }

}
