using Leopotam.EcsLite;
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
			// Debug.Log($"Hit {JsonUtility.ToJson(hitComponent)} provide to: {movableEntities.GetEntitiesCount()} entities");
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