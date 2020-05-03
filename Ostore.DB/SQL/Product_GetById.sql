﻿drop proc if exists dbo.Product_GetById
go

create proc [dbo].[Product_GetById]
	@Id int
as
begin
	select	
		prod.Id,
		prod.Brand,
		prod.Model,
		prod.Price,
		cat.[Name] as CategoryName,
		subcat.[Name] as SubcategoryName
	from dbo.Product prod
	left join dbo.Subcategory subcat on prod.SubcategoryId = subcat.Id
	left join dbo.CategoryDictionary cat on subcat.CategoryId = cat.Id
	where prod.Id = @Id
end