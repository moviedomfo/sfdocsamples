
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Globalization;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Xml;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a client
            CalculatorClient client = new CalculatorClient();

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            // Call the Sum service operation.
            int[] values = { 1, 2, 3, 4, 5 };

            using (new OperationContextScope(client.InnerChannel))
            {
                Message request = Message.CreateMessage(OperationContext.Current.OutgoingMessageHeaders.MessageVersion, 
                    "http://Microsoft.ServiceModel.Samples/ICalculator/Sum", values);

                Message reply = client.Sum(request);

                int sum = reply.GetBody<int>();
                Console.WriteLine("Sum(1,2,3,4,5) = {0}", sum);
            }

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }

    }

}
