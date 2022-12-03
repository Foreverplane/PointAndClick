using Leopotam.EcsLite;
using UnityEngine;
using Zenject;
public class TestSystem : IEcsSystem, IEcsInitSystem, IInitializable, IEcsRunSystem {
	public TestSystem() {
		Debug.Log("System created");
	}
	public void Init(IEcsSystems systems) {
		Debug.Log("System initialized by ecs");
	}
	public void Initialize() {
		Debug.Log("System initialized by zenject");
	}
	public void Run(IEcsSystems systems) {
		// Debug.Log("System run");
	}
}
