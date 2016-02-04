using System;

namespace CadernoAndroid
{
	public abstract class DateUtils
	{
		public DateUtils ()
		{
		}

		public static string GetStringFromDate (System.DateTime unespecifiedDate)
		{
			if (unespecifiedDate.Kind.Equals (DateTimeKind.Local)) {
				return unespecifiedDate.ToLocalTime().ToString("d");
			}

			System.DateTime localDateTime = System.TimeZoneInfo.ConvertTimeFromUtc(unespecifiedDate.ToUniversalTime(), TimeZoneInfo.Local);
			return localDateTime.ToLocalTime().ToString("d");
		}

	}
}

