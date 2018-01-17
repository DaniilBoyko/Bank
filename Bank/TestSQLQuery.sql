DELETE FROM OrmAccountTypes WHERE Id = 5;
UPDATE OrmAccountTypes SET "Type" = 'Platinum' WHERE "Type" = 'Premium';
SELECT * FROM OrmAccountTypes;
SELECT * FROM OrmAccounts;
DELETE FROM OrmAccounts WHERE 1 = 1;
SELECT * FROM OrmUsers;
DELETE FROM OrmAccounts WHERE Id = 2;