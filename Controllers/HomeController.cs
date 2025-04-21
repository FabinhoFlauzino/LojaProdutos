using LojaProdutos.Models;
using LojaProdutos.Services.Produtos;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers;
public class HomeController : Controller
{
    private readonly IProdutoInterface _produtoInterface;

    public HomeController(IProdutoInterface produtoInterface)
    {
        _produtoInterface = produtoInterface;
    }

    public async Task<IActionResult> Index(string? pesquisar)
    {
        var produtos = new List<ProdutoModel>();

        if(pesquisar == null)
        {
            produtos = await _produtoInterface.BuscarProdutos();
        }
        else
        {
            produtos = await _produtoInterface.BuscarProdutoFiltro(pesquisar);
        }

        return View(produtos);
    }

}
