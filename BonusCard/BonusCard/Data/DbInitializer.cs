using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonusCard.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BonusSystemDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return;   
            }

            Client[] clients = new Client[]
            {

                new Client {Name = "Ivan", Surname="Ivanov", DateOfBirth = new DateTime(1982, 12, 24), PhoneNumber = "0676284203"},
                new Client {Name = "Vasiliy", Surname="Vasiliev", DateOfBirth = new DateTime(1993, 07, 22), PhoneNumber = "0505864031"},
                new Client {Name = "Pavlo", Surname="Pavlov", DateOfBirth = new DateTime(1996, 05, 13), PhoneNumber = "0995842039"},
                new Client {Name = "Irina", Surname="Iriniva", DateOfBirth = new DateTime(1982, 04, 11), PhoneNumber = "0675842043"},
                new Client {Name = "Evgeniy", Surname="Evgenov", DateOfBirth = new DateTime(1976, 07, 10), PhoneNumber = "0975842057"},
                new Client {Name = "Petr", Surname="Petrov", DateOfBirth = new DateTime(1967, 08, 14), PhoneNumber = "0635842099"},
                new Client {Name = "Arsen", Surname="Arsenov", DateOfBirth = new DateTime(1982, 09, 28), PhoneNumber = "0635842087"},
                new Client {Name = "Timyr", Surname="Timyrov", DateOfBirth = new DateTime(1976, 02, 01), PhoneNumber = "0635842054"},
                new Client {Name = "Ahmed", Surname="Ahmedov", DateOfBirth = new DateTime(1993, 04, 02), PhoneNumber = "0635842012"},
                new Client {Name = "Galya", Surname="Galyava", DateOfBirth = new DateTime(1976, 05, 18), PhoneNumber = "0997842019"},
                new Client {Name = "Sanya", Surname="Sanin", DateOfBirth = new DateTime(1976, 05, 13), PhoneNumber = "0975842029"},
                new Client {Name = "Sergey", Surname="Sergeev", DateOfBirth = new DateTime(1993, 07, 13), PhoneNumber = "0965842077"},
                new Client {Name = "Ashot", Surname="Ashotov", DateOfBirth = new DateTime(1996, 09, 14), PhoneNumber = "0635842007"},
                new Client {Name = "Anton", Surname="Antonov", DateOfBirth = new DateTime(1979, 11, 17), PhoneNumber = "0635848006"},
                new Client {Name = "Grigoriy", Surname="Grigorov", DateOfBirth = new DateTime(1979, 10, 05), PhoneNumber = "0635842037"},
                new Client {Name = "Marysia", Surname="Maroy", DateOfBirth = new DateTime(1991, 07, 06), PhoneNumber = "0634842047"},
                new Client {Name = "Dmitriy", Surname="Dmitriev", DateOfBirth = new DateTime(1991, 09, 04), PhoneNumber = "0635842069"},
                new Client {Name = "Kira", Surname="Kirova", DateOfBirth = new DateTime(1996, 04, 13), PhoneNumber = "0635892058"},
                new Client {Name = "Masha", Surname="Masheva", DateOfBirth = new DateTime(1991, 08, 22), PhoneNumber = "0985845023"},
                new Client {Name = "Vera", Surname="Verova", DateOfBirth = new DateTime(1979, 01, 27), PhoneNumber = "0635842037"},
            };

            foreach (var item in clients)
            {
                context.Clients.Add(item);
            }

            ClientBonusCard[] cards = new ClientBonusCard[]
            {
               new ClientBonusCard { IsActivated = false, Client = clients[0]},
               new ClientBonusCard { IsActivated = true, Client = clients[1]},
               new ClientBonusCard { IsActivated = true, Client = clients[2]},
               new ClientBonusCard { IsActivated = false, Client = clients[3]},
               new ClientBonusCard { IsActivated = false, Client = clients[4]},
               new ClientBonusCard { IsActivated = true, Client = clients[5]},
               new ClientBonusCard { IsActivated = true, Client = clients[6]},
               new ClientBonusCard { IsActivated = true, Client = clients[7]},
               new ClientBonusCard { IsActivated = false, Client = clients[8]},
               new ClientBonusCard { IsActivated = false, Client = clients[9]},
               new ClientBonusCard { IsActivated = false, Client = clients[10]},
               new ClientBonusCard { IsActivated = true, Client = clients[11]},
               new ClientBonusCard { IsActivated = true, Client = clients[12]},
               new ClientBonusCard { IsActivated = false, Client = clients[13]},
               new ClientBonusCard { IsActivated = false, Client = clients[14]},
               new ClientBonusCard { IsActivated = true, Client = clients[15]},
               new ClientBonusCard { IsActivated = true, Client = clients[16]},
               new ClientBonusCard { IsActivated = false, Client = clients[17]},
               new ClientBonusCard { IsActivated = true, Client = clients[18]},
               new ClientBonusCard { IsActivated = true, Client = clients[19]}
            };

            foreach (var item in cards)
            {
                context.ClientBonusCard.Add(item);
            }

            Adress[] adresses = new Adress[]
            {
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 4, FlatNumber =33, Client = clients[0]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 81, FlatNumber =133, Client = clients[1]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 76, FlatNumber =393, Client = clients[2]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 50, FlatNumber =13, Client = clients[3]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 56, FlatNumber =3, Client = clients[4]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 9, FlatNumber =13, Client = clients[5]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 21, FlatNumber =22, Client = clients[6]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 89, FlatNumber =79, Client = clients[7]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 14, FlatNumber =38, Client = clients[8]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 19, FlatNumber =67, Client = clients[9]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 20, FlatNumber =34, Client = clients[10]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 45, FlatNumber =12, Client = clients[11]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 66, FlatNumber =11, Client = clients[12]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 18, FlatNumber =99, Client = clients[13]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 20, FlatNumber =89, Client = clients[14]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 15, FlatNumber =113, Client = clients[15]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 12, FlatNumber =33, Client = clients[16]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 67, FlatNumber = 63, Client = clients[17]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 98, FlatNumber = 76, Client = clients[18]},
                new Adress {Region = "Dnipropetrovskiy", District = " ", CityOrVillage = "Dnipro", Street ="Centralna", HouseNum = 1, FlatNumber = 111, Client = clients[19]},

            };

            foreach (var item in adresses)
            {
                context.Adreses.Add(item);
            }
            context.SaveChanges();
        }
    }
}
