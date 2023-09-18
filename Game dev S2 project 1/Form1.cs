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
        //number-of-levels parameter to 10
        public Form1()
        {
            InitializeComponent();
            gameEngine = new GameEngine(NUMBER_OF_LEVELS);
            UpdateDisplay();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        //This method should assign the 
        //GameEngine field’s ToString result to your display label’s text property
        public void UpdateDisplay()
        {
            IbIDisplay.Text = gameEngine.ToString();
        }
        //The label
        private void IbIDisplay_Click(object sender, EventArgs e)
        {
        }

        //Q4.3 - Returns keypress for moving the hero
        //private void Form1_CharacterMoveKey(object sender, KeyEventArgs e)
        //{
        //switch (e.KeyCode)
        //{
        //case Keys.W:
        //keyPress = Level.Direction.Up;
        //textBox1.Text = keyPress.ToString();
        //break;
        //case Keys.A:
        //  keyPress = Level.Direction.Left;
        //break;
        //case Keys.S:
        //  keyPress = Level.Direction.Down;
        //break;
        //case Keys.D:
        //  keyPress = Level.Direction.Right;
        //break;
        //default:
        //  keyPress = Level.Direction.None;
        //break;
        //}

        //gameEngine.TriggerMovement(keyPress);
        //UpdateDisplay();
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Up_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Moving up";
            keyPress = Level.Direction.Up;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Moving down";
            keyPress = Level.Direction.Down;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Moving right";
            keyPress = Level.Direction.Right;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Moving left";
            keyPress = Level.Direction.Left;
            gameEngine.TriggerMovement(keyPress);
            UpdateDisplay();
        }
        //private UpdateDisplay
        //GameEngine = gameengine;
    }
}
