using Colore.Data;

namespace rbridge.api;

public class Utils
{

    public static Color colorFromString(string s)
    {
        if (!s.Contains('#'))
        {
            switch (s)
            {
                case "red": return Color.Red;
                case "orange": return Color.Orange;
                case "yellow": return Color.Yellow;
                case "green": return Color.Green;
                case "blue": return Color.Blue;
                case "purple": return Color.Purple;
                case "pink": return Color.Pink;
                case "blank": return Color.Black;
                case "white": return Color.White;
            }
        }
        uint color = Convert.ToUInt32(s.Replace("#", ""), 16);
        return Color.FromRgb(color);
    }
    
}