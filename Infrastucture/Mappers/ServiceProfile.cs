using AutoMapper;
using Domain.Entities;

namespace Infrastucture.Meppers;
public class ServicesProfile:Profile
{
    public ServicesProfile()
    {
        CreateMap<AddTodoDto, Todo>()
        .ForMember(dest=>dest.ImageName, opt=>opt.MapFrom(scr=>scr.Image.FileName));
        CreateMap<Todo, GetTodoDto>().ReverseMap();
        CreateMap<GetTodoDto, AddTodoDto>().ReverseMap();
    }
}