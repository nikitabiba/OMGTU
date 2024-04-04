Car car1 = new Car(1);
Car car2 = new Car(2);
Car car3 = new Car(3);
Car car4 = new Car(4);
Garage garage = new Garage();
CarWash carwash = new CarWash();

CheckList(garage.Cars); // Гараж пуст
CheckList(carwash.Cars); // Мойка пуста

Car.CheckCar(car1, garage, carwash);
Car.CheckCar(car2, garage, carwash);
Car.CheckCar(car3, garage, carwash);
Car.CheckCar(car4, garage, carwash);

CheckList(garage.Cars); // Гараж полон
CheckList(carwash.Cars); // Мойка пуста

Car.wash(car1);
Car.wash(car2);
Car.wash(car3);
Car.CheckCar(car1, garage, carwash);
Car.CheckCar(car2, garage, carwash);
Car.CheckCar(car3, garage, carwash);
Car.CheckCar(car4, garage, carwash);

CheckList(garage.Cars); // В гараже car4
CheckList(carwash.Cars); // На мойке car1, car2, car3

Car.ret(car3);
Car.CheckCar(car1, garage, carwash);
Car.CheckCar(car2, garage, carwash);
Car.CheckCar(car3, garage, carwash);
Car.CheckCar(car4, garage, carwash);

CheckList(garage.Cars); // В гараже car3, car4
CheckList(carwash.Cars); // На мойке car1, car2

void CheckList(List<Car> list)
{
    if (list.Count != 0)
    {
        foreach (Car car in list) Console.Write(car.RegistrationNumber + " ");
        Console.WriteLine();
    }
    else Console.WriteLine("Список пуст");
}


class Car
{
    public int RegistrationNumber { get; set; }
    public bool CarInGarage { get; set; } = true;
    public Car(int registrationNumber, bool carInGarage = true)
    {
        RegistrationNumber = registrationNumber;
        CarInGarage = carInGarage;
    }

    public static void WashCar(Car car)
    {
        car.CarInGarage = false;
        Console.WriteLine($"Машина {car.RegistrationNumber} отправлена на мойку");
    }

    public static void ReturnToGarage(Car car)
    {
        car.CarInGarage = true;
        Console.WriteLine($"Машина {car.RegistrationNumber} отправлена в гараж");
    }

    public static void CheckCar(Car car, Garage cars_g, CarWash cars_w)
    {
        if (car.CarInGarage && cars_g.Cars.Contains(car)) Console.WriteLine($"Машина {car.RegistrationNumber} в гараже");
        else if (!car.CarInGarage && !cars_g.Cars.Contains(car)) Console.WriteLine($"Машина {car.RegistrationNumber} на мойке");
        if (!car.CarInGarage && cars_g.Cars.Contains(car))
        {
            bool empty = cars_g.Cars.Remove(car);
            cars_w.Cars.Add(car);
            Console.WriteLine($"Машина {car.RegistrationNumber} доставлена на мойку");
        }
        else if (car.CarInGarage && !cars_g.Cars.Contains(car)) 
        {
            bool empty = cars_w.Cars.Remove(car);
            cars_g.Cars.Add(car);
            Console.WriteLine($"Машина {car.RegistrationNumber} доставлена в гараж");
        }
    }

    public static CarOperation wash = WashCar;
    public static CarOperation ret = ReturnToGarage;
}


class Garage
{
    public List<Car> Cars { get; set; } = new List<Car>();
}


class CarWash
{
    public List<Car> Cars { get; set; } = new List<Car>();
}

delegate void CarOperation(Car car);