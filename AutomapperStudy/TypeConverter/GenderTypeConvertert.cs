using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy.TypeConverter
{
    /// <summary>
    /// 属性转化这个比较重要，可以从类型显示，枚举值显示中文标记
    /// </summary>
    public class GenderTypeConvertert : ITypeConverter<int, string>
    {
        public string Convert(int source, string destination, ResolutionContext context)
        {
            switch (source)
            {
                case (int)TypeEnum.成功:
                    destination = TypeEnum.成功.GetRemark();
                    break;
                case (int)TypeEnum.失败:
                    destination = TypeEnum.失败.GetRemark();
                    break;

                default:
                    destination = "6666";
                    break;
            }
            return destination;
        }
    }
}
