using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OTB.InterviewChallenge;
using System;

//Test Comments

namespace OTB.InterviewChallenge.Tests
{
    [TestFixture]
    public class JobFactoryTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void GetSortedJobs__EmptyInputStringArguments_ReturnsPassedValidationResult()
        {
            try
            {
                string sortedJobs = "";
                var input = new string[] { };

                JobFactory myFactory = new JobFactory(input);
                sortedJobs = myFactory.GetSortedJobs();

            }
            catch (Exception ex)
            {
                var expected = "Input string arguments can not be empty";
                Assert.That(ex.Message, Is.EqualTo(expected));
            }
        }

        [Test]
        public void GetSortedJobs__InvalidInputStringArguments_ReturnsPassedValidationResult()
        {
            try
            {

                string sortedJobs = "";
                var input = new string[] { "a=>", "b&>c" };

                JobFactory myFactory = new JobFactory(input);
                sortedJobs = myFactory.GetSortedJobs();
            }
            catch (Exception ex)
            {
                var expected = "Input is not in the correct format. Split chars => must exist with a mandatory value on the left of => and an optional value on the right. e.g. a=>b or a=>";
                Assert.That(ex.Message, Is.EqualTo(expected));
            }
        }

        [Test]
        public void GetSortedJobs__StringArrayArgumentsMultipleJobsDependencyOnItself_ReturnsPassedValidationResult()
        {
            try
            {
                string sortedJobs = "";
                var input = new[] { "a=>", "b=>", "c=>c" };

                JobFactory myFactory = new JobFactory(input);
                sortedJobs = myFactory.GetSortedJobs();

            }
            catch (Exception ex)
            {
                var expected = "jobs can’t depend on themselves";
                Assert.That(ex.Message, Is.EqualTo(expected));
            }
        }
        [Test]
        public void GetSortedJobs__StringArrayArgumentsSingleJobNoDependency_ReturnsPassedValidationResult()
        {
            string sortedJobs = "";
            var input = new[] { "a=>" };

            JobFactory myFactory = new JobFactory(input);
            sortedJobs = myFactory.GetSortedJobs();

            var expected = "a";
            Assert.AreEqual(expected, sortedJobs, $"Incorrect output returned. Output should be: {expected}");
        }
        [Test]
        public void GetSortedJobs__StringArrayArgumentsMultipleJobsWithNoDependency_ReturnsPassedValidationResult()
        {
            string sortedJobs = "";
            var input = new[] { "a=>", "b=>", "c=>" };

            JobFactory myFactory = new JobFactory(input);
            sortedJobs = myFactory.GetSortedJobs();

            var expected = "abc";
            Assert.AreEqual(expected, sortedJobs, $"Incorrect output returned. Output should be: {expected}");
        }
        [Test]
        public void GetSortedJobs__StringArrayArgumentsMultipleJobsWithDependency_ReturnsPassedValidationResult()
        {
            string sortedJobs = "";
            var input = new[] { "a=>", "b=>c", "c=>" };

            JobFactory myFactory = new JobFactory(input);
            sortedJobs = myFactory.GetSortedJobs();

            var expected = "acb";
            Assert.AreEqual(expected, sortedJobs, $"Incorrect output returned. Output should be: {expected}");
        }
        [Test]
        public void GetSortedJobs__StringArrayArgumentsMultipleJobsWithMultipleDependency_ReturnsPassedValidationResult()
        {
            string sortedJobs = "";
            var input = new[] { "a=>", "b=>c", "c=>f", "d=>a", "e=>b", "f=>" };

            JobFactory myFactory = new JobFactory(input);
            sortedJobs = myFactory.GetSortedJobs();

            var expected = "afcbde";
            Assert.AreEqual(expected, sortedJobs, $"Incorrect output returned. Output should be: {expected}");
        }

        [Test]
        public void GetSortedJobs__StringArrayArgumentsMultipleJobsCircularDependency_ReturnsPassedValidationResult()
        {
            try
            {
                string sortedJobs = "";
                var input = new[] { "a=>", "b=>c", "c=>f", "d=>a", "e=>", "f=>b" };

                JobFactory myFactory = new JobFactory(input);
                sortedJobs = myFactory.GetSortedJobs();

            }
            catch (Exception ex)
            {
                var expected = "jobs can’t have circular dependencies";
                Assert.That(ex.Message, Is.EqualTo(expected));
            }

        }

        [TearDown]
        public void TearDown()
        {

        }


    }
}
