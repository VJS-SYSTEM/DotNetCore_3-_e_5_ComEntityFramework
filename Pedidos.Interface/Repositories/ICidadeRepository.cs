using Pedidos.Domain;
using System.Collections.Generic;

namespace Pedidos.Interface
{
    public interface ICidadeRepository
    {
        dynamic Get();
        int Criar(CidadeDTO model);

        int Alterar(CidadeDTO model);
        bool Excluir(int id);
    }
}
