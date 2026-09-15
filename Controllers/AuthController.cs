using Microsoft.AspNetCore.Mvc;
using Caso_1_tarea.Models;
using Caso_1_tarea.Services;
 
namespace Caso_1_tarea.Controllers;
 
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
 
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
 
    public record RegistroRequest(string NombreUsuario, string Email, string Password, RolUsuario Rol);
    public record LoginRequest(string NombreUsuario, string Password);
 
    [HttpPost("registro")]
    public IActionResult Registrar([FromBody] RegistroRequest request)
    {
        try
        {
            var usuario = _authService.RegistrarUsuario(request.NombreUsuario, request.Email, request.Password, request.Rol);
            return Ok(new { usuario.Id, usuario.NombreUsuario, usuario.Rol });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
 
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var usuario = _authService.IniciarSesion(request.NombreUsuario, request.Password);
        if (usuario == null) return Unauthorized("Usuario o contraseña incorrectos.");
        return Ok(new { usuario.Id, usuario.NombreUsuario, usuario.Rol });
    }
}