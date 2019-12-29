namespace CommonLibrary.GameSets
{
    public abstract class AbstractGameSetFactory
    {
        protected IGameSet GameSet;

        public IGameSet CreateGameSet()
        {
            PrepareCards();
            return GameSet;
        }

        protected virtual void PrepareCards()
        {
            PrepareRouteCards();
            PrepareActionCards();
            PrepareGoldCard();
            PrepareStartCards();
            PrepareGoldCardCoordinates();
        }

        protected abstract void PrepareRouteCards();
        protected abstract void PrepareActionCards();
        protected abstract void PrepareGoldCard();
        protected abstract void PrepareStartCards();
        protected abstract void PrepareGoldCardCoordinates();

    }
}
