using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using AccountApp.Model;

namespace SerialDeserialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account("Sid", 102, 1500);
            a1.deposit(20000);

            Console.WriteLine("\nBefore Serialization Acc Details of A1 i.e. (Initial State): ");
            PrintAccountDetails(a1);

            IFormatter formatter = new BinaryFormatter();
            Stream st = new FileStream("AccountDetails.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(st,a1);
            st.Close();
            
            a1.withdraw(10000);
            a1.withdraw(4500);
            
            Console.WriteLine("\nBefore Deserialization Acc Details of A1:");
            PrintAccountDetails(a1);
            
            st = new FileStream("AccountDetails.txt", FileMode.Open, FileAccess.Read);
            a1 = (Account)formatter.Deserialize(st);
            
            Console.WriteLine("\nAfter Deserialization Acc Details of A1:");
            PrintAccountDetails(a1);
        
            Console.ReadLine();
        }
        static void PrintAccountDetails(Account acc)
        {
            Console.WriteLine("Name: "+acc.Name);
            Console.WriteLine("Id: " + acc.AccNo);
            Console.WriteLine("Balance: " + acc.Balance);
        }
    }
}
