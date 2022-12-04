using Leopotam.EcsLite;
using UnityEngine;

public abstract class Authoring : MonoBehaviour {
	public abstract void AddComponent(int entity, EcsWorld ecsWorld);
}
