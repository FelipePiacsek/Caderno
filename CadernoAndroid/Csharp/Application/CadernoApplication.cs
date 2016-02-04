using System;
using Android.App;
using Caderno.Shared;
using Android.Runtime;

namespace CadernoAndroid
{
	[Application]
	partial class CadernoApplication : Application
	{
		private InitializationService initializationService = new InitializationService();

		public CadernoApplication (IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
			
		}

		public override void OnCreate ()
		{
			base.OnCreate ();
			initializationService.SetupDatabase ();
		} 
	}
}

