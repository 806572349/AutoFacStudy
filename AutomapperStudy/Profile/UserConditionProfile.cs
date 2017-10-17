using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy.Profiles
{
    public class UserConditionProfile : Profile
    {
        /// <summary>
        /// 满足某种条件进行映射
        /// </summary>
        public UserConditionProfile()
        {
            CreateMap<User, UserDto6>().ForMember(dto => dto.Age, u1=>u1.Condition(u2=>u2.Age<20&&u2.Age>10));
        }
    }
}
