using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace Client
{
    public class CRUDManager
    {
        public List<Park> parks = new List<Park>();
        public List<Animal> animals = new List<Animal>();

        public Park park = new Park();
        public Animal animal = new Animal();

        public Uri url = new Uri("https://localhost:44335/api/");

        private Random random = new Random();

        // HELPER

        public bool ParkExists(int ParkId)
        {
            GetParks();
            Thread.Sleep(2000);

            var ParkExists = parks.FirstOrDefault(p => p.ParkId == ParkId);
            if (ParkExists != null) return true;
            else return false;
        }

        public bool AnimalExists(int animalId)
        {
            GetAnimals();
            Thread.Sleep(2000);

            var animalExists = animals.FirstOrDefault(a => a.AnimalId == animalId);
            if (animalExists != null) return true;
            else return false;
        }


        // CREATE

        public async void AddPark(Park park)
        {
            Console.WriteLine("===\tTryin to add New Park\t===");

            if (ParkExists(park.ParkId))
            {
                Console.WriteLine("==\tPark Exists\t==");
                return;
            }
            else
            {
                Console.WriteLine("==\tAdding park\t==");
                using (var httpclient = new HttpClient())
                {
                    // Convert JSON to String Object
                    var httpContent = new StringContent(JsonConvert.SerializeObject(park));

                    // Setting request headers
                    httpContent.Headers.ContentType.MediaType = "application/json";
                    httpContent.Headers.ContentType.CharSet = "UTF-8";

                    // Posting new park into database
                    var response = await httpclient.PostAsync(url + "parks", httpContent);
                    Console.WriteLine(response.StatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("===\tSuccessfully Added\t===");
                    }
                }
            }
        }

        public async void AddAnimal(Animal animal)
        {
            Console.WriteLine("===\tAdding New Animal\t===");

            if (!AnimalExists(animal.AnimalId))
            {
                Console.WriteLine("==\tAnimal Exists\t==");
                return;
            }
            else
            {
                using (var httpclient = new HttpClient())
                {
                    // Convert JSON to String Object
                    var httpContent = new StringContent(JsonConvert.SerializeObject(animal));

                    // Setting request headers
                    httpContent.Headers.ContentType.MediaType = "application/json";
                    httpContent.Headers.ContentType.CharSet = "UTF-8";

                    // Posting new Animal into database
                    var response = await httpclient.PostAsync(url + "parks/", httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("===\tSuccessfully Added\t===");
                    }
                }
            }
        }

        // READ

        public async void GetPark(int ParkId)
        {
            GetParks();
            Thread.Sleep(2000);

            if (!ParkExists(ParkId))
            {
                Console.WriteLine("===\tPark does not exist\t===");
                return;
            }
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url + "parks/" + ParkId);
                park = JsonConvert.DeserializeObject<Park>(response);
            }
        }

        public async void GetAnimal(int AnimalId)
        {
            GetAnimals();
            Thread.Sleep(2000);

            if (!AnimalExists(AnimalId))
            {
                Console.WriteLine("===\tAnimal does not exist\t===");
                return;
            }
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url + "Animals/" + AnimalId);
                animal = JsonConvert.DeserializeObject<Animal>(response);
            }
        }

        public async void GetParks()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url + "parks");
                parks = JsonConvert.DeserializeObject<List<Park>>(response);
            }
        }

        public async void GetAnimals()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url + "animals");
                animals = JsonConvert.DeserializeObject<List<Animal>>(response);
            }
        }

        // UPDATE

        public async void UpdatePark(int targetId, Park updatedPark)
        {
            Console.WriteLine("===\tUpdating Park\t===");
            var httpContent = new StringContent(JsonConvert.SerializeObject(updatedPark));

            // Setting request headers
            httpContent.Headers.ContentType.MediaType = "application/json";
            httpContent.Headers.ContentType.CharSet = "UTF-8";

            using (var httpclient = new HttpClient())
            {
                var targetUrl = url + "parks/" + targetId;
                var response = await httpclient.PutAsync(targetUrl, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("===\tSuccessfully Updated\t===");
                }
                else
                {
                    Console.WriteLine("===\tUnsuccessful Update\t===");
                }
                park = null;
            }
        }

        public async void UpdateAnimal(int targetId, Animal updatedAnimal)
        {
            GetAnimal(targetId);
            Thread.Sleep(2000);

            Console.WriteLine("===\tUpdating Animal\t===");

            var AnimalObj = JsonConvert.SerializeObject(updatedAnimal);
            var httpContent = new StringContent(AnimalObj);

            httpContent.Headers.ContentType.MediaType = "application/json";
            httpContent.Headers.ContentType.CharSet = "UTF-8";

            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.PutAsync(url + "animals/" + targetId, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("===\tSuccessfully Updated\t===");
                }
                else
                {
                    Console.WriteLine(response);
                }
                animal = null;
            }
        }

        // DELETE

        public async void DeleteParkAsync(int parkid)
        {
            if (ParkExists(parkid))
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync(url + "parks/" + parkid);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("===\tSuccessful Async Delete\t===");
                    }
                }
            }
            else
            {
                Console.Write("==\tId does not exist\t===");
            }
        }

        public async void DeleteAnimalAsync(int animalId)
        {
            if (AnimalExists(animalId))
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync(url + "Animals/" + animalId);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("===\tSuccessful Async Delete\t===");
                    }
                }
            }
            else
            {
                Console.Write("==\tId does not exist\t===");
            }
        }
    }
}
