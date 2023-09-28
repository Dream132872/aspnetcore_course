namespace Eshop.Web.Services;

public interface IViewRendererService
{
    string RenderToString(string viewName, object model, HttpContext context);
}