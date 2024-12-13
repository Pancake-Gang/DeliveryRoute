using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Route
{
    internal class Program
    {
        public struct Delivery
        {
            public string location;
            public string eta;
        }
        static string filePath()
        {
            string path = Directory.GetCurrentDirectory();
            string filepath = path + @"\RouteInfo.csv";
            return filepath;
        }
        static void getDeliveryDetails(ref Delivery[] deliveryArray, string filepath)
        {
            StreamReader sr = new StreamReader(filepath);
            int index = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lineParts = line.Split(',');
                if (index != 0)
                {
                    deliveryArray[index - 1] = new Delivery { location = lineParts[0], eta = lineParts[1] };
                }
                index++;
            }
        }
        static void bubbleSort(ref Delivery[] deliveryArray)
        {
            int arraySize = deliveryArray.Length;
            bool swapped = true;
            int passNum = 1;

            while (swapped == true)
            {
                swapped = false;
                for (int i = 0; i < arraySize - passNum; i++)
                {
                    int firstNum = int.Parse(deliveryArray[i].eta);
                    int secondNum = int.Parse(deliveryArray[i + 1].eta);

                    if ( firstNum > secondNum)
                    {
                        string temp = deliveryArray[i].eta;
                        deliveryArray[i].eta = deliveryArray[i + 1].eta;
                        deliveryArray[i + 1].eta = temp;
                        swapped = true;
                    }
                }
                passNum++;
            }
        }
        static void Main(string[] args)
        {
            Delivery[] deliveries = new Delivery[20];
            getDeliveryDetails(ref deliveries, filePath());
            bubbleSort(ref deliveries);

            for (int i = 0; i < deliveries.Length; i++)
            {
                Console.WriteLine($"{deliveries[i].eta}\t{deliveries[i].location}");
            }
        }
    }
}