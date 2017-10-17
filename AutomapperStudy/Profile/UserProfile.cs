using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy.Profiles
{
    public class UserProfile : Profile
    {
        /// <summary>
        /// 版本6.1的写法
        /// </summary>
        public UserProfile()
        {
            base.CreateMap<User, UserDto2>().ForMember(dto => dto.Name2, u1 => u1.MapFrom(u2 => u2.Name));
        }
    }
}
