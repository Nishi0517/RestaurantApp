
select * from [OrderMasters]
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *
  FROM [RestaurantDB].[dbo].[OrderDetails]
  --select * from Customers
  --select * from FoodItems

  insert into OrderMasters values(1,1,'Cash',3)
  insert into OrderDetails values(3,1,10,1)