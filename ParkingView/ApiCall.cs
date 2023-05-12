using Newtonsoft.Json;
using ParkingApp_Core;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingView
{
    public class ApiCall
    {
        public static string TYPE_XML = "application/xml";
        public static string TYPE_JSON = "application/json";

        public static Response RequestJSON(string url, object data, string resource, RestSharp.Method method)
        {

            var response = new Response();
            var client = new RestClient(url);
            var request = new RestRequest(resource, method);
            request.AddHeader("content-type", TYPE_JSON);
            request.AddHeader("Accept", TYPE_JSON);

            //request.AddParameter(TYPE_JSON, data, ParameterType.RequestBody);
            request.AddJsonBody(data);
            RestResponse restResponse = client.Execute(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
                response = JsonConvert.DeserializeObject<Response>(restResponse.Content);

            else
            {
                response.Message = restResponse.StatusCode + " " + restResponse.StatusDescription;
                response.Exception.Message = restResponse.ErrorException == null ? "" : restResponse.ErrorException.Message;
                response.Exception.ErrorCode = restResponse.ErrorException == null ? 0 : restResponse.ErrorException.HResult;
                response.Exception.InnerException = restResponse.ErrorException == null ? "" : restResponse.ErrorException.InnerException == null ? "" : restResponse.ErrorException.InnerException.ToString();
                response.Exception.StatusCode = (int)restResponse.StatusCode == 0 ? 0 : (int)restResponse.StatusCode;
            }

            return response;

        }
    }
}
