USE HOTEL
--23. Decrease Tax Rate:
UPDATE Payments
SET TaxRate *= 0.97
SELECT TaxRate FROM Payments

--24. Delete All Records:
DELETE FROM Occupancies