using System;
using System.Collections.Generic;
using System.Linq;
using FitnessApp.respository.GenericRepository;
using FitnessApp.respository.Models;
using NUnit.Framework;

namespace FitnessApp.unitTest
{
    public class RepositoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetAllUsers()
        {
            IGenericRepository<User> repository = new GenericRepository<User>();
            var users = repository.GetAll();
            Assert.IsTrue(users.Count() == 1);
        }


        [Test]
        public void TestGetUser()
        {
            IGenericRepository<User> repository = new GenericRepository<User>();
            Guid userId = Guid.Parse("451ab7ac-9f89-4d27-8154-66b94855f6c7");
            var user = repository.GetById(userId);
            Assert.IsTrue(user.Email == "emanuel.hiebeler@gmila.com");
        }

        [Test]
        public void TestInsertUser()
        {
            IGenericRepository<User> repository = new GenericRepository<User>();
            Guid uid = Guid.NewGuid();
            User newUser = new User(){Uid = uid, Email = "kim.gahan@gmail.com", Password = "Aut-1251"};
            repository.Insert(newUser);
            repository.Save();
            var user = repository.GetById(uid);
            Assert.IsTrue(user.Email == "kim.gahan@gmail.com");
        }

        [Test]
        public void TestUpdateUser()
        {
            IGenericRepository<User> repository = new GenericRepository<User>();
            Guid uid = Guid.Parse("0cd9e794-17aa-400c-acc3-609b563f9b76");
            User newUser = new User() { Uid = uid, Email = "test", Password = "Aut-1251" };
            repository.Update(newUser);
            repository.Save();
            var user = repository.GetById(uid);
            Assert.IsTrue(user.Email == "test");
        }

        [Test]
        public void TestDeleteUser()
        {
            IGenericRepository<User> repository = new GenericRepository<User>();
            Guid uid = Guid.Parse("0cd9e794-17aa-400c-acc3-609b563f9b76");
            repository.Delete(uid);
            repository.Save();
            var users = repository.GetAll();
            Assert.IsTrue(users.Count() == 1);
        }
    }
}