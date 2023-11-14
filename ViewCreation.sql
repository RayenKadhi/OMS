CREATE VIEW [dbo].[CustomerDetails] AS
SELECT CustomerId, CustomerName, Address, Mobile, Email
FROM Customer
SELECT * FROM CustomerDetails WHERE CustomerId = {id}


