namespace Web_RPG.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HP { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defencse { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; }
    }
}
