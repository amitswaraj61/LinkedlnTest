using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LinkedinApp
{
    class Screenshot
    {
        public static String Capture(IWebDriver driver,String ScreenShotName)
        {
            var ts = ((ITakesScreenshot)driver).GetScreenshot();
            String path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            String uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshot images\\" + ScreenShotName + ".png";
            String localPath = new Uri(uptobinpath).LocalPath;
            ts.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;







        }
    }
}
