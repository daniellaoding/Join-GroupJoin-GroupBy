using System;
using System.Collections.Generic;
using System.Linq;

namespace Joins
{

    public class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Product(string _name, string _type)
        {
            Name = _name;
            Type = _type;
        }

        public override string ToString()
        {
            return $"Product: {Name}. Type: {Type}";
        }
    }

    public class PhoneContactItem
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneContactItem(string _name, string _number)
        {
            Name = _name;
            PhoneNumber = _number;
        }
    }

    public class MailContactItem
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public MailContactItem(string _name, string _email)
        {
            Name = _name;
            Email = _email;
        }
    }

    public class AddressBookItem
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public AddressBookItem(string _name, string _email, string _number)
        {
            Name = _name;
            Email = _email;
            PhoneNumber = _number;
        }

        public override string ToString()
        {
            return $"Name: {Name}. Email: {Email}. PhoneNumber: {PhoneNumber}";
        }
    }

    public class ComplexAddressBookItem
    {
        public string Name { get; set; }
        public List<string> Emails { get; set; }
        public string PhoneNumber { get; set; }

        public ComplexAddressBookItem(string _name, string _number, IEnumerable<string> _emails)
        {
            Name = _name;
            PhoneNumber = _number;
            Emails = _emails.ToList();
        }

        public override string ToString()
        {
            return Emails.Aggregate($"Name: {Name}. PhoneNumber: {PhoneNumber}. Emails:", (accumulator, email) => $"{accumulator}{Environment.NewLine}-{email}");
        }
    }
}
