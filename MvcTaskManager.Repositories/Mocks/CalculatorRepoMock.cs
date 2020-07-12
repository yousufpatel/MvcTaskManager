using System;
using System.Collections.Generic;
using System.Text;
using MvcTaskManager.Repositories.Contracts;

namespace MvcTaskManager.Repositories.Mocks
{
    public class CalculatorRepoMock : ICalculatorRepo
    {
        public int add(int a, int b)
        {
            int result = a + b;
            if(result > 10)
            {
                throw new ArithmeticException("Please check the values");
            }
            else
            {
                return a + b;
            }
           
        }
    }
}
