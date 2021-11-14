DECLARE @XML_Doc XML;
DECLARE @XML_Doc_Handle INT;

--�������� ������, ��������� ������ � XML
SET @XML_Doc = (SELECT * 
FROM T1
FOR XML PATH ('Date'), TYPE, ROOT ('Dates'))

EXEC sp_xml_preparedocument @XML_Doc_Handle OUTPUT, @XML_Doc;

--�������� ������, ���������� ������ �� XML �� ����������� �������
--������������� ������ �� StatusId != 3
SELECT *
   FROM OPENXML (@XML_Doc_Handle, '/Dates/Date', 2)
   WITH (
          Id INT , 
          Code NVARCHAR(50),
		  Name_ NVARCHAR(50),
		  StatusId INT
      )
WHERE StatusId!=3;

   EXEC sp_xml_removedocument @XML_Doc_Handle;