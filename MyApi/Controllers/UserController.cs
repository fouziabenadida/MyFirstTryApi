using Microsoft.AspNetCore.Mvc;
using MyApi;
using System.Collections.Generic;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private static List<User> _users = new List<User>(); 

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest("Invalid user data");
        }

        user.Id = _users.Count + 1;
        _users.Add(user);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound("User not found");
        }

        _users.Remove(user);
        return NoContent(); 
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
        {
            return NotFound("User not found");
        }

        // Update the user properties with the new values
        existingUser.Username = updatedUser.Username;
        existingUser.Email = updatedUser.Email;
        // Update other properties as needed

        return Ok(existingUser);
    }
}
