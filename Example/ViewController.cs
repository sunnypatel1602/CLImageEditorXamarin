using System;
using CLImageEditor;
using UIKit;

namespace Example
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            UIButton btnChoose = new UIButton()
            {
                Frame = new CoreGraphics.CGRect(100,100,100,40),
                BackgroundColor = UIColor.Red
            };
            View.Add(btnChoose);
            btnChoose.SetTitle("Open Editor", UIControlState.Normal);

            btnChoose.TouchUpInside += (sender, e) =>
            {
                CLImageEditor.CLImageEditor cLImageEditor = new CLImageEditor.CLImageEditor(UIImage.FromFile("flower1.jpeg"));
                cLImageEditor.Delegate = new MyCLImageEditorDelegate();
                this.PresentViewController(cLImageEditor, true, null);

            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }


    public class MyCLImageEditorDelegate : CLImageEditorDelegate
    {
        public MyCLImageEditorDelegate()
        {

        }

        public override void ImageEditor(CLImageEditor.CLImageEditor editor, UIImage image)
        {
            Console.WriteLine("Image Edited");
            editor.DismissViewController(true, null);
        }

        public override void ImageEditorDidCancel(CLImageEditor.CLImageEditor editor)
        {
            Console.WriteLine("Image Cancelled");
            editor.DismissViewController(true, null);
        }
    }
}
