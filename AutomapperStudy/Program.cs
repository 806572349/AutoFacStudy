using AutoMapper;
using AutomapperStudy.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy
{
    class Program
    {
        static void Main(string[] args)
        {

            AutoMapperOne();
            Console.WriteLine("-----------------------");
            AutoMapperTwo();
            Console.WriteLine("----------");
            AutoMapperThree();
            AutoMapperFour();
            AutoMapperFive();
            AutoMapperSix();
            AutpMapperSevevn();
            AutpMapperEight();
            //1.普通转换  
            Name name1 = new Name() { FirstName = "L", LastName = "jz" };
            Mapper.Initialize(x => x.CreateMap<Name, NameDto>().BeforeMap((name, nameDto) => Console.WriteLine("hello world before"))
            .AfterMap((name, nameDto) => Console.WriteLine("hello world after")));
            NameDto nameDto1 = Mapper.Map<Name, NameDto>(name1);
            Console.WriteLine("1");
            Console.WriteLine(nameDto1.FirstName + nameDto1.LastName);
            Console.WriteLine();
            Console.Read();
        }
        /// <summary>
        /// 最简单的使用AutoMapper
        ///  AutoMapper会更加字段名称去自动对于，忽略大小写。
        /// </summary>
        public static void AutoMapperOne()
        {
            Mapper.Initialize(x => x.CreateMap<User, UserDto>());
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20
            };
            UserDto dto = Mapper.Map<UserDto>(user);
            Console.WriteLine(dto.Age + dto.Name);
        }
        /// <summary>
        /// 如果属性名称不同
        /// </summary>
        public static void AutoMapperTwo()
        {
            Mapper.Initialize(x => x.CreateMap<User, UserDto2>().ForMember(d => d.Name2, opt => opt.MapFrom(s => s.Name)));
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20
            };
            UserDto2 dto = Mapper.Map<UserDto2>(user);
            Console.WriteLine(dto.Age + dto.Name2);
        }

        /// <summary>
        /// 通过配置类来实现转化
        /// </summary>
        public static void AutoMapperThree()
        {
            Mapper.Initialize(x => x.AddProfile<UserProfile>());//可以在MVC中Global中一次性注册
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20,

            };
            UserDto2 dto = Mapper.Map<UserDto2>(user);
            Console.WriteLine(dto.Age + dto.Name2);
        }



        /// <summary>
        /// 原数据某个属性为空时，dto显示自定义属性
        /// </summary>
        public static void AutoMapperFour()
        {
            Mapper.Initialize(x => x.AddProfile<UserNullSubProfile>());//可以在MVC中Global中一次性注册
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20,
            };
            UserDto3 dto = Mapper.Map<UserDto3>(user);
            Console.WriteLine(dto.Age + dto.Name2 + dto.NullText);
        }


        /// <summary>
        /// 忽略属性
        /// </summary>
        public static void AutoMapperFive()
        {
            Mapper.Initialize(x => x.AddProfile<UserIgornProfile>());//可以在MVC中Global中一次性注册
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20,
                NullText = "123"
            };
            UserDto3 dto = Mapper.Map<UserDto3>(user);
            Console.WriteLine(dto.Age + dto.Name2 + dto.NullText);
        }

        /// <summary>
        /// 预设值
        /// 如果目标属性多于源属性，可以进行预设值
        /// </summary>
        public static void AutoMapperSix()
        {
            Mapper.Initialize(x => x.AddProfile<UserPreinstallProfile>());//可以在MVC中Global中一次性注册
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20,
                NullText = "123",

            };
            UserDto4 dto = new UserDto4() { MoreParams = "66666" };
            Mapper.Map<User, UserDto4>(user, dto);
            Console.WriteLine(dto.Age + dto.Name2 + dto.NullText + dto.MoreParams);
        }
        /// <summary>
        /// 属性名相同，属性类型不同，可进行转化；
        /// </summary>
        public static void AutpMapperSevevn()
        {

            Mapper.Initialize(x => x.AddProfile<UserTypeConverterProfile>());//可以在MVC中Global中一次性注册
            User user = new User()
            {
                Type=1
            };
            UserDto6 dto= Mapper.Map<UserDto6>(user);
            Console.WriteLine("77777"+dto.Age + dto.Name2 + dto.NullText + dto.MoreParams+dto.Type);

        }

        /// <summary>
        /// 满足某种条件进行映射
        /// </summary>
        public static void AutpMapperEight()
        {

            Mapper.Initialize(x => x.AddProfile<UserConditionProfile>());//可以在MVC中Global中一次性注册
            User user = new User()
            {
                Age=30,
                Type = 1
            };
            UserDto6 dto = Mapper.Map<UserDto6>(user);
            Console.WriteLine("8888" + dto.Age + dto.Name2 + dto.NullText + dto.MoreParams + dto.Type);

        }

        public class Store
        {
            public Name Name { get; set; }
            public int Age { get; set; }
        }

        public class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class StoreDto
        {
            public NameDto Name { get; set; }
            public int Age { get; set; }
        }

        public class NameDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AllName { get; set; }
        }

        public class FlattenName
        {
            public string NameFirstname { get; set; }
            public string NameLastName { get; set; }
        }

    //    #region All
    //    public void All() {



    //        //1.普通转换  
    //        Name name1 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .BeforeMap((name, nameDto) => Console.WriteLine("hello world before"))
    //        .AfterMap((name, nameDto) => Console.WriteLine("hello world after"));
    //        NameDto nameDto1 = Mapper.Map<Name, NameDto>(name1);
    //        Console.WriteLine("1");
    //        Console.WriteLine(nameDto1.FirstName + nameDto1.LastName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //整体设置  
    //        //2.整体即时转换  
    //        Mapper.Reset();
    //        Name name2 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ConstructUsing(name => new NameDto() { AllName = name.FirstName + name.LastName });
    //        NameDto nameDto2 = Mapper.Map<Name, NameDto>(name2);
    //        Console.WriteLine("2");
    //        Console.WriteLine(nameDto2.AllName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //3.整体通过TypeConverter类型转换  
    //        Mapper.Reset();
    //        Name name3 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ConvertUsing<NameConverter>();
    //        NameDto nameDto3 = Mapper.Map<Name, NameDto>(name3);
    //        Console.WriteLine("3");
    //        Console.WriteLine(nameDto3.AllName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //单属性设置  
    //        //4.属性条件转换  
    //        Mapper.Reset();
    //        Name name4 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ForMember(name => name.FirstName, opt => opt.Condition(name => !name.FirstName.Equals("l", StringComparison.OrdinalIgnoreCase)));
    //        NameDto nameDto4 = Mapper.Map<Name, NameDto>(name4);
    //        Console.WriteLine("4");
    //        Console.WriteLine(string.IsNullOrEmpty(nameDto4.FirstName));
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //5.属性忽略  
    //        Mapper.Reset();
    //        Name name5 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ForMember(name => name.FirstName, opt => opt.Ignore());
    //        NameDto nameDto5 = Mapper.Map<Name, NameDto>(name5);
    //        Console.WriteLine("5");
    //        Console.WriteLine(string.IsNullOrEmpty(nameDto5.FirstName));
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //6.属性转换  
    //        Mapper.Reset();
    //        Name name6 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ForMember(name => name.AllName, opt => opt.MapFrom(name => name.FirstName + name.LastName))
    //        .ForMember(name => name.FirstName, opt => opt.MapFrom(name => name.FirstName));
    //        NameDto nameDto6 = Mapper.Map<Name, NameDto>(name6);
    //        Console.WriteLine("6");
    //        Console.WriteLine(nameDto6.AllName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //7.属性通过ValueResolver转换  
    //        Mapper.Reset();
    //        Name name7 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, StoreDto>()
    //        .ForMember(storeDto => storeDto.Name, opt => opt.ResolveUsing<NameResolver>());
    //        StoreDto store1 = Mapper.Map<Name, StoreDto>(name7);
    //        Console.WriteLine("7");
    //        Console.WriteLine(store1.Name.FirstName + store1.Name.LastName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //8.属性填充固定值  
    //        Mapper.Reset();
    //        Name name8 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ForMember(name => name.AllName, opt => opt.UseValue<string>("ljzforever"));
    //        NameDto nameDto8 = Mapper.Map<Name, NameDto>(name8);
    //        Console.WriteLine("8");
    //        Console.WriteLine(nameDto8.AllName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //9.属性格式化  
    //        Mapper.Reset();
    //        Name name9 = new Name() { FirstName = "L", LastName = "jz" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ForMember(name => name.FirstName, opt => opt.AddFormatter<StringFormatter>());
    //        NameDto nameDto9 = Mapper.Map<Name, NameDto>(name9);
    //        Console.WriteLine("9");
    //        Console.WriteLine(nameDto9.FirstName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //10.属性null时的默认值  
    //        Mapper.Reset();
    //        Name name10 = new Name() { FirstName = "L" };
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ForMember(name => name.LastName, opt => opt.NullSubstitute("jz"));
    //        NameDto nameDto10 = Mapper.Map<Name, NameDto>(name10);
    //        Console.WriteLine("10");
    //        Console.WriteLine(nameDto10.LastName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //其它设置与特性  
    //        //11.转换匿名对象  
    //        Mapper.Reset();
    //        object name11 = new { FirstName = "L", LastName = "jz" };
    //        NameDto nameDto11 = Mapper.DynamicMap<NameDto>(name11);
    //        Console.WriteLine("11");
    //        Console.WriteLine(nameDto11.FirstName + nameDto11.LastName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //12.转换DataTable  
    //        Mapper.Reset();
    //        DataTable dt = new DataTable();
    //        dt.Columns.Add("FirstName", typeof(string));
    //        dt.Columns.Add("LastName", typeof(string));
    //        dt.Rows.Add("L", "jz");
    //        List<NameDto> nameDto12 = Mapper.DynamicMap<IDataReader, List<NameDto>>(dt.CreateDataReader());
    //        Console.WriteLine("12");
    //        Console.WriteLine(nameDto12[0].FirstName + nameDto12[0].LastName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  
    //        //emitMapper error  
    //        //List<NameDto> nameDto20 = EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<IDataReader, List<NameDto>>().Map(dt.CreateDataReader());  


    //        //13.转化存在的对象  
    //        Mapper.Reset();
    //        Mapper.CreateMap<Name, NameDto>()
    //        .ForMember(name => name.LastName, opt => opt.Ignore());
    //        Name name13 = new Name() { FirstName = "L" };
    //        NameDto nameDto13 = new NameDto() { LastName = "jz" };
    //        Mapper.Map<Name, NameDto>(name13, nameDto13);
    //        //nameDto13 = Mapper.Map<Name, NameDto>(name13);//注意,必需使用上面的写法,不然nameDto13对象的LastName属性会被覆盖  
    //        Console.WriteLine("13");
    //        Console.WriteLine(nameDto13.FirstName + nameDto13.LastName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //14.Flatten特性 Store.Name.FirtName=FlattenName.NameFirstname  
    //        Mapper.Reset();
    //        Mapper.CreateMap<Store, FlattenName>();
    //        Store store2 = new Store() { Name = new Name() { FirstName = "L", LastName = "jz" } };
    //        FlattenName nameDto14 = Mapper.Map<Store, FlattenName>(store2);
    //        Console.WriteLine("14");
    //        Console.WriteLine(nameDto14.NameFirstname + nameDto14.NameLastName);
    //        Console.WriteLine();
    //        //Console.ReadKey();  

    //        //15.将Dictionary转化为对象,现在还不支持  
    //        Mapper.Reset();
    //        Mapper.CreateMap<Dictionary<string, object>, Name>();
    //        Dictionary<string, object> dict = new Dictionary<string, object>();
    //        dict.Add("FirstName", "L");
    //        //Name name15 = Mapper.DynamicMap<Dictionary<string, object>, Name>(dict);  
    //        Name name15 = Mapper.Map<Dictionary<string, object>, Name>(dict);
    //        Console.WriteLine("15");
    //        Console.WriteLine(name15.FirstName);
    //        Console.WriteLine();
    //        Console.ReadKey();
    //    }
    //    public class Store
    //    {
    //        public Name Name { get; set; }
    //        public int Age { get; set; }
    //    }

    //    public class Name
    //    {
    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //    }

    //    public class StoreDto
    //    {
    //        public NameDto Name { get; set; }
    //        public int Age { get; set; }
    //    }

    //    public class NameDto
    //    {
    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //        public string AllName { get; set; }
    //    }

    //    public class FlattenName
    //    {
    //        public string NameFirstname { get; set; }
    //        public string NameLastName { get; set; }
    //    }

    //    public class NameConverter : TypeConverter<Name, NameDto>
    //    {
    //        protected override NameDto ConvertCore(Name source)
    //        {
    //            return new NameDto() { AllName = source.FirstName + source.LastName };
    //        }
    //    }

    //    public class NameResolver : ValueResolver<Name, NameDto>
    //    {
    //        protected override NameDto ResolveCore(Name source)
    //        {
    //            return new NameDto() { FirstName = source.FirstName, LastName = source.LastName, AllName = source.FirstName + source.LastName };
    //        }
    //    }

    //    public class NameFormatter : ValueFormatter<NameDto>
    //    {
    //        protected override string FormatValueCore(NameDto name)
    //        {
    //            return name.FirstName + name.LastName;
    //        }
    //    }

    //    public class StringFormatter : ValueFormatter<string>
    //    {
    //        protected override string FormatValueCore(string name)
    //        {
    //            return name + "-";
    //        }
    //    }
    //}
    //    #endregion



    }
}
