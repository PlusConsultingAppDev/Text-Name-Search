using System.Threading.Tasks;

namespace App.HttpClient
{
    public interface IProxy
    {
        Task<T> Get<T>(string url);

        Task<TReturn> Post<TInput, TReturn>(string url, TInput content);

        Task<T> Put<T>(string url, T content);

        Task<T> Delete<T>(string url);
    }
}
