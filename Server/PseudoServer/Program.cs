
using Test.Systems;
using Zenject;
namespace PseudoServer {
	internal class Program {
		
		public static void Main(string[] args) {
			Console.WriteLine("Server start!");
			var container = new DiContainer();
			container.Settings = ZenjectSettings.Default;
			ZenjectManagersInstaller.Install(container);
			container.Bind<Kernel>().AsSingle();
			container.Install<ServerInstaller>();
			container.ResolveRoots();
			var kernel = container.Resolve<Kernel>();
			kernel.Initialize();
			
			var timeProvider = container.Resolve<TimeProvider>();
			var timer = new Timer((dt) => {
				timeProvider.Tick += 1;
				kernel.Tick();
				Console.WriteLine($"Tick: {timeProvider.Tick}");
			}, null, 0, TimeProvider.TICK_RATE_MS);
			Console.WriteLine("Server running...");
			Console.ReadLine();
			timer.Dispose();
		}
	}

}
