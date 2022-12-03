using System.Collections;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller {
	[SerializeField]
	private SceneView _SceneView;
	public override void InstallBindings() {
		Debug.Log("Install client bindings");
		Container.BindInterfacesAndSelfTo<SceneView>().FromInstance(_SceneView).AsSingle();
		var world = new EcsWorld();
		var systems = new EcsSystems(world);
		Container.BindInterfacesAndSelfTo<EcsWorld>().FromInstance(world).AsSingle();
		Container.BindInterfacesAndSelfTo<EcsSystems>().FromInstance(systems).AsSingle();
		var systemsToAdd = CollectSystems();
		foreach (IEcsSystem o in systemsToAdd) {
			Debug.Log($"<b>{o.GetType().Name}</b> added to systems");
			Container.Bind().FromInstance(o).AsSingle();
			systems.Add(o);
		}
		Container.BindInterfacesAndSelfTo<SystemsInitializer>().AsSingle();
		Container.BindInterfacesAndSelfTo<SystemsUpdater>().AsSingle();
	}

	private IEnumerable CollectSystems() {
	    #if UNITY_EDITOR
		yield return new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem();
	    #endif
		yield return new TestSystem();
	}
}