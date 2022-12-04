using Leopotam.EcsLite;
using Unity.Mathematics;
public class DisplayPositionSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		
		var world = systems.GetWorld();
		var positions = world.GetPool<PositionComponent>();
		var transform = world.GetPool<TransformReferenceComponent>();
		var entities = world.Filter<PositionComponent>().Inc<TransformReferenceComponent>().End();
		foreach (var entity in entities) {
			ref var pos = ref positions.Get(entity);
			ref var transformRef = ref transform.Get(entity);
			transformRef.Transform.position = pos.Value;
		}
	}
}

public class DisplayRotationSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		
		var world = systems.GetWorld();
		var localRotations = world.GetPool<RotationLocalComponent>();
		var transform = world.GetPool<TransformReferenceComponent>();
		var entities = world.Filter<TransformReferenceComponent>().Inc<RotationLocalComponent>().End();
		foreach (var entity in entities) {
			ref var rot = ref localRotations.Get(entity);
			ref var transformRef = ref transform.Get(entity);
			if(!rot.Rotation.IsNaN())
				transformRef.Transform.localRotation = rot.Rotation;
		}
	}
}