using Pedidos.Domain;
using Pedidos.Interface;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pedidos.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private void OrdenarPorNome(IQueryable<Produto> query, string ordem)
        {
            if (string.IsNullOrEmpty(ordem) || ordem.ToUpper() == "ASC")
            {
                query = query.OrderBy(x => x.nome);
            }
            else
            {
                query = query.OrderByDescending(x => x.nome);
            }

        }
        public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public  dynamic Get(string ordem)
        {
            var query = _dbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.ativo);

            OrdenarPorNome(query, ordem);

            var queryRetorno = query
                .Select(x => new
                {
                    x.nome,
                    x.preco,
                    Categoria = x.Categoria.nome,
                    Imagens = x.Imagens.Select(i => new
                    {
                        i.id,
                        i.nome,
                        i.nomearquivo
                    })
                });
               
                
                 return queryRetorno.ToList();

        }

        public dynamic Search(string text, int pagina, string ordem)
        {

            var query = _dbContext.Produtos
                .Include(x => x.Categoria)
               .Where(x => x.ativo && (x.nome.ToUpper().Contains(text.ToUpper())
               || x.descricao.ToUpper().Contains(text.ToUpper())))
               .Skip(TamanhoPagina * (pagina - 1)) //quantidade de resgistros por página
               .Take(TamanhoPagina);

            OrdenarPorNome(query, ordem);

            var queryRetorno = query
               .Select(x => new
               {
                   x.nome,
                   x.preco,
                   Categoria = x.Categoria.nome,
                   Imagens = x.Imagens.Select(i => new
                   {
                       i.id,
                       i.nome,
                       i.nomearquivo
                   })
               });           

            var prod = queryRetorno.ToList();

            var quantiProduto = _dbContext.Produtos
                .Where(x => x.ativo && (x.nome.ToUpper().Contains(text.ToUpper())
               || x.descricao.ToUpper().Contains(text.ToUpper())))
                .Count();

            var quantiPagina = (quantiProduto / TamanhoPagina);
            if (quantiPagina < 1)
            {
                quantiPagina = 1;
            }
            return new { prod, quantiPagina };

        }

        public dynamic Detail(int id)
        {

            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
               .Where(x => x.ativo && x.id == id)
               .Select( x => new
               {
                   x.id,
                   x.nome,
                   x.codigo,
                   x.descricao,
                   x.preco,
                   Categoria = new
                   {
                       x.Categoria.id,
                       x.Categoria.nome
                   },
                   Imagens = x.Imagens.Select( i => new
                   {
                       i.id,
                       i.nome,
                       i.nomearquivo
                   })
               })
               .FirstOrDefault();
        }

        public dynamic Imagens(int id)
        {

            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
               .Where(x => x.ativo && x.id == id)
               .SelectMany(x => x.Imagens, (produto, imagem)=> new
               {
                   Id_Produto = produto.id,
                   imagem.id,
                   imagem.nome,
                   imagem.nomearquivo
               })
               .FirstOrDefault();
        }

    }
}
