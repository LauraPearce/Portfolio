using NailsByNikki.Models;

namespace NailsByNikki.Data
{
    public class SeedTestData
    {
        public static void TestData(NailsByNikkiDbContext context)
        {

            if (context.Customers.Any()
                && context.Bookings.Any()
                && context.AvailableSlots.Any()
                && context.BookingsHistory.Any())
            {
                return;   // DB has been seeded
            }

            Customer customerOne = new Customer { FirstName = "Tracey", Surname = "Jeeves", DateOfBirth = new DateTime(1962, 07, 04), Email = "trace.jeeves@outlook.com", PhoneNumber = "07799413195", Allergies = "Double Cream", Medication = "None", AdditionalInformation = "Favourite colour is blue", PrivateNotes = "None" };
            Customer customerTwo = new Customer { FirstName = "Laura", Surname = "Jeeves", DateOfBirth = new DateTime(1992, 05, 15), Email = "laurajeeves@hotmail.co.uk", PhoneNumber = "07594682802", Allergies = "Caffeine", Medication = "Pill", AdditionalInformation = "Loves pinks and nudes", PrivateNotes = "None" };
            Customer customerThree = new Customer { FirstName = "Jo", Surname = "Brooks", DateOfBirth = new DateTime(1970, 08, 14), Email = "jobrooksemail", PhoneNumber = "07973576586", Allergies = "AllergiesCheck", Medication = "MedCheck", AdditionalInformation = "None", PrivateNotes = "None" };
            Customer customerFour = new Customer { FirstName = "Mia", Surname = "Brooks", DateOfBirth = new DateTime(2005, 06, 30), Email = "miabrooksemail", PhoneNumber = "miabrooksphonenumber", Allergies = "AllergiesCheck", Medication = "MedCheck", AdditionalInformation = "None", PrivateNotes = "None" };
            Customer customerFive = new Customer { FirstName = "Ella", Surname = "Brooks", DateOfBirth = new DateTime(2002, 04, 17), Email = "ellabrooksemail", PhoneNumber = "ellabrooksnumber", Allergies = "AllergyCheck", Medication = "MedCheck", AdditionalInformation = "None", PrivateNotes = "None" };

            context.Customers.Add(customerOne);
            context.Customers.Add(customerTwo);
            context.Customers.Add(customerThree);
            context.Customers.Add(customerFour);
            context.Customers.Add(customerFive);

            context.SaveChanges();

            AvailableSlot availableSlotOne = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 11, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 11, 20, 00, 00) };
            AvailableSlot availableSlotTwo = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 12, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 12, 20, 00, 00) };
            AvailableSlot availableSlotThree = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 13, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 13, 20, 00, 00) };
            AvailableSlot availableSlotFour = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 14, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 14, 20, 00, 00) };
            AvailableSlot availableSlotFive = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 15, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 15, 20, 00, 00) };
            AvailableSlot availableSlotSix = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 16, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 16, 20, 00, 00) };
            AvailableSlot availableSlotSeven = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 17, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 17, 20, 00, 00) };
            AvailableSlot availableSlotEight = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 18, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 18, 20, 00, 00) };
            AvailableSlot availableSlotNine = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 19, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 19, 20, 00, 00) };
            AvailableSlot availableSlotTen = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 20, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 20, 20, 00, 00) };
            AvailableSlot availableSlotEleven = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 21, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 21, 20, 00, 00) };
            AvailableSlot availableSlotTwelve = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 22, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 22, 20, 00, 00) };
            AvailableSlot availableSlotThirteen = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 23, 20, 00, 00), EndDateTime = new DateTime(2022, 08, 23, 20, 00, 00) };
            AvailableSlot availableSlotFourteen = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 24, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 24, 20, 00, 00) };
            AvailableSlot availableSlotFifteen = new AvailableSlot { StartDateTime = new DateTime(2022, 08, 25, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 25, 20, 00, 00) };

            context.AvailableSlots.Add(availableSlotOne);
            context.AvailableSlots.Add(availableSlotTwo);
            context.AvailableSlots.Add(availableSlotThree);
            context.AvailableSlots.Add(availableSlotFour);
            context.AvailableSlots.Add(availableSlotFive);
            context.AvailableSlots.Add(availableSlotSix);
            context.AvailableSlots.Add(availableSlotSeven);
            context.AvailableSlots.Add(availableSlotEight);
            context.AvailableSlots.Add(availableSlotNine);
            context.AvailableSlots.Add(availableSlotTen);
            context.AvailableSlots.Add(availableSlotEleven);
            context.AvailableSlots.Add(availableSlotTwelve);
            context.AvailableSlots.Add(availableSlotThirteen);
            context.AvailableSlots.Add(availableSlotFourteen);
            context.AvailableSlots.Add(availableSlotFifteen);

            context.SaveChanges();

            Booking bookingOne = new Booking { AvailableSlotId = 1, CustomerId = 1 };
            Booking bookingTwo = new Booking { AvailableSlotId = 2, CustomerId = 1 };
            Booking bookingThree = new Booking { AvailableSlotId = 3, CustomerId = 2 };
            Booking bookingFour = new Booking { AvailableSlotId = 4, CustomerId = 2 };
            Booking bookingFive = new Booking { AvailableSlotId = 5, CustomerId = 3 };
            Booking bookingSix = new Booking { AvailableSlotId = 6, CustomerId = 3 };
            Booking bookingSeven = new Booking { AvailableSlotId = 7, CustomerId = 4 };
            Booking bookingEight = new Booking { AvailableSlotId = 8, CustomerId = 4 };
            Booking bookingNine = new Booking { AvailableSlotId = 9, CustomerId = 5 };
            Booking bookingTen = new Booking { AvailableSlotId = 10, CustomerId = 5 };

            context.Bookings.Add(bookingOne);
            context.Bookings.Add(bookingTwo);
            context.Bookings.Add(bookingThree);
            context.Bookings.Add(bookingFour);
            context.Bookings.Add(bookingFive);
            context.Bookings.Add(bookingSix);
            context.Bookings.Add(bookingSeven);
            context.Bookings.Add(bookingEight);
            context.Bookings.Add(bookingNine);
            context.Bookings.Add(bookingTen);

            context.SaveChanges();

            BookingHistory previousAppointmentOne = new BookingHistory { CustomerId = 1, StartDateTime = new DateTime(2022, 08, 08, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 08, 20, 00, 00), ServicesCarriedOut = "French manicure" };
            BookingHistory previousAppointmentTwo = new BookingHistory { CustomerId = 1, StartDateTime = new DateTime(2022, 08, 01, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 01, 20, 00, 00), ServicesCarriedOut = "Repair and soak off" };
            BookingHistory previousAppointmentThree = new BookingHistory { CustomerId = 2, StartDateTime = new DateTime(2022, 08, 07, 18, 00, 00), EndDateTime = new DateTime(2022, 08, 07, 20, 00, 00), ServicesCarriedOut = "Gel manicure and glitter nail art on two fingers" };
            BookingHistory previousAppointmentFour = new BookingHistory { CustomerId = 2, StartDateTime = new DateTime(2022, 07, 28, 18, 00, 00), EndDateTime = new DateTime(2022, 07, 28, 20, 00, 00), ServicesCarriedOut = "Gel manicure" };

            context.BookingsHistory.Add(previousAppointmentOne);
            context.BookingsHistory.Add(previousAppointmentTwo);
            context.BookingsHistory.Add(previousAppointmentThree);
            context.BookingsHistory.Add(previousAppointmentFour);

            context.SaveChanges();
        }


    }
}
