namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string ShininessDescription
        {
            get
            {
                if (ShininessLevel < 2)
                {
                    return " Dull";
                }
                else if (ShininessLevel >= 2 && ShininessLevel <= 5)
                {
                    return " Noticeable";
                }
                else if (ShininessLevel >= 6 && ShininessLevel <= 9)
                {
                    return " Bright";
                }
                else
                {
                    return " Blinding";
                }
            }
        }

        public Hat(int shininessLevel)
        {
            ShininessLevel = shininessLevel;
        }
    }
}
