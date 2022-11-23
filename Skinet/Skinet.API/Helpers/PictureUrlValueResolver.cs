using AutoMapper;
using Microsoft.Extensions.Configuration;
using Skinet.API.DTOs;
using Skinet.Core.Entities;

namespace Skinet.API.Helpers
{
    public class PictureUrlValueResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlValueResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (source.PictureUrl is null)
            {
                return null;
            }

            var url = _configuration.GetValue<string>("ImagesUrl");
            return $"{url}{source.PictureUrl}";
        }
    }
}
