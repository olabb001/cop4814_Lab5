using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace GamesForm
{

    public partial class GamesForm : Form
    {
        XmlSerializer serial;
        StreamWriter sw;
        List<Game> gameList;
        GameFactory gameFactory;


        public GamesForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameList = new List<Game>();
            gameFactory = new GameFactory();
        }


        private void btnCreate_Click_1(object sender, EventArgs e)
        {

            gameFactory.CreateGameList();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            gameFactory.SerializeGameList();

        }
    }

    public class Game
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public Game() { }

        public Game(string Team1, string Team2, int Team1Score, int Team2Score)
        {
            this.Team1 = Team1;
            this.Team2 = Team2;
            this.Team1Score = Team1Score;
            this.Team2Score = Team2Score;

        }

        public override string ToString()
        {
            return Team1 + " (" + Team1Score + ") - " +
            Team2 + " (" + Team2Score + ") ";
        }

    } //Class Game

    public class GameFactory
    {
        List<Game> gameList;
        XmlSerializer serial;

        string GAMES_FILE = @"../../game.xml";
        StreamWriter sw;


        public void CreateGameList()
        {
            gameList = new List<Game>();
            Game G;
            G = new Game("Hornets", "Bulldogs", 50, 75);
            gameList.Add(G);
            G = new Game("Badgers", "WildCats", 50, 75);
            gameList.Add(G);            
            G = new Game("Iguanas", "Pitbulls", 50, 75);
            gameList.Add(G);
            G = new Game("Bees", "Monkeys", 50, 75);
            gameList.Add(G);
            G = new Game("Ants", "Geckos", 50, 75);
            gameList.Add(G);

            
        }

        public void SerializeGameList()
        {
            serial = new XmlSerializer(gameList.GetType());
            sw = new StreamWriter(GAMES_FILE);
            serial.Serialize(sw, gameList);
            sw.Close();
        }

    }
}
