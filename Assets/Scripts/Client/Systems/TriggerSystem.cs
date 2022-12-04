using Leopotam.EcsLite;
using Unity.Mathematics;
public class TriggerSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		var world = systems.GetWorld();
		var positionsPool = world.GetPool<PositionComponent>();
		var radiusPool = world.GetPool<RadiusComponent>();
		var triggerResultPool = world.GetPool<TriggerResult>();
		var entityIdPool = world.GetPool<EntityIdComponent>();
		var triggers = world.Filter<TriggerTag>().Inc<RadiusComponent>().Inc<PositionComponent>().Inc<EntityIdComponent>().End();
		var entities = world.Filter<TriggerRequest>().Inc<PositionComponent>().End();
		foreach (var entity in entities) {
			var entityPosition = positionsPool.Get(entity);
			bool isEntityTriggerDirty = false;
			foreach (var trigger in triggers) {
				var triggerPosition = positionsPool.Get(trigger);
				var triggerRadius = radiusPool.Get(trigger);
				var distance = math.distance(entityPosition.Position, triggerPosition.Position);
				if (distance < triggerRadius.Radius) {
					if (!triggerResultPool.Has(entity)) {
						triggerResultPool.Add(entity);
					}
					ref var entityTriggerResult = ref triggerResultPool.Get(entity);
					var triggerId = entityIdPool.Get(trigger);
					entityTriggerResult.EntityId = triggerId.Id;
					isEntityTriggerDirty = true;
					if (!triggerResultPool.Has(trigger)) {
						triggerResultPool.Add(trigger);
					}
					ref var triggerResult = ref triggerResultPool.Get(trigger);
					ref var entityIdComponent = ref entityIdPool.Get(entity);
					triggerResult.EntityId = entityIdComponent.Id;

				}
				else {
					if (triggerResultPool.Has(trigger)) {
						
						triggerResultPool.Del(trigger);
					}
				}
			}
			if (!isEntityTriggerDirty) {
				if (triggerResultPool.Has(entity)) {
					triggerResultPool.Del(entity);
				}
			}
		}
	}
}
