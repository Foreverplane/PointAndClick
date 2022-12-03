using Leopotam.EcsLite;
using UnityEngine;
using Zenject;
public class SystemsInitializer : IInitializable {

	[Inject]
	private EcsSystems _EcsSystems;
	public void Initialize() {
		Debug.Log("Systems initializer initialize");
		_EcsSystems.Init();
	}
}