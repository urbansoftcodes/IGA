using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IGA.WebAPI.OAuth
{
    public class ApiResponseWrapperHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)


        {
            var response = await base.SendAsync(request, cancellationToken);

            return BuildApiResponse(request, response);
        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            object content;
            string errorMessage = null;
            int statusCode =0;

            if (request.RequestUri.ToString().Contains("swagger")) //&& HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //  SKIP you global logic
                return response;
            }

            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;

                if (error != null)
                {
                    content = null;
                    errorMessage = error.Message;

                    #if DEBUG
                    errorMessage = string.Concat(errorMessage, error.ExceptionMessage, error.StackTrace);
                    #endif
                }
            }

            statusCode = (int)response.StatusCode;

            if(statusCode!=200)
            {
                errorMessage = response.ReasonPhrase;
            }

            var newResponse = request.CreateResponse(response.StatusCode, new ApiResponseWrapper(request.RequestUri,response.StatusCode,request.Method.Method, content, errorMessage));

            foreach (var header in response.Headers)
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }
}