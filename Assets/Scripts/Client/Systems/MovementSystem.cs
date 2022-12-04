using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;
public class MovementSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		var world = systems.GetWorld();
		var requests = world.GetPool<MoveToPointRequest>();
		var positions = world.GetPool<PositionComponent>();
		var moveData = world.GetPool<MovementData>();
		var movableEntities = world.Filter<MoveableTag>().Inc<MoveToPointRequest>().Inc<PositionComponent>().Inc<MovementData>().End();
		foreach (var movableEntity in movableEntities) {
			ref var pos = ref positions.Get(movableEntity);
			ref var move = ref moveData.Get(movableEntity);
			var targetPoint = requests.Get(movableEntity).TargetPoint;
			var direction = targetPoint - pos.Position;
			var normalized = math.normalize(direction);
			pos.Position += move.MaxSpeed * Time.deltaTime * normalized;
			if (math.length(direction) < move.PositionThreshold) {
				requests.Del(movableEntity);
			}
		}
	}
}
