namespace Backend.Api.Common.ModelBinding;

public class ShortGuidRouteConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        return ShortGuid.CanParse(values[routeKey]?.ToString());
    }
}
