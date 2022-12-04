using System.Collections;
using Leopotam.EcsLite;
using Test;
using Zenject;
public class ClientSystemsProvider : SystemsProvider {

	protected override IEnumerable CollectSystems() {
		#if UNITY_EDITOR
		yield return new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem();
	    #endif
		yield return new TestSharedSystem();

		yield return new CameraRaycastSystem();
		yield return new MovementTargetSystem();
		yield return new MovementDirectionSystem();
		yield return new DeltaTimeSystem();
		yield return new DisplayPositionSystem();
		yield return new DisplayRotationSystem();
		yield return new DisplayMovementAnimationSystem();
		
		
		yield return new EntityIdMapSystem();
		yield return new MovementSystem();
		yield return new TriggerSystem();
		yield return new RotateIfTriggeredSystem();
		yield return new RotateToMovementDirectionSystem();
		yield return new CalculateVelocitySystem();

	}

}
