using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BIT706AS1
{
    public class Microchip
    {
        [Required (ErrorMessage ="Microchip is required")]
        public string MicrochipNumber { get; private set; }

        [Required(ErrorMessage = "Microchip State is required")]
        public MicrochipState MicrochipState { get; private set; }

        [Required(ErrorMessage = "Target Animal is required")]
        public AnimalType TargetAnimal { get; set; }

        public DateOnly? IssueDate { get; set; }

        public Microchip(long microchipNumber, MicrochipState microchipState, AnimalType targetAnimal)
        {
            MicrochipState = microchipState;
            TargetAnimal = targetAnimal;

            FormatMicrochip(microchipNumber);
        }

        public void FormatMicrochip(long microchipNumber)
        {
            // The Microchip needs to be formatting through a checksum before it is used

            // Add together all the digits in the given Microchip  Number

            long microchipSum = 0; // Sets an initial value for the microchipSum so we can add our numbers to it
            long firstNum = 0; // The variable for splitting the checkSum - ones column
            long secondNum = 0; // Another variable for splitting the checkSum - tens column
            long thirdNum = 0; // A third variable, in case the number is in the hundreds - hundreds column
            long microchipToProcess = microchipNumber; // A seperate variable for adding up the checkSum so we can use the original microchipNumber later on
            long checkSum = 0; // The final checkSum


            while (microchipToProcess != 0) // This loop takes the given microchipNumber and iterates through it until it is equal to zero
            {
                microchipSum += microchipToProcess % 10; // Modulus returns the remaining of a number once it is divided by 10. This will always leave us the number in the "ones" column
                microchipToProcess /= 10; // Divides the number by 10 so that the last number is removed (we don't need it because we have already added it to the sum above)
            }

            // Find the lowest of the digits produced by the checkSum

            // Splitting the checkSum into two separate numbers to be compared
            firstNum += microchipSum % 10; // divide the sum by ten and the remainder is allocated (should be the digit in the ones column)
            microchipSum /= 10; // This will remove the number in the ones column
            secondNum += microchipSum % 10; // divide the sum by ten and the remainder is allocated (should be the digit from the tens column)

            if (microchipSum != 0) // Evaluate whether there is still value remaining
            {
                microchipSum -= secondNum; // This will remove the number from the tens column
                thirdNum = microchipSum /= 10; // Divide the Sum by 10 to leave the numbers in the hundreds column
                checkSum = Math.Min(firstNum, secondNum); // Check which is smaller between the first two numbers
                checkSum = Math.Min(checkSum, thirdNum); // Check whether the last number is smaller than the above smaller number
            }
            else
            {
                checkSum = Math.Min(firstNum, secondNum); // Check which is smaller between the first two numbers
            }

            // Converting the microchipNumber and checkSum into a string so they can be concatenated rather than added
            string sMicrochip = Convert.ToString(microchipNumber);
            string sCheckSum = Convert.ToString(checkSum);
            string microchipCheckSum = sMicrochip + sCheckSum;

            // Formatting the microchip number to the required format with the dashes
            string formattedMicrochip = String.Format("{0: 0000-0000-0000-0000-0000}", ulong.Parse(microchipCheckSum));
            this.MicrochipNumber = formattedMicrochip;
        }

        public void UpdateState(MicrochipState microchipState) // The below method updates the microchip state but first checks whether the microchip state is already set.
        {
            if(microchipState == this.MicrochipState)
            {
                if (microchipState == MicrochipState.Implanted) // This if statement checks whether the microchip is already in use
                {
                    throw new InvalidOperationException("This Microchip has already been implanted");
                }
                else
                {
                    Console.WriteLine("No change required (the state remains the same)");
                }
            }
            else
            {
                this.MicrochipState = microchipState;
            }
        }

        public override string ToString()
        {
            return MicrochipNumber + ", " + TargetAnimal + ", " + "issued: " + IssueDate + ", " + MicrochipState;
        }
    }
}