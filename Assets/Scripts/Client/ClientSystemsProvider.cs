using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using Test;
using Zenject;
public class ClientSystemsProvider : SystemsProvider {

	public override IEnumerable<IEcsSystem> CollectSystems() {
		#if UNITY_EDITOR
		yield return new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem();
	    #endif
		yield return new CameraRaycastSystem();
		yield return new DisplayPositionSystem();
		yield return new DisplayRotationSystem();
		yield return new DisplayMovementAnimationSystem();
		var sharedSystems = new SharedSystemsProvider();
		foreach (var system in sharedSystems.CollectSystems()) {
			yield return system;
		}
	}

}
