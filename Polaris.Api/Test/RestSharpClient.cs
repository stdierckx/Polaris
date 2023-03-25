using RestSharp;

namespace Polaris.Api.Test;

public class RestSharpClient
{
    private readonly RestClient _restClient;

    public RestSharpClient(string baseUrl)
    {
        _restClient = new RestClient(baseUrl);
    }

    public T Execute<T>(RestRequest request) where T : new()
    {
        var response = _restClient.Execute<T>(request);
        if (response.ErrorException != null)
        {
            const string message = "Error retrieving response. Check inner details for more info.";
            var apiException = new ApplicationException(message, response.ErrorException);
            throw apiException;
        }

        return response.Data;
    }
}