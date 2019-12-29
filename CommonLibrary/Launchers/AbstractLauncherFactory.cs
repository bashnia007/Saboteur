using CommonLibrary.GameSets;

namespace CommonLibrary.Launchers
{
    public abstract class AbstractLauncherFactory
    {
        public abstract AbstractGameSetFactory AbstractGameSetFactory { get; }
        public abstract AbstractLauncher CreateLauncher();

        public AbstractLauncherFactory()
        {
        }

        protected virtual void PrepareCardSet()
        {
            AbstractGameSetFactory.CreateGameSet();
        }
    }
}
