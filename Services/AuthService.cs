using System.Security.Cryptography;
using System.Text;
using Caso_1_tarea.Models;
 
namespace Caso_1_tarea.Services;
 
public class AuthService : IAuthService
{
    private readonly List<Usuario> _usuarios = new();
    private int _siguienteId = 1;
 
    public Usuario RegistrarUsuario(string nombreUsuario, string email, string password, RolUsuario rol)
    {
        if (_usuarios.Any(u => u.NombreUsuario == nombreUsuario))
            throw new InvalidOperationException("Ese nombre de usuario ya existe.");
 
        var usuario = new Usuario
        {
            Id = _siguienteId++,
            NombreUsuario = nombreUsuario,
            Email = email,
            PasswordHash = HashPassword(password),
            Rol = rol
        };
 
        _usuarios.Add(usuario);
        return usuario;
    }
 
    public Usuario? IniciarSesion(string nombreUsuario, string password)
    {
        var usuario = _usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Activo);
        if (usuario == null) return null;
        return usuario.PasswordHash == HashPassword(password) ? usuario : null;
    }
 
    public bool TienePermiso(Usuario usuario, RolUsuario rolMinimoRequerido)
    {
        return (int)usuario.Rol >= (int)rolMinimoRequerido;
    }
 
    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}