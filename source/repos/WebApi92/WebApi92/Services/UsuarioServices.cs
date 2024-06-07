using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi92.Context;

namespace WebApi92.Services
{
    public class UsuarioServices : IUsuariosServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.ToListAsync();
                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error pa" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetById(int id)
        {
            try
            {
                Usuario response = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                return new Response<Usuario>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error pa" + ex.Message);
            }
        }

        public async Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol,
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error pa" + ex.Message);
            }
        }

        public async Task<Response<UsuariosResponse>> ActualizarUsuario(int id, UsuariosResponse request)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    throw new Exception("El usuario no existe");
                }
                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error pa" + ex.Message);
            }
        }
        public async Task<Response<UsuariosResponse>> EliminarUsuario(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    throw new Exception("El usuario no existe");
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(new UsuariosResponse());
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error pa" + ex.Message);
            }
        }


    }
}