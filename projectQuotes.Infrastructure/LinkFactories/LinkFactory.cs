using Microsoft.AspNetCore.Http;
using projectQuotes.Constants.Controller;

namespace projectQuotes.Infrastructure.LinkFactories;

public class LinkFactory : ILinkFactory
{
    public string GetConfirmingLink(HttpRequest httpRequest, string email, string code)
    {
        var scheme = httpRequest.Scheme;

        var hostValue = httpRequest.Host.Value;

        return $"{scheme}://{hostValue}/" + ControllerStringConstants.Version + $"/User/Confirm?email={email}&code={code}";

    }

    public string GetImageUrl(HttpRequest httpRequest, string guid)
    {
        var scheme = httpRequest.Scheme;

        var hostValue = httpRequest.Host.Value;

        return $"{scheme}://{hostValue}/" + ControllerStringConstants.Version + $"/Photo/{ControllerStringConstants.EndpointForDisplayImage}/" + guid;
    }
}
