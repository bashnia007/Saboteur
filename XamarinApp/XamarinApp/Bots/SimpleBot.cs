using CommonLibraryStandard;

namespace XamarinApp.Bots
{
    public class SimpleBot : Player
    {
        public SimpleBot(int id, string name)
        {
            Id = id.ToString();
            Name = name;
        }
    }
}
