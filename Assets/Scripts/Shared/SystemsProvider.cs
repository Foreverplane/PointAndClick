using System.Collections;
using Leopotam.EcsLite;
using Test;
using Zenject;
public abstract class SystemsProvider {
	
	[Inject]
	private DiContainer _Container;
	[Inject]
	private EcsSystems _Systems;
	[Inject]
	private Test.ILogger _Logger;

	
	public void Provide() {

		var systemsToAdd = CollectSystems();
		foreach (IEcsSystem o in systemsToAdd) {
			_Logger?.Log($"<b>{o.GetType().Name}</b> added to systems");
			_Container.BindInstance(o);
			_Container.Inject(o);
			_Systems.Add(o);
		}
	}
	protected abstract IEnumerable CollectSystems();

}
