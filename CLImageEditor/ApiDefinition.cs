using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace CLImageEditor
{

    // @interface CLImageToolInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface CLImageToolInfo
    {
        // @property (readonly, nonatomic) NSString * toolName;
        [Export("toolName")]
        string ToolName { get; }

        // @property (nonatomic, strong) NSString * title;
        [Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // @property (assign, nonatomic) BOOL available;
        [Export("available")]
        bool Available { get; set; }

        // @property (assign, nonatomic) CGFloat dockedNumber;
        [Export("dockedNumber")]
        nfloat DockedNumber { get; set; }

        // @property (nonatomic, strong) NSString * iconImagePath;
        [Export("iconImagePath", ArgumentSemantic.Strong)]
        string IconImagePath { get; set; }

        // @property (readonly, nonatomic) UIImage * iconImage;
        [Export("iconImage")]
        UIImage IconImage { get; }

        // @property (readonly, nonatomic) NSArray * subtools;
        [Export("subtools")]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Subtools { get; }

        // @property (nonatomic, strong) NSMutableDictionary * optionalInfo;
        [Export("optionalInfo", ArgumentSemantic.Strong)]
        NSMutableDictionary OptionalInfo { get; set; }

        // -(NSString *)toolTreeDescription;
        [Export("toolTreeDescription")]
        //[Verify(MethodToProperty)]
        string ToolTreeDescription { get; }

        // -(NSArray *)sortedSubtools;
        [Export("sortedSubtools")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] SortedSubtools { get; }

        // -(CLImageToolInfo *)subToolInfoWithToolName:(NSString *)toolName recursive:(BOOL)recursive;
        [Export("subToolInfoWithToolName:recursive:")]
        CLImageToolInfo SubToolInfoWithToolName(string toolName, bool recursive);
    }

    // @interface CLImageEditorTheme : NSObject
    [BaseType(typeof(NSObject))]
    interface CLImageEditorTheme
    {
        [Wrap("WeakDelegate")]
        CLImageEditorThemeDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<CLImageEditorThemeDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong) NSString * bundleName;
        [Export("bundleName", ArgumentSemantic.Strong)]
        string BundleName { get; set; }

        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * toolbarColor;
        [Export("toolbarColor", ArgumentSemantic.Strong)]
        UIColor ToolbarColor { get; set; }

        // @property (nonatomic, strong) NSString * toolIconColor;
        [Export("toolIconColor", ArgumentSemantic.Strong)]
        string ToolIconColor { get; set; }

        // @property (nonatomic, strong) UIColor * toolbarTextColor;
        [Export("toolbarTextColor", ArgumentSemantic.Strong)]
        UIColor ToolbarTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * toolbarSelectedButtonColor;
        [Export("toolbarSelectedButtonColor", ArgumentSemantic.Strong)]
        UIColor ToolbarSelectedButtonColor { get; set; }

        // @property (nonatomic, strong) UIFont * toolbarTextFont;
        [Export("toolbarTextFont", ArgumentSemantic.Strong)]
        UIFont ToolbarTextFont { get; set; }

        // @property (assign, nonatomic) BOOL statusBarHidden;
        [Export("statusBarHidden")]
        bool StatusBarHidden { get; set; }

        // @property (assign, nonatomic) UIStatusBarStyle statusBarStyle;
        [Export("statusBarStyle", ArgumentSemantic.Assign)]
        UIStatusBarStyle StatusBarStyle { get; set; }

        // +(CLImageEditorTheme *)theme;
        [Static]
        [Export("theme")]
        //[Verify(MethodToProperty)]
        CLImageEditorTheme Theme { get; }
    }

    // @protocol CLImageEditorThemeDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface CLImageEditorThemeDelegate
    {
        // @optional -(UIActivityIndicatorView *)imageEditorThemeActivityIndicatorView;
        [Export("imageEditorThemeActivityIndicatorView")]
        //[Verify(MethodToProperty)]
        UIActivityIndicatorView ImageEditorThemeActivityIndicatorView { get; }
    }

    // @interface CLImageEditor : UIViewController
    [BaseType(typeof(UIViewController))]
    interface CLImageEditor
    {
        [Wrap("WeakDelegate")]
        CLImageEditorDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<CLImageEditorDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) CLImageEditorTheme * theme;
        [Export("theme")]
        CLImageEditorTheme Theme { get; }

        // @property (readonly, nonatomic) CLImageToolInfo * toolInfo;
        [Export("toolInfo")]
        CLImageToolInfo ToolInfo { get; }

        // -(id)initWithImage:(UIImage *)image;
        [Export("initWithImage:")]
        IntPtr Constructor(UIImage image);

        // -(id)initWithImage:(UIImage *)image delegate:(id<CLImageEditorDelegate>)delegate;
        [Export("initWithImage:delegate:")]
        IntPtr Constructor(UIImage image, CLImageEditorDelegate @delegate);

        // -(id)initWithDelegate:(id<CLImageEditorDelegate>)delegate;
        [Export("initWithDelegate:")]
        IntPtr Constructor(CLImageEditorDelegate @delegate);

        // -(void)showInViewController:(UIViewController<CLImageEditorTransitionDelegate> *)controller withImageView:(UIImageView *)imageView;
        [Export("showInViewController:withImageView:")]
        void ShowInViewController(CLImageEditorTransitionDelegate controller, UIImageView imageView);

        // -(void)refreshToolSettings;
        [Export("refreshToolSettings")]
        void RefreshToolSettings();
    }

    // @protocol CLImageEditorDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface CLImageEditorDelegate
    {
        // @optional -(void)imageEditor:(CLImageEditor *)editor didFinishEdittingWithImage:(UIImage *)image __attribute__((deprecated("")));
        [Export("imageEditor:didFinishEdittingWithImage:")]
        void ImageEditor(CLImageEditor editor, UIImage image);

        //// @optional -(void)imageEditor:(CLImageEditor *)editor didFinishEditingWithImage:(UIImage *)image;
        //[Export("imageEditor:didFinishEditingWithImage:")]
        //void ImageEditor(CLImageEditor editor, UIImage image);

        // @optional -(void)imageEditorDidCancel:(CLImageEditor *)editor;
        [Export("imageEditorDidCancel:")]
        void ImageEditorDidCancel(CLImageEditor editor);
    }

    // @protocol CLImageEditorTransitionDelegate <CLImageEditorDelegate>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface CLImageEditorTransitionDelegate //: CLImageEditorDelegate
    {
        // @optional -(void)imageEditor:(CLImageEditor *)editor willDismissWithImageView:(UIImageView *)imageView canceled:(BOOL)canceled;
        [Export("imageEditor:willDismissWithImageView:canceled:")]
        void WillDismissWithImageView(CLImageEditor editor, UIImageView imageView, bool canceled);

        // @optional -(void)imageEditor:(CLImageEditor *)editor didDismissWithImageView:(UIImageView *)imageView canceled:(BOOL)canceled;
        [Export("imageEditor:didDismissWithImageView:canceled:")]
        void DidDismissWithImageView(CLImageEditor editor, UIImageView imageView, bool canceled);
    }

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double CLImageEditorVersionNumber;
        [Field("CLImageEditorVersionNumber", "__Internal")]
        double CLImageEditorVersionNumber { get; }

        //// extern const unsigned char [] CLImageEditorVersionString;
        //[Field("CLImageEditorVersionString", "__Internal")]
        //byte[] CLImageEditorVersionString { get; }
    }

}
