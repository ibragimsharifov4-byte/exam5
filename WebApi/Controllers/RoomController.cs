using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController(IRoomService roomService) : ControllerBase
{
    private IRoomService _roomService = roomService;

    [HttpGet]
    public async Task<ApiResponse<List<RoomDto>>> GetAllRooms()
    {
        return await _roomService.GetAllRooms();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<RoomDto>> GetRoom(int id)
    {
        return await _roomService.GetRoom(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddRoom(RoomDto room)
    {
        return await _roomService.AddRoom(room);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteRoom(int id)
    {
        return await _roomService.DeleteRoom(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateRoom(RoomDto room , int id)
    {
        return await _roomService.UpdateRoom(room , id);
    }
}
