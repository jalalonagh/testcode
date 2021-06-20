using MediatR;

namespace BusinessBaseConfig.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}