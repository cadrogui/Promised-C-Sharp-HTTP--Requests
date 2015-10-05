using RSG;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

using UnityEngine;

namespace PromisedRequest{
	
	public class HTTPRequest {

		private string url;
		private Dictionary<string, string> headers;

		public HTTPRequest(string url, Dictionary<string, string> headers){
			this.url = url;
			this.headers = headers;
		}

		public IPromise<string> GetJsonString(){

			var promise = new Promise<string> ();

			using (var client = new WebClient())
			{

				if (this.headers != null) {
					foreach(KeyValuePair<string, string> h in this.headers){
						client.Headers.Add(h.Key, h.Value);
					}
				}

				client.DownloadStringCompleted +=
					(s, ev) =>
				{
					if (ev.Error != null){
						promise.Reject(ev.Error);
					} else {
						promise.Resolve(ev.Result);
					}
				};
				
				client.DownloadStringAsync(new Uri(this.url), null);
			}
			return promise;
		}

		public IPromise<string> GET(Dictionary<string, string> parameters){

			if (parameters == null) {
				throw new ArgumentNullException ();
			}

			var promise = new Promise<string> ();

			using(var client = new WebClient()){

				if (this.headers != null) {
					foreach(KeyValuePair<string, string> h in this.headers){
						client.Headers.Add(h.Key, h.Value);
					}
				}

				client.DownloadStringCompleted +=
					(s, ev) =>
				{
					if (ev.Error != null){
						promise.Reject(ev.Error);
					} else {
						promise.Resolve(ev.Result);
					}
				};

				client.DownloadStringAsync(new Uri(this.url + "?" + PromisedRequest.Helpers.GenerateQueryString(parameters)), null);

			}
			return promise;
		}




	}

}

