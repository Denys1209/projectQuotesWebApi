using Microsoft.AspNetCore.Http;

namespace projectQuotes.Infrastructure.LinkFactories;

public interface ILinkFactory
{
    public string GetImageUrl(HttpRequest httpRequest, string guid);

    public string GetConfirmingLink(HttpRequest httpRequest, string email, string code);
}
