namespace STG
{
    public class GameplayManager
    {
        private RNG rng = new RNG();
        private InputStringParser parser = new InputStringParser();

        /// <summary>
        /// The in memory protobuf gameboard. Mutable.
        /// Faster to return it than make a deep copy,
        /// at the cost of exposing internal game state
        /// to potential corruption.
        /// </summary>
        public Gameboard gameboard { get; private set; }

        private GameplayManager(Gameboard gameboard)
        {
            this.gameboard = gameboard;
        }

        /// <summary>
        /// Static factory method for initializing.
        /// </summary>
        /// <param name="gameboard">
        /// The gameboard protobuf to initialize with.
        /// Should already be set up and ready to play.
        /// </param>
        /// <returns>
        /// The GameplayManager ready to play.
        /// </returns>
        public static GameplayManager Init(Gameboard gameboard)
        {
            return new GameplayManager(gameboard);
        }

        /// <summary>
        /// Static factory method for initializing with a specified random seed.
        /// </summary>
        /// <param name="gameboard">
        /// The gameboard protobuf to initialize with.
        /// Should already be set up and ready to play. 
        /// </param>
        /// <param name="seed">
        /// Nonnegative integer to seed the RNG with.
        /// </param>
        /// <returns></returns>
        public static GameplayManager Init(Gameboard gameboard, int seed)
        {
            GameplayManager manager = GameplayManager.Init(gameboard);
            manager.SeedRNG(seed);
            return manager;
        }

        /// <summary>
        /// Perform a single input.
        /// </summary>
        /// <param name="input">
        /// An Input protobuf.
        /// </param>
        public void DoInput(Input input)
        {

        }

        /// <summary>
        /// Perform a series of inputs specified as a string.
        /// </summary>
        /// <param name="inputs">
        /// An input string in a parseable format.
        /// Directions are "NESW" or "UDLR".
        /// Actions are "XYZ".
        /// Durations are integers representing number of ticks.
        /// Combinations are enclosed in curly brackets {}.
        /// No action is "-"
        /// Example string: "U-L2D3-R4-{ULX2}{UL3}"
        /// </param>
        public void DoInputs(string inputStr)
        {
            foreach (Input input in parser.Parse(inputStr))
            {
                this.DoInput(input);
            }
        }

        private void SeedRNG(int seed)
        {
            this.rng = new RNG(seed);
        }
    }
}
