using System;
using System.Collections.Generic;
using System.Text;

namespace FrontDeskManagement
{
    static class InstanceGlobals
    {
        private static string _id = "";
        public static string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private static string _token = "";
        public static string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        private static string _firstName = "";
        public static string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private static string _lastName = "";
        public static string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private static string _birthYear = "";
        public static string BirthYear
        {
            get { return _birthYear; }
            set { _birthYear = value; }
        }
        private static string _username = "";
        public static string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private static string _type = "";
        public static string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
