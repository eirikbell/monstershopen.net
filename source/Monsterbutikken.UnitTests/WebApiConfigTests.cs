using System;
using System.Collections.Generic;
using System.Web.Http;
using Monsterbutikken.Controllers.Service;
using Monsterbutikken.Models;
using Monsterbutikken.UnitTests.Fixtures;
using Monsterbutikken.UnitTests.Infrastructure;
using Monsterbutikken.UnitTests.TestDataBuilders;
using NUnit.Framework;

namespace Monsterbutikken.UnitTests
{
    [TestFixture]
    public class WebApiConfigTests
    {
        [Test]
        public void MonstreControllerGetRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((MonsterTypesController p) => p.Get());
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((MonsterTypesController p) => p.Get());
            var controllerType = typeof(MonsterTypesController);

            var url = new UrlStringBuilder().WithRelativePath("/service/monsterTypes").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url);

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IEnumerable<MonsterJson>));
        }

        [Test]
        public void BasketControllerGetRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((BasketController p) => p.Get());
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((BasketController p) => p.Get());
            var controllerType = typeof(BasketController);

            var url = new UrlStringBuilder().WithRelativePath("/service/basket/").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url);

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IEnumerable<BasketItemJson>));
        }

        [Test]
        public void BasketControllerAddRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((BasketController p) => p.Add("Kraken"));
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((BasketController p) => p.Add("Kraken"));
            var controllerType = typeof(BasketController);

            var url = new UrlStringBuilder().WithRelativePath("/service/basket/add/Kraken").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url).Post();

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IHttpActionResult));
        }

        [Test]
        public void BasketControllerRemoveRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((BasketController p) => p.Remove("Kraken"));
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((BasketController p) => p.Remove("Kraken"));
            var controllerType = typeof(BasketController);

            var url = new UrlStringBuilder().WithRelativePath("/service/basket/remove/Kraken").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url).Post();

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IHttpActionResult));
        }

        [Test]
        public void BasketControllerSumRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((BasketController p) => p.Sum());
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((BasketController p) => p.Sum());
            var controllerType = typeof(BasketController);

            var url = new UrlStringBuilder().WithRelativePath("/service/basket/sum").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url);

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(BasketSumJson));
        }

        [Test]
        public void OrdersControllerPlaceOrderRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((OrdersController p) => p.PlaceOrder());
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((OrdersController p) => p.PlaceOrder());
            var controllerType = typeof(OrdersController);

            var url = new UrlStringBuilder().WithRelativePath("/service/orders/placeorder").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url).Post();

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IHttpActionResult));
        }

        [Test]
        public void OrdersControllerGetRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((OrdersController p) => p.Get());
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((OrdersController p) => p.Get());
            var controllerType = typeof(OrdersController);

            var url = new UrlStringBuilder().WithRelativePath("/service/orders").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url);

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IDictionary<Guid, OrderJson>));
        }

        [Test]
        public void OrdersControllerGetByIdRoute()
        {
            var guid = new Guid();
            var methodName = ReflectionHelpers.GetMethodName((OrdersController p) => p.Get(guid));
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((OrdersController p) => p.Get(guid));
            var controllerType = typeof(OrdersController);

            var url = new UrlStringBuilder().WithRelativePath("/service/orders/" + guid).Build();

            var fixture = new WebApiConfigFixture().WithUrl(url);

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(OrderJson));
        }

        [Test]
        public void AuthControllerLogInRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((AuthController p) => p.LogIn("username"));
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((AuthController p) => p.LogIn("username"));
            var controllerType = typeof(AuthController);

            var url = new UrlStringBuilder().WithRelativePath("/service/auth/login/username").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url).Post();

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IHttpActionResult));
        }

        [Test]
        public void AuthControllerLogOutRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((AuthController p) => p.LogOut());
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((AuthController p) => p.LogOut());
            var controllerType = typeof(AuthController);

            var url = new UrlStringBuilder().WithRelativePath("/service/auth/logout").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url).Post();

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(IHttpActionResult));
        }

        [Test]
        public void AuthControllerCustomerRoute()
        {
            var methodName = ReflectionHelpers.GetMethodName((AuthController p) => p.Customer());
            var methodReturnType = ReflectionHelpers.GetMethodReturnType((AuthController p) => p.Customer());
            var controllerType = typeof(AuthController);

            var url = new UrlStringBuilder().WithRelativePath("/service/auth/customer").Build();

            var fixture = new WebApiConfigFixture().WithUrl(url);

            var sut = fixture.CreateSut();

            var result = sut.GetRequestResult();

            Assert.AreEqual(controllerType, result.Controller);
            Assert.AreEqual(methodName, result.ActionName);
            Assert.AreEqual(methodReturnType, typeof(CustomerJson));
        }
    }
}
