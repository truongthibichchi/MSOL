using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOL.UTILITIES
{
    class ControlUtils
    {
        public static byte[] convertImageToByte(Image hinhanh)
        {
            MemoryStream ms = new MemoryStream();
            hinhanh.Save(ms, hinhanh.RawFormat);
            byte[] result = ms.GetBuffer();
            ms.Close();
            return result;
        }

        public static Image convertByteToImage(byte[] binary)
        {
            MemoryStream ms = new MemoryStream(binary);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

    }
}
