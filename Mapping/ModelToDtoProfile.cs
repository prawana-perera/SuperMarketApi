using AutoMapper;
using Supermarket.API.Models;

namespace Supermarket.API.Mapping
{
  public class ModelToDtoProfile : Profile
  {
    public ModelToDtoProfile() {
        CreateMap<Category, CategoryDTO>();
    }
  }
}