﻿using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Dtos.Resources.BookResources
{
    public class AddBookDto
    {
        public string BookName { get; set; }
        public List<AuthorIds> Authors { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int NumberOfPages { get; set; }
        public string Location { get; set; }
    }
}
