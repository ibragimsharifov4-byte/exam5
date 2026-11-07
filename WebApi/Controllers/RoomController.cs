using Application.interfaces;
using Domain.Models;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController(IRoomService roomService) : ControllerBase
{
    private IRoomService _roomService = roomService;

    [HttpGet]
    public async Task<ApiResponse<List<Room>>> GetAllRooms()
    {
        return await _roomService.GetAllRooms();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<Room>> GetRoom(int id)
    {
        return await _roomService.GetRoom(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddRoom(Room room)
    {
        return await _roomService.AddRoom(room);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteRoom(int id)
    {
        return await _roomService.DeleteRoom(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateRoom(Room room , int id)
    {
        return await _roomService.UpdateRoom(room , id);
    }
}
