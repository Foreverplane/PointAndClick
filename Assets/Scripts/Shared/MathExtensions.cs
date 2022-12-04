using Unity.Mathematics;
public static class MathExtensions{
	public static bool IsNaN(this quaternion q) {
		return float.IsNaN(q.value.x) || float.IsNaN(q.value.y) || float.IsNaN(q.value.z) || float.IsNaN(q.value.w);
	}
}
