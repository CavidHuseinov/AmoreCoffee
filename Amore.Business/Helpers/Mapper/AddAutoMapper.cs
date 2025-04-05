using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Category;
using Amore.Business.Helpers.DTOs.Checkout;
using Amore.Business.Helpers.DTOs.ContactForm;
using Amore.Business.Helpers.DTOs.HeadBanner;
using Amore.Business.Helpers.DTOs.Location;
using Amore.Business.Helpers.DTOs.Logo;
using Amore.Business.Helpers.DTOs.Order;
using Amore.Business.Helpers.DTOs.OrderProduct;
using Amore.Business.Helpers.DTOs.Payment;
using Amore.Business.Helpers.DTOs.Product;
using Amore.Business.Helpers.DTOs.ProductTag;
using Amore.Business.Helpers.DTOs.ProductVariant;
using Amore.Business.Helpers.DTOs.Promocode;
using Amore.Business.Helpers.DTOs.Review;
using Amore.Business.Helpers.DTOs.ShippingInfo;
using Amore.Business.Helpers.DTOs.Slider;
using Amore.Business.Helpers.DTOs.Slogan;
using Amore.Business.Helpers.DTOs.SocialMedia;
using Amore.Business.Helpers.DTOs.Spotify;
using Amore.Business.Helpers.DTOs.Tag;
using Amore.Business.Helpers.DTOs.UploadFile;
using Amore.Business.Helpers.DTOs.User;
using Amore.Business.Helpers.DTOs.UserPromocode;
using Amore.Business.Helpers.DTOs.Variant;
using Amore.Business.Helpers.Validators.UploadFileValidator;
using Amore.Core.Entities;
using AutoMapper;

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

            CreateMap<CreateSliderDto, Slider>().ReverseMap();
            CreateMap<UpdateSliderDto, Slider>().ReverseMap();
            CreateMap<GetSliderDto, Slider>().ReverseMap();

            CreateMap<CreateSloganDto, Slogan>().ReverseMap();
            CreateMap<UpdateSloganDto, Slogan>().ReverseMap();
            CreateMap<GetSloganDto, Slogan>().ReverseMap();

            CreateMap<GetUploadFileDto, string>().ReverseMap();

            CreateMap<CreateLocationDto, Location>().ReverseMap();
            CreateMap<UpdateLocationDto, Location>().ReverseMap();
            CreateMap<GetLocationDto, Location>().ReverseMap();

            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaDto, SocialMedia>().ReverseMap();

            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();

            CreateMap<Tag, GetTagDto>().ReverseMap();
            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>().ReverseMap();

            CreateMap<GetProductTag, ProductTag>().ReverseMap();
            CreateMap<CreateProductTag, ProductTag>().ReverseMap();

            CreateMap<LoginDto, AppUser>().ReverseMap();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<ProfileUpdateDto, AppUser>().ReverseMap();

            CreateMap<ContactFormDto, string>().ReverseMap();

            CreateMap<GetOrderDto, Order>().ReverseMap();
            CreateMap<CreateOrderDto, Order>().ReverseMap();

            CreateMap<GetReviewDto, Review>().ReverseMap();
            CreateMap<CreateReviewDto, Review>().ReverseMap();

            CreateMap<GetCheckoutDto, Checkout>().ReverseMap();
            CreateMap<CreateCheckoutDto, Checkout>().ReverseMap();


            CreateMap<GetShippingInfoDto, ShippingInfo>().ReverseMap();
            CreateMap<CreateShippingInfoDto, ShippingInfo>().ReverseMap();

            CreateMap<PaymentRequestDto, string>().ReverseMap();
            CreateMap<PaymentResponseDto, string>().ReverseMap();

            CreateMap<GetOrderProductDto, OrderProduct>().ReverseMap();
            CreateMap<CreateOrderProductDto, OrderProduct>().ReverseMap();

            CreateMap<GetPromocodeDto, Promocode>().ReverseMap();
            CreateMap<CreatePromocodeDto, Promocode>().ReverseMap();

            CreateMap<GetUserPromocodeDto, UserPromocode>().ReverseMap();
            CreateMap<CreateUserPromocodeDto, UserPromocode>().ReverseMap();

            CreateMap<GetVariantDto, Variant>().ReverseMap();
            CreateMap<CreateVariantDto, Variant>().ReverseMap();
            CreateMap<UpdateVariantDto, Variant>().ReverseMap();

            CreateMap<GetProductVariantDto, ProductVariant>().ReverseMap();
            CreateMap<CreateProductVariant, ProductVariant>().ReverseMap();

            CreateMap<CustomPlaylistDto, SpotifyPlaylist>().ReverseMap();

        }
    }
}
