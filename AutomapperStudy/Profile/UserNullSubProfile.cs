using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy.Profiles
{
    /// <summary>
    /// 为空时
    /// </summary>
    public class UserNullSubProfile : Profile
    {
        public UserNullSubProfile()
        {
            CreateMap<User, UserDto3>().ForMember(dto => dto.Name2, u1 => u1.MapFrom(u2 => u2.Name))
                .ForMember(dto => dto.NullText, u1 => u1.NullSubstitute("为空"));
        }
    }
}
