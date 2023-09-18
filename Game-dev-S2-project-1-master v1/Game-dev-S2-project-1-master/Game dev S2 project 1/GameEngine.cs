using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class GameEngine
    {
        //NumLevels stores the number of levels in the game
        private Level currentlevel;
        private int NumLevels;
        private int currentLevelNumber = 1;
        //private random used for rolling random numbers

        private Random random;
        const int MIN_SIZE = 10;
        const int MAX_SIZE = 20;

        //Enum for tracking level state
        private GameState game = GameState.InProgress;

        public GameEngine(int NumLevels)
        {
            //The width and height of the level will be determined by rolling
            //a random number between MIN_SIZE and MAX_SIZE for both the width
            //and the height of the level

            Random rnd = new Random();
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            this.NumLevels = NumLevels;
            currentlevel = new Level(width, height);

        }
        //This method will return the ToString value of the current-level , or an end screen if the game is completed
        public String ToString()
        {
            String result = "";
            if (game == GameState.Complete)
            {
                result = "CONGRATULATIONS, YOU'VE FINISHED THE GAME!";
            }
            else if (game == GameState.InProgress) {
                result = currentlevel.ToString();
            } 
            else if (game == GameState.GameOver) {
                result = "";
            }
            return result;
        }

        //MoveHero method which signifies the desired move
        private bool MoveHero(Level.Direction move)
        {
            
            bool success = false;
            int targetTile = (int)move;

            HeroTile hero = currentlevel.getHeroTile();

            //Checks if tile is an exit tile
            if (hero.visionArray[targetTile].display == '▒') {
                success = true;

                if (currentLevelNumber >= NumLevels)
                {
                    game = GameState.Complete;
                    success = false;
                }
                else {
                    NextLevel();
                    success = true;
                }
            }

            //checks if tile is an empty tile
            if (hero.visionArray[targetTile].display == '.')
            {
                success = true;
                currentlevel.SwopTiles(hero.visionArray[targetTile], currentlevel.getHeroTile());
                hero.UpdateVision(currentlevel);
            }
            return success;
        }

        //Calls MoveHero()
        public void TriggerMovement(Level.Direction move)
        {
            //debug.Text = "Moving";
            MoveHero(move);
        }

        
        //Global enum for tracking progress regarding levels
        public enum GameState { 
        InProgress,
        Complete,
        GameOver,
        }

        //Loads next level while maintaining hero's attributes across levels
        public void NextLevel() {
            currentLevelNumber++;
            HeroTile tempHero = currentlevel.getHeroTile();

            Random rnd = new Random();
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1);

            currentlevel = new Level(width, height, tempHero);
        }
    }
}
