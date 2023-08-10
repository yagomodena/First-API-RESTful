using CRUD_DAPPER.Models;
using Dapper;
using System.Data.SqlClient;

namespace CRUD_DAPPER.Services.LivroService
{
    public class LivroService : ILivroInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;

        public LivroService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Livro>> CreateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "INSERT INTO Livros (titulo, autor) VALUES (@titulo, @autor)";

                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livro>("SELECT * FROM Livros");
            }
        }

        public async Task<IEnumerable<Livro>> DeleteLivro(int livroId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "DELETE FROM Livros WHERE Id = @id";

                await con.ExecuteAsync(sql, new { Id = livroId});

                return await con.QueryAsync<Livro>("SELECT * FROM Livros");
            }
        }

        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "SELECT * FROM Livros";
                //o await pega a conexão e faz um queryAsync, ele pega tudo dentro do banco
                return await con.QueryAsync<Livro>(sql);
            }
        }

        public async Task<Livro> GetLivrosById(int livroId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "SELECT * FROM Livros WHERE Id = @Id";

                return await con.QueryFirstOrDefaultAsync<Livro>(sql, new { Id = livroId });
            }
        }

        public async Task<IEnumerable<Livro>> UpdateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "UPDATE Livros SET titulo = @titulo, autor = @autor WHERE Id = @id";
                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livro>("SELECT * FROM Livros");
            }
        }
    }
}
