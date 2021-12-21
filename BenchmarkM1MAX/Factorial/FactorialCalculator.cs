namespace BenchmarkM1MAX.Factorial;

public class FactorialCalculator
{
    public int FactorialIterative(int number)
    {
        int n = 0;
        while (number > 0)
        {
            n = number;
            for (int i = n - 1; i > 0; i--)
            {
                n *= i;
            }
            number--;
        }
        return n;
    }
    
    public int FactorialRecursive(int number)
    {
        if (number == 1)
            return 1;
        else
            return number*FactorialRecursive(number - 1);
    }
    
}