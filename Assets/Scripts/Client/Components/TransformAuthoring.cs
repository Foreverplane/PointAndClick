using System;
using UnityEngine;

public class TransformAuthoring : GenericAuthoring<TransformReferenceComponent> {

	private void OnValidate() {
		Component.Transform = transform;
	}

}
[Serializable]
public struct TransformReferenceComponent {
	public Transform Transform;
}