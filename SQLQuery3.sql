insert [dbo].Customers ([CustomerName]) values (N'abc')
go
insert [dbo].Customers ([CustomerName]) values (N'abcd')
go
insert [dbo].Customers ([CustomerName]) values (N'xyz')
go
insert [dbo].Customers ([CustomerName]) values (N'mno')
go
insert [dbo].Customers ([CustomerName]) values (N'def')
go
insert [dbo].Customers ([CustomerName]) values (N'spo')


set identity_insert [dbo].[fooditems] ON
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (1,N'Chiense',Cast(3.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (2,N'Pavbhaji',Cast(13.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (3,N'Dhosa',Cast(10.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (4,N'Pizza',Cast(8.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (5,N'Frenky',Cast(2.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (6,N'Fries',Cast(3.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (7,N'Cold-drinks',Cast(9.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (8,N'Burger',Cast(5.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (9,N'Garlic bread',Cast(4.50 as decimal(18,2)))
go
insert [dbo].FoodItems([FoodItemId],[FoodItemName],[Price]) values (10,N'Pasta',Cast(7.50 as decimal(18,2)))
go
set identity_insert [dbo].[FoodItems] OFF

  
