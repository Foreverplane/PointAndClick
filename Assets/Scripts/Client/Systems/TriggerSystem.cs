using Leopotam.EcsLite;
using Unity.Mathematics;
public class TriggerSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		var world = systems.GetWorld();
		var positions = world.GetPool<PositionComponent>();
		var radius = world.GetPool<RadiusComponent>();
		var triggerResult = world.GetPool<TriggerResult>();
		var entityId = world.GetPool<EntityIdComponent>();
		var triggers = world.Filter<TriggerTag>().Inc<RadiusComponent>().Inc<PositionComponent>().Inc<EntityIdComponent>().End();
		var entities = world.Filter<TriggerRequest>().Inc<PositionComponent>().End();
		foreach (var entity in entities) {
			var entityPosition = positions.Get(entity);
			bool isDirty = false;
			foreach (var trigger in triggers) {
				var triggerPosition = positions.Get(trigger);
				var triggerRadius = radius.Get(trigger);
				var distance = math.distance(entityPosition.Position, triggerPosition.Position);
				if (distance < triggerRadius.Radius) {
					if (!triggerResult.Has(entity)) {
						triggerResult.Add(entity);
					}
					ref var result = ref triggerResult.Get(entity);
					var id = entityId.Get(trigger);
					result.EntityId = id.Id;
					isDirty = true;
					break;
				}
			}
			if (!isDirty) {
				if (triggerResult.Has(entity)) {
					triggerResult.Del(entity);
				}
			}
		}
	}
}
