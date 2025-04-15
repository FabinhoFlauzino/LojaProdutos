using LojaProdutos.Models;

namespace LojaProdutos.Services.Produtos;

public interface IProdutoInterface
{
    Task<List<ProdutoModel>> BuscarProdutos();
    
}
