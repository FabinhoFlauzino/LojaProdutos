using LojaProdutos.Dto.Produto;
using LojaProdutos.Models;

namespace LojaProdutos.Services.Produtos;

public interface IProdutoInterface
{
    Task<List<ProdutoModel>> BuscarProdutos();
    Task<ProdutoModel> Cadastrar(CriarProdutoDto criarProdutoDto, IFormFile foto);
}
