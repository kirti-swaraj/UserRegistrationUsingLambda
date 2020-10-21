// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidEntry.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace UserRegistrationUsingLambda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Text;
    using System.Text.RegularExpressions;
    public class ValidEntry
    {
        private readonly List<UserDetails> userDetailsList = new List<UserDetails>();

        /// <summary>
        /// UC 13 : Refactor to use Lambda Exp to validate user details
        ///         Func AreValid declared which returns true if valid entry otherwise false. 
        /// </summary>
        public static Func<string, string, bool> AreValid = (userEntry, pattern) => Regex.IsMatch(userEntry, pattern);

        /// <summary>
        /// UC 1-2 : Validates the first name of the or last.
        /// </summary>
        /// <returns></returns>
        public string ValidateFirstOrLastName()
        {
            //Pattern for valid first or last name
            string firstOrLastNamePattern = @"^[A-Z]{1}[a-zA-Z]{2,}$";
            while (true)
            {
                //User input        
                string firstOrLastName = Console.ReadLine();
                //IF valid first or last name
                if (AreValid(firstOrLastName, firstOrLastNamePattern))
                {
                    Console.WriteLine("Thank you for entering a valid name");
                    return firstOrLastName;
                }
                //If invalid first or last name
                else
                {
                    Console.WriteLine("Invalid name! Enter again: must have atleast 3 characters and first letter must be capital");
                }
            }
        }
        /// <summary>
        /// UC 3 : Validates the email.
        /// </summary>
        /// <returns></returns>
        public string ValidateEmail()
        {
            //Pattern for valid email
            string emailPattern = @"^[a-zA-Z0-9]+([.+_-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+([.][a-zA-Z]{3})+([.][a-zA-Z]{2})?$";
            while (true)
            {
                //User input
                Console.WriteLine("Enter the email of the user");
                string email = Console.ReadLine();
                //If valid email
                if (AreValid(email, emailPattern))
                {
                    Console.WriteLine("Thank you for entering a valid email");
                    return email;
                }
                //If invalid email
                else
                {
                    Console.WriteLine("Invalid email:" + email);
                }
            }
        }

        /// <summary>
        /// UC 4 : Validates the mobile number.
        /// </summary>
        /// <returns></returns>
        public string ValidateMobileNumber()
        {
            //Pattern for valid mobile number
            //string mobileNumberPattern = @"^91[ ][6-9]{1}[0-9]{9}$";
            string mobileNumberPattern = @"^[0-9]{2}[ ][0-9]{10}$";
            while (true)
            {
                //User input
                Console.WriteLine("Enter the country code and mobile number of the user");
                string mobileNumber = Console.ReadLine().ToString();
                //IF valid mobile number
                if (AreValid(mobileNumber, mobileNumberPattern))
                {
                    Console.WriteLine("Thank you for entering a valid mobile number");
                    return mobileNumber;
                }
                //If invalid mobile number
                else
                {
                    Console.WriteLine("Invalid mobile number");
                }
            }
        }

        /// <summary>
        /// Uc 5-8 : Validates the password.
        /// </summary>
        /// <returns></returns>
        public string ValidatePassword()
        {
            //Pattern for valid password  
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[^0-9a-zA-Z])(?!.*[^0-9a-zA-Z].*[^0-9a-zA-Z]).{8,}$";
            while (true)
            {
                //User input
                Console.WriteLine("Enter the password");
                string password = Console.ReadLine().ToString();
                //IF valid password
                if (AreValid(password, passwordPattern))
                {
                    Console.WriteLine("Voila! You entered a strong password");
                    return password;
                }
                //If invalid password
                else
                {
                    Console.WriteLine("Invalid password: It must contain at least one each of Upper case, number and special character and must be 8 chars long\n");
                }
            }
        }
        /// <summary>
        /// Registers the user details.
        /// </summary>
        public void RegisterUserDetails()
        {
            Console.WriteLine("Enter a valid first name:");
            string firstName = ValidateFirstOrLastName();
            Console.WriteLine("Enter a valid last name:");
            string lastName = ValidateFirstOrLastName();
            string email = ValidateEmail();
            string mobileNumber = ValidateMobileNumber();
            string password = ValidatePassword();
            UserDetails userDetails = new UserDetails(firstName, lastName, email, mobileNumber, password);
            userDetailsList.Add(userDetails);
            Console.Clear(); 
            Console.WriteLine("User Details:\n");
            foreach (var v in userDetailsList)
            {
                Console.WriteLine("First Name: " + v.firstName + "\nLast Name: " + v.lastName + "\nEmail: " + v.email + "\nMobile Number: " + v.mobileNumber + "\nPassword: " + v.password + "\n");
            }
        }

        /// <summary>
        /// UC 9 : Checks the given email samples to give valid and invalid emails out.
        /// </summary>
        public void CheckEmailSamples()
        {
            string[] samples = {"abc@yahoo.com","abc-100@yahoo.com", "abc.100@yahoo.com", "abc111@abc.com",
            "abc-100@abc.net", "abc.100@abc.com.au", "abc@1.com", "abc@gmail.com.com", "abc+100@gmail.com", "abc",
            "abc@.com.my", "abc123@gmail.a", "abc123@.com", "abc123@.com.com", ".abc@abc.com", "abc()*@gmail.com",
            "abc@%*.com", "abc..2002@gmail.com", "abc.@gmail.com", "abc@abc@gmail.com", "abc@gmail.com.1a",
            "abc@gmail.com.aa.au" };
            string emailPattern = @"^[a-zA-Z0-9]+([.+_-][a-zA-Z0-9]+)*[@][a-zA-Z0-9]+([.][a-zA-Z]{3})+([.][a-zA-Z]{2})?$";
            Regex regex = new Regex(emailPattern);
            string[] validEmails = samples.Where(sample => regex.IsMatch(sample) == true).ToArray();
            string[] invalidEmails = samples.Where(sample => regex.IsMatch(sample) == false).ToArray();
            foreach (var v in validEmails)
            {
                Console.WriteLine("Valid Email: " + v);
            }
            foreach (var v in invalidEmails)
            {
                Console.WriteLine("Invalid email:" + v);
            }
        }

        /// <summary>
        /// UC 10 : Returns true if ... the pattern and userValue matches
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="userValue">The user value.</param>
        /// <returns>
        ///   <c>true</c> if the specified pattern is valid; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="UserRegistrationCustomException">Exception: Invalid Details Entered</exception>
        public static bool IsValid(string userValue, string pattern)
        {
                if (AreValid(userValue, pattern))
                    return true;
                else
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_DETAILS, "Exception: Invalid Details Entered");
                }
        }
    }
}