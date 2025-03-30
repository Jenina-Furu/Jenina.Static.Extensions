using System;
using System.Collections.Generic;
using System.Text;

namespace Jenina.Static.Extensions
{
    public static class NullableDecimalExtensions
    {
        /// <summary>
        /// 保留指定的小数位,并四舍五入。如果源为null,则返回null。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal? Keep(this decimal? source)
        {
            return source.Keep(2);
        }

        /// <summary>
        /// 保留指定的小数位,并四舍五入。如果源为null,则返回null。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keepPlaceCount">需要保留的小数位</param>
        /// <returns></returns>
        public static decimal? Keep(this decimal? source, int keepPlaceCount)
        {
            if (source.HasValue)
            {
                return source.Value.Keep(keepPlaceCount);
            }
            else
            {
                return null;
            }
        }
    }
}
