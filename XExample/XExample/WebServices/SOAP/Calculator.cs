using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace XExample.WebServices.SOAP
{
    public class Calculator
    {
        private CalculatorService.CalculatorSoap SOAPClient;
        const string EndPointURL = @"http://www.dneonline.com/calculator.asmx?wsdl";

            
        /// <summary>
        /// Create a new Web service client instance.
        /// </summary>
        public Calculator()
        {
            EndpointAddress EndPoint = new EndpointAddress(EndPointURL);
            SOAPClient = new CalculatorService.CalculatorSoapClient(new BasicHttpBinding(), EndPoint);
        }

        /// <summary>
        /// Call the web service that add two numbers.
        /// </summary>
        /// <param name="Number1">First number to add.</param>
        /// <param name="Number2">Second number to add.</param>
        /// <returns>Result of adding two numbers.</returns>
        public async Task <string>  AddTwoNumbers(int Number1, int Number2)
        {
            try
            {
                var Result = await Task.Factory.FromAsync(SOAPClient.BeginAdd, SOAPClient.EndAdd, Number1, Number2,TaskCreationOptions.None);
                return Result.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
