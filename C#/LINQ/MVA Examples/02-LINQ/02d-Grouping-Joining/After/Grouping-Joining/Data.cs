using System;

namespace Grouping_Joining
{
    static class Data
    {
        public static string[] Names
        {
            get
            {
                return new[]
                { 
                    "Burke", "Connor", "Frank", "Everett", 
                    "Albert", "Johnny", "Harris", "Jeremy" 
                };
            }
        }

        public static AuthorHobby[] AuthorHobbies
        {
            get
            {
                return new[]
                {
                    new AuthorHobby {Name = "Johnny", Hobby = "Computers"},
                    new AuthorHobby {Name = "Johnny", Hobby = "Programming"},
                    new AuthorHobby {Name = "Johnny", Hobby = "Halo3"},
                    new AuthorHobby {Name = "Julie", Hobby = "Wrestling"},
                    new AuthorHobby {Name = "George", Hobby = "Polo"},
                    new AuthorHobby {Name = "Jeremy", Hobby = "Cooking"},
                    new AuthorHobby {Name = "Jeremy", Hobby = "Dining Out"}
                };
            }
        }
    }

    class AuthorHobby
    {
        public string Name { get; set; }
        public string Hobby { get; set; }
    }
}
