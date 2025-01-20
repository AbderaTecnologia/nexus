namespace Nexus.Folha.Domain.Entities;

public sealed class Funcionario
{
    public Guid Id { get; init; }
    public string NomeCompleto { get; init; }
    public DateTime DataNascimento { get; init; }

    public string NomePai { get; init; }

    public string NomeMae { get; init; }

    public string Cep { get; init; }

    public string Endereco { get; init; }

    public string Cidade { get; init; }

    public string UF { get; init; }

    public string LocalNascimento { get; init; }

    public string Telefone { get; init; }

    public string NomeConjuge { get; init; }
}