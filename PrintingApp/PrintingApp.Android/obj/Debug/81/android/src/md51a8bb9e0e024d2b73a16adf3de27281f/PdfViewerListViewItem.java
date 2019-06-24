package md51a8bb9e0e024d2b73a16adf3de27281f;


public class PdfViewerListViewItem
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Syncfusion.SfPdfViewer.XForms.Droid.PdfViewerListViewItem, Syncfusion.SfPdfViewer.XForms.Android", PdfViewerListViewItem.class, __md_methods);
	}


	public PdfViewerListViewItem ()
	{
		super ();
		if (getClass () == PdfViewerListViewItem.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.PdfViewerListViewItem, Syncfusion.SfPdfViewer.XForms.Android", "", this, new java.lang.Object[] {  });
	}

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
