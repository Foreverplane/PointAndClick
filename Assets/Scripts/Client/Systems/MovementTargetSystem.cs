using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;
public class MovementTargetSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		EcsWorld world = systems.GetWorld();
		var cameraRaycastHits = world.Filter<CameraRaycastHitComponent>().End();
		var hitsPool = world.GetPool<CameraRaycastHitComponent>();
		var targetPointPool = world.GetPool<MoveToPointRequest>();
		var movableEntities = world.Filter<MoveableTag>().End();
		foreach (var entity in cameraRaycastHits) {
			ref var hitComponent = ref hitsPool.Get(entity);
			Debug.Log($"Hit {JsonUtility.ToJson(hitComponent)} provide to: {movableEntities.GetEntitiesCount()} entities");
			foreach (var movableEntity in movableEntities) {
				if (!targetPointPool.Has(movableEntity)) {
					targetPointPool.Add(movableEntity);
				}
				ref var targetPointComponent = ref targetPointPool.Get(movableEntity);
				targetPointComponent.TargetPoint = hitComponent.Position;
			}
			hitsPool.Del(entity);
		}
	}
}

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

public class PositionDisplaySystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		
		var world = systems.GetWorld();
		var positions = world.GetPool<PositionComponent>();
		var transform = world.GetPool<TransformReferenceComponent>();
		var entities = world.Filter<PositionComponent>().Inc<TransformReferenceComponent>().End();
		foreach (var entity in entities) {
			ref var pos = ref positions.Get(entity);
			ref var transformRef = ref transform.Get(entity);
			transformRef.Transform.position = pos.Position;
		}
	}
}
