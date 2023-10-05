﻿using System;
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

        //Amount of moves made in the game
        private int numMoves = 0;

        public string heroStats;

        public GameEngine(int NumLevels)
        {
            //The width and height of the level will be determined by rolling
            //a random number between MIN_SIZE and MAX_SIZE for both the width
            //and the height of the level

            Random rnd = new Random();
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            this.NumLevels = NumLevels;
            currentlevel = new Level(width, height, currentLevelNumber);

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
                result = "GAME OVER";
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
                currentlevel.UpdateVision(currentlevel, currentlevel.getHeroTile(), currentlevel.GetEnemyTiles());
            }
            return success;
        }

        //Calls MoveHero()
        public void TriggerMovement(Level.Direction move)
        {
            numMoves++;
            if (numMoves % 2 == 0)
            {
                MoveHero(move);
                MoveEnemies();
            }
            else {
                MoveHero(move);
            }   
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

            currentlevel = new Level(width, height, currentLevelNumber, tempHero);
        }

        //Part 2 - Q2.4
        private void MoveEnemies() {

            EnemyTile[] enemyArray = currentlevel.GetEnemyTiles();
            Tile target;

            for (int i = 0; i < enemyArray.Length; i++)
            {
                if (enemyArray[i].IsDead())
                {}
                else
                {
                    if (enemyArray[i].GetMove(out target)) {
                        if (target != null)
                        {
                            currentlevel.SwopTiles(enemyArray[i], target);
                        }  
                    }
                }    
            }
            currentlevel.UpdateVision(currentlevel, currentlevel.getHeroTile() ,enemyArray);
        }

        //Part 2 - Q3.1
        //Checks if the hero can attack a nearby character tile if one is available in the vision array
        private bool HeroAttack(Level.Direction direct) {
            //Part 2 Q3.3
            if (game != GameState.GameOver)
            {
                bool success = false;
                HeroTile ht = currentlevel.getHeroTile();
                CharacterTile ct;
                Tile targetTile;

                try
                {
                    targetTile = ht.visionArray[(int)direct];

                    if (targetTile.display == 'Ϫ')
                    {
                        success = true;
                        ct = targetTile as CharacterTile;
                        ht.Attack(ct);
                    }
                    else
                    {
                        success = false;
                    }

                }
                catch (NullReferenceException ex)
                {
                    success = false;
                }


                return success;
            }
            return false;
        }

        //LABEL PARAMETER USED FOR DEBUGGING - REMOVE AFTER USE
        public void TriggerAttack(Level.Direction direct)
        {
            if (game != GameState.GameOver) {

                //Will be updated later in POE
                HeroAttack(direct);
                EnemiesAttack();
                heroStats = getHeroStats();

                if (currentlevel.getHeroTile().IsDead())
                {
                    game = GameState.GameOver;
                }
            }
        }

        //Loops through all living enemies and attacks any character tiles in their vision arrays 
        //LABEL PARAMETER USED FOR DEBUGGING - REMOVE AFTER USE
        private void EnemiesAttack() {

            EnemyTile[] et = currentlevel.GetEnemyTiles();
            
            for (int i = 0; i < et.Length; i++) {
                if (et[i].display != 'x')
                {
                    CharacterTile[] targets = et[i].GetTargets();


                    for (int j = 0; j < targets.Length; j++)
                    {
                        if (targets[j] != null)
                        {
                            et[i].Attack(targets[j]);
                        }
                    }
                }
            }
        }

        public string getHeroStats() {
            string temp = "HP: " + currentlevel.getHeroTile().HP() + "/40"; 
            return temp;
        }


    }
}
