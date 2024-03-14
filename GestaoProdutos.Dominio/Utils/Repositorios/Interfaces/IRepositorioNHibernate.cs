using Autoglass.Autoplay.Dominio.Utils.Consultas;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces
{
    public interface IRepositorioNHibernate<T> where T : class
    {
        void Inserir(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
        T Recuperar(int id);
        IQueryable<T> Query();
        PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd);
    }
}