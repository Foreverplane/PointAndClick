using Leopotam.EcsLite;
using Unity.Mathematics;
public class RotateToMovementDirectionSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		var world = systems.GetWorld();
		var requests = world.Filter<RotateToMovementDirectionRequest>().Inc<RotationData>().Inc<RotationLocalComponent>().End();
		var rotationPool = world.GetPool<RotationLocalComponent>();
		var rotateRequest = world.GetPool<RotateToMovementDirectionRequest>();
		foreach (var request in requests) {
			ref var globalRotation =ref  rotationPool.Get(request);
			var direction = rotateRequest.Get(request).Direction;
			globalRotation.Rotation = quaternion.LookRotation(direction, math.up());
		}
	}
}