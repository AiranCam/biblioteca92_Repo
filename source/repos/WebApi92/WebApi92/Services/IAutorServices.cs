using Domain.Entities;
namespace WebApi92.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();

        public Task<Response<Autor>> CreateAutor(Autor request);

        public Task<Response<Autor>> EditarAutor(Autor request, int id);
    }
}