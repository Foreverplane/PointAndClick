using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Install client bindings");
    }
}