using System;
using System.Text.RegularExpressions;

namespace Caderno.Shared
{
	public abstract class StringUtils
	{
		/*
		 * Transforms a string from PascalCase or camelCase to underscore_case.
		 */
		public static string ToUnderscoreCase(string word)
		{
			string pattern = @"[A-Z]";
			word = Char.ToLower(word[0]) + word.Remove(0,1);
			return Regex.Replace (word, pattern, m => "_" + m.Groups[0].Value.ToLower()).ToLower();
		}
	}
}

