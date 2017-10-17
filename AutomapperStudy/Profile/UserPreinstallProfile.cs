using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy.Profiles
{
  public  class UserPreinstallProfile: Profile
    {
        /// <summary>
        /// dto属性多了，
        /// </summary>
        public UserPreinstallProfile() {
            CreateMap<User, UserDto4>();
        }
    }
}
