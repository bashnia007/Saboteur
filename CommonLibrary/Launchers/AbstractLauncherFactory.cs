namespace CommonLibrary.Launchers
{
    public abstract class AbstractLauncherFactory
    {
        public abstract AbstractLauncher CreateLauncher();

        protected abstract void PrepareCardSet();
    }
}
