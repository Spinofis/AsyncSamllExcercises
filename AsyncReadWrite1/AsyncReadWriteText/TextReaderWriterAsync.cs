using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncReadWriteText
{
    public class TextReaderWriterAsync
    {

        public void WriteText(string path, string content)
        {
            var data = Encoding.UTF8.GetBytes(content);

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 4096, true);

            fs.WriteAsync(data, 0, data.Length).ContinueWith(t => fs.Close());
        }

        public void RewriteFileAsync(string pathFrom, string pathTo)
        {
            FileStream fsRead = new FileStream(pathFrom, FileMode.Open, FileAccess.Read, FileShare.None, 99999999, true);
            FileStream fsWrite = new FileStream(pathTo, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 99999999, true);



            byte[] readBuffer = new byte[99999999];

            Task.Factory.FromAsync(fsRead.BeginRead, fsRead.EndRead, readBuffer, 0, readBuffer.Length, null).ContinueWith(tr =>
            {
                fsRead.Close();
                var writeBuffer = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(readBuffer).Trim());
                fsWrite.WriteAsync(writeBuffer, 0, writeBuffer.Length)
                .ContinueWith
                (tw =>
                {
                    fsWrite.Close();
                    MessageBox.Show("End writting!");
                });
            });
        }

        public void RewriteFile(string pathFrom, string pathTo)
        {
            FileStream fsRead = new FileStream(pathFrom, FileMode.Open, FileAccess.Read, FileShare.None, 99999999, false);
            FileStream fsWrite = new FileStream(pathTo, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 99999999, false);

            byte[] readBuffer = new byte[99999999];

            fsRead.Read(readBuffer, 0, readBuffer.Length);
            fsRead.Close();
            var writeBuffer = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(readBuffer).Trim());
            fsWrite.Write(writeBuffer, 0, writeBuffer.Length);
            fsWrite.Close();
            MessageBox.Show("End writting!");
        }
    }
}
