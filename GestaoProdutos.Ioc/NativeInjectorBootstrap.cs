using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GestaoProdutos.Aplicacao.Fornecedores.Profiles;
using GestaoProdutos.Aplicacao.Fornecedores.Servicos;
using GestaoProdutos.Dominio.Fornecedores.Servicos;
using GestaoProdutos.Infra.Fornecedores.Mapeamentos;
using GestaoProdutos.Infra.Fornecedores.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace GestaoProdutos.Ioc;

public class NativeInjectorBootstrap
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISessionFactory>(factory =>
            {
                string connectionString = configuration.GetConnectionString("MySql");
                return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString)
                .FormatSql()
                .ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<FornecedorMap>())
                .BuildSessionFactory();
            });

            services.AddScoped<NHibernate.ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());

            services.AddScoped<ITransaction>(factory => factory.GetService<ISession>()!.BeginTransaction());

            services.AddAutoMapper(typeof(FornecedoresProfile));

            services.Scan(scan => scan
                .FromAssemblyOf<FornecedoresAppServico>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                            .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<FornecedoresServico>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                            .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<FornecedoresRepositorio>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                            .WithScopedLifetime());
        } 
}
