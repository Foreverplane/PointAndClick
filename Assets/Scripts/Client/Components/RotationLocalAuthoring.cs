using System;
public class RotationLocalAuthoring : GenericAuthoring<RotationLocalComponent> {

	private void OnValidate() {
		Component.Rotation = transform.localRotation;
	}

}