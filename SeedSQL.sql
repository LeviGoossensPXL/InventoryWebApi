
INSERT INTO "Items" ("Id", "Name", "Brand", "Type")
VALUES
(1, '3d printer', 'Prusa', 'CoreOne'),
(2, 'repair toolkit', 'iFixIt', 'pro tech toolkit'),
(3, 'monitor arm', 'Alberenz', 'single monitorarm Donkergrijs')
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO "OwnedItems" ("Id", "OwnerId", "ItemId", "Price", "ImageUrl", "AcquiredAt", "Notes")
VALUES
(1, 1, 1, 1500.00, 'https://localhost:7027/images/items/b95db868-ecb5-41f1-8f82-5a8bf520ad66.jpg', '4/11/2025', 'can not print in cold tempertature'),
(2, 2, 2, 77.41, 'https://localhost:7027/images/items/c82af8a4-3662-4734-8453-a4e08197efc6.jpg', '10/09/2025', 'repair most things'),
(3, 3, 3, 99.00, 'https://localhost:7027/images/items/45690b8f-3173-4e74-be8f-c773612046bb.jpg', '15/09/2025', 'good arm')
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO "WishedItems" ("Id", "UserId", "ItemId", "Price", "Priority")
VALUES
(1, 1, 1, 1500.00, 1),
(2, 2, 2, 77.41, 2),
(3, 3, 3, 99.00, 3)
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO "Projects" ("Id", "Name", "Description")
VALUES
(1, 'led cube', 'leds in de vorm van een kubus om mooie effect te tonen door programmatie'),
(2, 'self balancing cube', 'een kubus die zich zelf kan balanceren op zijn punt')
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO "Groups" ("Id", "Name", "Description")
VALUES
(1, 'work', 'Items used for work, office tasks, or professional activities'),
(2, 'home', 'Everyday items used around the house'),
(3, 'food', 'Groceries, pantry items, and consumable food products'),
(4, 'electronics', 'Electronic devices, gadgets, and accessories'),
(5, 'other', 'Items that do not fit into any specific category')
ON CONFLICT ("Id") DO NOTHING;

