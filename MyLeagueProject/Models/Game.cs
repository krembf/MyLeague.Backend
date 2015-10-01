using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Home
    {
        public int team { get; set; }
        public int score { get; set; }
    }

    public class Away
    {
        public int team { get; set; }
        public int score { get; set; }
    }

    public class Teams
    {
        public Home home { get; set; }
        public Away away { get; set; }
    }

    public class Judges
    {
        public int main { get; set; }
        public int side1 { get; set; }
        public int side2 { get; set; }
    }

    public class Fact
    {
        public string time { get; set; }
        public int team { get; set; }
        public int player { get; set; }
        public string type { get; set; }
        public string own { get; set; }
        public string color { get; set; }
    }

    public class Game
    {
        public int id { get; set; }
        public string date { get; set; }
        public Teams teams { get; set; }
        public Judges judges { get; set; }
        public int pitch { get; set; }
        public List<Fact> facts { get; set; }
    }
}