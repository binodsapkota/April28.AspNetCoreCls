// See https://aka.ms/new-console-template for more information
using InheritanceAndPolymorphism;

Console.WriteLine("Hello, World!");


ElectricCar electricCar = new ElectricCar();
electricCar.StartEngine();

PetrolCar petrolCar = new PetrolCar();
petrolCar.StartEngine();


Animal animal = new Animal();
animal.MakeSound();

Dog dog = new Dog();
dog.MakeSound();




Circle circle = new Circle();
circle.Draw();

Rectangle rectangle = new Rectangle();
rectangle.Draw();