using System;
using System.Net;
using System.Runtime.InteropServices;

namespace wallpaperChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "newBackground.jpg";

            // download new background
            new WebClient().DownloadFile("https://static.toiimg.com/photo/msid-67586673/67586673.jpg?3918697", fileName);
            string imagePath = AppDomain.CurrentDomain.BaseDirectory;

            changeBackground(imagePath+fileName);
        }

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01; 

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static void changeBackground(string filename)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, filename, SPIF_UPDATEINIFILE);
        }
    }
}
