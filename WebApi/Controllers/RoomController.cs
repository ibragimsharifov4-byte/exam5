using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController(IRoomService roomService, ILogger<RoomController> logger) : ControllerBase
{
    private IRoomService _roomService = roomService;
    private readonly ILogger<RoomController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<RoomDto>>> GetAllRooms()
    {
        _logger.LogInformation("Geting the rooms");
        return await _roomService.GetAllRooms();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<RoomDto>> GetRoom(int id)
    {
        _logger.LogInformation("Get room by id");
        return await _roomService.GetRoom(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddRoom(RoomDto room)
    {
        _logger.LogInformation("Adding the room");
        return await _roomService.AddRoom(room);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteRoom(int id)
    {
        _logger.LogInformation("Delete the room");
        return await _roomService.DeleteRoom(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateRoom(RoomDto room , int id)
    {
        _logger.LogInformation("Update the room");
        return await _roomService.UpdateRoom(room , id);
    }
}
