using FluentValidation;

namespace Nexus.Cadastro.Application.Models.Dtos;

public sealed record OverviewDto(
    string Name,
    string Identifier,
    string Email
);

public sealed class OverviewDtoValidation : AbstractValidator<OverviewDto>
{
    public OverviewDtoValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

        RuleFor(x => x.Identifier).NotEmpty().WithMessage("O CPF é obrigatório")
            .Must(BeAValidCpfOrCnpj).WithMessage("O CPF deve ser válido");

        RuleFor(x => x.Email).NotEmpty().WithMessage("O Email é obrigatório")
            .EmailAddress().WithMessage("O Email deve ser valido");
    }

    private bool BeAValidCpfOrCnpj(string cpfCnpj)
    {
        if (string.IsNullOrWhiteSpace(cpfCnpj))
            return false;

        cpfCnpj = cpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cpfCnpj.Length == 11)
            return IsValidCpf(cpfCnpj);
        else if (cpfCnpj.Length == 14)
            return IsValidCnpj(cpfCnpj);

        return false;

        bool IsValidCpf(string cpf)
        {
            if (cpf.All(c => c == cpf[0]))
                return false;

            int[] multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplier2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            string tempCpf = cpf[..9];
            int sum = tempCpf.Select((t, i) => int.Parse(t.ToString()) * multiplier1[i]).Sum();
            int remainder = sum % 11;
            string digit = (remainder < 2 ? 0 : 11 - remainder).ToString();

            tempCpf += digit;
            sum = tempCpf.Select((t, i) => int.Parse(t.ToString()) * multiplier2[i]).Sum();
            remainder = sum % 11;
            digit = (remainder < 2 ? 0 : 11 - remainder).ToString();

            return cpf.EndsWith(digit);
        }

        bool IsValidCnpj(string cnpj)
        {
            if (cnpj.All(c => c == cnpj[0]))
                return false;

            int[] multiplier1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplier2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

            string tempCnpj = cnpj[..12];
            int sum = tempCnpj.Select((t, i) => int.Parse(t.ToString()) * multiplier1[i]).Sum();
            int remainder = sum % 11;
            string digit = (remainder < 2 ? 0 : 11 - remainder).ToString();

            tempCnpj += digit;
            sum = tempCnpj.Select((t, i) => int.Parse(t.ToString()) * multiplier2[i]).Sum();
            remainder = sum % 11;
            digit = (remainder < 2 ? 0 : 11 - remainder).ToString();
            return cnpj.EndsWith(digit);
        }
    }
}