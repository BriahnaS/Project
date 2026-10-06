using BookRecommendationApp.Model.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using BookRecommendationApp.View;

namespace BookRecommendationApp.ViewModel
{
    public class BookResultsViewModel 
    {
        public ICommand OpenBookDetailsCommand { get; }
        public ObservableCollection<BookDto> Books { get; private set; } = new();

        public BookResultsViewModel()
        {
            OpenBookDetailsCommand = new Command<BookDto>(OpenBookDetails);
        }
        public void SetBooks(List<BookDto> books)
        {
            Books.Clear();
            foreach (var book in books)
                Books.Add(book);
        }

        private async void OpenBookDetails(BookDto book)
        {
            var page = new BookDetailsPopup(book);
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

    }
}
