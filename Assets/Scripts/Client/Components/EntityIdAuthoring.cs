using System;
public class EntityIdAuthoring : GenericAuthoring<EntityIdComponent> {

	private void OnValidate() {
		Component.Id = Guid.NewGuid().ToString();
	}

}

[Serializable]
public struct EntityIdComponent {
	public string Id;
}