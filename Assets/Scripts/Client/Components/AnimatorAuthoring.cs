using System;
using UnityEngine;
public class AnimatorAuthoring : GenericAuthoring<AnimatorReferenceComponent> {
	
}
[Serializable]
public struct AnimatorReferenceComponent {
	public Animator Animator;
}