using System.ComponentModel.DataAnnotations;

namespace registerDog.Models
{
    public class Dog
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        public string Breed { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        public string Sex { get; set; }

        public Dog()
        {
        }

        public Dog(int id, string name, string breed, int idade, string sexo)
        {
            Id = id;
            Name = name;
            Breed = breed;
            Age = idade;
            Sex = sexo;
        }

     
    }
}
