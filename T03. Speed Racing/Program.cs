using System;
using System.Collections.Generic;

namespace T03._Speed_Racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TraveledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TraveledDistance { get; set; }

        public bool CanDriveDistance(double kmToTravel)
        {
            if (FuelConsumption * kmToTravel <= FuelAmount)
            {
                return true;
            }

            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                // AudiA4 23 0.3
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKm = double.Parse(carInfo[2]);

                allCars.Add(new Car(carModel, fuelAmount, fuelConsumptionPerKm));
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                // Drive <CarModel> <amountOfKm>
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = cmdArgs[1];
                double kilometersToTravel = double.Parse(cmdArgs[2]);

                if (allCars.Find(c => c.Model == carModel).CanDriveDistance(kilometersToTravel))
                {
                    Car currentCar = allCars.Find(c => c.Model == carModel);

                    currentCar.FuelAmount -=
                        kilometersToTravel * currentCar.FuelConsumption;

                    currentCar.TraveledDistance += kilometersToTravel;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
