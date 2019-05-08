using System;
using System.IO;
using System.Reflection;

namespace HowToWebView.CommonClass
{
    /// <summary>
    /// Text저장을 도와주는 클래스
    /// </summary>
    public class LoadResourceText
    {
        public LoadResourceText()
        {

        }
        public static string GetText(string _fileName)
        {
            string text = "";
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _fileName);
            text = File.ReadAllText(filename);
            //var aseembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            //Stream stream = aseembly.GetManifestResourceStream(fileIDName);


            //using (var reader = new StreamReader(stream))
            //{
            //    text = reader.ReadToEnd();
            //}
            return text;
        }
        public static bool SaveText(string _fileName,string _text)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _fileName);
            File.WriteAllText(filename, _text);
            return true;
        }
    }
}
