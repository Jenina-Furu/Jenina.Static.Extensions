using System;
using System.Text.RegularExpressions;

namespace Jenina.Static.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Keep(this decimal source)
        {
            var result = Math.Round(source, 2, MidpointRounding.AwayFromZero);
            return result;
        }

        /// <summary>
        /// 保留指定的小数位,并四舍五入
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keepPlaceCount">需要保留的小数位</param>
        /// <returns></returns>
        public static decimal Keep(this decimal source, int keepPlaceCount)
        {
            var result = Math.Round(source, keepPlaceCount, MidpointRounding.AwayFromZero);
            return result;
        }

        public static string CapitalAmount(this decimal source)
        {
            if (source == 0)
            {
                return "零元";
            }

            var STRING = "#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A";
            var str = source.ToString(STRING);

            var s = Regex.Replace(str, @"(((?<=-)|(?!-)^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            var result = Regex.Replace(s, ".", c => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万亿兆京垓秭穰"[c.Value[0] - '-'].ToString());

            if (source % 1 == 0)
            {
                result += "整";
            }

            return result;
        }
    }
}
