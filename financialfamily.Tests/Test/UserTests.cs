using System;
using System.Linq;
using financialfamily.domain.Entity.AuthenticationContext;
using financialfamily.domain.Enums;
using financialfamily.domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace financialfamily.Tests.Test
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Dado_Um_Usuario_Com_Nome_Invalido_Deve_Retornar_False()
        {
            var user = new User(new Name("da", "as"),
            "dniel.moreira@gamil.com",
            "abcd12345",
            RolesEnum.Administrator,
            "admin");

            Assert.AreEqual(false, user.IsValid());
        }

        [TestMethod]
        public void Dado_Um_Usuario_Com_Email_Invalido_Deve_Retornar_False()
        {
            var user = new User(new Name("Daniel", "Moreira"),
            "dniel.moreira",
            "abcd12345",
            RolesEnum.Administrator,
            "admin");

            Assert.AreEqual(false, user.IsValid());
        }

        [TestMethod]
        public void Dado_Um_Usuario_Com_Password_Invalido_Deve_Retornar_False()
        {
            var user = new User(new Name("Daniel", "Moreira"),
            "dniel.moreira@gmail.com",
            "123",
            RolesEnum.Administrator,
            "admin");

            Assert.AreEqual(false, user.IsValid());
        }

        [TestMethod]
        public void Dado_Um_Usuario_Com_Dados_Validos_Deve_Passar()
        {
            var user = new User(new Name("Daniel", "Moreira"),
            "dniel.moreira@gmail.com",
            "1234Da5820",
            RolesEnum.Administrator,
            "admin");

            Assert.AreEqual(true, user.IsValid());
        }

    }
}