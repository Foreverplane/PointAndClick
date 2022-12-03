using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller {
	[SerializeField]
	private SceneView _SceneView;

	public override void InstallBindings() {
		Debug.Log("Install client bindings");
		
		Container.BindInterfacesAndSelfTo<SceneView>().FromInstance(_SceneView).AsSingle();
		var coreInstaller = new SharedInstaller();
		coreInstaller.Install(Container,new ClientSystemsProvider(),new UnityLogger());
	}
}