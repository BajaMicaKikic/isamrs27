namespace mrs.Services
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces;
    using mrs.Interfaces;
    using mrs.ViewModels.CultureObjectsHome;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// Class that contains logic for Culture Object View Service.
    /// </summary>
    /// <seealso cref="mrs.Interfaces.ICultureObjectViewModelService" />
    public class CultureObjectViewModelService : ICultureObjectViewModelService
    {
        /// <summary>
        /// The culture object repository
        /// </summary>
        private readonly IAsyncRepository<CultureObject> _cultureObjectRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectViewModelService"/> class.
        /// </summary>
        /// <param name="cultureObjectRepository">The culture object repository.</param>
        public CultureObjectViewModelService(IAsyncRepository<CultureObject> cultureObjectRepository)
        {
            _cultureObjectRepository = cultureObjectRepository;
        }
        /// <summary>
        /// Gets all cinemas for unregistered users.
        /// </summary>
        /// <returns></returns>
        public async Task<CinemasViewModel> GetAllCinemasForUnregisteredUsers()
        {
            var objects = (await _cultureObjectRepository.ListAllAsync());
            var cinemas = objects.Where( i => i.ObjectDiscriminator == Object.Cinema).ToList();
            return CreateViewModelFromCultureObjects(cinemas);
        }
        /// <summary>
        /// Gets all theaters for unregistered users.
        /// </summary>
        /// <returns></returns>
        public async Task<CinemasViewModel> GetAllTheatersForUnregisteredUsers()
        {
            var cinemas = (await _cultureObjectRepository.ListAllAsync()).Where(i => i.ObjectDiscriminator == Object.Theater).ToList();
            return CreateViewModelFromCultureObjects(cinemas);
        }
        /// <summary>
        /// Creates the view model from culture objects.
        /// </summary>
        /// <param name="cultureObjects">The culture objects.</param>
        /// <returns></returns>
        private CinemasViewModel CreateViewModelFromCultureObjects(List<CultureObject> cultureObjects)
        {
            var viewModel = new CinemasViewModel
            {
                Items = cultureObjects.Select(i =>
                {
                    var itemModel = new CinemaItemViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Address = i.Address,
                        PromoDescription = i.PromoDescription,
                        Remark = decimal.Parse("0")//(decimal)i.Remarks.Average(r => r.Grade)
                    };
                    return itemModel;
                }).ToList()
            };

            return viewModel;
        }
    }
}
