// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace NeHeLesson7 {
	
	
	// Should subclass MonoMac.AppKit.NSWindow
	[MonoMac.Foundation.Register("MainWindow")]
	public partial class MainWindow {
	}
	
	// Should subclass MonoMac.AppKit.NSWindowController
	[MonoMac.Foundation.Register("MainWindowController")]
	public partial class MainWindowController {
		
		private MyOpenGLView __mt_openGLView;
		
		#pragma warning disable 0169
		[MonoMac.Foundation.Export("goFullScreen:")]
		partial void goFullScreen (MonoMac.Foundation.NSObject sender);

		[MonoMac.Foundation.Connect("openGLView")]
		private MyOpenGLView openGLView {
			get {
				this.__mt_openGLView = ((MyOpenGLView)(this.GetNativeField("openGLView")));
				return this.__mt_openGLView;
			}
			set {
				this.__mt_openGLView = value;
				this.SetNativeField("openGLView", value);
			}
		}
	}
	
	// Should subclass MonoMac.AppKit.NSView
	[MonoMac.Foundation.Register("MyOpenGLView")]
	public partial class MyOpenGLView {
	}
}
