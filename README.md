# Curso-WebAPI-Macoratti

# Requisitos para rodar projeto
    - SQL Server (Alterar string de conexão para a configuração do seu SQl Server)
    - Abrir terminal na camada de infrastrucure e rodar o comando dotnet ef database update(Aplicará os dados da migration no banco)

# Padrões de roteamento
   [Route("api/[controller]")] - api/products
    [HttpGet("first")] - api/products/firt
    [HttpGet("{id}")] - api/products/id
    [HttpGet("/first")] - first
    [HttpGet("second/{id}")] - api/products/second/id=3
    [HttpGet("{id}/{param2?}")] - api/products/id/param2

# Tipos de retorno
    - IActionResult: Esse tipo de  retorno é apropriado quando vários ActionResult tipos de retorno são possíveis em uma ação. Os tipos ActionResult representam vários códigos de status HTTP
        
    - ActionResult<T>:  Esse tipo de retorno alem de retornar os ActionResult(Códigos HTTP), o mesmo aceita tipos. EX: ActionResult<Products>
 
 # Métodos Síncronos/Assíncronos
    - Síncrono: Métodos síncronos uma vez chamados, "bloqueam" a aplicação enquanto o retorno não for dado, com isso em alguns casos, pode atrapalhar a experencia do uso da aplicação uma vez que enquanto o método estiver em processamento, não será possivel realizar outras tarefas na aplicação.
    - Assíncrono: No C# usamos as palavras reservadas (Task, async e await) para deixarmos nossos métodos assincronos. De uma forma simples, são métodos que após serem chamados, não "bloqueia" a aplicação enquanto estiver processando os dados ou etcs, o mesmo irá fazer suas "tarefas" e quando acabar de fazer, irá devolver o response.

  