
using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OpenCV
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadImage();
        }

        public void LoadImage()
        {
            //Mat img = new Mat(200, 400, DepthType.Cv8U, 3);
            //string s = new Uri("../../Resources/logo.png").ToString();
            Mat img = new Mat(@"../../../../../Images/RoboCup1.jpg");

            imageCamera1.Source = ImageSourceFromBitmap(img.ToBitmap());
            //Image <Bgr, Byte> myImage = new Image<Bgr, byte>("../../Images/RoboCup1.jpg");
            //imageSource.Source = BitmapSourceConvert.BitmapToImageSource(myImage.ToBitmap());
        }


        //If you get 'dllimport unknown'-, then add 'using System.Runtime.InteropServices;'
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }
    }        
}
