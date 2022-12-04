using System;
public class PositionAuthoring : GenericAuthoring<PositionComponent> {
	private void OnValidate() {
		Component.Position = transform.position;
	}
}