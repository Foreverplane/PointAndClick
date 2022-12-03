using Leopotam.EcsLite;

using Zenject;
public class TestSharedSystem : IEcsInitSystem, IInitializable, IEcsRunSystem {
	[Inject]
	protected Test.ILogger _Logger;
	// public TestSharedSystem() {
	// 	_Logger.Log("System created");
	// }
	public void Init(IEcsSystems systems) {
		_Logger?.Log("System initialized by ecs");
	}
	public void Initialize() {
		_Logger?.Log("System initialized by zenject");
	}
	public void Run(IEcsSystems systems) {
		_Logger?.Log("System run");
	}
}
