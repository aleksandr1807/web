using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            if(!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                var result = await roleManager.CreateAsync(roleAdmin);
            }
            if(!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                var admin = new ApplicationUser
                { 
                    Email = "admin@mail.ru", 
                    UserName = "admin@mail.ru" 
                };
                await userManager.CreateAsync(admin, "123456");
                admin = await userManager.FindByNameAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            if(!context.TehnikaGroups.Any())
            {
                context.TehnikaGroups.AddRange(
                    new List<TehnikaGroup>
                    {
                        new TehnikaGroup {GroupName = "Строительная техника" },
                        new TehnikaGroup {GroupName = "Дорожная техника" },
                        new TehnikaGroup {GroupName = "Грузовые автомобили" },
                        new TehnikaGroup {GroupName = "Эвакуаторы" }
                    });
                await context.SaveChangesAsync();
            }
            if (!context.Tehniks.Any())
            {
                context.Tehniks.AddRange(
                    new List<Tehnika>
                    {
                        new Tehnika
                {
                    
                    Name="Автогрейдер",
                    Images="автогрейдер.jpg",
                    TehnikaGroupId=1,
                    Cost=30,
                    ArendaDays=7
                },
                new Tehnika
                {
                    
                    Name="Скрепер",
                    Images="скрепер.jpg",
                    TehnikaGroupId=1,
                    Cost=60,
                    ArendaDays=3
                },
                new Tehnika
                {
                    
                    Name="Автогудронатор",
                    Images="автогудронатор.jpg",
                    TehnikaGroupId=1,
                    Cost=50,
                    ArendaDays=1
                },
                new Tehnika
                {
                    
                    Name="Каток комбинированный",
                    Images="каток.jpg",
                    TehnikaGroupId=1,
                    Cost=20,
                    ArendaDays=10
                },
                new Tehnika
                {
                   
                    Name="Виброкатка",
                    Images="виброкатка.jpg",
                    TehnikaGroupId=1,
                    Cost=10,
                    ArendaDays=30
                },
                new Tehnika
                {
                    
                    Name="Виброплита",
                    Images="виброплита.jpg",
                    TehnikaGroupId=1,
                                        Cost=10,
                    ArendaDays=30

                },
                new Tehnika
                {
                    
                    Name="Асфальтоукладчик",
                    Images="асфальтоукладчик.jpg",
                    TehnikaGroupId=1,
                    Cost=100,
                    ArendaDays=20

                },
                new Tehnika
                {
                    
                    Name="Экскаватор",
                    Images="экскаватор.jpg",
                    TehnikaGroupId=2,
                    Cost=80,
                    ArendaDays=7

                },
                new Tehnika
                {
                    
                    Name="Кабелеукладчик",
                    Images="кабелеукладчик.jpg",
                    TehnikaGroupId=2,
                    Cost=100,
                    ArendaDays=3

                },
                new Tehnika
                {
                    
                    Name="Гидромолот",
                    Images="гидромолот.jpg",
                    TehnikaGroupId=2,
                    Cost=50,
                    ArendaDays=3

                },
                new Tehnika
                {
                    
                    Name="Бульдозер",
                    Images="бульдозер.jpg",
                    TehnikaGroupId=2,
                    Cost=90,
                    ArendaDays=10

                },
                new Tehnika
                {
                    
                    Name="Автокран",
                    Images="автокран.jpg",
                    TehnikaGroupId=2,
                    Cost=60,
                    ArendaDays=10

                },
                new Tehnika
                {
                    
                    Name="Автосамосвал",
                    Images="автосамосвал.jpg",
                    TehnikaGroupId=3,
                    Cost=50,
                    ArendaDays=90

                },
                new Tehnika
                {
                    
                    Name="Прицеп самосвал",
                    Images="прицепсамосвал.jpg",
                    TehnikaGroupId=3,
                    Cost=40,
                    ArendaDays=90

                },
                new Tehnika
                {
                    
                    Name="Трактор колесный",
                    Images="тракторколесный.jpg",
                    TehnikaGroupId=3,
                    Cost=50,
                    ArendaDays=90

                },
                new Tehnika
                {
                   
                    Name="Трактор гусеничный",
                    Images="тракторгусеничный.jpeg",
                    TehnikaGroupId=3,
                    Cost=80,
                    ArendaDays=60

                },
                new Tehnika
                {
                    
                    Name="Автобитумовоз",
                    Images="автобитумовоз.jpg",
                    TehnikaGroupId=3,
                    Cost=100,
                    ArendaDays=5

                },
                new Tehnika
                {
                    
                    Name="Эвакуатор Газель",
                    Images="газель.jpg",
                    TehnikaGroupId=4,
                    Cost=90,
                    ArendaDays=2

                },
                new Tehnika
                {
                   
                    Name="Грузовой эвакуатор",
                    Images="грузэвакуатор.jpg",
                    TehnikaGroupId=4,
                    Cost=150,
                    ArendaDays=2

                }
             });
                await context.SaveChangesAsync();
            }
        }
    }
}
