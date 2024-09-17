<h1>KaskataDDD - Projeto de Gerenciamento de Tarefas</h1>

<p><strong>KaskataDDD</strong> é um sistema de gerenciamento de tarefas desenvolvido utilizando <strong>.NET Core</strong>, seguindo princípios de <strong>DDD (Domain-Driven Design)</strong>, <strong>SOLID</strong>, <strong>POO</strong> e <strong>Clean Architecture</strong>. O projeto tem como objetivo fornecer funcionalidades de cadastro, atualização, remoção e listagem de tarefas, oferecendo uma estrutura modular, escalável e de fácil manutenção.</p>

<h2>Estrutura do Projeto</h2>

<p>O projeto segue a abordagem de separação por camadas, utilizando <strong>Domain-Driven Design (DDD)</strong> para garantir a clareza e separação das responsabilidades. Abaixo está uma breve explicação de cada uma das camadas e seus respectivos diretórios.</p>

<h3>1. KaskataDDD.Application</h3>
<p>Esta camada contém os serviços e a lógica de negócios da aplicação. Ela faz uso das entidades do domínio e realiza operações sobre elas, como:</p>
<ul>
    <li>Cadastro de novas tarefas.</li>
    <li>Atualização de tarefas existentes.</li>
    <li>Remoção de tarefas.</li>
    <li>Listagem de todas as tarefas.</li>
</ul>

<h3>2. KaskataDDD.Domain</h3>
<p>A camada de <strong>Domain</strong> contém as entidades principais e as regras de negócio que definem o comportamento do sistema. As entidades são os objetos de negócios que representam os conceitos essenciais, como:</p>
<ul>
    <li><code>Tarefa</code>: Representa a entidade principal do sistema, com atributos como <code>Id</code>, <code>Título</code>, <code>Descrição</code>, <code>Data de Criação</code> e <code>Status de Conclusão</code>.</li>
    <li><strong>Interfaces</strong> e <strong>Repositórios</strong>: Definições de interfaces que representam abstrações para interagir com os dados.</li>
</ul>

<h3>3. KaskataDDD.Entities</h3>
<p>Nesta camada, encontramos as definições das <strong>entidades</strong> do sistema. As entidades são modelos de dados que possuem a lógica central e atributos da aplicação. Exemplo:</p>
<ul>
    <li><code>Tarefa</code>: Entidade que encapsula as propriedades da tarefa e o comportamento associado, como a conclusão de uma tarefa.</li>
</ul>

<h3>4. KaskataDDD.Infrastructure</h3>
<p>Esta camada contém a implementação de acesso a dados e persistência. É responsável pela interação com o banco de dados, e usa <strong>Entity Framework Core</strong> para realizar as operações de CRUD. Principais componentes:</p>
<ul>
    <li><strong>Repositórios</strong>: Implementação dos repositórios definidos na camada de domínio, como <code>TarefaRepository</code>.</li>
    <li><strong>Configurações do banco de dados</strong>: Define como as entidades são mapeadas e salvas no banco de dados.</li>
</ul>

<h3>5. KaskataDDD.WebService</h3>
<p>A camada de apresentação do sistema, que expõe a API RESTful. Os controladores desta camada fornecem endpoints para interagir com o sistema, utilizando os serviços da camada de aplicação. A API fornece as seguintes operações:</p>
<ul>
    <li><code>GET /api/tarefas</code>: Listar todas as tarefas.</li>
    <li><code>GET /api/tarefas/{id}</code>: Obter uma tarefa específica.</li>
    <li><code>POST /api/tarefas</code>: Criar uma nova tarefa.</li>
    <li><code>PUT /api/tarefas/{id}</code>: Atualizar uma tarefa existente.</li>
    <li><code>DELETE /api/tarefas/{id}</code>: Remover uma tarefa pelo ID.</li>
</ul>

<h3>6. Outros Arquivos</h3>
<ul>
    <li><code>.editorconfig</code>: Arquivo de configuração que define as convenções de estilo de código.</li>
    <li><code>.gitignore</code>: Arquivo que especifica quais arquivos e diretórios devem ser ignorados no controle de versão.</li>
    <li><code>KaskataDDD.sln</code>: Arquivo de solução do Visual Studio que gerencia todos os projetos da aplicação.</li>
</ul>

<h2>Instalação e Configuração</h2>

<h3>Pré-requisitos</h3>
<ul>
    <li><strong>.NET 6.0 SDK</strong> ou superior</li>
    <li><strong>SQL Server</strong> ou outro banco de dados compatível com o Entity Framework Core</li>
    <li><strong>Visual Studio</strong> ou <strong>Visual Studio Code</strong></li>
</ul>

<h3>Passos para Configuração</h3>

<ol>
    <li>
        <p><strong>Clone o repositório:</strong></p>
        <pre><code>git clone https://github.com/seu-usuario/KaskataDDD.git
cd KaskataDDD
        </code></pre>
    </li>
    <li>
        <p><strong>Configurar o banco de dados:</strong></p>
        <p>Atualize a string de conexão no arquivo <code>appsettings.json</code> do projeto <strong>KaskataDDD.WebService</strong> para apontar para o seu banco de dados.</p>
        <pre><code>"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=KaskataDDD;Trusted_Connection=True;MultipleActiveResultSets=true"
}
        </code></pre>
    </li>
    <li>
        <p><strong>Executar as migrações:</strong></p>
        <p>No diretório principal, execute os seguintes comandos para aplicar as migrações e criar o banco de dados:</p>
        <pre><code>dotnet ef database update
        </code></pre>
    </li>
    <li>
        <p><strong>Compilar o projeto:</strong></p>
        <pre><code>dotnet build
        </code></pre>
    </li>
    <li>
        <p><strong>Executar a aplicação:</strong></p>
        <p>Inicie a aplicação usando o comando:</p>
        <pre><code>dotnet run --project KaskataDDD.WebService
        </code></pre>
        <p>A API será exposta no endereço <code>https://localhost:7221/swagger/index.html</code>, onde você poderá acessar a documentação Swagger e testar os endpoints.</p>
    </li>
</ol>

<h2>Tecnologias Utilizadas</h2>
<ul>
    <li><strong>.NET Core 6.0</strong></li>
    <li><strong>Entity Framework Core</strong></li>
    <li><strong>Swagger (OpenAPI)</strong> para documentação da API</li>
    <li><strong>SQL Server</strong> para persistência de dados</li>
    <li><strong>DDD, SOLID, POO e Clean Architecture</strong> como princípios de design</li>
</ul>

<h2>Contribuindo</h2>

<p>Contribuições são bem-vindas! Siga os seguintes passos para colaborar:</p>
<ol>
    <li>Faça um fork do repositório</li>
    <li>Crie uma branch para sua feature (<code>git checkout -b minha-feature</code>)</li>
    <li>Faça commit das suas alterações (<code>git commit -am 'Adicionar nova feature'</code>)</li>
    <li>Envie para o repositório (<code>git push origin minha-feature</code>)</li>
    <li>Crie um novo Pull Request</li>
</ol>

<h2>Licença</h2>

<p>Este projeto está sob a licença <a href="LICENSE">MIT</a>.</p>
