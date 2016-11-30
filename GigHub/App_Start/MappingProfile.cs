using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GigHub.Controllers.Api;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        //protected override void Configure()
        //{
        //    this.CreateMap<Genre, GenreDto>();
        //    base.Configure();
        //}

        public MappingProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();

            //Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<ApplicationUser, UserDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Gig, GigDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Notification, NotificationDto>());
        }

    }
}