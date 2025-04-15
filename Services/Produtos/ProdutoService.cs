﻿using LojaProdutos.Data;
using LojaProdutos.Dto.Produto;
using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Produtos;

public class ProdutoService : IProdutoInterface
{
    private readonly DataContext _context;
    private readonly string _sistema;

    public ProdutoService(DataContext context, IWebHostEnvironment sistema)
    {
        _context = context;
        _sistema = sistema.WebRootPath;
    }

    public async Task<List<ProdutoModel>> BuscarProdutos()
    {
        try
        {
            return await _context.Produtos.Include(c => c.Categoria).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProdutoModel> Cadastrar(CriarProdutoDto criarProdutoDto, IFormFile foto)
    {
        try
        {
            var nomeCaminhoImagem = GeraCaminhoArquivo(foto);

            var produto = new ProdutoModel
            {
                Nome = criarProdutoDto.Nome,
                Marca = criarProdutoDto.Marca,
                Valor = criarProdutoDto.Valor,
                CategoriaModelId = criarProdutoDto.CategoriaModelId,
                QuantidadeEstoque = criarProdutoDto.QuantidadeEstoque,
                Foto = nomeCaminhoImagem
            };

            _context.Produtos.Add(produto);

            await _context.SaveChangesAsync();

            return produto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private string GeraCaminhoArquivo(IFormFile foto)
    {
        var codigoUnico = Guid.NewGuid().ToString();
        var nomeCaminhoImagem = foto.FileName.Replace(" ", "").ToLower() + codigoUnico + ".png";
        var caminhoParaSalvarImagens = _sistema + "\\imagem\\";

        if (!Directory.Exists(caminhoParaSalvarImagens))
        {
            Directory.CreateDirectory(caminhoParaSalvarImagens);
        }

        using (var stream = File.Create(caminhoParaSalvarImagens + nomeCaminhoImagem))
        {
            foto.CopyToAsync(stream).Wait();
        }


        return nomeCaminhoImagem;
    }
}
