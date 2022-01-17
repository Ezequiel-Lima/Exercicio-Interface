namespace Exercicio_31.Services
{
    public interface IOnlinePaymentService 
    {
        double PaymentFree(double amount);
        double Interest(double amount, int months);
    }
}
