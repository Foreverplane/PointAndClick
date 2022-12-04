using System;
using UnityEngine;
public class PositionAuthoring : GenericAuthoring<PositionComponent> {
	private void OnValidate() {
		Component.Value = transform.position;
	}
}