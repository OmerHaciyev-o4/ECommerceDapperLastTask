create database ECommerceDapperDb
use ECommerceDapperDb

create table Admins(
[Id] int primary key identity(1, 1) not null,
[Username] nvarchar(30) not null,
[Password] nvarchar(30) not null)

insert into Admins([Username], [Password])
values('omer.o4', '04118'), ('Elvin', '1999')

create table Users(
[Id] int primary key identity(1, 1) not null,
[Username] nvarchar(30) not null unique,
[Password] nvarchar(30) not null)

insert into Users([Username], [Password])
values('kamran', 'kam123'), ('hesen', 'hesen753'), ('orxan', '951')

create table Products(
[Id] int primary key identity(1, 1) not null,
[Code] int not null unique,
[Name] nvarchar(30) not null,
[Quantity] int not null,
[Price] float not null)

drop table Orders

create table Orders(
[Id] int primary key identity(1, 1) not null,
[ProductId] int foreign key references Products([Id]) on delete cascade not null,
[UserId] int foreign key references Users([Id]) on delete cascade not null,
[Date] datetime2 not null,
[Quantity] int not null,
[Price] float not null)

---------

create procedure AddAdmin
@Name as nvarchar(30),
@Pass as nvarchar(30)
as
begin
    declare @state as int = 0;
    select @state = 1
    from Admins as A
    where A.[Username] = @Name and A.[Password] = @Pass
    if @state = 1
    begin
        rollback transaction
    end
    else
    begin
        insert into Admins([Username], [Password])
        values(@Name, @Pass)
    end
end

create procedure AddUser
@Name as nvarchar(30),
@Pass as nvarchar(30)
as
begin
    declare @state as int = 0;
    select @state = 1
    from Users as S
    where S.[Username] = @Name and S.[Password] = @Pass
    if @state = 1
    begin
        rollback transaction
    end
    else
    begin
        insert into Users([Username], [Password])
        values(@Name, @Pass)
    end
end

create procedure AddProduct
@Code as int,
@Name as nvarchar(30),
@Quantity as int,
@Price as float
as
begin
    declare @state as int = 0
    select @state = 1
    from Products as P
    where P.[Code] = @Code
    if (@state = 1)
    begin
        rollback transaction
    end
    begin
        insert into Products([Code], [Name], [Quantity], [Price])
        values(@Code, @Name, @Quantity, @Price)
    end
end

create procedure GetAllProduct
as
begin
    select * from Products  
end

create procedure UpdateProduct
@PId as int,
@PCode as int,
@PName as nvarchar(30),
@PQuantity as int,
@PPrice as float
as
begin
    declare @state as int = 0;
    select @state = 1
    from Products
    where Id = @PId
    if (@state = 0)
    begin
        rollback transaction
    end
    else
    begin
        Update Products
        Set [Code] = @PCode,
        [Name] = @PName,
        [Quantity] = @PQuantity,
        [Price] = @PPrice
        where Id = @PId
    end
end

create procedure DeleteProduct
@PId as int
as
begin
    declare @state as int  = 0;

    select @state = 1
    from Products
    where Id = @PId

    if (@state = 0)
    begin
        rollback transaction
    end
    else
    begin
        Delete Products
        where Id = @PId
    end
end
----------------------------
create procedure GetAllOrder
as
begin
    select * from Orders
end



create procedure AddOrder
@PProductId as int,
@PUserId as int,
@PQuantity as int
as
begin
	declare @state as int = 0, @price as float = 0, @quantity as int = 0, @result as float = 0
	   
	select @state = 1, @quantity=P.Quantity, @price = P.Price
	from Orders as O
	inner join Products as P
	on O.ProductId = P.Id
	inner join Users as U
	on O.UserId = U.Id
	where O.ProductId = @PProductId and O.UserId = @PUserId


	if(@state = 1)
	begin
		Set @result = @quantity * @price;

		Update Orders
		Set [Date] = GetDate(),
		[Quantity] = @PQuantity,
		[Price] = @result
		Where Orders.ProductId = @PProductId and Orders.UserId = @PUserId
	end
	else
	begin
		select @price = P.[Price]
		from Orders as O
		inner join Products as P
		on O.[ProductId] = P.[Id]
		where O.ProductId = @PProductId and O.UserId = @PUserId

		Set @result = @PQuantity * @price

		insert into Orders([ProductId], [UserId], [Date], [Quantity], [Price])
		values(@PProductId, @PUserId, GETDATE(), @PQuantity, @result)
	end
end


