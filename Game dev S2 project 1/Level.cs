using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_dev_S2_project_1
{
    public class Level
    //Q.2.4 
    {
        public Tile[,] array2D;
        // 2D array of type Tile
        private int Width;
        private int Height;
        private HeroTile heroTile = new HeroTile(null);
        private ExitTile exitTile;

        //It must declare an enum called TileType:
        //This enum will have single value named Empty for now
        public enum TileType
        {
            Empty,
            Wall,
            Hero,
            Exit,
        }

        //Q4.3 - Direction enum for moving the hero character
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left,
            None,
        }

        //The constructor  initialises the 2D Tile array, using the width and the 
        //height values as the array’s dimensions.
        public Level(int width, int height, HeroTile ht = null)
        {
            Width = width;
            Height = height;
            array2D = new Tile[Width, Height];

            InitialiseTiles();

            //Creates a new hero tile + object if one doesn't already exist
            //If it exists, it gets assigned a new position
            Position randomHero = GetRandomEmptyPosition();

            if (ht == null)
            {
              CreateTile(TileType.Hero, randomHero);
              heroTile = new HeroTile(randomHero);
            }
            else
            {
                ht.x = randomHero.XCod;
                ht.y = randomHero.YCod;
                heroTile = ht;
            }
            heroTile.UpdateVision(this);
            

            //Q5.1 - sets up a random tile to be the exit tile
            Position randomExit = GetRandomEmptyPosition();
            CreateTile(TileType.Exit, randomExit);
            ExitTile et = new ExitTile(randomExit);
            exitTile = et;    
        }

        private Tile CreateTile(TileType type, int x, int y)
        {
            Position pos = new Position(x, y);
            return CreateTile(type, pos);
        }

        //uses the tiletype and position to decide if it will be an empty tile, wall tile or hero tile
        private Tile CreateTile(TileType type, Position pos)
        {
            Tile tile = null;
            switch (type)
            {
                case TileType.Empty:
                    tile = new EmptyTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                case TileType.Wall:
                    tile = new WallTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                //Q4.2
                case TileType.Hero:
                    tile = new HeroTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                //Q5.1
                case TileType.Exit:
                    tile = new ExitTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                default:
                    break;
            }
            return tile;
        }

        //Creates the tiles
        private void InitialiseTiles()
        {
            for (int y = 0; y < Height; y++)    
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1)
                    {
                        CreateTile(TileType.Wall, x, y);
                    }
                    else
                    {
                        CreateTile(TileType.Empty, x, y);
                    }
                }
            }
        }
        //Displays 
        //The overridden ToString method will construct one long string to form the 
        //entire level’s visual representation.

        //It should loop through the 2D Tile array row by row, adding each Tile’s
        //character representation to the string by accessing its Display property.
        //Once the entire string is constructed, it should be returned from the
        //method
        public String ToString()
        {
            String result = "";

            for (int y = 0; y < Height; y++)   
            {
                for (int x = 0; x < Width; x++)
                {
                    Tile basic = array2D[(int)x, (int)y];
                    result += basic.display;
                }
                result += "\n";
            }
            return result;
        }

        //Q4.2
        //Finds a random empty tile, returns as Position object
        private Position GetRandomEmptyPosition()
        {
            Random rnd = new Random();
            int randomX = rnd.Next(0, Width);
            int randomY = rnd.Next(0, Height);
            bool found = false;

            while (found == false)
            {
                if (array2D[randomX, randomY].display == '.')
                {
                    found = true;
                }
                else
                {
                    randomX = rnd.Next(0, Width);
                    randomY = rnd.Next(0, Height);
                }
            }
            Position ps = new Position(randomX, randomY);
            return ps;
        }

        //Q4.3
        //Swaps 2 tiles
        public void SwopTiles(Tile swap1, Tile swap2)
        {
            try
            {
                // Swapping Tiles in array
                array2D[swap2.x, swap2.y] = swap1;
                array2D[swap1.x, swap1.y] = swap2;

                // Swopping x and y coordinates in the tiles themselves
                int tempX, tempY;

                tempY = swap1.y;
                swap1.y = swap2.y;
                swap2.y = tempY;

                tempX = swap1.x;
                swap1.x = swap2.x;
                swap2.x = tempX;

                
            }
            catch (NullReferenceException ex)
            {
            }
        }

        //Q4.2 - HeroTile read only property for exposure, make sure the return type is HeroFile to have access
        // to all methods
        public HeroTile getHeroTile()
        {
            return heroTile;
        }

        //Q5.1 - ExitTile read only property for exposure
        public ExitTile getExitTile()
        {
            return exitTile;
        }
    }
}
//reference
//https://stackoverflow.com/questions/622832/how-to-build-a-tiled-map-in-java-for-a-2d-game
//https://codereview.stackexchange.com/questions/10550/creating-a-2d-array-of-map-tiles
//https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
//https://www.infoworld.com/article/3546242/how-to-use-const-readonly-and-static-in-csharp.html#:~:text=Use%20the%20readonly%20keyword%20in,or%20in%20a%20constructor%20only.