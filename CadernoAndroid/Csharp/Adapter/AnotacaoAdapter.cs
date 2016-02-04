using System;
using Android.Widget;
using Caderno.Shared;
using System.Collections.Generic;
using Android.Views;
using Android.App;
using System.Linq;

namespace CadernoAndroid
{
	public class AnotacaoAdapter : BaseAdapter<Anotacao>
	{
		private List<Anotacao> anotacoes;

		private Activity context;

		#region implemented abstract members of BaseAdapter

		public override Anotacao this [int index] {
			get {
				return anotacoes [index];
			}
		}

		public override long GetItemId (int position)
		{
			return anotacoes [position].GetId ();
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			Anotacao anotacao = anotacoes [position];
			View view = convertView;
			if (view == null) 
			{
				view = context.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem1, null);
			}
			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text = anotacao.DataCriacao.ToString ("dd/MM/yyyy") + " - " + anotacao.Titulo;
			return view;

		}

		public override int Count {
			get {
				return anotacoes.Count;
			}
		}

		#endregion

		public AnotacaoAdapter (Activity context, List<Anotacao> anotacoes)
		{
			this.anotacoes = anotacoes;
			this.anotacoes.Sort ((x, y) => DateTime.Compare (x.DataCriacao, y.DataCriacao));
			this.context = context;
		}
	}
}

