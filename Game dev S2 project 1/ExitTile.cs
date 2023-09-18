using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class ExitTile : Tile
    {
        //Q5.1
        //Displays the exit 
        public override char display
        {
            get
            {
                return char.Parse("▒");
            }
        }

        //Constructor
        public ExitTile(Position position) : base(position)
        {
        }



    }
}
