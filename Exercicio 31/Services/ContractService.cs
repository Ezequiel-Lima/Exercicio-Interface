using Exercicio_31.Entities;
using System;

namespace Exercicio_31.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService OnlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            OnlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            for (int i = 0; i < months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + OnlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updateQuota + OnlinePaymentService.PaymentFree(updateQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
