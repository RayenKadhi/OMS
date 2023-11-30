SELECT SUM(UnitPrice * Quantity) AS Revenue, MAX(CONVERT(date,OrderDate)) AS OrderDate
FROM Product p JOIN OrderDetails o ON p.ProductId = o.ProductId JOIN [Order] ord ON ord.OrderId = o.OrderId
WHERE OrderDate LIKE '%2020%' GROUP BY MONTH(OrderDate)


SELECT SUM(UnitPrice * Quantity) AS Revenue, MAX(CONVERT(date,OrderDate)) AS OrderDate 
FROM Product p JOIN OrderDetails o ON p.ProductId = o.ProductId JOIN [Order] ord ON ord.OrderId = o.OrderId 
WHERE OrderDate LIKE '%2021%' GROUP BY MONTH(OrderDate)

SELECT SUM(UnitPrice * Quantity) AS Revenue, MAX(CONVERT(date,OrderDate)) AS OrderDate
FROM Product p JOIN OrderDetails o ON p.ProductId = o.ProductId JOIN [Order] ord ON ord.OrderId = o.OrderId
WHERE OrderDate LIKE '%2022%' GROUP BY MONTH(OrderDate)

SELECT TOP(3) CustomerName, TotalPrice FROM CustomerDetailsView ORDER BY TotalPrice DESC;
SELECT TOP(5) CustomerName, TotalPrice FROM CustomerDetailsView ORDER BY TotalPrice DESC;
SELECT TOP(10) CustomerName, TotalPrice FROM CustomerDetailsView ORDER BY TotalPrice DESC;


CREATE FUNCTION GetTopRecordsFunction (@Top INT)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP(@Top) CustomerName, TotalPrice FROM CustomerDetailsView ORDER BY TotalPrice DESC
);

SELECT * FROM GetTopRecordsFunction(5);


CREATE FUNCTION GetRevenueDataFunction (@Year INT)
RETURNS TABLE
AS
RETURN
(
SELECT 
SUM(UnitPrice * Quantity) AS Revenue, 
MAX(CONVERT(date, OrderDate)) AS OrderDate 
FROM 
Product p 
JOIN OrderDetails o ON p.ProductId = o.ProductId 
JOIN [Order] ord ON ord.OrderId = o.OrderId 
WHERE 
OrderDate LIKE '%' + CAST(@Year AS NVARCHAR(4)) + '%' 
GROUP BY 
MONTH(OrderDate)
);


