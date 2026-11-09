namespace DeliveryApp;

interface IPayment
{
    void Pay(double amount);
}

class CardPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплата карткою: {amount} грн");
    }
}
class CashPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплата готівкою: {amount} грн");
    }
}