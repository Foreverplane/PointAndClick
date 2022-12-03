using Leopotam.EcsLite;
using Zenject;
public class SystemsInitializer : IInitializable {

	[Inject]
	private EcsSystems _EcsSystems;

	[Inject]
	private Test.ILogger _Logger;
	public void Initialize() {
		_Logger.Log($"Try initialize {_EcsSystems.GetAllSystems().Count} systems");
		_EcsSystems.Init();
	}
}