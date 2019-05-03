using xa002.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(Caller_UWP))]
namespace xa002.UWP
{
    class Caller_UWP : IDialer
    {
        public bool dial(string strPhoneNumber)
        {
            System.Diagnostics.Debug.WriteLine("PC에서 전화를 걸고 있습니다." + strPhoneNumber);

            return true;
        }
    }
}
