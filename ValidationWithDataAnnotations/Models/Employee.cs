﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationWithDataAnnotations.Models
{
    public class Employee
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public decimal? YearsOfExperience { get; set; }

        public Address Address { get; set; } = new Address();
    }

    public class Address
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public static IEnumerable<Country> GetCountries()
        {
            return new List<Country>
            {
                new() { Name = "Croatia", Code = "HR" },
                new() { Name = "United Kingdom", Code = "UK" },
                new() { Name = "United States", Code = "US" },
            };
        }
    }

    public class City
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string CountryCode { get; set; }

        public static IEnumerable<City> GetCities()
        {
            return new List<City>
            {
                new() { Name = "San Francisco", CountryCode = "US", Code="US-101" },
                new() { Name = "Los Angeles", CountryCode = "US", Code="US-102" },
                new() { Name = "Boston", CountryCode = "US", Code="US-103" },
                new() { Name = "Portland", CountryCode = "US", Code="US-104" },
                new() { Name = "Split", CountryCode = "HR", Code="HR-101" },
                new() { Name = "Zagreb", CountryCode = "HR", Code="HR-102" },
                new() { Name = "Dubrovnik", CountryCode = "HR", Code="HR-103" },
                new() { Name = "London", CountryCode = "UK", Code="UK-101" },
                new() { Name = "Glasgow", CountryCode = "UK", Code="UK-102" },
                new() { Name = "Liverpool", CountryCode = "UK", Code="UK-103" }
            };
        }
    }

    public class Gender
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public static IEnumerable<Gender> GetGenders()
        {
            return new List<Gender>
            {
                new() { Name = "Male", Code = "A" },
                new() { Name = "Female", Code = "B" },
                new() { Name = "Non-binary", Code = "C" },
                new() { Name = "Transgender", Code = "D" },
                new() { Name = "Intersex", Code = "E" },
                new() { Name = "I prefer not to say", Code = "F" },
            };
        }
    }
}
