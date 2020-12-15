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

 # Model Binding
    É um recurso que permite mapear dados de uma requisição HTTP para os parâmetros de uma Action de um controlador. Esse mapeamento inclui todos os tipos de parâmetro: int, strings, arrays, lists, Complex Types, Object List entre outros. 
   [FromForm] - Utilizado para dados recebidos de um formulário.
   [FromRoute] - Vincula apenas os dados que são oriundos da rota de dados.
   [FromQuery] - Recebe apenas os dados da cadeia de consulta(QueryString)
   [FromHeader] - Vincula os valores que vêm no cabeçalho da requisição HTTP
   [FromBody] - Vincula os dados apartir do Body do request.
   [FromServices] - Permite injetar as dependencias diretamente no método Action do controlador que requer a dependência.

 # Data Annotations
    Fornece classes e atributos que são usados para realizar a validação dos dados, o mesmo permite aplicar validação no modelo de dominiio definindo atributos. EX:
    [Required] - Informa que a entrada de um dado é obrigatória
    [StringLength] - Restringe o tamanho de uma string
    [MaxLength] - Determina o tamanho máximo do campo da tabela(EF CORE)

    OBS: Podemos criar nossos próprios Data Annotations, criando uma classe onde a mesma deve ser herdada da classe ValidationAttribute e sobrecrever o método IsValid