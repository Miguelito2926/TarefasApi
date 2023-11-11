// Importa os namespaces necessários para o código.
using TarefasApi.Endpoints;  // Importa o namespace que contém os endpoints relacionados às tarefas.
using TarefasApi.Extensions;  // Importa o namespace que contém as extensões específicas da API.

// Criação do construtor da aplicação web.
var builder = WebApplication.CreateBuilder(args);

// Adiciona a persistência (provavelmente configurações do banco de dados, conexões, etc.).
builder.AddPersistence();

// Constrói a aplicação web com as configurações fornecidas.
var app = builder.Build();

// Mapeia os endpoints relacionados às tarefas na aplicação.
app.MapTarefasEndpoints();

// Inicia a execução da aplicação web.
app.Run();
