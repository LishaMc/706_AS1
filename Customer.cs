using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BIT706AS1
{
    public class Customer
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public ArrayList? Animals { get; set; }

        public Customer(string Name, string? Email, string Address, string? PhoneNumber)
        {
            this.Name = Name; // Can set these are they are both required
            this.Address = Address;


            if ((string.IsNullOrWhiteSpace(Email)) && (string.IsNullOrWhiteSpace(PhoneNumber))) // Check to see whether either of these are empty
            {
                throw new ArgumentException("Minimum requirement: enter either email or phone number");
            }
            else if((!string.IsNullOrWhiteSpace(Email)) && (!string.IsNullOrWhiteSpace(PhoneNumber))) // Check if both are provided
            {
                
                this.Email = Email;
                this.PhoneNumber = PhoneNumber;
            }
            else if (!string.IsNullOrWhiteSpace(PhoneNumber)) // Check if the PhoneNumber is provided
            {
                this.PhoneNumber = PhoneNumber;
                
            }
            else // Check if just the Email is provided
            {
                this.Email = Email;
               
            }
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public override string ToString()
        {
            if(PhoneNumber is null)
            {
                return Name + ", " + Email;
            }else if(Email is null)
            {
                return Name + ", " + PhoneNumber;
            }
            else
            {
                return Name + ", " + PhoneNumber + ", " + Email;
            }
                
        }
    }
}