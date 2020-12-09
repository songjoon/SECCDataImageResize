using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECCDataImageResize
{
    internal class Program
    {
        private static string rootFolder = @"F:\Data\";
        private static Size targetSize = new Size(500, 500);

        private static void Main(string[] args)
        {
            Stack<string> st = new Stack<string>();
            st.Push(rootFolder);
            while (st.Count != 0)
            {
                string r = st.Pop();
                string[] dirs = Directory.GetDirectories(r);
                foreach (var dir in dirs)
                    st.Push(dir);
                string[] files = Directory.GetFiles(r);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    if (info.Extension == ".png")
                        continue;

                    Bitmap origin = new Bitmap(file);

                    Bitmap bitmap = new Bitmap(origin, targetSize);
                    origin.Dispose();
                    File.Delete(file);
                    bitmap.Save(file);
                }
            }
        }
    }
}