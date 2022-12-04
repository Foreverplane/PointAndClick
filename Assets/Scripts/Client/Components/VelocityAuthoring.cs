using System;
using UnityEngine;
[RequireComponent(typeof(PositionAuthoring))]
public class VelocityAuthoring : GenericAuthoring<VelocityComponent> {
	private void OnValidate() {
		Component.LastPosition = GetComponent<PositionAuthoring>().InitialComponent.Value;
	}
}
