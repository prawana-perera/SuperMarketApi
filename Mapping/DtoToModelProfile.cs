using AutoMapper;
using Supermarket.API.Models;

namespace Supermarket.API.Mapping
{
  public class DtoToModelProfile : Profile
  {
    public DtoToModelProfile() {
        CreateMap<CreateCategoryDTO, Category>();
    }
  }
}