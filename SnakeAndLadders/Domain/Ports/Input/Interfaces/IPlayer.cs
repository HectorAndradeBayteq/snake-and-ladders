namespace Domain.Ports.Input.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        string Id { get; }
        string UserCommand { get; }
    }
}
