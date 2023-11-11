// Importa os namespaces necessários para o código.
using System.Data.SqlClient;  // Importa o namespace para usar o SqlConnection.
using static TarefasApi.Data.TarefaContext;  // Importa o contexto das tarefas.

namespace TarefasApi.Extensions
{
    // Classe de extensão para ServiceCollection.
    public static class ServiceCllectionsExtensions
    {
        // Método de extensão para adicionar persistência à aplicação web.
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            // Obtém a string de conexão do arquivo de configuração (appsettings.json).
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Adiciona um serviço escopo (Scoped) para obter a conexão com o banco de dados.
            builder.Services.AddScoped<GetConnection>(sp =>
                async () =>
                {
                    // Cria uma nova conexão com o banco de dados usando a string de conexão.
                    var connection = new SqlConnection(connectionString);

                    // Abre a conexão de forma assíncrona.
                    await connection.OpenAsync();

                    // Retorna a conexão aberta.
                    return connection;
                });

            // Retorna o construtor da aplicação web com a persistência adicionada.
            return builder;
        }
    }
}
