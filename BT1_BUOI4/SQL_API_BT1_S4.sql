CREATE PROC Sp_Employee
@Sr_no int, @Emp_name nvarchar(500),
@City nvarchar(500), @STATE nvarchar(500),
@Counrty nvarchar(500), @Department nvarchar (500),
@flagh nvarchar(50)

AS BEGIN
	IF (@flagh = 'insert')
	BEGIN
		INSERT INTO dbo.tbl_Employee
		( Emp_name, City, STATE, Country, Department)
		Values
		(@Emp_name, @City, @STATE, @Counrty, @Department)
	END

	ElSE IF(@flagh = 'update')
		BEGIN
			UPDATE dbo.tbl_Employee SET
				Emp_name = @Emp_name, City = @City,
				STATE = @STATE, Country = @Counrty,
				Department = @Department
			WHERE Sr_no = @Sr_no
		END

	ELSE IF(@flagh = 'delete')
		BEGIN
			DELETE FROM tbl_Employee
			WHERE Sr_no = @Sr_no
		END
	ELSE IF(@flagh = 'getid')
		BEGIN 
			SELECT * FROM tbl_Employee
			WHERE Sr_no = @Sr_no
		END

	ELSE IF(@flagh = 'get')
		BEGIN 
			SELECT * FROM tbl_Employee
		END
END