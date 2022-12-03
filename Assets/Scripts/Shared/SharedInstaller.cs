using Leopotam.EcsLite;
using Zenject;
public class SharedInstaller {

	public void Install(DiContainer container, SystemsProvider systemsProvider,Test.ILogger logger = null) {

		SignalBusInstaller.Install(container);
		var world = new EcsWorld();
		var systems = new EcsSystems(world);
		container.BindInterfacesAndSelfTo<Test.ILogger>().FromInstance(logger).AsSingle();
		container.BindInterfacesAndSelfTo<EcsWorld>().FromInstance(world).AsSingle();
		container.BindInterfacesAndSelfTo<EcsSystems>().FromInstance(systems).AsSingle();
		container.Inject(systemsProvider);
		systemsProvider.Provide();
		container.BindInterfacesAndSelfTo<SystemsInitializer>().AsSingle();
		container.BindInterfacesAndSelfTo<TimeProvider>().AsSingle();
		container.BindInterfacesAndSelfTo<SystemsUpdater>().AsSingle();
	}
}
