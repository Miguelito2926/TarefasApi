// Importa os namespaces necess�rios para o c�digo.
using TarefasApi.Endpoints;  // Importa o namespace que cont�m os endpoints relacionados �s tarefas.
using TarefasApi.Extensions;  // Importa o namespace que cont�m as extens�es espec�ficas da API.

// Cria��o do construtor da aplica��o web.
var builder = WebApplication.CreateBuilder(args);

// Adiciona a persist�ncia (provavelmente configura��es do banco de dados, conex�es, etc.).
builder.AddPersistence();

// Constr�i a aplica��o web com as configura��es fornecidas.
var app = builder.Build();

// Mapeia os endpoints relacionados �s tarefas na aplica��o.
app.MapTarefasEndpoints();

// Inicia a execu��o da aplica��o web.
app.Run();
