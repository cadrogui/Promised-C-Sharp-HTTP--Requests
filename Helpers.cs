using System;
using System.Collections;
using System.Collections.Generic;

namespace PromisedRequest{

	public class Helpers {
		
		public static string GenerateQueryString(Dictionary<string, string> dict)
		{
			int i = 0;
			string prms = "";
			
			foreach (var item in dict)
			{
				prms += item.Key + "=" + item.Value;
				prms += i != dict.Count ? "&" : string.Empty;
				i++;
			}
			
			return prms;
		}
		
		
	}
}

