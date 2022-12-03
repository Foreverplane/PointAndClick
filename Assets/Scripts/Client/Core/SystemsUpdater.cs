using Leopotam.EcsLite;
using Zenject;
public class SystemsUpdater : ITickable {

	[Inject]
	private EcsSystems _EcsSystems;
	public void Tick() {
		_EcsSystems.Run();
	}
}
