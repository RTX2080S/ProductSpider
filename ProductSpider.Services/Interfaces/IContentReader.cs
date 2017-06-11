using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSpider.Services.Interfaces
{
    public interface IContentReader
    {
        /// <summary>
        /// Set the context
        /// </summary>
        /// <param name="context">A string where the operation is performed</param>
        void SetContext(string context);

        /// <summary>
        /// Find the content between a starting tag and end tag inside a string context
        /// </summary>
        /// <param name="startingTag">The starting tag of the content which will be searched for</param>
        /// <param name="endTag">The ending tag of the content, which index in the context should be greater than the startingTag </param>
        /// <returns></returns>
        string ReadContent(string startingTag, string endTag);
    }
}
