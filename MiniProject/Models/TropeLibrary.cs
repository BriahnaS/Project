using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace MiniProject.Models
{
    public static class TropeLibrary
    {
        public static readonly Dictionary<Book.Genre, List<string>> TropesByGenre = new Dictionary<Book.Genre, List<string>>
        {
            { Book.Genre.Action, new List<string>
                {
                    "Lone Hero / One-Man Army",
                    "Reluctant Hero",
                    "High Stakes",
                    "Relentless Antagonist",
                    "Race Against Time",
                    "Mentor-Student Dynamic",
                    "Mysterious Past",
                    "Showdown",
                    "Daring Escape / Chase Sequence",
                    "Underdog Victory"
                }
            },

            {Book.Genre.Fantasy, new List<string>
                {
                    "Chosen One",
                    "Reluctant / Outcast Hero",
                    "Wise Old Mentor",
                    "Lost Heir / Secret Royalty",
                    "Magical Creature Sidekick",
                    "Antihero",
                    "The Quest",
                    "Prophecy",
                    "Coming-of-Age",
                    "Good vs. Evil",
                    "Rags to Riches",
                    "Fated Love",
                    "Magical World",
                    "Fobidden Forest",
                    "Magic School",
                    "Royal Court / Kingdom",
                    "Secret Lair",
                    "Magical Objects"
                }
            },

            {Book.Genre.HistoricalFiction, new List<string>
                {
                    "Historical Figures",
                    "Marriage of Convenience",
                    "Progressive Characters",
                    "Hero from Nothing",
                    "Evil Antagonist",
                    "Dual Narratives",
                    "Cultural & Social Conflict",
                    "Times are Changing",
                    "Minor Characters with Big Impacts",
                    "Western Expansion",

                }
            },

            {Book.Genre.Horror, new List<string>
                {
                    "Haunted House",
                    "Isolated Setting",
                    "Abandoned Places",
                    "Small Town with Secrets",
                    "Final Person",
                    "Evil Child / Creepy Kid",
                    "Innocent / Vulnerable Protagonist",
                    "Psychotic / Serial Killer",
                    "Ancient Evil",
                    "Demonic Possession",
                    "Cursed Artifact / Object",
                    "Found / Old Footage",
                    "Splitting Up",
                    "Jump Scare",
                    "Mysterious Deaths",
                    "Monsters in the Dark",
                    "Evil Clown",
                    "Zombie Apocalypse",
                    "Nightmare That Might Be Real",
                    "Monster as Metaphor",
                    "Inclement Nighttime Weather"
                }
            },

            {Book.Genre.LiteraryFiction, new List<string>
                {
                    "Chosen One",
                    "Found Family",
                    "Enemies-to-Lovers",
                    "Unreliable Narrator",
                    "Redemption Arc",
                    "Quest / Journey",
                    "Slow Burn",
                    "Fake Dating",
                }
            },

            {Book.Genre.Mystery, new List<string>
                {
                    "Unassuming Suspect",
                    "Incompetent Police",
                    "Red Herrings",
                    "Locked Room",
                    "Femme Fatale",
                    "Amateur Sleuth",
                    "Misjudged Death",
                    "Eccentric Detective",
                    "Twist Ending",
                    "Clue That Was There All Along"
                }
            },

            {Book.Genre.NewAdult, new List<string>
                {
                    "Deep, Dark, Trouble Past",
                    "Reluctant or Dangerous Love Interest",
                    "Enemies-to-Lovers",
                    "Forbidden Love / Star-Crossed Lovers",
                    "Found Family",
                    "First Love",
                    "Secret Identity / Hidden Past",
                    "Second Chance",
                    "Love Triangle",
                    "Coming-of-Age"
                }
            },

            {Book.Genre.NonFiction, new List<string>
                {
                    "Underdog Story",
                    "Eureka Moment",
                    "Lessons Learned",
                    "Expert Guide",
                    "Before and After",
                }
            },

            {Book.Genre.Romance, new List<string>
                {
                   "Enemies-to-Lovers",
                   "Friends-to-Lovers",
                   "Forced Proximity",
                   "Fake Dating",
                   "Marriage of Convenience",
                   "Meet-Cute",
                   "Small-Town",
                   "Grumpy-Sunshine",
                   "Second Chance",
                   "Roylaty / Billionaire",
                   "Slow Burn",
                   "Mafia",
                   "Dark"
                }
            },

            {Book.Genre.SciFi, new List<string>
                {
                    "Space & Space Travel",
                    "Alien First Contact",
                    "Alien Invasion",
                    "Hive Mind",
                    "Universal Translator",
                    "AI Takeover",
                    "Bad Robots",
                    "Cyborgs / Andriods",
                    "Technobabble",
                    "Alternate Universes",
                    "Everything is a Simulation",
                    "Alternate History",
                    "Mad Scientist",
                    "Super Soldier",
                    "Space Pirate",
                    "Clone / Genetically Engineered Human",
                }
            },

            {Book.Genre.Thriller, new List<string>
                {
                    "Isolated Locale",
                    "Mysterious Stranger",
                    "Missing Person",
                    "Stalker / Unhinged Ex",
                    "Secret Societies / Cults",
                    "Strange or Threatening Messages",
                    "Supposedly Dead Person Returns",
                    "The Intelligent Psychopath",
                    "The Irascible Detective and Sidekick",
                    "Broken Vehicle / Transportation Failure",
                    "Affairs, Suicides, & Unsolvable Mysteries"
                }
            },

            {Book.Genre.YoungAdult, new List<string>
                {
                    "Found Family",
                    "Love Triangles",
                    "Enemies-to-Lovers",
                    "Hidden Powers",
                    "Fake Dating",
                    "Forbidden Love",
                    "The Outcast Protagonist",
                    "Rebellion Against Authority",
                    "Underdog",
                    "Identity Formation Struggles",
                }
            }
        };
    }
}
