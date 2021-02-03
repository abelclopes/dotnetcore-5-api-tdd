using System;

namespace domain.Model
{
    public class User : EntidadeBase
    {

        public User()
        {

        }

        public User(string name, int age,  bool isActive)
        {
            Name = name;
            Age = age;
            IsActive = isActive;
        }

        public User( Guid id,  string name, int age, bool isActive)
        {
            Id = id;
            Name = name;
            Age = age;
            IsActive = isActive;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}