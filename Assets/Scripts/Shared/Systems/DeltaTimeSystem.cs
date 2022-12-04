using Leopotam.EcsLite;
using Zenject;
public class DeltaTimeSystem : IEcsRunSystem {
	[Inject]
	private TimeProvider _TimeProvider;
	public void Run(IEcsSystems systems) {
		#if UNITY_5_3_OR_NEWER
		_TimeProvider.RealDeltaTime = UnityEngine.Time.deltaTime;
		#else
		_TimeProvider.RealDeltaTime = TimeProvider.TICK_RATE_MS;
		#endif
	}
}