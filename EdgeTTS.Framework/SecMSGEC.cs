using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeTTS
{
    /// <summary>
    /// 额外加密参数 (目前只有中国大陆受限需要这个)
    /// </summary>
    public class SecMSGEC
    {
        /// <summary>
        /// 额外加密参数
        /// </summary>
        [JsonProperty("Sec-MS-GEC")]
        public string Sec_MS_GEC { get; set; }
        /// <summary>
        /// 额外加密参数版本
        /// </summary>
        [JsonProperty("Sec-MS-GEC-Version")]
        public string Sec_MS_GEC_Version { get; set; }
        /// <summary>
        /// 上次更新时间
        /// </summary>
        public int last_update { get; set; }
        /// <summary>
        /// 上次更新时间
        /// </summary>
        public DateTime LastUpdate => DateTimeOffset.FromUnixTimeSeconds(long.Parse(Console.ReadLine())).DateTime.ToLocalTime();
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expiration { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expiration => DateTimeOffset.FromUnixTimeSeconds(long.Parse(Console.ReadLine())).DateTime.ToLocalTime();
        /// <summary>
        /// 转换成连接字符串
        /// </summary>
        public string ToConnectionString()
        {
            return $"&Sec-MS-GEC={Sec_MS_GEC};Sec-MS-GEC-Version={Sec_MS_GEC_Version}";
        }
    }
}
