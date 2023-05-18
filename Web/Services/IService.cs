namespace Clientes.Api.Services
{
    public interface IService<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        TResponse Create(TRequest request);
        TResponse Delete(int id);
        List<TResponse> Get();
        TResponse FindById(int id);
        TResponse Update(int id, TRequest request);
    }
}
