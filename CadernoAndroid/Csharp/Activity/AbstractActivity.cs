using System;
using Android.App;
using Android.OS;

namespace CadernoAndroid
{
	public abstract class AbstractActivity : Activity, IActivity
	{
		#region IActivity implementation

		public abstract void FindViews ();

		public abstract void InitViewsValue ();

		public abstract void DelegateClicks ();

		public abstract int ContentView();

		#endregion

		public AbstractActivity ()
		{
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(ContentView());

			FindViews ();
			InitViewsValue ();
			DelegateClicks ();
		}
	}
}

