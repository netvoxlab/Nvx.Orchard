using System;
using System.Data.Services;
using System.IO;
using System.Text;
using System.Web;

namespace Nvx.Orchard.OData.Models {
    public class OrchardDataServiceHost:IDataServiceHost {
        private readonly HttpRequestBase _request;
        private MemoryStream _responseStream = new MemoryStream();

        public OrchardDataServiceHost(HttpRequestBase request) {
            _request = request;
        }

        public byte[] Content {
            get { _responseStream.Flush();
                return _responseStream.ToArray();
            }
        }

        #region Implementation of IDataServiceHost

        /// <summary>
        /// Gets a data item identified by the identity key contained by the parameter of the method.
        /// </summary>
        /// <returns>
        /// The data item requested by the query serialized as a string.
        /// </returns>
        /// <param name="item">String value containing identity key of item requested.</param>
        public string GetQueryStringItem(string item) {
            return _request.QueryString.Get(item);
        }

        /// <summary>
        /// Handles a data service exception using information in  the <paramref name="args"/> parameter.
        /// </summary>
        /// <param name="args"><see cref="T:System.Data.Services.HandleExceptionArgs"/>  that contains information on the exception object.</param>
        public void ProcessException(HandleExceptionArgs args) {
            throw new Exception("OData exception", args.Exception);
        }

        /// <summary>
        /// Gets an absolute URI that is the URI as sent by the client.
        /// </summary>
        /// <returns>
        /// A string that is the absolute URI of the request.
        /// </returns>
        public Uri AbsoluteRequestUri {
            get { return _request.Url; }
        }

        /// <summary>
        /// Gets an absolute URI that is the root URI of the data service.
        /// </summary>
        /// <returns>
        /// A string that is the absolute root URI of the data service.
        /// </returns>
        public Uri AbsoluteServiceUri {
            get { return new Uri(_request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/OData")); }
        }

        /// <summary>
        /// The transport protocol specified by the request accept header.
        /// </summary>
        /// <returns>
        /// String that indicates the transport protocol required by the request.
        /// </returns>
        public string RequestAccept {
            get { return _request.Headers.Get("Accept"); }
        }

        /// <summary>
        /// Gets a string representing the value of the Accept-Charset HTTP header.
        /// </summary>
        /// <returns>
        /// String representing the value of the Accept-Charset HTTP header.
        /// </returns>
        public string RequestAcceptCharSet {
            get { return _request.Headers.Get("Accept-Charset"); }
        }

        /// <summary>
        /// Gets the transport protocol specified by the content type header.
        /// </summary>
        /// <returns>
        /// String value that indicates content type.
        /// </returns>
        public string RequestContentType {
            get { return _request.ContentType; }
        }

        /// <summary>
        /// Gets the request method of GET, PUT, POST, or DELETE.
        /// </summary>
        /// <returns>
        /// String value that indicates request method.
        /// </returns>
        public string RequestHttpMethod {
            get { return _request.HttpMethod; }
        }

        /// <summary>
        /// Gets the value for the If-Match header on the current request.
        /// </summary>
        /// <returns>
        /// String value for the If-Match header on the current request.
        /// </returns>
        public string RequestIfMatch {
            get { return _request.Headers.Get("If-Match"); }
        }

        /// <summary>
        /// Gets the value for the If-None-Match header on the current request.
        /// </summary>
        /// <returns>
        /// String value for the If-None-Match header on the current request.
        /// </returns>
        public string RequestIfNoneMatch {
            get { return _request.Headers.Get("If-None-Match"); }
        }

        /// <summary>
        /// Gets the value that identifies the highest version that the request client is able to process.
        /// </summary>
        /// <returns>
        /// A string that contains the highest version that the request client is able to process, possibly null.
        /// </returns>
        public string RequestMaxVersion {
            get { return null; }
        }

        /// <summary>
        /// Gets the stream that contains the HTTP request body.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.IO.Stream"/> object that contains the request body.
        /// </returns>
        public Stream RequestStream {
            get { return _request.InputStream; }
        }

        /// <summary>
        /// Gets the value that identifies the version of the request that the client submitted, possibly null.
        /// </summary>
        /// <returns>
        /// A string that identifies the version of the request that the client submitted, possibly null.
        /// </returns>
        public string RequestVersion {
            get { return null; }
        }

        /// <summary>
        /// Gets a string value that represents cache control information.
        /// </summary>
        /// <returns>
        /// A string value that represents cache control information.
        /// </returns>
        public string ResponseCacheControl {
            get; set; }

        /// <summary>
        /// Gets the transport protocol of the response.
        /// </summary>
        /// <returns>
        /// String value containing the content type.
        /// </returns>
        public string ResponseContentType {
            get; set; }

        /// <summary>
        /// Gets an eTag value that represents the state of data in response.
        /// </summary>
        /// <returns>
        /// A string value that represents the eTag state value.
        /// </returns>
        public string ResponseETag { get;
            set;
        }

        /// <summary>
        /// Gets or sets the service location.
        /// </summary>
        /// <returns>
        /// String that contains the service location.
        /// </returns>
        public string ResponseLocation {
            get; set; }

        /// <summary>
        /// Gets or sets the response code that indicates results of query.
        /// </summary>
        /// <returns>
        /// Integer value that contains the response code.
        /// </returns>
        public int ResponseStatusCode {
            get; set; }

        /// <summary>
        /// Gets the response stream to which the HTTP response body will be written.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.IO.Stream"/> object to which the response body will be written.
        /// </returns>
        public Stream ResponseStream {
            get { return _responseStream; }
        }

        /// <summary>
        /// Gets the version used by the host in the response.
        /// </summary>
        /// <returns>
        /// A string value that contains the host version.
        /// </returns>
        public string ResponseVersion {
            get; set; }

        #endregion
    }
}