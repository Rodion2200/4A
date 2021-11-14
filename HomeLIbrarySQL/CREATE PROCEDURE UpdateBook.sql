CREATE PROCEDURE UpdateBook
	@Id INT,
    @name NVARCHAR(50),
    @birth DATE,
    @author NVARCHAR(50),
    @contents XML
AS
	UPDATE Books
	SET NameBook = @name , DateBirth = @birth, Author=@author,Contents=@contents
	WHERE Id =@Id;
