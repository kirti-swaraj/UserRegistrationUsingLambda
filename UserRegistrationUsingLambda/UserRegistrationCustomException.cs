// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRegistrationCustomException.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace UserRegistrationUsingLambda
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UserRegistrationCustomException : Exception
    {
        public enum ExceptionType
        {
            INVALID_DETAILS
        }
        public readonly ExceptionType type;

        /// <summary>
        /// UC 12 : Created Custom Exception For User Reg Problem
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public UserRegistrationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}