package Algorithms_DataStructures.FinancialForecasting;

public class FinancialForecast {

    public static double calculateFutureValue(double currentValue, double growthRate, int years) {
        if (years == 0) {
            return currentValue;
        }

        return calculateFutureValue(currentValue, growthRate, years - 1) * (1 + growthRate);
    }

    public static void main(String[] args) {

        double currentValue = 10000;
        double growthRate = 0.10;
        int years = 5;

        double futureValue = calculateFutureValue(currentValue, growthRate, years);

        System.out.println("Current Value: " + currentValue);
        System.out.println("Growth Rate: " + (growthRate * 100) + "%");
        System.out.println("Years: " + years);
        System.out.println("Future Value: " + futureValue);

        System.out.println();
        System.out.println("Analysis:");
        System.out.println("Recursion is a technique where a method calls itself to solve smaller parts of a problem.");
        System.out.println("The recursive method calculates future value year by year until years becomes 0.");
        System.out.println("Time Complexity: O(n), where n is the number of years.");
        System.out.println("Space Complexity: O(n), due to recursive call stack.");
        System.out.println("Optimization: Use an iterative loop or direct formula to reduce space complexity.");
    }
}