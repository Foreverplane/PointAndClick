using Leopotam.EcsLite;
using UnityEngine;
public class MovementTargetSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		EcsWorld world = systems.GetWorld();
		var cameraRaycastHits = world.Filter<CameraRaycastHitComponent>().End();
		var hitsPool = world.GetPool<CameraRaycastHitComponent>();
		var targetPointPool = world.GetPool<MovementTargetPointComponent>();
		var movableEntities = world.Filter<MoveableTag>().End();
		foreach (var entity in cameraRaycastHits) {
			ref var hitComponent = ref hitsPool.Get(entity);
			Debug.Log($"Hit {JsonUtility.ToJson(hitComponent)} provide to: {movableEntities.GetEntitiesCount()} entities");
			hitsPool.Del(entity);
			foreach (var movableEntity in movableEntities) {
				int e = movableEntity;
				if (targetPointPool.Has(e)) {
					e = movableEntity;
				}
				else {
					e = world.NewEntity();
					targetPointPool.Add(e);
				}
				ref var targetPointComponent = ref targetPointPool.Get(e);
				targetPointComponent.TargetPoint = hitComponent.Position;
			}
		}
	}
}
