-- Check if the category exists before inserting
INSERT INTO Categories (Id, Name)
SELECT 1, 'Electronics' WHERE NOT EXISTS (SELECT 1 FROM Categories WHERE Id = 1);
INSERT INTO Categories (Id, Name)
SELECT 2, 'Books' WHERE NOT EXISTS (SELECT 1 FROM Categories WHERE Id = 2);
INSERT INTO Categories (Id, Name)
SELECT 3, 'Apparel' WHERE NOT EXISTS (SELECT 1 FROM Categories WHERE Id = 3);

-- Then, insert things with foreign keys to the Category
INSERT INTO Things (Id, Name, Description, Price, CreatedDate, CategoryId, TagsString) VALUES 
(1, 'Smartphone', 'A smartphone with 5G capability', 699.99, CURRENT_TIMESTAMP, 1, 'New Arrival, Popular'),
(2, 'Novel', 'A mystery novel by a best-selling author', 14.99, CURRENT_TIMESTAMP, 2, 'Sale'),
(3, 'T-Shirt', 'A comfortable cotton t-shirt', 19.99, CURRENT_TIMESTAMP, 3, 'Limited Edition');

INSERT INTO ThingTags (ThingId, TagId)
SELECT 1, Id FROM Tags WHERE Name = 'New Arrival';
INSERT INTO ThingTags (ThingId, TagId)
SELECT 1, Id FROM Tags WHERE Name = 'Popular';
INSERT INTO ThingTags (ThingId, TagId)
SELECT 2, Id FROM Tags WHERE Name = 'Sale';
INSERT INTO ThingTags (ThingId, TagId)
SELECT 3, Id FROM Tags WHERE Name = 'Limited Edition';
