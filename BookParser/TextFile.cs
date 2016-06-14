using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookParser
{
    public class TextFile
    {
        private string FileContent;

        public TextFile(string path)
        {
            FileContent = System.IO.File
                .ReadAllText(path)
                .TrimEnd('\r', '\n');
        }

        public string RawText
        {
            get { return FileContent; }
        }
    }
}
