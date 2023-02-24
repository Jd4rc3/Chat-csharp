using EntryPoints.Grpc.Dtos.Protos;
using FluentValidation;
using Grpc.Core;
using System.Text.RegularExpressions;

namespace EntryPoints.Grpc.Validations
{
    public class SignUpValidation : AbstractValidator<SignUpRequest>
    {
        public SignUpValidation()
        {
            try
            {
                RuleFor(s => s.Correo).Must(e => Regex.IsMatch(e,
        @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)
*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)
                )
               .WithMessage("Invalid email").NotNull();
                RuleFor(s => s.Nombre).NotNull().NotEmpty();
            }
            catch (RpcException e)
            {
                throw;
            }

            //RuleFor(s => s.Clave).Must(e => Regex.IsMatch(e, @"^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[@$!%?&])[A-Za-z\d@$!%?&]{8,}$"))
            //.WithMessage("Mínimo 8 caracteres 1 minúscula, 1 mayúscula, y un carácter especial");
        }
    }
}