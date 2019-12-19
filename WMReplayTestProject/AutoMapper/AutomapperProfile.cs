using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.DAL.Entities;
using WMReplayTestProject.WEB.Models;

namespace WMReplayTestProject.WEB.AutoMapper
{
    public class AutomapperProfile :Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<RegisterViewModel, UserDTO>().ReverseMap();
            CreateMap<TagViewModel, TagDTO>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryDTO>().ReverseMap();
            CreateMap<ArticleViewModel, ArticleDTO>().ReverseMap();

        }
    }
}
