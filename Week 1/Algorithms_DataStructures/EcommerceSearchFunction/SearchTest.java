package Algorithms_DataStructures.EcommerceSearchFunction;

public class SearchTest {

    public static Product linearSearch(Product[] products, int searchId) {
        for (int i = 0; i < products.length; i++) {
            if (products[i].productId == searchId) {
                return products[i];
            }
        }
        return null;
    }

    public static Product binarySearch(Product[] products, int searchId) {
        int left = 0;
        int right = products.length - 1;

        while (left <= right) {
            int mid = (left + right) / 2;

            if (products[mid].productId == searchId) {
                return products[mid];
            } else if (products[mid].productId < searchId) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return null;
    }

    public static void main(String[] args) {

        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Shoes", "Fashion"),
            new Product(103, "Phone", "Electronics"),
            new Product(104, "Watch", "Accessories"),
            new Product(105, "Book", "Education")
        };

        Product result1 = linearSearch(products, 103);

        if (result1 != null) {
            System.out.println("Linear Search Result:");
            result1.displayProduct();
        } else {
            System.out.println("Product not found using Linear Search");
        }

        System.out.println();

        Product result2 = binarySearch(products, 104);

        if (result2 != null) {
            System.out.println("Binary Search Result:");
            result2.displayProduct();
        } else {
            System.out.println("Product not found using Binary Search");
        }

        System.out.println();
        System.out.println("Analysis:");
        System.out.println("Big O notation is used to describe how an algorithm performs as input size increases.");
        System.out.println("Linear Search Time Complexity: Best O(1), Average O(n), Worst O(n).");
        System.out.println("Binary Search Time Complexity: Best O(1), Average O(log n), Worst O(log n).");
        System.out.println("Binary Search is more suitable for large e-commerce platforms if products are sorted.");
    }
}
