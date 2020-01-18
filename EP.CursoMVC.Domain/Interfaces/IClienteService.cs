using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Interfaces
{
    /*
     * Não é um serviço de Entidade de Cliente
     * e sim uma raiz de agregação
     * Por exemplo o cliente possui:
     * - Endereços
     * - Contatos
     * Sendo que cliente é a entidade raíz e os outros são entidades
     * que fazem parte da regra de negócio do cliente
    */
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
    }
}
