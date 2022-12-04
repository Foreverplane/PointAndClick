using System;
using UnityEngine;
public class MovementAnimationDisplayAuthoring : GenericAuthoring<MovementAnimationDisplayRequest> {

	[SerializeField]
	private string _SpeedParameter = "Speed";
	
	private void OnValidate() {
		Component.SpeedParameterHash = Animator.StringToHash(_SpeedParameter);
	}

}
[Serializable]
public struct MovementAnimationDisplayRequest {
	public int SpeedParameterHash;
	public float SpeedToAnimatorMultiplier;
}