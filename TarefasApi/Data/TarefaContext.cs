using System.Data;  // Importa o namespace para utilizar a interface IDbConnection.
using System.Runtime.Intrinsics.X86;

namespace TarefasApi.Data
{
    // Classe que contém o contexto relacionado às tarefas no banco de dados.
    public class TarefaContext
    {
        // Define um delegate chamado GetConnection que retorna uma Task<IDbConnection>.
        public delegate Task<IDbConnection> GetConnection();

        /*Essa classe TarefaContext contém um delegate chamado GetConnection. Um delegate é um tipo que define a assinatura de um ou mais métodos.
         * Neste caso, GetConnection é um delegate que representa um método que retorna uma Task<IDbConnection>. Essa assinatura sugere que este
         * método é responsável por fornecer uma conexão com o banco de dados de forma assíncrona. O uso de Task indica que a operação pode ser 
         * assíncrona, o que é comum ao trabalhar com bancos de dados.*/

    }
}
