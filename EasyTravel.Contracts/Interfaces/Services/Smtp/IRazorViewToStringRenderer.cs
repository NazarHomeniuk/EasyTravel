using System.Threading.Tasks;

namespace EasyTravel.Contracts.Interfaces.Services.Smtp
{
    public interface IRazorViewToStringRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}