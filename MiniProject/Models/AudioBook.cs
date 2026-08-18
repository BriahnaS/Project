using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    public class AudioBook : Book
    {
        public string NarratorName { get; set; }
        public bool SingleNarration { get; set; }
        public bool DuetNarration { get; set; }
        public bool DualNarration { get; set; }
        public bool GraphicAudio { get; set; }

    }
}
