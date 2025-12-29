using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BIT706AS1
{
    public class Animal
    {
        [Required (ErrorMessage = "A name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "An animal type is required")]
        public AnimalType AnimalType { get; set; }

        public AnimalSex? Sex { get; set; }

        public string? Breed { get; set;}

        public int? Age { get; set; }

        public MicrochipStatus? MicrochipStatus { get; set; }

        public Customer? Customer { get; set; }

        public Microchip? Microchip { get; private set; }

        public Animal(string name, AnimalType animalType, AnimalSex? animalSex, string? breed, int? age,  MicrochipStatus? microchipStatus, Customer? customer, Microchip? microchip)
        {
            Name = name;
            AnimalType = animalType;

            if (animalSex != null)
            {
                Sex = animalSex;
            }
            if (breed != null)
            {
                Breed = breed;
            }
            if (age != null)
            {
                Age = age;
            }
            if (microchipStatus != null)
            {
                MicrochipStatus = microchipStatus;
            }
            if (customer != null)
            {
                Customer = customer;
            }
            if (microchip  != null)
            {
                Microchip = microchip;
            }
        }

        public void AssignMicrochip(Microchip microchip, MicrochipStatus microchipStatus) // This method should check whether there is already a micorchip assigned and whether the micorchip is already assigned. It should also changed the microchip status to microchipped
        {
            if (this.Microchip != null)
            {
                throw new InvalidOperationException("A microchip is already assigned to this animal");
            }
            else
            {
                microchip.UpdateState(MicrochipState.Implanted); // This will run the UpdateState method in microchip. 
                this.Microchip = microchip; // Assigns the Microchip to the animal
                this.MicrochipStatus = BIT706AS1.MicrochipStatus.Microchipped; // Updates the animal's microchip status to Microchipped

            }


        }

        public override string ToString()
        {
            return Name + ", " + Sex + " " + AnimalType + ", " + MicrochipStatus;
        }
    }
}