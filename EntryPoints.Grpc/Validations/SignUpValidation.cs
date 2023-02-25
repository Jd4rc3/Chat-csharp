using System.Text.RegularExpressions;
using EntryPoints.Grpc.Dtos.Protos;
using FluentValidation;

namespace EntryPoints.Grpc.Validations
{
    public class SignUpValidation : AbstractValidator<SignUpRequest>
    {
        public SignUpValidation()
        {
            RuleFor(s => s.Correo)
                .Must(e =>
                {
                    Regex rx = new Regex(
                        "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
                    return rx.Match(e).Length > 0;
                })
                .WithMessage("Correo electrónico inválido").NotNull();
            
            RuleFor(s => s.Nombre).NotNull().NotEmpty();

            RuleFor(s => s.Clave).Must(e => Regex.IsMatch(e, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            .WithMessage("Mínimo 8 caracteres 1 minúscula, 1 mayúscula, y un carácter especial");
        }
    }
}