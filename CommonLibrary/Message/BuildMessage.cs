namespace CommonLibrary.Message
{
    public class BuildMessage : Message
    {
        // ID карты, которую игрок хочет построить
        public int CardId { get; set; }
        // координаты, где игрок хочет построить карту тунеля
        public int X { get; set; }
        public int Y { get; set; }
    }
}
