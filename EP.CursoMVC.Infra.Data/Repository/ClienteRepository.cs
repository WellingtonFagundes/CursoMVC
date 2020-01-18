using EP.CursoMVC.Domain;
using EP.CursoMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using EP.CursoMVC.Domain.Models;

namespace EP.CursoMVC.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        
        public IEnumerable<Cliente> ObterAtivos()
        {
            //Usando Dapper mais performático
            var sql = @"SELECT * FROM Clientes c " +
                      "WHERE c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente>(sql);
            //return Buscar(c => c.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

       //Ler: Dapper - Gravar: Entity Framework
        public override Cliente ObterPorId(Guid id)
        {
            //throw new Exception("ERRO AO OBTER ID");

            const string sql = @"SELECT * FROM Clientes c " +
                      "LEFT JOIN Enderecos e " +
                      "ON c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            //Preciso olhar as tabelas Clientes e Endereços o terceiro parâmetro indica
            //qual objeto quero retornar que é Clientes
            //Usando Dapper mais performático
            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                (c,e)=>
                {
                    c.AdicionarEndereco(e);
                    return c;
                },
                new { uid = id }).FirstOrDefault();
            
            //Usando Entity
            //return Db.Clientes.AsNoTracking().Include("Enderecos").FirstOrDefault(c => c.Id == id);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();
            Atualizar(cliente);
        }

        

    }
}
