using Leopotam.EcsLite;
using Zenject;
public class DeltaTimeSystem : IEcsRunSystem {
	[Inject]
	private TimeProvider _TimeProvider;
	public void Run(IEcsSystems systems) {
		_TimeProvider.RealDeltaTime = UnityEngine.Time.deltaTime;
	}
}

public class CalculateVelocitySystem : IEcsRunSystem {

	[Inject]
	private TimeProvider _TimeProvider;
	public void Run(IEcsSystems systems) {
		var world = systems.GetWorld();
		var filter = world.Filter<VelocityComponent>().Inc<PositionComponent>().End();
		var velocityPool = world.GetPool<VelocityComponent>();
		var positionPool = world.GetPool<PositionComponent>();
		foreach (var entity in filter) {
			ref var velocity = ref velocityPool.Get(entity);
			var pos = positionPool.Get(entity);
			velocity.Value = pos.Value - velocity.LastPosition;
			velocity.Value /= _TimeProvider.RealDeltaTime;
			velocity.LastPosition = pos.Value;
		}
	}
}
