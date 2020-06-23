using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncReadWrite1
{
    public class TextReaderWriterAsync
    {
        private FileStream _fs;

        public void WriteText(string path, string content)
        {
            var data = Encoding.UTF8.GetBytes(content);

            _fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 4096, true);

            _fs.WriteAsync(data, 0, data.Length);
        }
    }
}
