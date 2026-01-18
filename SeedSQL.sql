
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

INSERT INTO "Users" ("Id", "NickName", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") 
VALUES
('94b0b023-915b-46e7-a551-f9fb1279b4dd', 'levi', 'levi1@gmail.com', 'LEVI1@GMAIL.COM', 'levi1@gmail.com', 'LEVI1@GMAIL.COM', false, 'AQAAAAIAAYagAAAAELzenAoyMUeutldQP6UUVuvdrYt3u9oMH9FzBhUOVkauC0kQmVKcINmlE8wapJBwWQ==', 'OFPPL4MARKQZSNUWZC2VVUMH4MURTPUK', 'b3cf1744-b53c-4b24-8fc4-62215a1b9d82', null, false, false, null, true, 0),
-- password: levi100
('1be472f3-d625-4957-af2f-dfd54fd81e79', 'alex', 'alex2@gmail.com', 'ALEX2@GMAIL.COM', 'alex2@gmail.com', 'ALEX2@GMAIL.COM', false, 'AQAAAAIAAYagAAAAEE7AEZOlYJ+etEWaMCUH22vdj0LYcfx5a2axXnN1ecSNKuzQqRxk4c1E6HxzFlHGjw==', '543SKA7KBO65WVFJ7BG5C52C2RBKTLGK', '925e3eb7-bf48-4d77-b0d0-9be669cf5a4c', null, false, false, null, true, 0),
-- password: alex200
('54c0a92c-3e61-4f79-ad73-a3cd61f9aec7', 'luca', 'luca3@gmail.com', 'LUCA3@GMAIL.COM', 'luca3@gmail.com', 'LUCA3@GMAIL.COM', false, 'AQAAAAIAAYagAAAAELLDQAAysDvZVzCia7Zs4AFYLuBfy2deqP/zcYL3mi3lYsCgAz2HAb9oUmEXS6ieKg==', 'DSP2LHJHSM5QHZJ6BBGLOFAWZVI4YPNO', 'c21d4d50-245a-4479-af2b-0287ae6ffde1', null, false, false, null, true, 0),
-- password: luca300
('9c49f6b9-663c-4dbd-96a9-87f30c370fb8', 'sami', 'sami4@gmail.com', 'SAMI4@GMAIL.COM', 'sami4@gmail.com', 'SAMI4@GMAIL.COM', false, 'AQAAAAIAAYagAAAAEGp47QHzC/wS88P4rUyth7QPyQLhFWD9IUEtsG7k7TldRJ9a8EqGQ73sSFyGTATJSA==', 'UKBTVTC7HQU6MWVG7OJ2S5F6JBVRISG4', '58fdd00a-b7e2-4183-9b3e-e48816317f4d', null, false, false, null, true, 0)
-- password: sami400
ON CONFLICT ("Id") DO NOTHING;

