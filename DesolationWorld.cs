using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Terraria.ID;

namespace Desolation
{
    public class DesolationWorld : ModWorld
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Glass Biome", delegate (GenerationProgress progress)
            {
                progress.Message = "Melting Sand";
                for (int i = 0; i < Main.maxTilesX / 700; i++)       //900 is how many biomes. the bigger is the number = less biomes
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 150);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100, Main.maxTilesY - 100);
                    int Xhigh = X + 800;
                    int Yhigh = Y;
                    int TileType = 54;    

                    WorldGen.TileRunner(X, Y, 125, WorldGen.genRand.Next(100, 200), TileType, false, 0f, 0f, true, true);  //125 is how big is the biome     100, 200 this changes how random it looks.

                    for (int A = X; A < Xhigh; A++)
                    {
                        for (int B = Y; B < Yhigh; B++)
                        {
                            if (Main.tile[A, B] != null)
                            {
                                if (Main.tile[A, B].type == 54) // A = x, B = y.
                                {
                                    WorldGen.KillWall(A, B);
                                }
                            }
                        }
                    }
                    WorldGen.digTunnel(X + 400, Y + 400, 0, 0, WorldGen.genRand.Next(15, 18), WorldGen.genRand.Next(14, 17), false);
                    for (int C = 0; C < 20; C++)
                    {
                        bool placeSuccessful = false;
                        Tile tile;
                        int tileToPlace = TileID.Containers;
                        while (!placeSuccessful)
                        {
                            int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                            int y = WorldGen.genRand.Next(0, Main.maxTilesY);
                            WorldGen.PlaceTile(X + WorldGen.genRand.Next(50, 150), Y + WorldGen.genRand.Next(50, 150), tileToPlace, false, false, -1, 47);
                            tile = Main.tile[x, y];
                            placeSuccessful = tile.active() && tile.type == tileToPlace;
                        }

                    }
                    tasks.Insert(genIndex + 1, new PassLegacy("Tar Biome", delegate (GenerationProgress progress)
                    {
                        progress.Message = "Fossilizing";
                        for (int i = 0; i < Main.maxTilesX / 700; i++)       //900 is how many biomes. the bigger is the number = less biomes
                        {
                            int X = WorldGen.genRand.Next(1, Main.maxTilesX - 150);
                            int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100, Main.maxTilesY - 100);
                            int Xhigh = X + 800;
                            int Yhigh = Y;
                            int TileType = 54;    

                            WorldGen.TileRunner(X, Y, 125, WorldGen.genRand.Next(100, 200), TileType, false, 0f, 0f, true, true);  //125 is how big is the biome     100, 200 this changes how random it looks.

                    for (int A = X; A < Xhigh; A++)
                    {
                        for (int B = Y; B < Yhigh; B++)
                        {
                            if (Main.tile[A, B] != null)
                            {
                                if (Main.tile[A, B].type == 54) // A = x, B = y.
                                {
                                    WorldGen.KillWall(A, B);
                                }
                            }
                        }
                    }
                }

            }));
        }
    }
}
