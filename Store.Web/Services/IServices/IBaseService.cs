using Store.Web.Models;
using Store.Web.Models.Dto;

namespace Store.Web.Services.IServices;

public interface IBaseService
{
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}