using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace HttpClientSample
{
    internal class User
    {

        public string Id;

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string DOB { get; set; }

        
        public string Points { get; set; }

        
        public string Posistion { get; set; }
        //private Boat boat;

        
        public string Address { get; set; }

        
        public string PostCode { get; set; }

        
        public string City { get; set; }

       
        public string Email { get; set; }

        
        public string Password { get; set; }

        
        public string PhoneNumber { get; set; }

        
        public string Team { get; set; }

        //User()
        //{
        //    this.firstName = null;
        //    this.lastName = null;
        //    this.address = null;
        //    this.city = null;
        //    this.postCode = null;
        //    this.phoneNumber = 0;
        //    this.dob = new DateTime(11,12,13);
        //    this.email = null;
        //    this.password = null;
        //    this.posistion = "Spectator";
        //    this.points = 0;
        //}

        //User(string firstName, string lastName, DateTime dob, string posistion,
        //        string address, string postCode, string email, int phoneNumber,
        //        string password, string city)
        //{
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //    this.address = address;
        //    this.city = city;
        //    this.postCode = postCode;
        //    this.phoneNumber = phoneNumber;
        //    this.dob = dob;
        //    this.email = email;
        //    this.password = password;
        //    this.posistion = posistion;
        //    this.points = 0;

        //}
    }
}
