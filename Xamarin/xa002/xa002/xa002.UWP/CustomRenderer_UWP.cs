
using xa002;
using xa002.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomView), typeof(CustomRenderer_UWP))]
namespace xa002.UWP
{
    public class CustomRenderer_UWP : ViewRenderer<CustomView, Xamarin.Forms.Platform.UWP.EntryCellTextBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);

            var box = new Xamarin.Forms.Platform.UWP.EntryCellTextBox();

            SetNativeControl(box);
        }
    }
}