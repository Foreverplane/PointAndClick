using Leopotam.EcsLite;
using Unity.Mathematics;
public class MovementDirectionSystem : IEcsRunSystem {
	public void Run(IEcsSystems systems) {
		EcsWorld world = systems.GetWorld();
		var movableEntities = world.Filter<MoveableTag>().Inc<RotateToMovementDirectionRequest>().End();
		var targetPointPool = world.GetPool<MoveToPointRequest>();
		var requestPool = world.GetPool<RotateToMovementDirectionRequest>();
		var positionPool = world.GetPool<PositionComponent>();
		foreach (var entity in movableEntities) {
			
			if (targetPointPool.Has(entity)) {
				var targetPointComponent = targetPointPool.Get(entity);
				var position = positionPool.Get(entity);
				ref var directionComponent = ref requestPool.Get(entity);
				
				directionComponent.Direction = math.normalize(targetPointComponent.TargetPoint - position.Value);
			}
		}
	}
}
