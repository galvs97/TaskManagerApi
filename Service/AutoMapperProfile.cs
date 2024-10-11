using AutoMapper;
using TaskManagerApi.Data.Models;
using TaskManagerApi.ViewModels; 

namespace TaskManagerApi.Service 
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile() 
        {
            CreateMap<TbTask, TaskModel>().ReverseMap();
        }
    }
}
