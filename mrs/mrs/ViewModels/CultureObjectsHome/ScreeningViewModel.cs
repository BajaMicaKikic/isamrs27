namespace mrs.ViewModels.CultureObjectsHome
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ScreeningViewModel
    {
        [Display(Name ="Title")]
        public string ScreeningProjectionTitle { get; set; }
        [Display(Name = "Hall")]
        public string ScreeningProjectionHall { get; set; }
        [Display(Name = "Date and Time of Screening")]
        public DateTime ScreeningDateTime { get; set; }
        [Display(Name = "Freee Spaces")]
        public int FreeSpacesNumber { get; set; }
    }
}
