namespace mrs.Services
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces;
    using mrs.Interfaces;
    using mrs.ViewModels.CultureObjectsHome;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CultureObjectViewModelService : ICultureObjectViewModelService
    {
        private readonly IAsyncRepository<CultureObject> _cultureObjectRepository;

        public CultureObjectViewModelService(IAsyncRepository<CultureObject> cultureObjectRepository)
        {
            _cultureObjectRepository = cultureObjectRepository;
        }

        public async Task<CinemasViewModel> GetAllCinemasForUnregisteredUsers()
        {
            var objects = (await _cultureObjectRepository.ListAllAsync());
            var cinemas = objects.Where( i => i.ObjectDiscriminator == Object.Cinema).ToList();
            return await CreateViewModelFromCultureObjects(cinemas);
        }
        public async Task<CinemasViewModel> GetAllTheatersForUnregisteredUsers()
        {
            var cinemas = (await _cultureObjectRepository.ListAllAsync()).Where(i => i.ObjectDiscriminator == Object.Theater).ToList();
            return await CreateViewModelFromCultureObjects(cinemas);
        }
        
        private async Task<CinemasViewModel> CreateViewModelFromCultureObjects(List<CultureObject> cultureObjects)
        {
            var viewModel = new CinemasViewModel();

            viewModel.Items = cultureObjects.Select(i =>
            {
                var itemModel = new CinemaItemViewModel
                {
                    Name = i.Name,
                    Address = i.Address,
                    PromoDescription = i.PromoDescription,
                    Remark = decimal.Parse("0")//(decimal)i.Remarks.Average(r => r.Grade)
                };
                return itemModel;
            }).ToList();

            return viewModel;
        }
    }
}
