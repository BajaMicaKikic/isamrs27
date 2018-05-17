namespace mrs.Infrastructure.Data
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    using System.Threading.Tasks;
    using System.Linq;

    public class MrsContextDbContextSeed
    {
        public static async Task SeedAsync(IProjectionRepository projectionRepository,
                                           IGenreRepository genreRepository,
                                           IActorRepository actorRepository,
                                           ICultureObjectRepository cultureObjectRepository,
                                           IHallSegmentRepository hallSegmentRepository,
                                           ICultureObjectHallRepository cultureObjectHallRepository,
                                           IScreeningRepository screeningRepository,
                                           ISeatRepository seatRepository,
                                           ISeatReservationRepository seatReservationRepository
                                           )
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

           
            var hall1 = new CultureObjectHall { HallName = "Mira Stupica", SeatsNo = 1000, CultureObject = cultureObject1 };
            var hall2 = new CultureObjectHall { HallName = "Main Hall", SeatsNo = 1300, CultureObject = cultureObject1 };
            var hall3 = new CultureObjectHall { HallName = "Private Hall", SeatsNo = 150, CultureObject = cultureObject1 };

            var hallSegment1 = new HallSegment { HallSegmentName = "Balkon", SeatsNo = 100, CultureObjecsHall = hall1   };
            var hallSegment2 = new HallSegment { HallSegmentName = "Parter", SeatsNo = 500, CultureObjecsHall = hall1 };
            var hallSegment3 = new HallSegment { HallSegmentName = "VIP", SeatsNo = 40, CultureObjecsHall = hall1 };

            var screening1 = new Screening { ScreenStartDateTime = new System.DateTime(2018, 5, 13, 20, 0, 0), CultureObjecsHall = hall2, Projection = projection };

            var seat1 = new Seat { Row = 1, SeatNumber = "1", HallSegment = hallSegment2 };
            var seat2 = new Seat { Row = 2, SeatNumber = "2", HallSegment = hallSegment2 };
            var seat3 = new Seat { Row = 3, SeatNumber = "3", HallSegment = hallSegment2 };
            var seat4 = new Seat { Row = 4, SeatNumber = "4", HallSegment = hallSegment2 };
            var seat5 = new Seat { Row = 5, SeatNumber = "5", HallSegment = hallSegment2 };

            var seatReservation1 = new SeatReservation { Screening = screening1, Seat = seat1 };
            var seatReservation2 = new SeatReservation { Screening = screening1, Seat = seat2 };
            var seatReservation3 = new SeatReservation { Screening = screening1, Seat = seat3 };

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

            
            await cultureObjectHallRepository.AddAsync(hall1);
            await cultureObjectHallRepository.AddAsync(hall2);
            await cultureObjectHallRepository.AddAsync(hall3);

            await hallSegmentRepository.AddAsync(hallSegment1);
            await hallSegmentRepository.AddAsync(hallSegment2);
            await hallSegmentRepository.AddAsync(hallSegment3);

            await screeningRepository.AddAsync(screening1);

            await seatRepository.AddAsync(seat1);
            await seatRepository.AddAsync(seat2);
            await seatRepository.AddAsync(seat3);
            await seatRepository.AddAsync(seat4);
            await seatRepository.AddAsync(seat5);

            await seatReservationRepository.AddAsync(seatReservation1);
            await seatReservationRepository.AddAsync(seatReservation2);
            await seatReservationRepository.AddAsync(seatReservation3);


        }
    }
}