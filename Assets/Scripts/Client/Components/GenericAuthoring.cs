using Leopotam.EcsLite;
using UnityEngine;


public class GenericAuthoring<TComponent> : Authoring where TComponent : struct {
	[SerializeField]
	protected TComponent Component;

	public override void AddComponent(int entity, EcsWorld ecsWorld) {
		ref var tComp = ref ecsWorld.GetPool<TComponent>().Add(entity);
		tComp = Component;
	}
}