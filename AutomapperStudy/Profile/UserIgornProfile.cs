using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy.Profiles
{
    /// <summary>
    /// 忽略属性，到dto就是null
    /// </summary>
   public  class UserIgornProfile: Profile
    {
        public UserIgornProfile() {
            CreateMap<User, UserDto3>().ForMember("NullText", u1 => u1.Ignore())
                .ForMember(dto=>dto.Name2,u1=>u1.MapFrom(u2=>u2.Name))
                ;
        }
    }
}
