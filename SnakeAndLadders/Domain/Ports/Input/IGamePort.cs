namespace Domain.Ports.Input
{
    public interface IGamePort<in TRequest, out TResponse>
    {
        TResponse HandlePlayerCommand(TRequest data);
    }
}
