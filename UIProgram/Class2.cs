using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProgram
{
    public class Class2
    {
        #region BigTiff
        // Saving the combined tiff file based on FCL classes
        Bitmap multi = null;
        ImageCodecInfo myImageCodecInfo;
        System.Drawing.Imaging.Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameter CompressionEncoderParameter;
        EncoderParameters myEncoderParameters;
        System.Drawing.Imaging.Encoder encoderCompression = System.Drawing.Imaging.Encoder.Compression;
        private void tiff()
        {
            /*
            // Get an ImageCodecInfo object that represents the TIFF codec.
            myImageCodecInfo = GetEncoderInfo("image/tiff");
            // Create an Encoder object based on the GUID
            // for the SaveFlag parameter category.
            myEncoder = System.Drawing.Imaging.Encoder.SaveFlag;
            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(2);
            while (enumerator.MoveNext())
            {
                //For mapping Image indices with Defect Id
                List<DefectImage> defImgList = new List<DefectImage>();
                IEnumerable<ImageClip> imgClipList = enumerator.Current.Value;
                foreach (ImageClip imgClip in imgClipList)
                {
                    Bitmap bmp = imgClip.Image;
                    if (validCount == 1) // for the first image.
                    {
                        multi = new Bitmap((Image)bmp);
                        myEncoderParameter = new EncoderParameter(myEncoder, (long)(EncoderValue.MultiFrame));
                        CompressionEncoderParameter = new EncoderParameter(encoderCompression, (long)(EncoderValue.CompressionNone));
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        myEncoderParameters.Param[1] = CompressionEncoderParameter;
                        multi.Save(fileName, myImageCodecInfo, myEncoderParameters);
                    }
                    else
                    {
                        myEncoderParameter = new EncoderParameter(myEncoder, (long)(EncoderValue.FrameDimensionPage));
                        CompressionEncoderParameter = new EncoderParameter(encoderCompression, (long)(EncoderValue.CompressionNone));
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        myEncoderParameters.Param[1] = CompressionEncoderParameter;
                        multi.SaveAdd(bmp, myEncoderParameters);
                    }
                    bmp.Dispose();
                }
            }
             */
        }
        #endregion
    }
}
