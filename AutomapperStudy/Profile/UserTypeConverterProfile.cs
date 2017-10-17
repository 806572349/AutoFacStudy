using AutoMapper;
using AutomapperStudy.TypeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy.Profiles
{
    /// <summary>
    /// 类型转化
    /// </summary>
   public  class UserTypeConverterProfile : Profile
    {
        public UserTypeConverterProfile() {
            CreateMap<User, UserDto6>();
           // CreateMap<User, UserDto5>().ForMember(dto=>dto.Type,u1=>u1.MapFrom(u2=>((TypeEnum)u2.Type).GetRemark()));//这个也可实现枚举类型的转化
            CreateMap<int, string>().ConvertUsing<GenderTypeConvertert>();
            //CreateMap<User, UserDto5>();
        }
    }
}
