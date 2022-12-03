using System.Collections;

public class ServerSystemsProvider : SystemsProvider {
	protected override IEnumerable CollectSystems() {
		yield return new TestSharedSystem();
	}

}
