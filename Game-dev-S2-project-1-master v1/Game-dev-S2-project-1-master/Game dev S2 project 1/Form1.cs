using System.Drawing.Text;

namespace Game_dev_S2_project_1
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;
        public Level.Direction keyPress = Level.Direction.None;
        public const int NUMBER_OF_LEVELS = 10;

        // private GameEngine field
        //Initialises the GameEngine field in the Form’s constructor and set the 
        //number-of-levels parameter
        public Form1()
        {
            InitializeComponent();
            gameEngine = new GameEngine(NUMBER_OF_LEVELS);
            UpdateDisplay();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


        // Assigns GameEngine field’s ToString result to your display label’s text property
        public void UpdateDisplay()
        {
            IbIDisplay.Text = gameEngine.ToString();
        }

        //The label
        private void IbIDisplay_Click(object sender, EventArgs e)
        {
        }


        private void Up_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Up;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }

        private void Down_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Down;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }

        private void Right_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Right;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }

        private void Left_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Left;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }

    }
}
