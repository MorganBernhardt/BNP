using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace C_Sharp_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            c_test nt = new c_test();

            nt.go("https://focus.interview/api/v1.0/payments/100", @"C:\temp\", "result100.txt");
            nt.go("https://focus.interview/api/v1.0/payments/110", @"C:\temp\", "result110.txt");
            nt.go("https://focus.interview/api/v1.0/payments/150", @"C:\temp\", "result150.txt");
        }
    }
}