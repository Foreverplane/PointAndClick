using UnityEngine;
public class RadiusAuthoring : GenericAuthoring<RadiusComponent> {

	[SerializeField]
	private Color _GizmoColor = new Color(1, 0, 0, 0.5f);
	private void OnDrawGizmos() {
		Gizmos.color = _GizmoColor;
		Gizmos.DrawSphere(transform.position, Component.Radius);
	}
}
