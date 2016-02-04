using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Caderno.Shared;
using CadernoAndroid;
using Android.Content.PM;
using System;
using System.Threading;

namespace CadernoAndroid.Screens 
{
	
	[Activity (Label = "Caderno",  
		Icon="@drawable/icon",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class AnotacoesActivity : AbstractActivity 
	{
		private Button btnNovaAnotacao;

		private AnotacaoService anotacaoService = new AnotacaoService ();

		private List<Anotacao> anotacoes;

		private AnotacaoAdapter anotacaoAdapter;

		private ListView anotacoesView;

		#region implemented abstract members of AbstractActivity

		public override int ContentView ()
		{
			return Resource.Layout.Anotacoes;
		}

		public override void FindViews ()
		{
			btnNovaAnotacao = FindViewById<Button> (Resource.Id.btn_aprendizado);
			anotacoesView = FindViewById<ListView> (Resource.Id.listViewAprendizados);
		}
		
		public override void InitViewsValue ()
		{
		}
		
		public override void DelegateClicks ()
		{
			btnNovaAnotacao.Click += (sender, e) => {
				StartActivity(typeof(NovaAnotacaoActivity));
			};
		}

		#endregion


		protected override void OnResume ()
		{
			base.OnResume ();
			anotacoes = anotacaoService.ListAll ();
			anotacaoAdapter = new AnotacaoAdapter (this, anotacoes);
			anotacoesView.Adapter = anotacaoAdapter;
		}



	}
}