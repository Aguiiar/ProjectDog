using registerDog.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace registerDog.Controllers
{
    public class DogController : Controller
    {

        private static List<Dog> dogs = new List<Dog>();
        private static int nextId = 1; 



        [HttpGet]
        public IActionResult Register(int? id)
        {
            if (id.HasValue)
            {
                var dog = dogs.FirstOrDefault(d => d.Id == id.Value);
                if(dog != null)
                {
                    return View(dog);
                }
            }
            return View(new Dog());
        }

        [HttpPost]
        public IActionResult Register(Dog dog)
        {
            if (ModelState.IsValid)
            {
                if(dog.Id == 0)
                {
                    dog.Id = nextId++;
                    dogs.Add(dog);

                }
                else
                {
                    var exitingDog = dogs.FirstOrDefault(d => d.Id == dog.Id);
                    if(exitingDog!= null)
                    {
                        exitingDog.Name = dog.Name;
                        exitingDog.Breed = dog.Breed;
                        exitingDog.Age = dog.Age;
                        exitingDog.Sex = dog.Sex;
                    }
                }
                return RedirectToAction("Index");

            }

            return View(dog);
          
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(dogs);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if(dog != null)
            {
                dogs.Remove(dog);
            }
            return RedirectToAction("Index");
        }


      
    }
}
