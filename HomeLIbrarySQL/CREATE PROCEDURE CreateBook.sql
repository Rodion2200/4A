CREATE PROCEDURE AddBook
    @name NVARCHAR(50),
    @birth DATE,
    @author NVARCHAR(50),
    @contents XML
AS
	INSERT INTO  Books
	VALUES (@name,@birth,@author,@contents)