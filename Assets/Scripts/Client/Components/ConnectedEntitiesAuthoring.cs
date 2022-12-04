using UnityEngine;
public class ConnectedEntitiesAuthoring : GenericAuthoring<ConnectedEntitiesComponent> {
	[SerializeField]
	private EntityIdAuthoring _Source;
	[SerializeField]
	private EntityIdAuthoring _Target;
	void Validate() {
		if (_Source == null||_Target == null) {
			Debug.LogWarning("Please assign EntityIdAuthoring");
			return;
		}
		Component.Source = _Source.InitialComponent.Id;
		Component.Target = _Target.InitialComponent.Id;
	}

	protected override void Prepare() {
		Validate();
	}
}