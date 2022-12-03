using System.Collections;
using Leopotam.EcsLite;
using Test;
using Zenject;
public class ServerSystems : SystemsProvider {
	protected override IEnumerable CollectSystems() {
		yield return new TestSharedSystem();
	}

}
