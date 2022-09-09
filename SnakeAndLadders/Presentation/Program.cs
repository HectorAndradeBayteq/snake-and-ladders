using Domain.Ports.Input.Interfaces;
using Domain.UseCases;
using Ninject;
using Presentation.Entities;
using Presentation.Modules;

IKernel kernel = new StandardKernel(new GameModule());
var useCase = kernel.Get<GameAdaptor>();

var players = new List<IPlayer>() {
    new PlayerDTO("A"),
    new PlayerDTO("B"),
    new PlayerDTO("C")
};

var state = useCase.StartGame(players);
var isRunning = true;

while (isRunning)
{
    Console.Clear();
    state = useCase.HandlePlayerCommand(state.NextPlayer);

    Console.WriteLine(state.StateMessage);
    Console.WriteLine($"Last dice result: { state.LastDiceResult }");
    
    state.Positions.ToList().ForEach(position =>
        Console.WriteLine($"Player {position.Key.Name} with ID: {position.Key.Id} is on position {position.Value.Id}"));
    
    Console.WriteLine($"Next player: {state.NextPlayer.Name}");
    
    Console.WriteLine("Continue [Y/n]");
    isRunning = Console.ReadLine() != "n";
}
