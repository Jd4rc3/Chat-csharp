using AutoMapper;
using Domain.Model.Entities;
using DrivenAdapters.Mongo.Entities;
using EntryPoints.Grpc.Dtos.Protos;

namespace Chat.AppServices.Auth.Automapper
{
    /// <summary>
    /// EntityProfile
    /// </summary>
    public class ConfigurationProfile : Profile
    {
        /// <summary>
        /// ConfigurationProfile
        /// </summary>
        public ConfigurationProfile()
        {
            CreateMap<SignUpRequest, Usuario>().ReverseMap();
            CreateMap<Usuario, UsuarioEntity>().ReverseMap();
        }
    }
}