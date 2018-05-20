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
                                           ISeatReservationRepository seatReservationRepository,
                                           IAccountRepository accountRepository,
                                           IUserRepository userRepository
                                           )
        {
            var genre1 = new Genre { GenreName = "Thriler" };
            var genre2 = new Genre { GenreName = "Horror" };
            var genre3 = new Genre { GenreName = "Drama" };
            var genre4 = new Genre { GenreName = "Tragedy" };
            var genre5 = new Genre { GenreName = "Commedy" };
            var genre6 = new Genre { GenreName = "Action" };

            var account1 = new Account { AccountType = "korisnik" };
            var account2 = new Account { AccountType = "adminFanZone" };
            var account3 = new Account { AccountType = "adminObjekta" };
            var account4 = new Account { AccountType = "adminSistema" };

            var user1 = new User { AccountId = 1, Password = "x", ConfirmPassword = "x", EmailAddress = "x", FirstName = "x", LastName = "x", Phone = "x", City = "x" };
            var user2 = new User { AccountId = 1, Password = "m", ConfirmPassword = "m", EmailAddress = "m", FirstName = "m", LastName = "m", Phone = "m", City = "m" };
            var user3 = new User { AccountId = 1, Password = "a", ConfirmPassword = "a", EmailAddress = "a", FirstName = "a", LastName = "a", Phone = "a", City = "a" };

            var cultureObject1 = new CultureObject { Address = "Belgrade, Serbia",Name="Jugoslvensko Dramsko Pozoriste", ObjectDiscriminator = Object.Theater, PromoDescription = "Teatar koji zauvek zivi."  };
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

            var hallSegment1 = new HallSegment { HallSegmentName = "Balkon", SeatsNo = 100, CultureObjecsHall = hall1 };
            var hallSegment2 = new HallSegment { HallSegmentName = "Parter", SeatsNo = 500, CultureObjecsHall = hall1 };
            var hallSegment3 = new HallSegment { HallSegmentName = "VIP", SeatsNo = 40, CultureObjecsHall = hall1 };

            var hallSegment4 = new HallSegment { HallSegmentName = "Balkon", SeatsNo = 100, CultureObjecsHall = hall2 };
            var hallSegment5 = new HallSegment { HallSegmentName = "Parter", SeatsNo = 500, CultureObjecsHall = hall2 };
            var hallSegment6 = new HallSegment { HallSegmentName = "VIP", SeatsNo = 40, CultureObjecsHall = hall2 };


            var screening1 = new Screening { ScreenStartDateTime = new System.DateTime(2018, 5, 13, 20, 0, 0), CultureObjecsHall = hall2, Projection = projection };
            var screening2 = new Screening { ScreenStartDateTime = new System.DateTime(2018, 5, 20, 20, 0, 0), CultureObjecsHall = hall1, Projection = projection };

            var seat31 = new Seat { Row = 1, SeatNumber = "1", HallSegment = hallSegment3 };
            var seat32 = new Seat { Row = 2, SeatNumber = "2", HallSegment = hallSegment3 };
            var seat33 = new Seat { Row = 3, SeatNumber = "3", HallSegment = hallSegment3 };
            var seat34 = new Seat { Row = 4, SeatNumber = "4", HallSegment = hallSegment3 };
            var seat35 = new Seat { Row = 5, SeatNumber = "5", HallSegment = hallSegment3 };

            var seat21 = new Seat { Row = 1, SeatNumber = "1", HallSegment = hallSegment2 };
            var seat22 = new Seat { Row = 2, SeatNumber = "2", HallSegment = hallSegment2 };
            var seat23 = new Seat { Row = 3, SeatNumber = "3", HallSegment = hallSegment2 };
            var seat24 = new Seat { Row = 4, SeatNumber = "4", HallSegment = hallSegment2 };
            var seat25 = new Seat { Row = 5, SeatNumber = "5", HallSegment = hallSegment2 };

            var seat11 = new Seat { Row = 1, SeatNumber = "1", HallSegment = hallSegment1 };
            var seat12 = new Seat { Row = 2, SeatNumber = "2", HallSegment = hallSegment1 };
            var seat13 = new Seat { Row = 3, SeatNumber = "3", HallSegment = hallSegment1 };
            var seat14 = new Seat { Row = 4, SeatNumber = "4", HallSegment = hallSegment1 };
            var seat15 = new Seat { Row = 5, SeatNumber = "5", HallSegment = hallSegment1 };

            var seat61 = new Seat { Row = 1, SeatNumber = "1", HallSegment = hallSegment6 };
            var seat62 = new Seat { Row = 2, SeatNumber = "2", HallSegment = hallSegment6 };
            var seat63 = new Seat { Row = 3, SeatNumber = "3", HallSegment = hallSegment6 };
            var seat64 = new Seat { Row = 4, SeatNumber = "4", HallSegment = hallSegment6 };
            var seat65 = new Seat { Row = 5, SeatNumber = "5", HallSegment = hallSegment6 };

            var seat51 = new Seat { Row = 1, SeatNumber = "1", HallSegment = hallSegment5 };
            var seat52 = new Seat { Row = 2, SeatNumber = "2", HallSegment = hallSegment5 };
            var seat53 = new Seat { Row = 3, SeatNumber = "3", HallSegment = hallSegment5 };
            var seat54 = new Seat { Row = 4, SeatNumber = "4", HallSegment = hallSegment5 };
            var seat55 = new Seat { Row = 5, SeatNumber = "5", HallSegment = hallSegment5 };

            var seat41 = new Seat { Row = 1, SeatNumber = "1", HallSegment = hallSegment4 };
            var seat42 = new Seat { Row = 2, SeatNumber = "2", HallSegment = hallSegment4 };
            var seat43 = new Seat { Row = 3, SeatNumber = "3", HallSegment = hallSegment4 };
            var seat44 = new Seat { Row = 4, SeatNumber = "4", HallSegment = hallSegment4 };
            var seat45 = new Seat { Row = 5, SeatNumber = "5", HallSegment = hallSegment4 };


            var seatReservation1 = new SeatReservation { Screening = screening1, Seat = seat21, User=user1 };
            var seatReservation2 = new SeatReservation { Screening = screening1, Seat = seat22, User=user2};
            var seatReservation3 = new SeatReservation { Screening = screening1, Seat = seat23, User=user2 };

            var seatReservation4 = new SeatReservation { Screening = screening2, Seat = seat31, User = user1 };
            var seatReservation5 = new SeatReservation { Screening = screening2, Seat = seat32, User = user2 };
            var seatReservation6 = new SeatReservation { Screening = screening2, Seat = seat33, User = user2 };

            await genreRepository.AddAsync(genre1);
            await genreRepository.AddAsync(genre2);
            await genreRepository.AddAsync(genre3);
            await genreRepository.AddAsync(genre4);
            await genreRepository.AddAsync(genre5);
            await genreRepository.AddAsync(genre6);

            await accountRepository.AddAsync(account1);
            await accountRepository.AddAsync(account2);
            await accountRepository.AddAsync(account3);
            await accountRepository.AddAsync(account4);
            
            await userRepository.AddAsync(user1);
            await userRepository.AddAsync(user2);
            await userRepository.AddAsync(user3);
            
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

            await hallSegmentRepository.AddAsync(hallSegment4);
            await hallSegmentRepository.AddAsync(hallSegment5);
            await hallSegmentRepository.AddAsync(hallSegment6);

            await screeningRepository.AddAsync(screening1);
            await screeningRepository.AddAsync(screening2);

            await seatRepository.AddAsync(seat11);
            await seatRepository.AddAsync(seat12);
            await seatRepository.AddAsync(seat13);
            await seatRepository.AddAsync(seat14);
            await seatRepository.AddAsync(seat15);
            await seatRepository.AddAsync(seat21);
            await seatRepository.AddAsync(seat22);
            await seatRepository.AddAsync(seat23);
            await seatRepository.AddAsync(seat24);
            await seatRepository.AddAsync(seat25);
            await seatRepository.AddAsync(seat31);
            await seatRepository.AddAsync(seat32);
            await seatRepository.AddAsync(seat33);
            await seatRepository.AddAsync(seat34);
            await seatRepository.AddAsync(seat35);
            await seatRepository.AddAsync(seat41);
            await seatRepository.AddAsync(seat42);
            await seatRepository.AddAsync(seat43);
            await seatRepository.AddAsync(seat44);
            await seatRepository.AddAsync(seat45);
            await seatRepository.AddAsync(seat51);
            await seatRepository.AddAsync(seat52);
            await seatRepository.AddAsync(seat53);
            await seatRepository.AddAsync(seat54);
            await seatRepository.AddAsync(seat55);
            await seatRepository.AddAsync(seat61);
            await seatRepository.AddAsync(seat62);
            await seatRepository.AddAsync(seat63);
            await seatRepository.AddAsync(seat64);
            await seatRepository.AddAsync(seat65);

            await seatReservationRepository.AddAsync(seatReservation1);
            await seatReservationRepository.AddAsync(seatReservation2);
            await seatReservationRepository.AddAsync(seatReservation3);

            await seatReservationRepository.AddAsync(seatReservation4);
            await seatReservationRepository.AddAsync(seatReservation5);
            await seatReservationRepository.AddAsync(seatReservation6);
        }
    }
}