using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Json
{
    public static class Extensions
    {

        /// <summary>
        /// 转换成JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="souce">对象</param>
        /// <param name="fiterProperty">过滤掉的属性</param>
        /// <returns></returns>
        public static string ToJson<T>(this T souce,string[] fiterProperty) where T : class, new()
        {
            var settings = new JsonSerializerSettings();

            //加上ContractResolver，正向表列哪些属性要序列化
            settings.ContractResolver =
            new LimitPropsContractResolver(fiterProperty);

            //Formatting.Indented 可读性好
            return JsonConvert.SerializeObject(souce, settings);
        }
        /// <summary>
        /// 转换成JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="souce"></param>
        /// <param name="containProperty">生成包含的属性</param>
        /// <returns></returns>
        public static string ToJson2<T>(this T souce, string[] containProperty) where T : class, new() {
            var settings = new JsonSerializerSettings();

            //加上ContractResolver，正向表列哪些属性要序列化
            settings.ContractResolver =
            new LimitPropsContractResolver(containProperty,false);

            //Formatting.Indented 可读性好
            return JsonConvert.SerializeObject(souce, settings);
        }
    }
}
