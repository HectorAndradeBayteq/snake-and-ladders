using Data;
using Domain.Ports.Output;
using Domain.UseCases;
using Ninject.Modules;

namespace Presentation.Modules
{
    public class GameModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameConfigPort>().To<GameConfigAdaptor>();
            Bind<GameAdaptor>().ToSelf().InSingletonScope();
        }
    }
}
