using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OTB.InterviewChallenge;
using System;

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
                string expected = "INVALID STRING";

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

                string expected = "INVALID STRING";
            }
            catch (Exception ex)
            {
                var expected = "Input is not in the correct format. Split chars => must exist with a mandatory value on the left of => and an optional value on the right. e.g. a=>b or a=>";
                Assert.That(ex.Message, Is.EqualTo(expected));
            }
        }

        [TearDown]
        public void TearDown()
        {

        }


    }
}
