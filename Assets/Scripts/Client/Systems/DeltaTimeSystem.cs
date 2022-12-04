
using Leopotam.EcsLite;
using Zenject;
public class DeltaTimeSystem : IEcsRunSystem {
	[Inject]
	private TimeProvider _TimeProvider;
	public void Run(IEcsSystems systems) {
		_TimeProvider.RealDeltaTime = UnityEngine.Time.deltaTime;
	}
}
