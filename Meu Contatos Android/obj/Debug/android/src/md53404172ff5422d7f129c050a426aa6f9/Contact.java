package md53404172ff5422d7f129c050a426aa6f9;


public class Contact
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Meu_Contatos_Android.Contact, Meu Contatos Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Contact.class, __md_methods);
	}


	public Contact () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Contact.class)
			mono.android.TypeManager.Activate ("Meu_Contatos_Android.Contact, Meu Contatos Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
