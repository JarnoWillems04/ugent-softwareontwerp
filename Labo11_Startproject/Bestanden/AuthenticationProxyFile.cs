using System;
using System.Collections.Generic;
using System.Text;

namespace Bestanden
{
    public class AuthenticationProxyFile : IFile
    {
        IFile file;

        public AuthenticationProxyFile(User user, string file)
        {
            if (!user.isAdmin)
            {
                // womp womp
            }
            this.file = new CachingProxyFile(file);
        }

        public string Content
        {
            get
            {
                return this.file.Content;
            }
        }
    }
}
