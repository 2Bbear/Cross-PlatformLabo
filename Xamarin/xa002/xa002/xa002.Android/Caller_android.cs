using xa002.Droid;
using Xamarin.Forms;



[assembly:Dependency(typeof(Caller_android))]
namespace xa002.Droid
{
    class Caller_android : IDialer
    {
        public bool dial(string strPhoneNumber)
        {
            System.Diagnostics.Debug.WriteLine("안드로이드에서 전화를 걸고 있습니다."+ strPhoneNumber);

            return true;
        }
    }
}