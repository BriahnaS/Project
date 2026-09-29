using BookRecommendationApp.Model.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRecommendationApp.Helpers
{
    public class FakeBookGenerator
    {
        private static readonly Random _random = new();

        private static readonly string[] FakeTitles =
        {
            "The Lost Pages",
            "Whispers in the Dark",
            "Shadows of Tomorrow",
            "The Forgotten Path",
            "Echoes of the Past",
            "The Hidden Library",
            "Journey to Nowhere",
            "The Last Chapter"
        };

        private static readonly string[] FakeAuthors =
        {
            "A. Writer",
            "M. Storyteller",
            "J. Page",
            "K. Novelson",
            "L. Inkwood"
        };
        public static BookDto GetFakeBook()
        {
            int authorCount = _random.Next(1, 4);

            var authors = new List<string>();

            for (int i = 0; i < authorCount; i++)
            {
                authors.Add(FakeAuthors[_random.Next(FakeAuthors.Length)]);
            }

            return new BookDto
            {
                Title = FakeTitles[_random.Next(FakeTitles.Length)],
                Authors = authors
            };
        }
    }
}
