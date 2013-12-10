using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("{0, 32:\t}", "ShitCode");
            Console.WriteLine("Program {0, 32:\t}", "ShitCode");
            TMethod tm = new TMethod();
            Console.WriteLine(tm.GetShit<TModel>());
            //Console.WriteLine(tm.GetShit<ITBase>());
            TModel t = new TModel() { ID = int.MaxValue, Name = "ShitOne" };
            Console.WriteLine(tm.GetShit<TModel>(t));
            Console.WriteLine(tm.GetT<TModel>().Shit());
            Console.ReadKey(true);
            //VaryQualityLevel();
            PictureAttributesMaker();
            Console.ReadKey(true);
            WriteCharString();

            Console.WriteLine(Console.ReadKey(true));
            //for (int i = 1; i < 10; i++)
            //{
            //    for (int j = 1; j < i + 1; j++)
            //    {
            //        Console.Write(" {0}x{1}={2}{3}", j, i, i * j, (i == j) ? "\r\n" : "");
            //    }
            //}

            //Tree
            var t1 = Tree.Default;
            var t2 = Tree.Default;
            if (t1 == t2)
            {
                t1.GrowUp();
            }
            else
            {
                t1.Drink();
            }

            BigTree bt = new BigTree() { Name = "BigTree" };
            bt.GrowUp();
            bt.SayHi();
            bt.SayHi<BigTree, BigTree>(bt, bt);
            //Dead Tree

            Console.ReadKey();
            // Note that each lambda expression has no parameters.
            LazyValue<int> lazyOne = new LazyValue<int>(() => ExpensiveOne());
            LazyValue<long> lazyTwo = new LazyValue<long>(() => ExpensiveTwo("apple"));

            Console.WriteLine("LazyValue objects have been created.");

            // Get the values of the LazyValue objects.
            Console.WriteLine(lazyOne.Value);
            Console.WriteLine(lazyTwo.Value);

            #region
            IList<App> apps = new List<App>() { new App { ID = 1, Name = "A", Code = "1;2;3;4;5;6;7;" }, new App { ID = 2, Name = "B", Code = "0;1;2;3;4;5;6;7;" }, new App { ID = 3, Name = "C", Code = "-1;0;1;2;3;4;5;6;7;" }, new App { ID = 4, Name = "D", Code = "-1;0;1;2;3;4;5;6;7;" } };
            MyValue<App> myValue = new MyValue<App>();
            var codeA = myValue.Getter((ps) => ps.Select((p) => p.Code).Distinct(), apps);
            Console.WriteLine(myValue.Getter((cs) =>
            {
                var result = "";
                foreach (var c in cs)
                {
                    result += c;
                }
                return result;
            }, codeA));
            var codeS = myValue.Getter((cs) =>
            {
                var result = "";
                foreach (var c in cs)
                {
                    result += c;
                }
                return result;
            }, codeA);
            foreach (var c in codeS.Split(';'))
            {
                Console.Write("[{0}] ", c);
            } Console.WriteLine();
            foreach (var c in codeS.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                Console.Write("[{0}] ", c);
            } Console.WriteLine();
            codeS = myValue.NewGetter((ps) => ps.Select((p) => p.Code).Distinct(), apps);
            Console.WriteLine(codeS);
            #endregion

            Console.ReadKey(true);
        }

        private static void PictureAttributesMaker()
        {
            using (Bitmap img = new Bitmap(320, 240))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.Bisque);

                    //var comment = "www.baidu.com";
                    //char[] chars = comment.ToCharArray();
                    //var len = chars.Length;
                    //byte[] buffer = new byte[len];
                    //Encoding e = Encoding.Default;
                    //System.Text.Encoder en = e.GetEncoder();
                    //int count = en.GetBytes(chars, 0, len, buffer, 0, true);

                    ImageCodecInfo info = GetEncoder(ImageFormat.Gif);
                    EncoderParameters eps = new EncoderParameters(1);

                    System.Drawing.Imaging.Encoder sEn = System.Drawing.Imaging.Encoder.SaveFlag;
                    EncoderParameter mep = new EncoderParameter(sEn, (long)(EncoderValue.FrameDimensionTime));//100L);//
                    eps.Param[0] = mep;

                    //System.Drawing.Imaging.Encoder cEn = System.Drawing.Imaging.Encoder.Compression;
                    //EncoderParameter gep = new EncoderParameter(cEn, (long)(EncoderValue.VersionGif89));//100L);//
                    //eps.Param[1] = gep;

                    img.Save("C:\\Intel\\Comment.gif", info, eps);

                    mep = new EncoderParameter(sEn, (long)(EncoderValue.FrameDimensionTime));//100L);//
                    eps.Param[0] = mep;

                    //gep = new EncoderParameter(cEn, (long)(EncoderValue.VersionGif89));//100L);//
                    //eps.Param[1] = gep;

                    img.SaveAdd(new Bitmap(@"C:\Intel\flash_windows.gif"), eps);
                }
            }
        }
        /***************************************************************************************************************/
        private static void VaryQualityLevel()
        {
            // Get a bitmap.
            Bitmap bmp1 = new Bitmap(@"C:\Intel\2e441f6548df98aeae5d8d02080be41b.jpg");
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"c:\TestPhotoQualityFifty.jpg", jgpEncoder, myEncoderParameters);

            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"c:\TestPhotoQualityHundred.jpg", jgpEncoder, myEncoderParameters);

            // Save the bitmap as a JPG file with zero quality level compression.
            myEncoderParameter = new EncoderParameter(myEncoder, 0L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"c:\TestPhotoQualityZero.jpg", jgpEncoder, myEncoderParameters);

        }


        //...


        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        /***************************************************************************************************************/
        private static void WriteCharString()
        {
            int n = 0;
            for (int ctr = 0x20; ctr <= 0x017F; ctr++)
            {
                string string1 = Convert.ToChar(ctr).ToString();
                string upperString = string1.ToUpper();
                if (string1 != upperString)
                {
                    Console.Write(@"{0} (\u+{1}) --> {2} (\u+{3})         ",
                                  string1,
                                  Convert.ToUInt16(string1[0]).ToString("X4"),
                                  upperString,
                                  Convert.ToUInt16(upperString[0]).ToString("X4"));
                    n++;
                    if (n % 2 == 0) Console.WriteLine();
                }
            }
        }

        static int ExpensiveOne()
        {
            Console.WriteLine("\nExpensiveOne() is executing.");
            return 1;
        }

        static long ExpensiveTwo(string input)
        {
            Console.WriteLine("\nExpensiveTwo() is executing.");
            return (long)input.Length;
        }
    }

    public class TMethod
    {
        public string GetShit<T>() where T : TBase, new()
        {
            T t = new T() { ID = 1, Name = "Some One" };
            return t.Eate();
        }

        public string GetShit<U>(U u) where U : ITBase
        {
            return u.Name;
        }

        public M GetT<M>() where M : class, ITBase, new()
        {
            //return new M() { ID = int.MinValue, Name = "ShitTwo" };
            return new TModel() { ID = int.MinValue, Name = "ShitTwo" } as M;
        }
    }

    public class TModel : TBase
    {
        public string Shit() { return this.Name + "：Shit Again!"; }
    }

    public class TBase : ITBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Eate() { return this.Name + "：Go Eate Shit!"; }
    }

    public interface ITBase
    {
        int ID { get; set; }
        string Name { get; set; }
        string Eate();
    }

    /*
    uses GdiPlus;

    procedure TForm1.FormDblClick(Sender: TObject);
    var
      Image: IGPImage;
      Graphics: IGPGraphics;
      PageCount: Integer;
      i: Integer;
    begin
      Image := TGPImage.Create('C:\GdiPlusImg\Chicken.gif');
      PageCount := Image.GetFrameCount(FrameDimensionTime);
      Graphics := TGPGraphics.Create(Handle);
      Graphics.Clear($FF000000);
      for i := 0 to PageCount - 1 do
      begin
        Image.SelectActiveFrame(FrameDimensionTime, i);
        Graphics.DrawImage(Image, 4, 4, Image.Width, Image.Height);
        Graphics.TranslateTransform(Image.Width + 4, 0);
        if (i+1) mod 7 = 0 then
        begin
          Graphics.TranslateTransform(-Graphics.Transform.OffsetX, Image.Height + 4);
        end;
      end;
    end;
     */

    public class MyValue<T>
    {
        private Func<IList<T>, IEnumerable<string>> GetObject;
        public string[] Getter(Func<IList<T>, IEnumerable<string>> func, IList<T> ts)
        {
            this.GetObject = func;
            return this.GetObject(ts).ToArray();
        }

        private Func<string[], string> GetString;
        public string Getter(Func<string[], string> func, string[] codes)
        {
            //this.GetString = new Func<string[], string>(DoGetter);
            this.GetString = func;
            return this.GetString(codes);
        }

        public string NewGetter(Func<IList<T>, IEnumerable<string>> func, IList<T> ts)
        {
            this.GetObject = func;
            return string.Join("", this.GetObject(ts).ToArray());
        }

        private string DoGetter(string[] codes)
        {
            var result = "";
            foreach (var c in codes)
            {
                result += c;
            }
            return result;
        }
    }

    public class App
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class LazyValue<T> where T : struct
    {
        private Nullable<T> val;
        private Func<T> getValue;

        public LazyValue() { }

        // Constructor.
        public LazyValue(Func<T> func)
        {
            val = null;
            getValue = func;
        }

        public T Value
        {
            get
            {
                if (val == null)
                    // Execute the delegate.
                    val = getValue();
                return (T)val;
            }
        }
    }
    /* The example produces the following output:

        LazyValue objects have been created.

        ExpensiveOne() is executing.
        1

        ExpensiveTwo() is executing.
        5
    */
}

//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        }
//    }
//}