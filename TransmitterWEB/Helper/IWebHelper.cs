using System.Web;

namespace TransmitterWEB.Helpers
{
    public interface IWebHelper
    {
        #region Public Methods

        HttpContextBase GetCurrentContext();

        string GetCurrentCulture();

        string GetCurrentIpAddress();

        int GetCurrentUserId();

        string GetPageUrl(bool includeQueryString);

        string GetUrlReferrer();

        #endregion Public Methods
    }
}