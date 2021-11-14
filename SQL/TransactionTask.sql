CREATE PROCEDURE Pay
	@Account_1 INT,
	@Account_2 INT,
	@Accoynt_Money MONEY
AS
	DECLARE @Account_1_money MONEY;
	DECLARE @Account_2_money MONEY;
	SET @Account_1_money = (SELECT Account.Money_ FROM Account WHERE Account.Id=@Account_1)
	SET @Account_2_money = (SELECT Account.Money_ FROM Account WHERE Account.Id=@Account_2)
IF(@Account_1_money > @Accoynt_Money) 
	BEGIN
	BEGIN TRAN
	SET @Account_1_money = @Account_1_money - @Accoynt_Money
	SET @Account_2_money = @Account_2_money + @Accoynt_Money
	UPDATE Account	SET Money_ = @Account_1_money  WHERE Id =@Account_1;
	UPDATE Account	SET Money_ = @Account_2_money  WHERE Id =@Account_2;
	COMMIT
	END
ELSE
	PRINT'Insufficient funds'