using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MiniProject.Models
{
    public static class SubplotLibrary
    {
        public static readonly Dictionary<Book.Genre, List<string>> SubplotsByGenre = new Dictionary<Book.Genre, List<string>>
        {
            { Book.Genre.Action, new List<string>
                {
                    "Romantic",
                    "Conflict",
                    "Personal Struggle",
                    "Side Character",
                    "Adventure",
                    "World Building"
                }
            },

            {Book.Genre.Fantasy, new List<string>
                {
                    "High Fantasy",
                    "Epic Fantasy",
                    "Urban Fantasy",
                    "Contemporary Fantasy",
                    "Dark Fantasy",
                    "Historical Fantasy",
                    "Paranormal Fantasy",
                    "Portal Fantasy",
                    "Romantasy",
                    "Action & Adventure",
                    "Apocalyptic / Post-Apocalyptic Fantasy",
                    "Sword & Sorcery"
                }
            },

            {Book.Genre.HistoricalFiction, new List<string>
                {
                    "Regency, Medieval, or Victorian Romance",
                    "Mystery",
                    "Fantasy",
                    "Alternate History",
                    "Biographical",
                    "Thriller",
                    "Adventure",
                    "Saga",
                    "War",
                    "Western",
                    "Ancient Civilization",
                    "Gothic",
                    "Crime",
                    "Nautical",
                    "Pioneer",
                }
            },

            {Book.Genre.Horror, new List<string>
                {
                    "Ghost / Supernatural",
                    "Psychological",
                    "Gothic",
                    "Slasher",
                    "Body",
                    "Cosmic",
                    "Folk",
                    "Dark Fantasy",
                    "Comedy",
                    "Eco/Apocalysptic"
                }
            },

            {Book.Genre.LiteraryFiction, new List<string>
                {
                    "Romantic / Relational",
                    "Conflict",
                    "Character Growth / Transformation",
                    "Habit, Trait, or Addiction",
                    "Fear or Vulnerability",
                    "Backstroy/Expository",
                    "Two Worlds Collide",
                    "Parallel / Mirror",
                } 
            },

            {Book.Genre.Mystery, new List<string>  
                {
                    "Romance / Relational Arcs",
                    "Personal Backstory / Family Secrets",
                    "Character Growth / Life Challenges",
                    "Humor / Quirky Side Stories",
                    "Parallel Investigation / Secondary Case",
                    "Romantic Suspense / Forbidden Love"
                } 
            },

            {Book.Genre.NewAdult, new List<string>
                {
                    "Romantic",
                    "Character Growth / Personal Struggles",
                    "Thematic",
                    "Friendship / Loyalty",
                    "Conflict",
                    "Mystery / Discovery",
                    "Parallel / Mirror"
                } 
            },

            {Book.Genre.NonFiction, new List<string>
                {
                    "Biographies, Autobigraphies, or Memoirs",
                    "History",
                    "Self Help & Instruction",
                    "Health & Wellness",
                    "True Crime & Journalism",
                    "Science & Nature Writing",
                    "Philosophy",
                    "Travel & Culture",
                    "How-to Manuals & Guides"
                } 
            },

            {Book.Genre.Romance, new List<string>
                {
                   "Reverse Harem",
                   "Love Triangle",
                   "Family Drama",
                   "Career / Personal Goals",
                   "Friendship / Rivalry",
                   "Mystery / Suspence",
                   "Cultural / Social Conflict",
                   "Comedic",
                   "Dramatic",
                   "Suspenseful",
                   "Academic"
                } 
            },

            {Book.Genre.SciFi, new List<string>
                {
                    "Crossworld / Portal",
                    "Special Destiny",
                    "Robots / Artificial Intelligence",
                    "Time Traveling",
                    "Aliens",
                    "Space",
                    "Action & Adventure",
                    "Apocalyptic / Post-Apocalyptic",
                    "Cozy",
                    "Cyberpunk",
                    "Dark Academia",
                    "Dystopian",
                    "Epic",
                    "Gothic",
                    "Hard",
                    "Horror",
                    "Humourous",
                    "Political Intrigue"
                } 
            },

            {Book.Genre.Thriller, new List<string>
                {
                    "Psychological", 
                    "Crime", 
                    "Mystery",
                    "Suspense",
                    "Action",
                    "Spy",
                    "Legal",
                    "Political",
                    "Medical",
                    "Techno"
                } 
            },

            {Book.Genre.YoungAdult, new List<string>
                {
                    "Chosen One",
                    "Coming-of-Age",
                    "Romance",
                    "Magical School / Secret Societies",
                    "Friendship",
                    "Self-Discovery",
                    "Dystopian Rebellion",
                    "Tournament & Competition"
                } 
            }
        };

        // Used for user input instead of menu selection
        public static string GetCanonical(Book.Genre genre, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            if (!SubplotsByGenre.TryGetValue(genre, out var subplots)) return value.Trim();

            // Exact trimmed, case-insensitive match
            var exact = subplots.FirstOrDefault(s => string.Equals(s?.Trim(), value.Trim(), StringComparison.OrdinalIgnoreCase));
            if (exact != null) return exact;

            // Fallback: normalize by removing punctuation and comparing
            static string Normalize(string s) => new string(s?.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray() ?? Array.Empty<char>()).ToLowerInvariant().Trim();
            var normValue = Normalize(value);
            var fuzzy = subplots.FirstOrDefault(s => Normalize(s) == normValue);
            return fuzzy ?? value.Trim();
        }
    }
}
