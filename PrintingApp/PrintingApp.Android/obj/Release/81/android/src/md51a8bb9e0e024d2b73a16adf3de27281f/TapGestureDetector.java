package md51a8bb9e0e024d2b73a16adf3de27281f;


public class TapGestureDetector
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSingleTapConfirmed:(Landroid/view/MotionEvent;)Z:GetOnSingleTapConfirmed_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfPdfViewer.XForms.Droid.TapGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", TapGestureDetector.class, __md_methods);
	}


	public TapGestureDetector ()
	{
		super ();
		if (getClass () == TapGestureDetector.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.TapGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", "", this, new java.lang.Object[] {  });
	}

	public TapGestureDetector (android.widget.TextView p0, md51a8bb9e0e024d2b73a16adf3de27281f.SfPdfViewerEx p1)
	{
		super ();
		if (getClass () == TapGestureDetector.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.TapGestureDetector, Syncfusion.SfPdfViewer.XForms.Android", "Android.Widget.TextView, Mono.Android:Syncfusion.SfPdfViewer.XForms.Droid.SfPdfViewerEx, Syncfusion.SfPdfViewer.XForms.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean onSingleTapConfirmed (android.view.MotionEvent p0)
	{
		return n_onSingleTapConfirmed (p0);
	}

	private native boolean n_onSingleTapConfirmed (android.view.MotionEvent p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
