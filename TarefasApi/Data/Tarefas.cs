using System.ComponentModel.DataAnnotations.Schema;  // Importa o namespace para utilizar a anotação [Table].

namespace TarefasApi.Data
{
    // Define a classe Tarefa como um registro (record), representando uma entidade no banco de dados.
    [Table("Tarefas")]  // Atribui a tabela "Tarefas" à classe Tarefa no banco de dados.
    public record Tarefa(int Id, string Atividade, string Status);
    // A classe tem três propriedades: Id, Atividade e Status.
    // Essa classe pode ser usada para mapear objetos Tarefa para linhas na tabela "Tarefas" do banco de dados.
}
