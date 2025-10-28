# OSLite — Mini-domínio Ordem de Serviço

Projeto didático que modela um **mini-domínio de Ordem de Serviço** para assistência técnica usando:

* **Classes** para entidades (Cliente, OrdemDeServico, ItemDeServico)
* **record / record struct** para value objects (Email, Money)
* **enum** para estados (`StatusOS`)
* **Fail-fast** com exceções de domínio para proteger invariantes
* **TDD** com testes xUnit cobrindo cenários felizes e de falha

---

## Tecnologias

* .NET 8 (C#)
* xUnit para testes
* Projeto pensado para rodar com `dotnet` CLI (`dotnet build`, `dotnet test`)

---

## Estrutura do repositório

```
/OSLite
 ├── Domain
 │   ├── Cliente.cs
 │   ├── OrdemDeServico.cs
 │   ├── ItemDeServico.cs
 │   ├── ValueObjects
 │   │    ├── Email.cs
 │   │    └── Money.cs
 │   └── Enums
 │        └── StatusOS.cs
 ├── Exceptions
 │   ├── DomainException.cs
 │   ├── EmailInvalidoException.cs
 │   ├── StatusInvalidoException.cs
 │   └── ValorInvalidoException.cs
 ├── Tests
 │   ├── OrdemDeServicoTests.cs
 │   ├── ClienteTests.cs
 │   └── ItemDeServicoTests.cs
 └── Program.cs
```

---

## Visão geral do domínio

* **Cliente**: entidade com identidade (`Guid`), nome e `Email` (value object). Possui coleção de `OrdemDeServico` (1:N). Navegabilidade bidirecional: cliente -> ordens e ordem -> cliente.
* **OrdemDeServico**: entidade que contém itens (composição 1:N). Tem `StatusOS` (enum) e expõe `Total` calculado a partir dos `ItemDeServico`.
* **ItemDeServico**: entidade simples com `Descricao` e `Preco` (Money).
* **Value Objects**: `Email` (validação por regex) e `Money` (valor decimal não negativo). Implementados como `record struct` imutáveis.
* **Enums**: `StatusOS` possui `Aberta`, `EmAndamento`, `Concluida`, `Cancelada`.

---

## Invariantes e regras de negócio (fail-fast)

* `Email` inválido lança `EmailInvalidoException`.
* `Money` com valor negativo lança `ValorInvalidoException`.
* Só é possível **adicionar itens** em uma OS que esteja `Aberta`.
* `Iniciar()` só funciona quando `Status == Aberta`.
* `Concluir()` só funciona quando `Status == EmAndamento`.
* `Cancelar()` não permite cancelar uma OS `Concluida`.
* Todas as violações disparam exceções de domínio específicas, garantindo comportamento **fail-fast**.

---

## Como rodar (CLI)

1. Clone este repositório.
2. Abra o terminal na raiz do projeto.
3. Para compilar: `dotnet build`
4. Para executar testes: `dotnet test`

> Recomenda-se ter instalado o .NET 8 SDK.

---

## Exemplos de uso (em código)

```csharp
var cliente = new Cliente("Ana", new Email("ana@teste.com"));
var os = new OrdemDeServico();
os.AdicionarItem(new ItemDeServico("Limpeza interna", new Money(80)));
cliente.AdicionarOrdem(os);

os.Iniciar();
os.Concluir();

Console.WriteLine(os.Total); // Money
Console.WriteLine(os.Status); // StatusOS.Concluida
```

---

## Testes incluídos

* `OrdemDeServicoTests` — total calculado, transições de status corretas, bloqueios de operações por estado
* `ClienteTests` — associação cliente ↔ ordem
* `ItemDeServicoTests` — criação e proteção de invariantes básicas

---

## Decisões de modelagem (resumo)

* Usamos **classes** para entidades porque possuem identidade e ciclo de vida.
* Usamos **record structs** para value objects (`Email`, `Money`) para garantir imutabilidade e igualdade por valor.
* **Enums** para estados tornam o domínio mais legível e menos sujeito a erros de strings.
* Evitamos herança e polimorfismo por restrição do exercício; o design fica mais simples e explícito.

---

## Reflexão curta (impacto de records/structs e enums)

O uso de `record struct` para value objects melhora a expressividade e a segurança: imutabilidade e igualdade por valor reduzem bugs e facilitam testes (objetos pequenos e determinísticos). Enums tornam estados explícitos e evitam strings "mágicas", simplificando transições e validações. Juntos, eles aumentam a clareza do modelo, tornam invariantes mais fáceis de expressar e testam comportamentos de forma isolada, resultando em código mais robusto e de manutenção mais simples.

---

## Contribuição

Pull requests são bem-vindos. Para alterações de comportamento do domínio, favor adicionar testes que cubram os novos cenários.

---

## Licença

Este projeto de exemplo é fornecido sem licença específica — adapte conforme sua necessidade. Se desejar, posso adicionar MIT/Apache/Outro.

---

Se quiser, eu posso:

1. Gerar o `.zip` do projeto pronto para abrir no Visual Studio / Rider (com `.csproj` e `dotnet` config).
2. Adicionar um `README.md` em outro idioma (inglês) ou incluir badges (build/test).

Diga o que prefere.
