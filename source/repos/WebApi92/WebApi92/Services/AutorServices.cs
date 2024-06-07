using Dapper;
using Domain.Entities;
using System.Data;
using WebApi92.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi92.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;
        public AutorServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> Response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);
                Response = result.ToList();

                return new Response<List<Autor>>(Response);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Autor>> CreateAutor(Autor request)
        {

            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { request.Nombre, request.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error");
            }
        }

        public async Task<Response<Autor>> EditarAutor (Autor request, int id)
        {

            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spEditarAutor", new { id, request.Nombre, request.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }
            catch (Exception ex) 
            {

                throw new Exception("Te equivocaste pa" + ex.Message);
            }

        }

    }
}