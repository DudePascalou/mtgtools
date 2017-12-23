using Microsoft.VisualStudio.TestTools.UnitTesting;
using mtgtools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgtools.Tests.Models
{
    [TestClass]
    public class AvailableManaTests
    {
        [TestMethod]
        public void CanTellWhetherIsEnoughFor()
        {
            // Arrange
            Assert.IsTrue(new AvailableMana("{W}{G}").IsEnoughFor(TypedMana.Parse("{G}")));
            Assert.IsTrue(new AvailableMana("{W}{G}").IsEnoughFor(TypedMana.Parse("{W}")));
            Assert.IsTrue(new AvailableMana("{W}{G}").IsEnoughFor(TypedMana.Parse("{1}{G}")));
            Assert.IsTrue(new AvailableMana("{W}{G}").IsEnoughFor(TypedMana.Parse("{1}{W}")));
            Assert.IsFalse(new AvailableMana("{W}{G}").IsEnoughFor(TypedMana.Parse("{W}{W}")));
            Assert.IsFalse(new AvailableMana("{W}{G}").IsEnoughFor(TypedMana.Parse("{G}{G}")));

            Assert.IsTrue(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{W}")));
            Assert.IsTrue(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{W}{W}")));
            Assert.IsTrue(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{W}{W}{W}")));
            Assert.IsFalse(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{W}{W}{W}{W}")));

            Assert.IsTrue(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{B}{R}{G}")));
            Assert.IsTrue(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{B}{B}{R}{G}")));
            Assert.IsTrue(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{B}{B}{R}{R}{G}")));
            Assert.IsFalse(new AvailableMana("{AC}{AT}{C}{W}{U}{B}{R}{G}").IsEnoughFor(TypedMana.Parse("{B}{B}{R}{R}{G}{G}")));

            // TODO bilands ?
        }
    }
}
