using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller {
	[SerializeField]
	private SceneView _SceneView;
	[SerializeField]
	private Camera _Camera;

	public override void InstallBindings() {
		Debug.Log("Install client bindings");
		
		Container.Bind<SceneView>().FromInstance(_SceneView).AsSingle();
		Container.Bind<Camera>().FromInstance(_Camera).AsSingle();
		var coreInstaller = new SharedInstaller();
		coreInstaller.Install(Container,new ClientSystemsProvider(),new UnityLogger());
	}
}