using System;
using System.Collections.Generic;
using System.Text;

namespace BookRecommendationApp.Model.Classes
{
    public class Audiobook : Book
    {
        public string NarratorName { get; set; } // Needs to accept multiple somehow -- look into relational database
        public bool SingleNarration { get; set; }
        public bool DuetNarration { get; set; }
        public bool DualNarration { get; set; }
        public bool GraphicAudio { get; set; }
    }
}
