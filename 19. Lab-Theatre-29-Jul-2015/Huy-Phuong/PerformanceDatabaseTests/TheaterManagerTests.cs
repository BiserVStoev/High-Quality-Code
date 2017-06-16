namespace PerformanceDatabaseTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Huy_Phuong.Exceptions;
    using Huy_Phuong.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TheaterManagerTests
    {
        private static PerformanceDatabase database;

        [TestInitialize]
        public void TestIntialize()
        {
            database = new PerformanceDatabase();
        }

        [TestMethod]
        public void TestListTheatresWhenDatabaseIsEmpty_ShouldReturnAnEmptyCollectionOfTypeString()
        {
            // Arange
            var expectedResult = new List<string>();

            // Act
            var result = database.ListTheatres();

            // Assert 
            Assert.AreEqual(
                expectedResult.Count,
                result.Count(),
                "ListTheatres method returned a collection with a non-zero Count.");
        }

        [TestMethod]
        public void TestListTheatresWhenDatabaseIsEmpty_ShouldReturnACollectionOfTypeString()
        {
            // Arange

            // Act
            var result = database.ListTheatres() as ICollection;

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(
                result,
                typeof(string),
                "ListTheatres method returned a collection of the wrong parameter type.");
        }

        [TestMethod]
        public void TestListTheatresWithOneEntryInTheDatabase_ShouldReturnACollectionOfOneElement()
        {
            // Arange
            var expectedResult = 1;
            
            // Act
            database.AddTheatre("Theatre Sofia");
            var result = database.ListTheatres() as ICollection;

            // Assert
            Assert.AreEqual(expectedResult, result.Count, "ListTheatres method returned a collection of a wrong size.");
        }

        [TestMethod]
        public void TestListTheatresWithOneEntryInTheDatabase_ShouldReturnACollectionOfStrings()
        {
            // Arange
            var database = new PerformanceDatabase();

            // Act
            database.AddTheatre("Theatre Sofia");
            var result = database.ListTheatres() as ICollection;

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(
                result,
                typeof(string),
                "ListTheatres method returned a collection of a wrong type.");
        }

        [TestMethod]
        public void TestListTheatresWithOneEntryInTheDatabase_ShouldReturnACollectionWithCorrectValues()
        {
            // Arange
            var expectedResult = new string[] { "Theatre Sofia" } as ICollection;

            // Act
            database.AddTheatre("Theatre Sofia");
            var result = database.ListTheatres() as ICollection;

            // Assert
            CollectionAssert.AreEquivalent(
                expectedResult,
                result,
                "ListTheatres method returned a collection with wrong values.");
        }

        [TestMethod]
        public void TestListTheatresWithThreeEntriesInTheDatabase_ShouldReturnACollectionOfThreeElements()
        {
            // Arange
            var expectedResult = 3;

            // Act
            database.AddTheatre("Theatre Sofia");
            database.AddTheatre("Theatre Test");
            database.AddTheatre("Theatre Ivan Vazov");
            var result = database.ListTheatres() as ICollection;

            // Assert
            Assert.AreEqual(expectedResult, result.Count, "ListTheatres method returned a collection of a wrong size.");
        }

        [TestMethod]
        public void TestListTheatresWithThreeEntriesInTheDatabase_ShouldReturnACollectionOfStrings()
        {
            // Arange

            // Act
            database.AddTheatre("Theatre Sofia");
            database.AddTheatre("Theatre Test");
            database.AddTheatre("Theatre Ivan Vazov");
            var result = database.ListTheatres() as ICollection;

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(
                result,
                typeof(string),
                "ListTheatres method returned a collection of a wrong type.");
        }

        [TestMethod]
        public void TestListTheatresWithThreeEntriesInTheDatabase_ShouldReturnACollectionWithCorrectValues()
        {
            // Arange
            var expectedResult = new string[] { "Theatre Sofia", "Theatre Test", "Theatre Ivan Vazov" } as ICollection;

            // Act
            database.AddTheatre("Theatre Sofia");
            database.AddTheatre("Theatre Test");
            database.AddTheatre("Theatre Ivan Vazov");
            var result = database.ListTheatres() as ICollection;

            // Assert
            CollectionAssert.AreEquivalent(
                expectedResult,
                result,
                "ListTheatres method returned a collection with wrong values.");
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddPerformanceWithAnIncorrectTheaterName_ShouldThrowAnException()
        {
            // Arange
            var date = new DateTime(2000, 10, 10, 10, 30, 30);
            var duration = new TimeSpan(0, 2, 0, 0);

            // Act
            database.AddPerformance("Test", "TestPerformance", date, duration, 10m);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void TestAddPerformanceWithAnOverlapingTIme_ShouldThrowAnException()
        {
            // Arange
            var date = new DateTime(2000, 10, 10, 10, 30, 30);
            var duration = new TimeSpan(0, 2, 0, 0);

            // Act
            database.AddTheatre("Test Theatre");
            database.AddPerformance("Test Theatre", "TestPerformance", date, duration, 10m);
            database.AddPerformance("Test Theatre", "TestPerformance2", date, duration, 10m);

            // Assert
        }

        [TestMethod]
        public void TestAddPerformance_ShouldAddAPerformanceToTheSpecifiedTheatre()
        {
            // Arange
            string theatreName = "Test Theatre";
            string performanceName = "TestPerformance";
            var date = new DateTime(2000, 10, 10, 10, 30, 30);
            var duration = new TimeSpan(0, 2, 0, 0);
            decimal price = 10m;
            var expectedPerformance = new Performance(performanceName, theatreName, date, duration, price);

            // Act
            database.AddTheatre(theatreName);
            database.AddPerformance(theatreName, performanceName, date, duration, price);
            var result = database.ListPerformances(theatreName).First();

            // Assert
            Assert.AreEqual(
                expectedPerformance.Date,
                result.Date,
                "AddPerformanceMethod saved and incorrect performance.");
            Assert.AreEqual(
                expectedPerformance.Name,
                result.Name,
                "AddPerformanceMethod saved and incorrect performance.");
            Assert.AreEqual(
                expectedPerformance.Duration,
                result.Duration,
                "AddPerformanceMethod saved and incorrect performance.");
            Assert.AreEqual(
                expectedPerformance.Price,
                result.Price,
                "AddPerformanceMethod saved and incorrect performance.");
            Assert.AreEqual(
                expectedPerformance.Theater, 
                theatreName,
                "AddPerformanceMethod saved and incorrect performance.");
        }

        [TestMethod]
        public void TestListAllPerformancesWhenDatabaseIsEmpty_ShouldReturnAnEmptyCollection()
        {
            // Arange
            int expectedResult = 0;

            // Act
            var result = database.ListAllPerformances();

            // Assert
            Assert.AreEqual(
                expectedResult,
                result.Count(),
                "ListAllPerformances method returned a collection of a wrong size.");
        }

        [TestMethod]
        public void TestListAllPerformancesWithOneElementInTheDatabase_ShouldReturnACollectionWithOneElement()
        {
            // Arange
            var expectedResult = 1;
            string theatreName = "Test Theatre";
            string performanceName = "TestPerformance";
            var date = new DateTime(2000, 10, 10, 10, 30, 30);
            var duration = new TimeSpan(0, 2, 0, 0);
            decimal price = 10m;

            // Act
            database.AddTheatre(theatreName);
            database.AddPerformance(theatreName, performanceName, date, duration, price);
            var result = database.ListAllPerformances();

            // Assert
            Assert.AreEqual(
                expectedResult,
                result.Count(),
                "ListAllPerformances method returned a collection of a wrong size.");
        }
    }
}
