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
		yield return new MovementSystem();
		yield return new PositionDisplaySystem();
	}

}
