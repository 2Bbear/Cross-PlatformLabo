using Android.Views;
using xa002;
using xa002.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomView),typeof(CustomRenderer_android))]
namespace xa002.Droid
{
    public class CustomRenderer_android : ViewRenderer<CustomView, Android.Widget.DatePicker>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);

            var datePicker = new Android.Widget.DatePicker(Forms.Context);

            SetNativeControl(datePicker);
        }
    }
}