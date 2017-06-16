using System;
using System.Threading;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TransmitterWEB.Helpers
{
    public class WebHelper : IWebHelper
    {
        #region Private Fields

        private readonly HttpContextBase _httpContext;

        #endregion Private Fields

        #region Public Constructors

        public WebHelper(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual HttpContextBase GetCurrentContext()
        {
            return _httpContext;
        }

        public virtual string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        public virtual string GetCurrentIpAddress()
        {
            if (_httpContext != null && _httpContext.Request != null)
            {
                return _httpContext.Request.UserHostAddress;
            }

            return string.Empty;
        }

        public virtual int GetCurrentUserId()
        {
            var userId = _httpContext.User.Identity.GetUserId();
            if (!String.IsNullOrEmpty(userId)) 
                return Convert.ToInt32(userId);
            return 0;
        }

        public virtual string GetPageUrl(bool includeQueryString)
        {
            string url = string.Empty;
            if (_httpContext == null || _httpContext.Request == null)
                return url;

            if (includeQueryString)
            {
                string rawUrl = string.Empty;
                rawUrl = _httpContext.Request.RawUrl;
                url = rawUrl;
            }
            else
            {
                if (_httpContext.Request.Url != null)
                {
                    url = _httpContext.Request.Url.GetLeftPart(UriPartial.Path);
                }
            }

            return url.ToLowerInvariant();
        }

        public virtual string GetUrlReferrer()
        {
            string referrerUrl = string.Empty;

            if (_httpContext != null &&
                _httpContext.Request != null &&
                _httpContext.Request.UrlReferrer != null)
                referrerUrl = _httpContext.Request.UrlReferrer.ToString();

            return referrerUrl;
        }

        #endregion Public Methods
    }
}