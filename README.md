# Curso-WebAPI-Macoratti

# Requisitos para rodar projeto
	- 	SQL Server (Alterar string de conexão para a configuração do seu SQl Server)
    - 	Abrir terminal na camada de infrastructure e rodar o comando dotnet ef database update(Aplicará os dados da migration no banco)

# Padrões de roteamento
   	[Route("api/[controller]")] - api/products
   	[HttpGet("first")] - api/products/firt
   	[HttpGet("{id}")] - api/products/id
   	[HttpGet("/first")] - first
   	[HttpGet("second/{id}")] - api/products/second/id=3
   	[HttpGet("{id}/{param2?}")] - api/products/id/param2

# Tipos de retorno
	- 	IActionResult: Esse tipo de  retorno é apropriado quando vários ActionResult tipos de retorno são possíveis em uma ação. Os tipos ActionResult representam vários códigos de status HTTP
	- 	ActionResult<T>:  Esse tipo de retorno alem de retornar os ActionResult(Códigos HTTP), o mesmo aceita tipos. EX: ActionResult<Products>
 
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

# Middleware
 	De uma forma simples, é uma camada no meio de duas aplicações, ou seja, uma camada que ajuda duas aplicações, partes, sistemas, a se comunicarem. Um middlerare é um "bloco" onde faz um processamento de dados e devolve um response, porem, em alguns casos, um middleware pode se comunicar com outros middlewares.

# Modelo de Configuração
	A configuração de aplicatiovos no ASP.NET CORE se baseia em uma lista de pares chave-valor estabelecidos por provedores de configuração.
   	Os provedores leem os dados de configuração em pares chave-valor de várias fonte de comunicação.
   	EX:
    -	Arquivos no formato JSON, XML, INI, TEXT, etc.
    -	Variaveis de ambiente.
    -	Argumento da linha de comando.
    -	Uma coleção na memória.
    -	Provedores personalizados.
    -	Arquivo de configuração.

# Filtros
	Os filtros são atributos anexados ás classes ou métodos dos controlacores que injetam lógica extra ao processamento da requisição e permitem a implementação de funcionalidades relacionadas a (autorização, exception, log e cache).
   	-  	Eles permitem executar um código personalizado antes ou depois de executar um método action.
   	- 	Permitem também realizar tarefas repetitivas comuns a métodos Actions e são chamados em certos estágios do pipeline.	

# Repository Pattern
	O padrão repositório, faz a mediação entre o domínio e as camadas de mapeamento de dados, agindo como uma coleção de objetos de dominio em memoria. "Martin Fowler". 
	Vantagens:
	-	Minimiza a lógica de consultas na aplicação evitando consultas espalhadas pelo código(encapsula a logica das consultas no repositório)
	-	Desacopla a aplicação dos frameworks de persistência como exemplo o EF Core.
	-	Facilita a realização de testes unitários.  

# Unit of Work
	Unit Of Work ou Unidade de Trabalho é um padrão de projeto onde de acordo com Martin Fowler, o padrão de unidade de trabalho “mantém uma lista de objetos afetados por uma transação, coordena a escrita de mudanças e trata possíveis problemas de concorrência".

# DTO(Data Transfer Objects)
	É um padrão de projeto onde tem como objetivo transportar dados entre camadas de uma aplicação. Como boa prática, não é recomendado que nossos controllers conhecam/acessem nossas classes de dominio, com base nisso, usamos os DTO's para expor somente os dados necessários, restritas a um conjunto de dados.

# AutoMapper
	O AutoMapper é uma biblioteca simples construída para resolver um problema aparentemente complexo, que é livrar-se de um código que mapeou um objeto para outro. Um exemplo muito usado é com o DTO. Em muitos casos, não queremos devolver para o usuário entidade de dominio, e com isso, usamos o automapper para mapear o objeto de dominio para um DTO(DataTransferObject) ou vice-versa.

# Paginação na API REST
	A paginação refere-se em obter resultados parcias na consulta de uma API. Ela permite que as informações sejam divididas entre páginas tendo como objetivo evitar a apresentação de uma única pagina com grande quantidade de dados tornando a aplicação mais rapida e eficente. 

# Autenticação e Autorização
	São recursos utilizados para segurança de nossa aplicação tendo como objetivo controlar/restringir informações/dados.
	- Autenticaçao: Refere-se ao processo de validação. Ex: Verificar a identidade de um usuário pela comparação de credencias apresentadas com outras pré-definidas.
	- Autorização: Refere-se ao processo de validar as permissões que um determinado usuário poderá fazer após autenticado.
	- No ASP.NET Core, existe o recurso nativo que é o Identity para realização de autenticação e autorização. 
	- Provedores externos (Google, Facebook, etcs).
	- Autenticação no servidor com: Identity Server, OpenId, Azure Active Directory, etcs.
	- Esquemas de autenticação:
		- Anônimo: Uma requisição anônima não contém informações de autenticação.
		- Basic: A autenticação básica envia uma cadeia de caracteres codificadas em base64 contendo nome de usuário e senha para o cliente com conexão SSL/HTTPS.
		- Tokens(Bearer) - É um esquema de autenticação HTTP que envolve tokens de segurança, chamado: "tokens de portador"(bearer token), onde pode ser entendido como "dar acesso ao portador do token". O mesmo é uma string cifrada geralmente gerada pelo servidor em resposta de uma requisição de login.

# JWT (Json Web Token)
	Padrão que define uma forma segura de transmitir informações entre duas partes. A transmissão pode ser feita via URL, POST ou em cabeçalho HTTP e a informação é assinada digitalmente por um algoritmo ou par de chaves publica/privada usando RSA(sistema de criptografia de chave publica).
	São usados assim tokens criptografados para permitir o acesso aos recursos de uma WEBAPI (essa abordagem é conhecida como Bearer Authentication)
	- Token JWT é formado por 3 partes: header.payload.signature
	 	- Header: Contém o tipo de token(JWT) e a criptografia usada (HMAC ou RSA)
	 	- Payload: Contém os "pedidos", são usados declarações ou claims associadas ao usuário do token.
		- Signature: Assinatura usada na validação do token usando um "chave secreta" onde é anexada ao final do token que pode ser usado (por quem tiver a chave secreta) para verificar se o emissor do JWT é quem ele afirma ser e se o token é valido(claims). OBS: Para gerar a assinatura usamos o Header o Payload codificando-os e a seguir assinamos usando o algoritmo definido.
		Exemplo Token JWT: EYEWfdfd121.dsdsWDSDSD12.EfdsfeYDS121 
		HEADER{"alg": "HSASA", "typ": "JWT} PAYLOAD{"sub": "1234", "name": "Bruno", "iat": 123421} VERIFY SIGNATURE(base64UrlEncode(header)+ ...)
	- Etapas do processo de autenticação via token JWT
		1.Controlador: Gerar Token
		 	- Verifica as credencias
			- Definir claims do usuário (nome, email, etcs)
			- Definir a chave secreta e algoritmo de encriptação usados.
			- Gerar token com base no emissor, audiência, claims e definir a data de expiração
		2.Startup: Validar o token
			- Validar emissor
			- Validar audiência
			- Validar assinatura com chave secreta
	
	 
	