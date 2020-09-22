using System.Net.Http;

namespace ContactsUI.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
    }
}