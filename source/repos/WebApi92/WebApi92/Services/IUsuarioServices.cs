using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi92.Services
{
    public interface IUsuariosServices
    {
        public Task<Response<List<Usuario>>> GetUsuarios();
        public Task<Response<Usuario>> GetById(int id);
        public Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request);
        public Task<Response<UsuariosResponse>> ActualizarUsuario(int id, UsuariosResponse request);

        public Task<Response<UsuariosResponse>> EliminarUsuario(int id);
    }
}