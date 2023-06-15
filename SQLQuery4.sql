/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [OrderMasterId]
      ,[OrderNumber]
      ,[CustomerId]
      ,[pMethod]
      ,[gTotal]
  FROM [RestaurantDB].[dbo].


  select * from Customers