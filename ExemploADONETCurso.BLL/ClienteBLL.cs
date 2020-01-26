using ExemploADONETCurso.DAL;
using ExemploADONETCurso.Domain;
using ExemploADONETCurso.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploADONETCurso.BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL dal;

        public ClienteBLL()
        {
            dal = new ClienteDAL();
        }

        public Cliente Buscar(int id)
        {
            return dal.Buscar(id);
        }

        public List<Cliente> Buscar()
        {
            return dal.Buscar();
        }

        public void Inserir(Cliente c)
        {
            if (string.IsNullOrWhiteSpace(c.Nome))
            {
                throw new BusinessException("O nome deve ser preenchido");
            }

            dal.Inserir(c);
        }

        public void Atualizar(Cliente c)
        {
            dal.Atualizar(c);
        }

        public void Excluir(Cliente c)
        {
            dal.Excluir(c);
        }
    }
}
