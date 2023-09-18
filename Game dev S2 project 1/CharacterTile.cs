using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    //Q4.1 
    public abstract class CharacterTile : Tile
    {
        //Variables
        Position charPos;
        private int hitPoints, maxHitPoints, attPower;
        public Tile[] visionArray;   //BEING STATIC MIGHT CAUSE ISSUES

        //Constructor
        public CharacterTile(Position pos, int hitPnts, int attPwr) : base(pos)
        {
            charPos = pos;
            hitPoints = hitPnts;
            attPower = attPwr;
            maxHitPoints = hitPnts;

            visionArray = new Tile[4];

            // Initializing vision field
        }

        //Vision - updates the vision tiles according to the character's position
        public void UpdateVision(Level lvl)
        {
            try
            {
                Tile[,]  array = lvl.array2D;

                Tile tileUp = array[charPos.XCod, charPos.YCod  - 1];
                Tile tileDown = array[charPos.XCod, charPos.YCod + 1];
                Tile tileLeft = array[charPos.XCod - 1, charPos.YCod];
                Tile tileRight = array[charPos.XCod + 1, charPos.YCod];

                        //Moving Up
                        visionArray[0] = tileUp;
                        visionArray[1] = tileRight;
                        visionArray[2] = tileDown;
                        visionArray[3] = tileLeft;
                
                //vArray[1].XCod = charPos.XCod + 1;
                //vArray[1].YCod = charPos.YCod;
                //visionArray[1].setTilePosition(vArray[1]);

                //vArray[2].XCod = charPos.XCod;
                //vArray[2].YCod = charPos.YCod - 1;
                //visionArray[2].setTilePosition(vArray[2]);

                //vArray[3].XCod = charPos.XCod - 1;
                //vArray[3].YCod = charPos.YCod;
                //visionArray[3].setTilePosition(vArray[3]);
            }
            catch (NullReferenceException ex)
            {
            }
        }

        //Subtracts damage taken from character's hitpoints
        public void TakeDamage(int dmg)
        {
            hitPoints = hitPoints - dmg;
            if (hitPoints < 0)
            {
                hitPoints = 0;
            }
        }

        //Deals damage to targeted character object based off characters attack power
        public void Attack(CharacterTile attChar)
        {
            attChar.TakeDamage(attPower);
        }

        //Checks if character has any remaining hit points
        public bool IsDead()
        {
            return hitPoints <= 0;
        }
    }
    //References:
    //https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling
}


