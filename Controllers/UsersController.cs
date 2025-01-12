using ElasticWithNet8.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElasticWithNet8.Controllers;

public class UsersController(ILogger<UsersController> logger, IElasticService elasticService) : ControllerBase
{
    [HttpPost("create-index")]
    public async Task<IActionResult> CreateIndex(string indexName)
    {
        await elasticService.CreateIndexIfNotExistsAsync(indexName);

        return Ok($"Index {indexName} created or already exists.");
    }

    [HttpPost("add-user")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        var result = await elasticService.AddOrUpdate(user);
        
        return result 
            ? Ok("User added successfully")
            : StatusCode(500, "Error adding or updating user.");
    }
    
    [HttpPost("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        var result = await elasticService.AddOrUpdate(user);
        
        return result 
            ? Ok("User added or updated successfully")
            : StatusCode(500, "Error adding or updating user.");
    }

    [HttpGet("get-user/{key}")]
    public async Task<IActionResult> GetUser(string key)
    {
        var user = await elasticService.Get(key);
        
        return user != null
            ? Ok(user)
            : NotFound($"User with key {key} not found.");
    }

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await elasticService.GetAll();

        return users != null
            ? Ok(users)
            : NoContent();
    }

    [HttpDelete("delete-user/{key}")]
    public async Task<IActionResult> DeleteUser(string key)
    {
        var user = await elasticService.Get(key);

        var result = await elasticService.Remove(key);
        
        return result 
            ? Ok("User deleted successfully")
            : StatusCode(500, "Error deleting or updating user.");
    }
    
    
}
