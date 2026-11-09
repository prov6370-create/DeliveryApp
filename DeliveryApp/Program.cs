namespace DeliveryApp;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        DeliveryService service = new DeliveryService();
        Bike bike = new Bike("Велосипед");
        Car car = new Car("Автомобіль");
        Truck truck = new Truck("Вантажівка");
        Moto moto = new Moto("Мотоцикл");
        service.AddTransport(bike);
        service.AddTransport(car);
        service.AddTransport(truck);
        service.AddTransport(moto);

        Order o1 = new Order(1, "Книги", 3.5, 4);
        Order o2 = new Order(2, "Холодильник", 100, 12);
        Order o3 = new Order(3, "Документи", 1, 15);
        Order o4 = new Order(4, "Піца", 2, 3);

        Console.WriteLine("=== 1. Вартість доставки ===");
        service.ShowCosts(o1);
        service.ShowCosts(o2);
        service.ShowCosts(o3);

        Console.WriteLine();
        Console.WriteLine("=== 2. Призначення ===");
        service.Assign(o2, bike);   // велосипед вільний, але заказ занадто важкий
        service.Assign(o3, bike);   // велосипед вільний, але занадто далеко
        service.Assign(o1, bike);   // успіх
        service.Assign(o4, bike);   // велосипед тепер зайнятий
        service.Assign(o2, truck);// успіх
        service.Assign(o3, car);
        // TODO: призначи o3 на car (має вийти успіх)
        service.ShowActiveOrders();

        Console.WriteLine();
        Console.WriteLine("=== 3. Доставка ===");
        service.Deliver(o1, new CardPayment());
        service.Deliver(o2, new CashPayment());
        service.Deliver(o3, new CardPayment());
        // TODO: доставь o3 карткою
        service.Deliver(o1, new CardPayment());   // вже доставлений
        service.Deliver(o4, new CashPayment());   // ніколи не призначався

        Console.WriteLine();
        Console.WriteLine("=== 4. Транспорт знову вільний ===");
        service.Assign(o4, bike);   // велосипед звільнився, тепер успіх
        service.Deliver(o4, new CashPayment());

        Console.WriteLine();
        Console.WriteLine("=== 5. Підсумок ===");
        service.ShowActiveOrders();
        service.ShowHistory();
    }

}