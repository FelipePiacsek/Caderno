
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
	[Activity (Label = "Nova anotação",  
		Icon="@drawable/icon",
		MainLauncher = false,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class NovaAnotacaoActivity : AbstractActivity
	{
		private AnotacaoService anotacaoService = new AnotacaoService();

		private Anotacao anotacao = new Anotacao();

		private EditText tituloText;

		private EditText anotacoesText;

		private Button btnSalvar;

		private Button btnCancelar;

		#region implemented abstract members of AbstractActivity
		public override int ContentView ()
		{
			return Resource.Layout.NovaAnotacao;
		}
	
		public override void FindViews ()
		{
			btnSalvar = FindViewById<Button> (Resource.Id.SaveButton);
			btnCancelar = FindViewById<Button> (Resource.Id.CancelDeleteButton);
			anotacoesText = FindViewById<EditText> (Resource.Id.AnotacoesText);
			tituloText = FindViewById<EditText> (Resource.Id.TituloText);
		}

		public override void InitViewsValue ()
		{
		}

		public override void DelegateClicks ()
		{
			btnCancelar.Click += (sender, e) => {
				Finish();
			};

			btnSalvar.Click += (sender, e) => {
				anotacao.Texto = anotacoesText.Text;
				anotacao.Titulo = tituloText.Text;

				Tag t1 = new Tag();
				t1.nome = "vida particular";
				Tag t2 = new Tag();
				t2.nome = "trabalho";

				ISet<Tag> tags = new HashSet<Tag>();
				tags.Add(t1);
				tags.Add(t2);

				anotacao.Tags = tags;

				if(anotacao.ID > 0)
				{
					anotacaoService.Update(anotacao);
				}
				else
				{
					anotacaoService.Save(anotacao);
				}
				Finish();
			};
		}

		#endregion

		void InitAnotacao ()
		{
			int anotacaoID = Intent.GetIntExtra("AnotacaoID", 0);
			if (anotacaoID > 0) 
			{
				anotacao = anotacaoService.FindById (anotacaoID);
			} else 
			{
				anotacao.DataCriacao = DateTime.Today;
			}
		}


		protected override void OnResume ()
		{
			base.OnResume ();
			InitAnotacao ();

		}



	}
}

