using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFData
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                                {
                                    new AppUser
                                        {
                                            DisplayName = "TestUserFirst",
                                            UserName = "TestUserFirst",
                                            Email = "testuserfirst@test.com"
                                        },

                                    new AppUser
                                        {
                                            DisplayName = "TestUserSecond",
                                            UserName = "TestUserSecond",
                                            Email = "testusersecond@test.com"
                                        }
                                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "qazwsX123@");
                }
            }

            if (!EnumerableExtensions.Any(context.Clients))
            {
                var clients = new List<Client>
                {
                    new Client()
                    {
                        Email = "test2@mail.ru",
                        FirstName = "Евгений",
                        Phone = "89111111111",
                        SecondName = "Васючков",
                        Surname = "Леонидович"
                    },

                    new Client()
                    {
                        Email = "test@mail.ru",
                        FirstName = "Анастасия",
                        Phone = "89111111222",
                        SecondName = "Москаленко",
                        Surname = "Евгеньевна"
                    }
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }



            if (!EnumerableExtensions.Any(context.Orders))
            {
                var orders = new List<Order>
                {
                    new Order
                    {
                        Balloon = true,
                        Brush = true,
                        ModelElement = true,
                        OrderDetails = "Заказ 1",
                        PrePrice = 320,
                        QuantityOfMaterial = 200,
                        MaterialType = MaterialType.Source,
                        PaintType = PaintType.Metallic,
                        Client = context.Clients.FirstOrDefault(x => x.Phone == "89776804475")

                    },
                    new Order
                    {
                        Balloon = false,
                        Brush = false,
                        ModelElement = false,
                        OrderDetails = "Заказ 2",
                        PrePrice = 520,
                        QuantityOfMaterial = 300,
                        MaterialType = MaterialType.Product,
                        PaintType = PaintType.Acril,
                        Client = context.Clients.FirstOrDefault(x => x.Phone == "89193281815")

                    }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}