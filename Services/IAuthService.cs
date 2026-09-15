using Caso_1_tarea.Models;
 
namespace Caso_1_tarea.Services;
 
public interface IAuthService
{
    Usuario RegistrarUsuario(string nombreUsuario, string email, string password, RolUsuario rol);
    Usuario? IniciarSesion(string nombreUsuario, string password);
    bool TienePermiso(Usuario usuario, RolUsuario rolMinimoRequerido);
}