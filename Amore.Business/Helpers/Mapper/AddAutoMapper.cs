using Amore.Business.Helpers.DTOs.HeadBanner;
using Amore.Business.Helpers.DTOs.Logo;
using Amore.Business.Helpers.DTOs.Slider;
using Amore.Business.Helpers.DTOs.Slogan;
using Amore.Business.Helpers.DTOs.UploadFile;
using Amore.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Amore.Business.Helpers.Mapper
{
    public class AddAutoMapper : Profile
    {
        public AddAutoMapper()
        {
            CreateMap<CreateHeadBannerDto, HeadBanner>().ReverseMap();
            CreateMap<UpdateHeadBannerDto, HeadBanner>().ReverseMap();
            CreateMap<GetHeadBannerDto, HeadBanner>().ReverseMap();

            CreateMap<CreateLogoDto, Logo>().ReverseMap();
            CreateMap<UpdateLogoDto, Logo>().ReverseMap();
            CreateMap<GetLogoDto, Logo>().ReverseMap();

            CreateMap<GetUploadFileDto, string>().ReverseMap();

            CreateMap<CreateSliderDto, Slider>().ReverseMap();
            CreateMap<UpdateSliderDto, Slider>().ReverseMap();
            CreateMap<GetSliderDto, Slider>().ReverseMap();

            CreateMap<CreateSloganDto, Slogan>().ReverseMap();
            CreateMap<UpdateSloganDto, Slogan>().ReverseMap();
            CreateMap<GetSloganDto, Slogan>().ReverseMap();


        }
    }
}