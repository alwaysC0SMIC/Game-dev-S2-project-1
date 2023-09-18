using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public abstract class Tile
    //Q.2.2 
    {
        //properties, a private field of type position
        private Position pos;
        //public int x;
        //public int y;

        public int x
        {
            get { return pos.XCod; }
            set { pos.XCod = value; }

        }

        public int y
        {
            get { return pos.YCod; }
            set { pos.YCod = value; }

        }



        // an abstract Property of type char named Display that only has 
        //the get accessor. 
        public abstract char display { get; }

        // a constructor that accepts a Position type as a parameter, and 
        //then assigns it to the class’s Position field.
        public Tile(Position pos)
        {
            this.pos = pos;
        }
    }
}
