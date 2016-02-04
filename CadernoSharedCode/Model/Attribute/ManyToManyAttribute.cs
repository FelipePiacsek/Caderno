using System;

namespace Caderno.Shared
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ManyToManyAttribute : System.Attribute
	{
		public ManyToManyAttribute ()
		{
		}
	}
}

