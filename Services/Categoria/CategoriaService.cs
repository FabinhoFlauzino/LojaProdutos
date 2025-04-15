﻿using LojaProdutos.Data;
using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Categoria;

public class CategoriaService : ICategoriaInterface
{
    private readonly DataContext _context;

    public CategoriaService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<CategoriaModel>> BuscarCategorias()
    {
        try
        {
            var categoria = await _context.Categorias.ToListAsync();
            return categoria;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
