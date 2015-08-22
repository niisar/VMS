namespace VMS.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VMS.EF.Entitities;

    internal sealed class Configuration : DbMigrationsConfiguration<VMS.EF.vmsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VMS.EF.vmsDBContext context)
        {
            context.Visitors.AddOrUpdate(
                p => p.VisitorID,
                new Visitors { VisitorID = 1, Name = "Babu Rao", Email = "BR@live.com", Phone = "9983252398", IdCard = "540236T", Vehicle = "Car, BMW", VehicleNu = "HYD0464", Color = "Black", ParkineZone = "PKZ4-11", Building = "IBM", MeeTTo = "Ram Kripalu", TokenNo = "1892T89", EntryDate = DateTime.Now.AddDays(-30) },
                new Visitors { VisitorID = 2, Name = "Amit Khuranna", Email = "kavril@gmail.com", Phone = "9829253389", IdCard = "540238T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "IBM", MeeTTo = "Sarita", TokenNo = "5892B83",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 3, Name = "Rajesh Behera", Email = "Raj_329@gmail.com", Phone = "9832925389", IdCard = "540239T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "IBM", MeeTTo = "Sandeep", TokenNo = "6892X11",  EntryDate = DateTime.Now.AddDays(-29) },

                new Visitors { VisitorID = 4, Name = "Joti Dora", Email = "jotidora@hotmail.com", Phone = "9983225839", IdCard = "5402341T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "George Smit", TokenNo = "1892T90", EntryDate = DateTime.Now.AddDays(-30) },
                new Visitors { VisitorID = 5, Name = "Chavinder Ram", Email = "chavi_raj@rediffmail.com", Phone = "9983225839", IdCard = "5402344T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Chandra",  TokenNo = "1892T91",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 6, Name = "Utkarsh Kumar", Email = "srivastiv@gmail.com", Phone = "9983225839", IdCard = "5402345T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Yadav", TokenNo = "1892T92",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 7, Name = "Biren Satpaty", Email = "satpaty_biren@gmail.com", Phone = "9983225839", IdCard = "5402346T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Indu Nanda", TokenNo = "1892T93",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 8, Name = "Dipti Ranjan", Email = "dipty_ranjan@yahomail.com", Phone = "9983225839", IdCard = "5402347T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Sadab",  TokenNo = "1892T94",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 9, Name = "Manesh Behera", Email = "beheramanash@gmail.com", Phone = "9983225839", IdCard = "5402348T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Ramesh",  TokenNo = "1892T95",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 10, Name = "Kishore Manikonda", Email = "manikinda89@gmail.com", Phone = "9983225839", IdCard = "5402349T", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Rakesh",  TokenNo = "1892T96",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 11, Name = "Parween Sultan", Email = "sultana@gmail.com", Phone = "9983225839", IdCard = "540234T0", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Jeshan",  TokenNo = "1892T97",  EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 12, Name = "Krishna Mani", Email = "manikrihsna@rediffmail.com", Phone = "9983225839", IdCard = "540234T1", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Swalleh", TokenNo = "1892T98", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 13, Name = "Ram Kripalu", Email = "ramkripalu63@gmail.com", Phone = "9983225839", IdCard = "540234T2", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "TCS", MeeTTo = "Ram Kumar", TokenNo = "1892T99", EntryDate = DateTime.Now.AddDays(-29) },

                new Visitors { VisitorID = 14, Name = "RadhaNath Mishra", Email = "nathradha_ki@yahoomail.com", Phone = "9983225839", IdCard = "540234T3", Vehicle = "Bike", VehicleNu = "ORD1044", Color = "Blue", ParkineZone = "PKZ1-33", Building = "Accenture", MeeTTo = "Nisar Ansari", TokenNo = "1892T100", EntryDate = DateTime.Now.AddDays(-30) },
                new Visitors { VisitorID = 15, Name = "Lalita Jim", Email = "laila@program.com", Phone = "9983225839", IdCard = "540234T7", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "Appa G", TokenNo = "1892T104", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 16, Name = "Chanmaya Patnayak", Email = "chanmaya_p@gmail.com", Phone = "9983225839", IdCard = "540234T8", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "Emili", TokenNo = "1892T105", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 17, Name = "Karan Kumar", Email = "karan_kka@cost.co.in", Phone = "9982328539", IdCard = "540234T9", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "Demi Lov", TokenNo = "1892T106", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 18, Name = "Nakul Malahotra", Email = "nakul@gmail.com", Phone = "9839252839", IdCard = "540234T11", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "Faizan Ansari", TokenNo = "1892T107", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 19, Name = "Shiva Das", Email = "shiva_nath@live.com", Phone = "9983225389", IdCard = "540234T12", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "Fakiruddin", TokenNo = "1892T108", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 20, Name = "Paro Ram", Email = "paro100@hotmail.com", Phone = "9982253839", IdCard = "5403234A", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "M. Radhavar", TokenNo = "1892T109", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 21, Name = "Rabi Naranaya", Email = "narayan_rabi@gmail.com", Phone = "9983225839", IdCard = "540234B", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "K. Kumud", TokenNo = "1892T110", EntryDate = DateTime.Now.AddDays(-29) },
                new Visitors { VisitorID = 22, Name = "Ram Jane", Email = "jane_r34@gmail.com", Phone = "9982358239", IdCard = "540234E", Vehicle = "Bike, Honda Plus", VehicleNu = "ORD1044", Color = "Red", ParkineZone = "PKZ4-23", Building = "Accenture", MeeTTo = "Shyama Sharma", TokenNo = "1892T111", EntryDate = DateTime.Now.AddDays(-29) }
                );
            context.InOuts.AddOrUpdate(
                new InOuts { ID = 1, VisitorID = 1, InTime = "9:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 2, VisitorID = 1, InTime = "11:00 AM", OutTime = "", Status = "Lobby Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 3, VisitorID = 1, InTime = "11:00 AM", OutTime = "1:30 PM", Status = "Lobby Checkout", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 4, VisitorID = 1, InTime = "9:00 AM", OutTime = "1:35 PM", Status = "Security Checkout", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 5, VisitorID = 2, InTime = "11:13 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 6, VisitorID = 3, InTime = "12:09 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },


                new InOuts { ID = 7, VisitorID = 4, InTime = "10:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 8, VisitorID = 4, InTime = "10:10 AM", OutTime = "", Status = "Lobby Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 9, VisitorID = 4, InTime = "10:10 AM", OutTime = "1:30 PM", Status = "Lobby Checkout", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 10, VisitorID = 4, InTime = "10:00 AM", OutTime = "1:35 PM", Status = "Security Checkout", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 11, VisitorID = 5, InTime = "2:40 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 12, VisitorID = 6, InTime = "9:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 13, VisitorID = 7, InTime = "4:00 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 14, VisitorID = 8, InTime = "10:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 15, VisitorID = 9, InTime = "10:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 16, VisitorID = 10, InTime = "4:55 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 17, VisitorID = 11, InTime = "4:54 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 18, VisitorID = 12, InTime = "4:54 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 19, VisitorID = 13, InTime = "4:54 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },

                new InOuts { ID = 20, VisitorID = 14, InTime = "9:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 21, VisitorID = 14, InTime = "10:00 AM", OutTime = "", Status = "Lobby Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 22, VisitorID = 14, InTime = "10:00 AM", OutTime = "1:30 PM", Status = "Lobby Checkout", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 23, VisitorID = 14, InTime = "9:00 AM", OutTime = "1:32 PM", Status = "Security Checkout", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 24, VisitorID = 15, InTime = "10:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 25, VisitorID = 16, InTime = "10:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 26, VisitorID = 17, InTime = "4:00 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 27, VisitorID = 18, InTime = "2:40 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 28, VisitorID = 19, InTime = "4:54 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 29, VisitorID = 20, InTime = "10:00 AM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 30, VisitorID = 21, InTime = "4:54 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) },
                new InOuts { ID = 31, VisitorID = 22, InTime = "4:54 PM", OutTime = "", Status = "Security Checkin", EntryDate = DateTime.Now.AddDays(-29) }
                );
        }
    }
}
