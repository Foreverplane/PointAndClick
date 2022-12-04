using System;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;
public class GameObjectToEntityConverter : MonoBehaviour {

	[SerializeField] 
	private Authoring[] _Authorings;

	private void OnValidate() {
		_Authorings = GetComponents<Authoring>();
	}

	[Inject]
	public void Construct(EcsWorld EcsWorld) {
		// Debug.Log($"Constructing: {gameObject.name}");
		var entity = EcsWorld.NewEntity();
		foreach (var authoring in _Authorings) {
			authoring.AddComponent(entity, EcsWorld);
		}
	}
	
}

