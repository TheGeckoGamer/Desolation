using Terraria.ModLoader;

namespace Desolation
{
	class Desolation : Mod
	{
		public Desolation()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
