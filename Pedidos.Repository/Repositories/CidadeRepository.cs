using Pedidos.Domain;
using Pedidos.Interface;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Pedidos.Repository
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        public CidadeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public dynamic Get()
        {

            return _dbContext.Cidades
                .Where(x => x.ativo)
                .Select(x => new
                {
                    x.id,
                    x.nome,
                    x.uf,
                    x.ativo
                })
                .ToList();
        }
        public int Criar(CidadeDTO model)
        {
            if (model.id>0)
            {
                return 0;
            }

            var nomeDuplicado = _dbContext.Cidades.Any(x => x.ativo && x.nome.ToUpper() == model.nome.ToUpper());
            if (nomeDuplicado)
            {
                return 0;
            }

            var entity = new Cidade()
            {
                nome = model.nome,
                uf = model.uf,
                ativo = model.ativo
            };

            try
            {
                _dbContext.Cidades.Add(entity);
                _dbContext.SaveChanges();
                return entity.id;
            }
            catch (Exception ex)
            {
            }
            return 0;
       
        }

        public int Alterar(CidadeDTO model)
        {
            if (model.id <= 0)
            {
                return 0;
            } 

            var entity = _dbContext.Cidades.Find(model.id);
            if (entity == null)
            {
                return 0;
            }
         

            var nomeDuplicado = _dbContext.Cidades.Any(x => x.ativo && x.nome.ToUpper() == model.nome.ToUpper() && x.id != model.id);
            if (nomeDuplicado)
            {
                return 0;
            }

            entity.nome = model.nome;
            entity.uf = model.uf;
            entity.ativo = model.ativo;

            try
            {
                _dbContext.Cidades.Update(entity);
                _dbContext.SaveChanges();
                return entity.id;
            }
            catch(Exception ex)
            {
            }
            return 0;
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var entity = _dbContext.Cidades.Find(id);
            if (entity == null)
            {
                return false;

            }

            try
            {
                _dbContext.Cidades.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;

        }

    }
}
