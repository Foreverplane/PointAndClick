using System;
using Zenject;
namespace PseudoServer {
	internal class Program {
		public static void Main(string[] args) {
			var installer = new ServerInstaller();
			installer.InstallBindings();
		}
	}

	internal class ServerInstaller : Installer {

		public override void InstallBindings() {
			Console.WriteLine("Hello World!");
			var installer = new SharedInstaller();
		
			var systemsProvider = new ServerSystemsProvider();
			var logger = new ServerLogger();
			installer.Install(Container, systemsProvider, logger);
			Console.ReadLine();

		}
	}

}
