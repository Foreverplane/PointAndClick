using System;
using Unity.Mathematics;
[Serializable]
public struct RotateTargetOnSourceTriggeredRequest {
	public float3 TargetRotationEuler;
	public float CurrentT;
}