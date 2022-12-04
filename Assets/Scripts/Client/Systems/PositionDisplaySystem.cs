using Leopotam.EcsLite;
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