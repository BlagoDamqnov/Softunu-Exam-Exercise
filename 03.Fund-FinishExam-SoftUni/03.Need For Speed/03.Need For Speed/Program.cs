using System;
using System.Collections.Generic;

namespace _03.Need_For_Speed
{
    class Program
    {
        static void Main(string[] args)
        {
            int carNumber = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> carInfo = new Dictionary<string, List<int>>();

            for (int i = 0; i < carNumber; i++)
            {
                string[] aboutCarInfo = Console.ReadLine().Split("|");
                 carInfo.Add(aboutCarInfo[0], new List<int>() { int.Parse(aboutCarInfo[1]), int.Parse(aboutCarInfo[2]) });
            }

            string command = Console.ReadLine();

            while (command!="Stop")
            {
                string[] token = command.Split(" : ",StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "Drive")
                {
                    string carName = token[1];
                    int distance = int.Parse(token[2]);
                    int fuel = int.Parse(token[3]);

                    if (carInfo.ContainsKey(carName))
                    {
                        if (carInfo[carName][1] >= fuel)
                        {
                            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            carInfo[carName][0] += distance;
                            carInfo[carName][1] -= fuel;
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        if (carInfo[carName][0]>=100000)
                        {
                            Console.WriteLine($"Time to sell the {carName}!");
                            carInfo.Remove(carName);
                        }
                    }
                }
                else if (token[0] == "Refuel")
                {
                    string nameCar = token[1];
                    int Refuelfuel = int.Parse(token[2]);
                    int fuelbefore = carInfo[nameCar][1];

                    if (carInfo.ContainsKey(nameCar))
                    {
                        carInfo[nameCar][1] += Refuelfuel;
                        if (carInfo[nameCar][1] > 75)
                        {
                            carInfo[nameCar][1] = 75;
                            Console.WriteLine($"{nameCar} refueled with {75 - fuelbefore} liters");
                        }
                        else
                        {
                            Console.WriteLine($"{nameCar} refueled with {Refuelfuel} liters");
                        }
                    }
                }
                else if (token[0] == "Revert")
                {
                    string nameOfCar = token[1];
                    int km = int.Parse(token[2]);

                    if (carInfo.ContainsKey(nameOfCar))
                    {
                        carInfo[nameOfCar][0] -= km;
                        if (carInfo[nameOfCar][0] < 10000)
                        {
                            carInfo[nameOfCar][0] = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{nameOfCar} mileage decreased by {km} kilometers");
                        }
                    }
                }
                
                command = Console.ReadLine();
            }

            foreach (var item in carInfo)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}
