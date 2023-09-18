using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class GameEngine
    // Q.2.5
    //Q.2.6
    {
        //private level that stores the current level that is being played
        private Level currentlevel;
        private int NumLevels;
        private int currentLevelNumber = 1;
        //private random used for rolling random numbers
        private Random random;
        const int MIN_SIZE = 10;
        const int MAX_SIZE = 20;
        //Q5.2 - enum for tracking level state
        private GameState game = GameState.InProgress;

        // Debug text box
        TextBox debug;

        public GameEngine(int NumLevels)
        {
            Random rnd = new Random();
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            this.NumLevels = NumLevels;
            currentlevel = new Level(width, height);

            // For debug purposes
            //debug = textBox;
            //debug.Text = "Calling Game engine";

            //The constructor should also initialise the current-level field with a new 
            //Level object.The width and height of the level will be determined by rolling
            //a random number between MIN_SIZE and MAX_SIZE for both the width
            //and the height of the level
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
            //Game over will be handled at a later state in the POE
            else if (game == GameState.GameOver) {
                result = "";
            }
            return result;
        }

        //Q4.3 - MoveHero method which signifies the desired move
        private bool MoveHero(Level.Direction move)
        {
            
            bool success = false;
            int targetTile = (int)move;
            //debug.Text = "Move value: " + targetTile;

            HeroTile hero = currentlevel.getHeroTile();

            //debug.Text = "Target value: " + hero.visionArray[targetTile].display;
            //Q5.2 - checks if tile is an exit tile
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
                //debug.Text = "Hero Vision Tile: " + hero.visionArray[targetTile].x + " " + hero.visionArray[targetTile].y 
                    //+ "   Hero position: " + currentlevel.getHeroTile().x + " " + currentlevel.getHeroTile().y;
                currentlevel.SwopTiles(hero.visionArray[targetTile], currentlevel.getHeroTile());
                //debug.Text = "Hero Vision Tile: " + hero.visionArray[targetTile].x + " " + hero.visionArray[targetTile].y
                //    + "   Hero position: " + currentlevel.getHeroTile().x + " " + currentlevel.getHeroTile().y;
                hero.UpdateVision(currentlevel);
            }
            return success;
        }

        //For now just calls MoveHero(), will be expanded on in part 2 of POE
        public void TriggerMovement(Level.Direction move)
        {
            //debug.Text = "Moving";
            MoveHero(move);
        }

        //Q5.2
        //Global enum for tracking progress regarding levels
        public enum GameState { 
        InProgress,
        Complete,
        GameOver,
        }

        //loads next level while maintaining hero's attributes across levels
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
