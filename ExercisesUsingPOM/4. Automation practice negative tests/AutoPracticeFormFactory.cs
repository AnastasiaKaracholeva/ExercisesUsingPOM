using AutoFixture;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._4._Automation_practice_negative_tests
{
    public static class AutoPracticeFormFactory
    {
        public static AutoPracticeModels CreateUser()
        {
            var fixture = new Fixture();

            return new AutoPracticeModels
            {
                FirstName = "John",
                LastName = "Doe",
                Email = fixture.Create<string>() + "@gmail.com",
                Password = "password123",
                Address = "825 Shelby Dry Frk, Shelbiana",
                City = "Montana",
                State = "Georgia",
                PostalCode = "92009",
                MobilePhone = "1234567899"
            };
        }
    }
}
