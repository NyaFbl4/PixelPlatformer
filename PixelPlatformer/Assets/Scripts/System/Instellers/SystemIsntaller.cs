using Zenject;

namespace PixelPlatformer
{
    public class SystemIsntaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<InputSystem>()
                .AsSingle();
        }
    }
}