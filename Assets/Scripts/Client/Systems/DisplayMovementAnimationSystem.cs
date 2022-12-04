using Leopotam.EcsLite;
using Unity.Mathematics;
public class DisplayMovementAnimationSystem : IEcsRunSystem {

	public void Run(IEcsSystems systems) {
		
		var world = systems.GetWorld();
		var requests = world.Filter<MovementAnimationDisplayRequest>().Inc<AnimatorReferenceComponent>().Inc<VelocityComponent>().End();
		var animatorPool = world.GetPool<AnimatorReferenceComponent>();
		var animationRequestPool = world.GetPool<MovementAnimationDisplayRequest>();
		var velocityPool = world.GetPool<VelocityComponent>();
		foreach (var request in requests) {
			ref var animator = ref animatorPool.Get(request);
			var animationRequest = animationRequestPool.Get(request);
			var velocity = velocityPool.Get(request);
			var speed = math.length(velocity.Value)*animationRequest.SpeedToAnimatorMultiplier;
			animator.Animator.SetFloat(animationRequest.SpeedParameterHash, speed);
		}
	}
}
