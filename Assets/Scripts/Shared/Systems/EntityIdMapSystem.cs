using Leopotam.EcsLite;
using Zenject;
public class EntityIdMapSystem : IEcsRunSystem {

	[Inject]
	private EntityIdMap _EntityIdMap;
	public void Run(IEcsSystems systems) {

		var world = systems.GetWorld();
		
		var idPool = world.GetPool<EntityIdComponent>();
		var filter = world.Filter<EntityIdComponent>().End();
		foreach (var id in filter) {
			var entityIdComponent = idPool.Get(id);
			_EntityIdMap.Map[entityIdComponent.Id] = id;
		}
	}
}