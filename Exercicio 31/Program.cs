using Exercicio_31.Entities;
using Exercicio_31.Services;
using System;

namespace Exercicio_31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data");
                Console.Write("Number: ");
                int contractNumber = int.Parse(Console.ReadLine());

                Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Contract value: ");
                double contractValue = double.Parse(Console.ReadLine());

                Console.Write("Enter number of installments: ");
                int numberInstallments = int.Parse(Console.ReadLine());

                Contract myContract = new Contract(contractNumber, date, contractValue);

                ContractService contractService = new ContractService(new PaypalService());
                contractService.ProcessContract(myContract, numberInstallments);

                Console.WriteLine("Installments:");
                foreach (Installment installment in myContract.Installments)
                {
                    Console.WriteLine(installment);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($">{e.Message}");
            }

            Console.WriteLine("\nPress any key to finish!");
            Console.ReadKey();
        }
    }
}
