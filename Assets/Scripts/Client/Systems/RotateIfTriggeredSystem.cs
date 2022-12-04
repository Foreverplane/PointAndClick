using Leopotam.EcsLite;
using Unity.Mathematics;
using Zenject;
public class RotateIfTriggeredSystem : IEcsRunSystem {
	[Inject]
	private EntityIdMap _EntityIdMap;
	[Inject]
	private TimeProvider _TimeProvider;
	
	public void Run(IEcsSystems systems) {
		var world = systems.GetWorld();
		var connectedEntities = world.Filter<RotateTargetOnSourceTriggeredRequest>().Inc<ConnectedEntitiesComponent>().End();
		var rotateTargetOnSourceTriggeredRequests = world.GetPool<RotateTargetOnSourceTriggeredRequest>();
		var connectedEntitiesPool = world.GetPool<ConnectedEntitiesComponent>();
		var triggerResultPool = world.GetPool<TriggerResult>();
		var rotationComponentPool = world.GetPool<RotationLocalComponent>();
		var rotationDataPool = world.GetPool<RotationData>();
		foreach (var connectedEntity in connectedEntities) {
			ref var request = ref rotateTargetOnSourceTriggeredRequests.Get(connectedEntity);
			ref var connectedEntitiesComponent = ref connectedEntitiesPool.Get(connectedEntity);
			if (_EntityIdMap.Map.TryGetValue(connectedEntitiesComponent.Source, out var sourceEntityId)) {
				if (triggerResultPool.Has(sourceEntityId)) {
					if (_EntityIdMap.Map.TryGetValue(connectedEntitiesComponent.Target, out var targetEntityId)) {
						ref var rotationComponent = ref rotationComponentPool.Get(targetEntityId);
						ref var rotationData = ref rotationDataPool.Get(targetEntityId);
						request.CurrentT += rotationData.Speed * _TimeProvider.RealDeltaTime;
						request.CurrentT = math.clamp(request.CurrentT, 0, 1);
						rotationComponent.Rotation = math.slerp(rotationComponent.Rotation, quaternion.Euler(math.radians(request.TargetRotationEuler)), request.CurrentT);
					}
				}
			}
		}
	}
}