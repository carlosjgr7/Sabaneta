using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Pconsulta.iOS.Renderers
{
    public class UITextFieldPadding:UITextField
    {
        public Thickness Padding { get; set; } = new Thickness(5);
        public UITextFieldPadding() { }
        public UITextFieldPadding(NSCoder coder) : base(coder) { }
        public UITextFieldPadding(CGRect rect) : base(rect) { }

        public override CGRect TextRect(CGRect forBounds)
        {
            var insets = new UIEdgeInsets(
                (float) Padding.Top,
                (float) Padding.Left,
                (float) Padding.Bottom,
                (float) Padding.Right
                );
            return insets.InsetRect(forBounds);
        }
        public override CGRect PlaceholderRect(CGRect forBounds)
        {
            var insets = new UIEdgeInsets(
               (float)Padding.Top,
                (float)Padding.Left,
                (float)Padding.Bottom,
                (float)Padding.Right);
            return insets.InsetRect(forBounds);
        }

        public override CGRect EditingRect(CGRect forBounds)
        {
            var insets = new UIEdgeInsets(
               (float)Padding.Top,
                (float)Padding.Left,
                (float)Padding.Bottom,
                (float)Padding.Right);
            return insets.InsetRect(forBounds);
        }

    }
}