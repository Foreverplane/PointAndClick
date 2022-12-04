using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
public class SharedSystemsProvider : SystemsProvider {

	public override IEnumerable<IEcsSystem> CollectSystems() {
		yield return new TestSharedSystem();
		yield return new MovementTargetSystem();
		yield return new MovementDirectionSystem();
		yield return new DeltaTimeSystem();
		yield return new EntityIdMapSystem();
		yield return new MovementSystem();
		yield return new TriggerSystem();
		yield return new RotateIfTriggeredSystem();
		yield return new RotateToMovementDirectionSystem();
		yield return new CalculateVelocitySystem();
	}
}
