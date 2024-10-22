using Microsoft.AspNetCore.Components;

namespace BlazorApp.Services
{
    public class NavigationService(NavigationManager navigationManager)
    {
        public string GetHref(string id)
        {
            Uri uri = new(navigationManager.Uri);
            string leftPart = uri.GetLeftPart(UriPartial.Path);

            return $"{leftPart}#{id}";
        }
    }
}
