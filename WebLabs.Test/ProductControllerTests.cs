using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLabs.Controllers;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;
using WebLabs.Models;
using Xunit;

namespace WebLabs.Test
{


   public class ProductControllerTests
    {
        [Theory]
        [MemberData(memberName:nameof(Data))]

        public void ControllerGetsProporPage(int page, int qty, int id)
        {
            //var controllerContext = new ControllerContext();
            //var httpContext = new DefaultHttpContext();
            //httpContext.Request.Headers.Add("x-requested-with", "");
            //controllerContext.HttpContext = httpContext;
            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //   .UseInMemoryDatabase(databaseName: "WebLabs_DB")
            //   .Options;

            //using (var context=new ApplicationDbContext(options))
            //{
            //    context.Tehniks.AddRange(
            //        new List<Tehnika>
            //        {
            //            new Tehnika{TehnikaId=1},
            //            new Tehnika{TehnikaId=2},
            //            new Tehnika{TehnikaId=3},
            //            new Tehnika{TehnikaId=4},
            //            new Tehnika{TehnikaId=5},
            //            new Tehnika{TehnikaId=6},
            //            new Tehnika{TehnikaId=7},
            //            new Tehnika{TehnikaId=8},
            //            new Tehnika{TehnikaId=9},
            //            new Tehnika{TehnikaId=10},
            //            new Tehnika{TehnikaId=11},
            //            new Tehnika{TehnikaId=12},
            //            new Tehnika{TehnikaId=13},
            //            new Tehnika{TehnikaId=14},
            //            new Tehnika{TehnikaId=15},
            //            new Tehnika{TehnikaId=16},
            //            new Tehnika{TehnikaId=17},
            //            new Tehnika{TehnikaId=18},
            //            new Tehnika{TehnikaId=19},
            //        });
            //    context.TehnikaGroups.Add(new TehnikaGroup { GroupName = "fake group" });
            //    context.SaveChanges();

            //    var controller = new ProductController(context, null)
            //    {
            //        ControllerContext = controllerContext
            //    };

            //    var result = controller.Index(pageNo: page, group: null) as ViewResult;
            //    var model = result?.Model as List<Tehnika>;
            //    Assert.NotNull(model);
            //    Assert.Equal(qty, model.Count);
            //    Assert.Equal(id, model[0].TehnikaId);

            //}
            //using (var context=new ApplicationDbContext(options))
            //{
            //    context.Database.EnsureDeleted();
            //}


            //controller._tehniks = GetTehnikaList();

            //var result = controller.Index(pageNo:page, group:null) as ViewResult;
            //var model = result?.Model as List<Tehnika>;

            //Assert.NotNull(model);
            //Assert.Equal(qty, model.Count);
            //Assert.Equal(id, model[0].TehnikaId);
        }
        [Theory]
        [MemberData(memberName: nameof(Data))]
        public void ControllerSelectsGroup()
        {
            //var controller = new ProductController();
            //controller._tehniks = GetTehnikaList();

            //var result = controller.Index(17) as ViewResult;
            //var model = result?.Model as List<Tehnika>;

            //Assert.Equal(2, model.Count);
            //Assert.Equal(GetTehnikaList()[4],
            //    model[0],
            //    Comparer<Tehnika>.GetComparer((t1, t2) =>
            //    {
            //        return t1.TehnikaId == t2.TehnikaId;
            //    }));
        }
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { 1, 3, 1 };
            yield return new object[] { 2, 3, 4 };
            yield return new object[] { 3, 3, 7 };
            yield return new object[] { 4, 3, 10 };
            yield return new object[] { 5, 3, 13};
            yield return new object[] { 6, 3, 16};
            yield return new object[] { 7, 1, 19};
        }
        private List<Tehnika> GetTehnikaList()
        {
            return new List<Tehnika>
                 {
                new Tehnika{TehnikaId=1, TehnikaGroupId=2},
                new Tehnika{TehnikaId=2, TehnikaGroupId=2},
                new Tehnika{TehnikaId=3, TehnikaGroupId=2},
                new Tehnika{TehnikaId=4, TehnikaGroupId=2},
                new Tehnika{TehnikaId=5, TehnikaGroupId=2},
                new Tehnika{TehnikaId=6, TehnikaGroupId=2},
                new Tehnika{TehnikaId=7, TehnikaGroupId=2},
                new Tehnika{TehnikaId=8, TehnikaGroupId=1},
                new Tehnika{TehnikaId=9, TehnikaGroupId=1},
                new Tehnika{TehnikaId=10, TehnikaGroupId=1},
                new Tehnika{TehnikaId=11, TehnikaGroupId=1},
                new Tehnika{TehnikaId=12, TehnikaGroupId=1},
                new Tehnika{TehnikaId=13, TehnikaGroupId=3},
                new Tehnika{TehnikaId=14, TehnikaGroupId=3},
                new Tehnika{TehnikaId=15, TehnikaGroupId=3},
                new Tehnika{TehnikaId=16, TehnikaGroupId=3},
                new Tehnika{TehnikaId=17, TehnikaGroupId=3},
                new Tehnika{TehnikaId=18, TehnikaGroupId=4},
                new Tehnika{TehnikaId=19, TehnikaGroupId=4}
            };
        }
        [Theory]
        [MemberData(memberName:nameof(Data))]
        public void ListViewCountsPages(int page, int qty, int id)
        {
            var model = ListViewModel<Tehnika>.GetModel(GetTehnikaList(), page, 3);
            Assert.Equal(7, model.TotalPage);
        }
        [Theory]
        [MemberData(memberName:nameof(Data))]
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            var model = ListViewModel<Tehnika>.GetModel(GetTehnikaList(), page, 3);
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(Data))]
        public void ListViewHasCorrectData(int page, int qty, int id)
        {
            var model = ListViewModel<Tehnika>.GetModel(GetTehnikaList(), page, 3);
            Assert.Equal(id, model[0].TehnikaId);
        }

    }
}
