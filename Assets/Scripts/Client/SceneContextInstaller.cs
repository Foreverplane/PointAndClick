using System;
using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller {

	[SerializeField]
	private Camera _Camera;
	[SerializeField]
	private GameObjectToEntityConverter[] _GameObjectToEntityConverter;

	private void OnValidate() {
		_GameObjectToEntityConverter = FindObjectsOfType<GameObjectToEntityConverter>();
	}

	public override void InstallBindings() {
		Debug.Log("Install client bindings");

		Container.Bind<Camera>().FromInstance(_Camera).AsSingle();
		var coreInstaller = new SharedInstaller();
		coreInstaller.Install(Container,new ClientSystemsProvider(),new UnityLogger());
		

	}
}