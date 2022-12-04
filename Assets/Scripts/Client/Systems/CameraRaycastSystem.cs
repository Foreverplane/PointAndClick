using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class CameraRaycastSystem : IEcsRunSystem {

	[Inject]
	private Camera _Camera;

	public void Run(IEcsSystems systems) {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = _Camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hit)) {
				// Debug.Log(hit.collider.gameObject.name);
				EcsWorld world = systems.GetWorld();
				var entity = world.NewEntity();
				var cameraRaycastHits = world.GetPool<CameraRaycastHitComponent>();
				cameraRaycastHits.Add(entity);
				ref var hitComponent = ref cameraRaycastHits.Get(entity);
				hitComponent.Position = hit.point;
			}
		}
	}

}