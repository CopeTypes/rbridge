

using Colore.Data;
using rbridge.api;

namespace rbridge
{
    internal abstract class Program
    {

        public static Color DefaultColor;

        public static async Task Main(string[] args)
        {
            DefaultColor = Color.Green;
            await RGBI.init();
        }

    }
}


