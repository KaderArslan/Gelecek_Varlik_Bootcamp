using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Dto;
using Workfollow.Entity.Models;

namespace Workfollow.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap: map oluştur
            //veritabanindan bir personel geliyorsa bunu modele donusturebilelim
            // ya personel kaydediyorsak o yuzden birbirine donuzturuyoruz bu seferde modele donuzturmamiz lazim

            CreateMap<Employee, DtoEmployee>().ReverseMap(); 
            CreateMap<Employee, DtoLoginEmployee>();
            CreateMap<DtoLogin, Employee>();
            CreateMap<Employee, DtoEmployeeRegister>().ReverseMap();
            CreateMap<DtoUpdatePassword, Employee>();

            CreateMap<Request, DtoRequest>().ReverseMap();
            CreateMap<Request, DtoAddRequest>();

            CreateMap<Department, DtoDepartment>().ReverseMap();

            CreateMap<JobList, DtoJobList>().ReverseMap();
            CreateMap<JobList, DtoJobListDetails>();

            CreateMap<Messaging, DtoMessaging>().ReverseMap(); //emin degilim

            CreateMap<Role, DtoRole>(); //emin degilim
        }
    }
}
