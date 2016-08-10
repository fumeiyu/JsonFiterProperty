using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Json
{
    /// <summary>
    /// V1.1 增加 isFiterOrContianer属性
    /// </summary>
    public class LimitPropsContractResolver : DefaultContractResolver

    {

        string[] props = null;
        bool isFiter = true;//false的时候，包含属性

        /// <summary>
        /// 过滤属性
        /// </summary>
        /// <param name="props">过滤属性</param>
        public LimitPropsContractResolver(string[] props):this(props,true)
        {

            //指定要序列化属性的清单


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="props"></param>
        /// <param name="isFiterOrContianer">true，过滤属性，false，只生成包含属性</param>
        public LimitPropsContractResolver(string[] props,bool isFiterOrContianer)
        {

            //指定要序列化属性的清单
            this.props = props;
            isFiter = isFiterOrContianer;

        }
        //REF: http://james.newtonking.com/archive/2009/10/23/efficient-json-with-json-net-reducing-serialized-json-size.aspx


        protected override IList<JsonProperty> CreateProperties(Type type,

        MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list =

            base.CreateProperties(type, memberSerialization);

            //只保留清单有列出的属性

            if(isFiter)
                return list.Where(p => !props.Contains(p.PropertyName)).ToList();
            else
                return list.Where(p => props.Contains(p.PropertyName)).ToList();


        }



    }


}
