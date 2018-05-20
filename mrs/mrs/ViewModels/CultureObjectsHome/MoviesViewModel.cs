namespace mrs.ViewModels.CultureObjectsHome
{
    using System.Collections.Generic;
    
    public class MoviesViewModel
    {
        public long CultureObjectId { get; set; }
        public List<MovieItemViewModel> Items { get; set; } = new List<MovieItemViewModel>();
    }
}
