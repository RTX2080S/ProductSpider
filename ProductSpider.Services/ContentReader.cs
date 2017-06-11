using ProductSpider.Services.Interfaces;
using System;

namespace ProductSpider.Services
{
    public class ContentReader : IContentReader
    {
        protected string documentContext;

        public void SetContext(string context)
        {
            documentContext = context;
        }

        public string ReadContent(string startingTag, string endTag)
        {
            if (string.IsNullOrWhiteSpace(documentContext))
                throw new InvalidOperationException("Document context is not set. ");

            // Tags not set - reject
            if (string.IsNullOrWhiteSpace(startingTag) || string.IsNullOrWhiteSpace(endTag))
                return string.Empty;

            // Tags not exists - reject
            if (!documentContext.Contains(startingTag) || !documentContext.Contains(endTag))
                return string.Empty;

            int startingPoint = documentContext.IndexOf(startingTag);

            // Searching endTag from the Starting Point, it would be pointless searching the whole doc for the endTag
            int endPoint = documentContext.IndexOf(endTag, startingPoint);

            // Tags not in correct order - reject
            if (startingPoint > endPoint)
                return string.Empty;

            // Now we can safely assume that the tags exists and in correct order
            int contentStartIndex = startingPoint + startingTag.Length;
            int contentLength = endPoint - contentStartIndex;

            string result = documentContext.Substring(contentStartIndex, contentLength);
            return result;
        }
    }
}
