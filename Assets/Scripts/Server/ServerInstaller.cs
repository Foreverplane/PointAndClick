using Zenject;

internal class ServerInstaller : Installer {

	public override void InstallBindings() {
		var installer = new SharedInstaller();
		var systemsProvider = new ServerSystemsProvider();
		var logger = new ServerLogger();
		installer.Install(Container, systemsProvider, logger);
	}
}
