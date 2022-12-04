using UnityEngine;
public class ConnectedEntityAuthoring : GenericAuthoring<ConnectedEntityComponent> {

	[SerializeField]
	private EntityIdAuthoring _EntityIdAuthoring;
	private void OnValidate() {
		if (_EntityIdAuthoring == null) {
			Debug.LogWarning("Please assign EntityIdAuthoring");
			return;
		}
		Component.ConnectedEntity = _EntityIdAuthoring.InitialComponent.Id;
	}
}