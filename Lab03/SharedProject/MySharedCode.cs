using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedProject
{
    public class MySharedCode
    {
        public string GetFilePath(string fileName)
        {
#if WINDOWS_UWP
            var filePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
#else
#if __ANDROID__
            string LibraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(LibraryPath, fileName);
#endif
#endif
            return filePath;
        }
    }
}
