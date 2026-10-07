using System;
using System.Collections.Generic;
using System.Text;

namespace BookRecommendationApp.Model
{
    public class UserSelectionState
    {
        public List<int> SelectedGenreIds { get; } = new();
        public List<int> SelectedTropeIds { get; } = new();
        public List<int> SelectedSubplotIds { get; } = new();

        public void ClearSelections()
        {
            SelectedGenreIds.Clear();
            SelectedTropeIds.Clear();
            SelectedSubplotIds.Clear();
        }
    }
}
