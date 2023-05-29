namespace Quest
{
    public class Robe
    {
        public string Color { get; set; }
        public int Length { get; set; }

        public Robe(string color, int length)
        {
            Color = color;
            Length = length;
        }
    
        public static void RobeDescription()
        {
            List<string> colors = new List<string>
            {
                "Magenta",
                "Octarine",
                "Mithril Silver",
                "Emerald Green"
            };

            List<int> lengths = new List<int>
            {
                48,
                52,
                58
            };
        }
    }
}
