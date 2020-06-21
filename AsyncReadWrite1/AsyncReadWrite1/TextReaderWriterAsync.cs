using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace AsyncReadWrite1
{
    public class TextReaderWriterAsync : IDisposable
    {
        private FileStream _fs;

        public void Dispose()
        {
            if (_fs != null)
                _fs.Close();
        }

        public void WriteText(string path, string content, TimeSpan timeout)
        {
            var data = Encoding.UTF8.GetBytes(content);

            _fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 4096, true);

            CancellationTokenSource ct = new CancellationTokenSource();

            _fs.WriteAsync(data, 0, data.Length, ct.Token);

            ct.CancelAfter(timeout);
        }
    }
}
