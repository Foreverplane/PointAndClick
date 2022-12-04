using Leopotam.EcsLite;
using UnityEngine;


public class GenericAuthoring<TComponent> : Authoring where TComponent : struct {
	[SerializeField]
	protected TComponent Component;

	public TComponent InitialComponent => Component;
	public override void AddComponent(int entity, EcsWorld ecsWorld) {
		Prepare();
		ref var tComp = ref ecsWorld.GetPool<TComponent>().Add(entity);
		tComp = Component;
		OnAdded(Component);
	}
	protected virtual void Prepare(){}
	protected virtual void OnAdded(TComponent component) {}
}