CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO Products VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00),
(5, 'Keyboard', 'Accessories', 150.00),
(6, 'Mouse', 'Accessories', 100.00),
(7, 'Chair', 'Furniture', 500.00),
(8, 'Table', 'Furniture', 500.00),
(9, 'Shelf', 'Furniture', 300.00);

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNumber,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankValue,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankValue
    FROM Products
) AS RankedProducts
WHERE RowNumber <= 3;