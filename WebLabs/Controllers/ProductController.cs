using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLabs.DAL.Entities;
using WebLabs.Models;
using Microsoft.AspNetCore.Http;
using WebLabs.Extensions;
using WebLabs.DAL.Data;
using Microsoft.Extensions.Logging;

namespace WebLabs.Controllers
{
    public class ProductController : Controller
    {
        //private ILogger _logger;
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context
            /*ILogger<ProductController> logger*/)
        {
            _pageSize = 3;
            _context = context;
           // _logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group ,int pageNo=1)
        {
            //var groupName = group.HasValue
            //    ? _context.TehnikaGroups.Find(group.Value)?.GroupName
            //    : "all groups";
            //_logger.LogInformation($"info: group={groupName}, page={pageNo}");


            var tehnikaFilter = _context.Tehniks
                .Where(t => !group.HasValue || t.TehnikaGroupId == group.Value);

            ViewData["Groups"] = _context.TehnikaGroups;
            var currentGroup = group.HasValue ? group.Value : 0;
            ViewData["CurrentGroup"] = currentGroup;

            if (Request.IsAjaxRequest())
                return PartialView("_ListPartial",
                    ListViewModel<Tehnika>.GetModel(tehnikaFilter, pageNo, _pageSize));

            return View(ListViewModel<Tehnika>.GetModel(tehnikaFilter, pageNo, _pageSize));
        }
        //private void Data()
        //{
            
        //    _tehnikaGroups = new List<TehnikaGroup>
        //    {
        //        new TehnikaGroup{TehnikaGroupId=1, GroupName="Строительная техника"},
        //        new TehnikaGroup{TehnikaGroupId=2, GroupName="Дорожная техника"},
        //        new TehnikaGroup{TehnikaGroupId=3, GroupName="Грузовые автомобили"},
        //        new TehnikaGroup{TehnikaGroupId=4, GroupName="Эвакуаторы"}
        //    };
        //    _tehniks = new List<Tehnika>
        //    {
        //        new Tehnika
        //        {
        //            TehnikaId=1,
        //            Name="Автогрейдер",
        //            Images="автогрейдер.jpg",
        //            TehnikaGroupId=2,
        //            Cost=30,
        //            ArendaDays=7
        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=2,
        //            Name="Скрепер",
        //            Images="скрепер.jpg",
        //            TehnikaGroupId=2,
        //            Cost=60,
        //            ArendaDays=3
        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=3,
        //            Name="Автогудронатор",
        //            Images="автогудронатор.jpg",
        //            TehnikaGroupId=2,
        //            Cost=50,
        //            ArendaDays=1
        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=4,
        //            Name="Каток комбинированный",
        //            Images="каток.jpg",
        //            TehnikaGroupId=2,
        //            Cost=20,
        //            ArendaDays=10
        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=5,
        //            Name="Виброкатка",
        //            Images="виброкатка.jpg",
        //            TehnikaGroupId=2,
        //            Cost=10,
        //            ArendaDays=30
        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=6,
        //            Name="Виброплита",
        //            Images="виброплита.jpg",
        //            TehnikaGroupId=2,
        //                                Cost=10,
        //            ArendaDays=30

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=7,
        //            Name="Асфальтоукладчик",
        //            Images="асфальтоукладчик.jpg",
        //            TehnikaGroupId=2,
        //            Cost=100,
        //            ArendaDays=20

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=8,
        //            Name="Экскаватор",
        //            Images="экскаватор.jpg",
        //            TehnikaGroupId=1,
        //            Cost=80,
        //            ArendaDays=7

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=9,
        //            Name="Кабелеукладчик",
        //            Images="кабелеукладчик.jpg",
        //            TehnikaGroupId=1,
        //            Cost=100,
        //            ArendaDays=3

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=10,
        //            Name="Гидромолот",
        //            Images="гидромолот.jpg",
        //            TehnikaGroupId=1,
        //            Cost=50,
        //            ArendaDays=3

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=11,
        //            Name="Бульдозер",
        //            Images="бульдозер.jpg",
        //            TehnikaGroupId=1,
        //            Cost=90,
        //            ArendaDays=10

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=12,
        //            Name="Автокран",
        //            Images="автокран.jpg",
        //            TehnikaGroupId=1,
        //            Cost=60,
        //            ArendaDays=10

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=13,
        //            Name="Автосамосвал",
        //            Images="автосамосвал.jpg",
        //            TehnikaGroupId=3,
        //            Cost=50,
        //            ArendaDays=90

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=14,
        //            Name="Прицеп самосвал",
        //            Images="прицепсамосвал.jpg",
        //            TehnikaGroupId=3,
        //            Cost=40,
        //            ArendaDays=90

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=15,
        //            Name="Трактор колесный",
        //            Images="тракторколесный.jpg",
        //            TehnikaGroupId=3,
        //            Cost=50,
        //            ArendaDays=90

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=16,
        //            Name="Трактор гусеничный",
        //            Images="тракторгусеничный.jpeg",
        //            TehnikaGroupId=3,
        //            Cost=80,
        //            ArendaDays=60

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=17,
        //            Name="Автобитумовоз",
        //            Images="автобитумовоз.jpg",
        //            TehnikaGroupId=3,
        //            Cost=100,
        //            ArendaDays=5

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=18,
        //            Name="Эвакуатор Газель",
        //            Images="газель.jpg",
        //            TehnikaGroupId=4,
        //            Cost=90,
        //            ArendaDays=2

        //        },
        //        new Tehnika
        //        {
        //            TehnikaId=19,
        //            Name="Грузовой эвакуатор",
        //            Images="грузэвакуатор.jpg",
        //            TehnikaGroupId=4,
        //            Cost=150,
        //            ArendaDays=2

        //        },
        //    };
        //}
       
    }
}