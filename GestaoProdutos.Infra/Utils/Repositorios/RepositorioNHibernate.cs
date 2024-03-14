using Autoglass.Autoplay.Dominio.Utils.Consultas;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using NHibernate;
using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;

namespace Autoglass.Autoplay.Infra.Utils.Repositorios
{
    public class RepositorioNHibernate<T> : IRepositorioNHibernate<T> where T : class
    {
        protected readonly ISession session;

        public RepositorioNHibernate(ISession session)
        {
            this.session = session;
        }

        public void Editar(T entidade)
        {
            session.Update(entidade);
        }

        public void Excluir(T entidade)
        {
            session.Delete(entidade);
        }

        public void Inserir(T entidade)
        {
            session.Save(entidade);
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd)
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd.ToString());
                return Paginar(query, qt, pg);
            }
            catch (ParseException)
            {
                throw new RegraDeNegocioExcecao("Deu erro no tipo de ordenação");
            }
        }

        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }

        private static PaginacaoConsulta<T> Paginar(IQueryable<T> query, int qt, int pg)
        {
            return new PaginacaoConsulta<T>
            {
                Registros = query.Skip((pg - 1) * qt).Take(qt).ToList(),
                Total = query.LongCount(),
            };
        }
    }
}