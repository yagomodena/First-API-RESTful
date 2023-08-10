using CRUD_DAPPER.Models;

namespace CRUD_DAPPER.Services.LivroService
{
    public interface ILivroInterface
    {

        Task<IEnumerable<Livro>> GetAllLivros();

        Task<Livro> GetLivrosById(int livroId);

        Task<IEnumerable<Livro>> CreateLivro(Livro livro);

        Task<IEnumerable<Livro>> UpdateLivro(Livro livro);

        Task<IEnumerable<Livro>> DeleteLivro(int livroId);
    }
}
