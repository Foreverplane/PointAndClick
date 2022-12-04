using System;
using UnityEngine;
public class EntityIdAuthoring : GenericAuthoring<EntityIdComponent> {

	private void OnValidate() {
		if (Component.Id == 0)
			Component.Id = gameObject.GetInstanceID();
	}

	protected override void OnAdded(EntityIdComponent component) {
		// Debug.Log($"Entity with id: {component.Id} added to ecs world");
	}
}
