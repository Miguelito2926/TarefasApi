using Dapper.Contrib.Extensions;  // Importa o namespace para usar as extensões do Dapper.
using TarefasApi.Data;  // Importa o namespace para acessar as classes relacionadas aos dados.
using static TarefasApi.Data.TarefaContext;  // Importa o contexto das tarefas.

namespace TarefasApi.Endpoints
{
    public static class TarefasEndpoints
    {
        // Método para mapear os endpoints relacionados às tarefas.
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            // Endpoint raiz da API, retorna uma mensagem de boas-vindas com a hora atual.
            app.MapGet("/", () => $"Bem-vindo a API Tarefas - {DateTime.Now}");

            // Endpoint para obter todas as tarefas.
            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                // Obtém todas as tarefas do banco de dados.
                var tarefas = con.GetAll<Tarefa>().ToList();
                if (tarefas is null)
                {
                    // Retorna 404 Not Found se as tarefas não forem encontradas.
                    return Results.NotFound("Recurso não encontrado.");
                }
                // Retorna 200 OK com a lista de tarefas se encontradas.
                return Results.Ok(tarefas);
            });

            // Endpoint para obter uma tarefa por ID.
            app.MapGet("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                // Obtém a tarefa do banco de dados com o ID fornecido.
                return con.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound("Recurso não encontrado");
            });

            // Endpoint para criar uma nova tarefa.
            app.MapPost("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                // Insere a nova tarefa no banco de dados e retorna o ID gerado.
                var id = con.Insert(tarefa);
                // Retorna 201 Created com o URL da nova tarefa e os dados da tarefa.
                return Results.Created($"/tarefas/{id}", tarefa);
            });

            // Endpoint para atualizar uma tarefa existente.
            app.MapPut("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                // Atualiza a tarefa no banco de dados.
                var id = con.Update(tarefa);
                // Retorna 200 OK.
                return Results.Ok();
            });

            // Endpoint para excluir uma tarefa por ID.
            app.MapDelete("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                // Obtém a tarefa a ser excluída.
                var deleted = con.Get<Tarefa>(id);
                if (deleted is null)
                {
                    // Retorna 404 Not Found se a tarefa não for encontrada.
                    return Results.NotFound("Recurso não encontrado");
                }
                // Exclui a tarefa do banco de dados e retorna 200 OK.
                con.Delete(deleted);
                return Results.Ok();
            });
        }
    }
}
