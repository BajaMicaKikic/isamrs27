namespace mrs.Infrastructure.Data
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    using System.Threading.Tasks;

    public class MrsContextDbContextSeed
    {
        public static async Task SeedAsync(IProjectionRepository projectionRepository,
                                           IGenreRepository genreRepository,
                                           IActorRepository actorRepository,
                                           ICultureObjectRepository cultureObjectRepository)
        {
            var genre1 = new Genre { GenreName = "Thriler" };
            var genre2 = new Genre { GenreName = "Horror" };
            var genre3 = new Genre { GenreName = "Drama" };
            var genre4 = new Genre { GenreName = "Tragedy" };
            var genre5 = new Genre { GenreName = "Commedy" };
            var genre6 = new Genre { GenreName = "Action" };

            var cultureObject1 = new CultureObject {Address ="Belgrade, Serbia",Name="Jugoslvensko Dramsko Pozoriste", ObjectDiscriminator = Object.Theater, PromoDescription = "Teatar koji zauvek zivi."  };
            var cultureObject2 = new CultureObject { Address = "Belgrade, Serbia", Name = "Beogradsko Dramsko Pozoriste", ObjectDiscriminator = Object.Theater, PromoDescription = "Teatar koji zauvek zivi." };
            var cultureObject3 = new CultureObject { Address = "Belgrade, Serbia", Name = "Narodno Pozoriste", ObjectDiscriminator = Object.Theater, PromoDescription = "Teatar koji zauvek zivi." };
            var cultureObject4 = new CultureObject { Address = "Belgrade, Serbia", Name = "Pozoriste na Terazijama", ObjectDiscriminator = Object.Theater, PromoDescription = "Teatar koji zauvek zivi." };

            var cultureObject5 = new CultureObject { Address = "Belgrade, Serbia", Name = "Cineplex", ObjectDiscriminator = Object.Cinema, PromoDescription = "Bioskop 3D" };
            var cultureObject6 = new CultureObject { Address = "Belgrade, Serbia", Name = "zvezda", ObjectDiscriminator = Object.Cinema, PromoDescription = "Bioskop 3D" };
            var cultureObject7 = new CultureObject { Address = "Belgrade, Serbia", Name = "Roda", ObjectDiscriminator = Object.Cinema, PromoDescription = "Bioskop 3D" };
            var cultureObject8 = new CultureObject { Address = "Belgrade, Serbia", Name = "Usce", ObjectDiscriminator = Object.Cinema, PromoDescription = "Bioskop 3D" };

            var actor1 = new Actor { FirstName = "Leo", LastName = "DiCaprio" };
            var actor2 = new Actor { FirstName = "Katrin Zita", LastName = "Jones" };

            var projection = new Projection { ProjectionName = "Titanik", Actor = actor1, Duration = decimal.Parse("123.34"), Genre = genre3, ProducerName = "James Cameron", ProjectionType = ProjectionType.Movie, ShortDescirption = "Description" };

            await genreRepository.AddAsync(genre1);
            await genreRepository.AddAsync(genre2);
            await genreRepository.AddAsync(genre3);
            await genreRepository.AddAsync(genre4);
            await genreRepository.AddAsync(genre5);
            await genreRepository.AddAsync(genre6);

            await actorRepository.AddAsync(actor1);
            await actorRepository.AddAsync(actor2);

            await projectionRepository.AddAsync(projection);

            await cultureObjectRepository.AddAsync(cultureObject1);
            await cultureObjectRepository.AddAsync(cultureObject2);
            await cultureObjectRepository.AddAsync(cultureObject3);
            await cultureObjectRepository.AddAsync(cultureObject4);
            await cultureObjectRepository.AddAsync(cultureObject5);
            await cultureObjectRepository.AddAsync(cultureObject6);
            await cultureObjectRepository.AddAsync(cultureObject7);
            await cultureObjectRepository.AddAsync(cultureObject8);


        }
    }
}