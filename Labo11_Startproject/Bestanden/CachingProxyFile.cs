using System;
using System.Collections.Generic;
using System.Text;

namespace Bestanden
{
    public class CachingProxyFile : IFile
    {
        string file;
        string? content;

        public CachingProxyFile(string file)
        {
            this.file = file;
        }

        public string Content
        {
            get
            {
                if (content == null)
                {
                    RealFile realFile = new RealFile(file); 
                    content = realFile.Content;
                }
                return content;
            }
        }
    }
}
