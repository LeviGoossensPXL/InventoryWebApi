--region remove all data
truncate table 
    "GroupProjects",
    "RoleClaims",
    "ExternalLogins",
    "GroupUsers",
    "UserClaims",
    "UserRoles",
    "Roles",
    "UserTokens",
    "GroupOwnedItems",
    "OwnedItems",
    "GroupWishedItems",
    "Groups",
    "WishedItems",
    "Users",
    "ProjectItems",
    "VoidItems",
    "Projects"
restart identity cascade;
--endregion

SET session_replication_role = replica; --disable constraints

SET search_path TO public;



--region seed data
INSERT INTO "VoidItems" ("Id", "Name", "Brand", "Type", "Description")
VALUES
(1, '3d printer', 'Prusa', 'CoreOne', 'A 3D printer for creating custom objects.'),
(2, 'repair toolkit', 'iFixIt', 'pro tech toolkit', 'Dont replace, repair!'),
(3, 'monitor arm', 'Alberenz', 'single monitorarm Donkergrijs', 'hold your monitor and move it more freely'),

-- AI gen
(4, 'Laptop', 'Dell', 'XPS 15', 'Used for work and computing tasks'),
(5, 'Notebook', 'Moleskine', 'Classic Large', 'For taking notes'),
(6, 'Pen', 'Parker', 'Jotter', 'For writing and drawing'),
(7, 'Projector', 'Epson', 'EX3260', 'For presentations'),
(8, 'Desk Chair', 'Ikea', 'Markus', 'Comfortable office chair'),
(9, 'Router', 'TP-Link', 'Archer C7', 'Internet access device'),
(10, 'Headphones', 'Sony', 'WH-1000XM4', 'For audio tasks'),
(11, 'Whiteboard', 'Quartet', 'Magnetic 36x24', 'For brainstorming'),

-- Hobby / ICT items & AI gen
(12, 'Raspberry Pi', 'Raspberry', '4 Model B', 'Single-board computer for projects'),
(13, 'Arduino Kit', 'Arduino', 'Starter Kit', 'Microcontroller kit for robotics and electronics'),
(14, 'Resistors Set', 'Generic', 'Assorted 1/4W', 'Assorted resistors for circuits'),
(15, 'Breadboard', 'Generic', 'MB-102', 'For prototyping circuits'),
(16, 'Jumper Wires', 'Generic', 'M/M 20cm', 'For connecting circuits'),
(17, 'Gaming GPU', 'NVIDIA', 'RTX 3060', 'Graphics card for gaming PC'),
(18, 'Power Supply', 'Corsair', 'RM750x', 'Power supply for PC builds'),
(19, 'Sensors Kit', 'Generic', '10-in-1', 'Sensors for IoT and robotics'),
(20, 'Microcontroller', 'ESP32', 'DevKitC', 'WiFi-enabled microcontroller for IoT projects'),
(21, 'Multimeter', 'Fluke', '117', 'For measuring voltage, current, and resistance')
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"VoidItems"', 'Id'),
              (SELECT MAX("Id") FROM "VoidItems"));

INSERT INTO "OwnedItems" ("Id", "Name", "Brand", "Type", "Description", "OwnerId", "Price", "ImageUrl", "AcquiredAt", "Notes")
VALUES
(1, 'repair toolkit', 'iFixIt', 'pro tech toolkit', 'Dont replace, repair!','94b0b023-915b-46e7-a551-f9fb1279b4dd', 1500.00, 'https://localhost:7027/images/items/b95db868-ecb5-41f1-8f82-5a8bf520ad66.jpg', '2025-04-11 20:36:32', 'can not print in cold tempertature'),
(2, 'repair toolkit', 'iFixIt', 'pro tech toolkit', 'Dont replace, repair!', '94b0b023-915b-46e7-a551-f9fb1279b4dd', 77.41, 'https://localhost:7027/images/items/c82af8a4-3662-4734-8453-a4e08197efc6.jpg', '2025-09-10 00:32:07', 'repair most things'),
(3, 'monitor arm', 'Alberenz', 'single monitorarm Donkergrijs', 'hold your monitor and move it more freely', '94b0b023-915b-46e7-a551-f9fb1279b4dd', 99.00, 'https://localhost:7027/images/items/45690b8f-3173-4e74-be8f-c773612046bb.jpg', '2025-09-15 14:58:03', 'good arm'),
(3, 'monitor arm', 'Alberenz', 'single monitorarm Donkergrijs', 'hold your monitor and move it more freely', '94b0b023-915b-46e7-a551-f9fb1279b4dd', 99.00, 'https://localhost:7027/images/items/45690b8f-3173-4e74-be8f-c773612046bb.jpg', '2025-09-25 15:33:03', 'damaged always droping under a tiny amount of weight')
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"OwnedItems"', 'Id'),
              (SELECT MAX("Id") FROM "OwnedItems"));

INSERT INTO "WishedItems" ("Id", "Name", "Brand", "Type", "Description", "UserId", "Price", "Priority")
VALUES
(1, '3d printer', 'Prusa', 'CoreOne', 'A 3D printer for creating custom objects.', '94b0b023-915b-46e7-a551-f9fb1279b4dd', 1500.00, 1),
(2, 'repair toolkit', 'iFixIt', 'pro tech toolkit', 'Dont replace, repair!', '94b0b023-915b-46e7-a551-f9fb1279b4dd', 80.41, 2),
(3, 'monitor arm', 'Alberenz', 'single monitorarm Donkergrijs', 'hold your monitor and move it more freely', '94b0b023-915b-46e7-a551-f9fb1279b4dd', 102.00, 3)
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"WishedItems"', 'Id'),
              (SELECT MAX("Id") FROM "WishedItems"));

INSERT INTO "Projects" ("Id", "Name", "Description")
VALUES
(1, 'led cube', 'LEDs in the shape of a cube to display beautiful effects through programming.'),
(2, 'self balancing cube', 'A cube that can balance itself on its point.'),
--ai gen
(3, 'Raspberry Pi Home Automation', 'Set up sensors and devices with Raspberry Pi for home automation'),
(4, 'Gaming PC Build', 'Assemble a gaming PC from components'),
(5, 'Arduino Robotics', 'Build a small robot using Arduino components'),
(6, 'Electronics Repair', 'Repair and maintain small electronics gadgets'),
(7, 'IoT Weather Station', 'Create a weather station with IoT sensors and microcontrollers')
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"Projects"', 'Id'),
              (SELECT MAX("Id") FROM "Projects"));

INSERT INTO "Groups" ("Id", "Name", "Description")
VALUES
(1, 'work', 'Items used for work, office tasks, or professional activities'),
(2, 'home', 'items used at the house'),
(3, 'hobby-ict', 'tools, electronic devices, gadgets, and accessories'),
(4, 'other', 'Items that do not fit into any specific category')
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"Groups"', 'Id'),
              (SELECT MAX("Id") FROM "Groups"));

INSERT INTO "Users" ("Id", "NickName", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount")
VALUES
('94b0b023-915b-46e7-a551-f9fb1279b4dd', 'levi', 'levi1@gmail.com', 'LEVI1@GMAIL.COM', 'levi1@gmail.com', 'LEVI1@GMAIL.COM', false, 'AQAAAAIAAYagAAAAELzenAoyMUeutldQP6UUVuvdrYt3u9oMH9FzBhUOVkauC0kQmVKcINmlE8wapJBwWQ==', 'OFPPL4MARKQZSNUWZC2VVUMH4MURTPUK', 'b3cf1744-b53c-4b24-8fc4-62215a1b9d82', null, false, false, null, true, 0),
-- password: levi100
('1be472f3-d625-4957-af2f-dfd54fd81e79', 'collega', 'alex2@gmail.com', 'ALEX2@GMAIL.COM', 'alex2@gmail.com', 'ALEX2@GMAIL.COM', false, 'AQAAAAIAAYagAAAAEE7AEZOlYJ+etEWaMCUH22vdj0LYcfx5a2axXnN1ecSNKuzQqRxk4c1E6HxzFlHGjw==', '543SKA7KBO65WVFJ7BG5C52C2RBKTLGK', '925e3eb7-bf48-4d77-b0d0-9be669cf5a4c', null, false, false, null, true, 0),
-- password: alex200
('54c0a92c-3e61-4f79-ad73-a3cd61f9aec7', 'collega', 'luca3@gmail.com', 'LUCA3@GMAIL.COM', 'luca3@gmail.com', 'LUCA3@GMAIL.COM', false, 'AQAAAAIAAYagAAAAELLDQAAysDvZVzCia7Zs4AFYLuBfy2deqP/zcYL3mi3lYsCgAz2HAb9oUmEXS6ieKg==', 'DSP2LHJHSM5QHZJ6BBGLOFAWZVI4YPNO', 'c21d4d50-245a-4479-af2b-0287ae6ffde1', null, false, false, null, true, 0),
-- password: luca300
('9c49f6b9-663c-4dbd-96a9-87f30c370fb8', 'vriend', 'sami4@gmail.com', 'SAMI4@GMAIL.COM', 'sami4@gmail.com', 'SAMI4@GMAIL.COM', false, 'AQAAAAIAAYagAAAAEGp47QHzC/wS88P4rUyth7QPyQLhFWD9IUEtsG7k7TldRJ9a8EqGQ73sSFyGTATJSA==', 'UKBTVTC7HQU6MWVG7OJ2S5F6JBVRISG4', '58fdd00a-b7e2-4183-9b3e-e48816317f4d', null, false, false, null, true, 0),
-- password: sami400
('20d9536d-d46e-4494-a80d-c31b7e412da1', 'vriend', 'andy5@gmail.com', 'ANDY5@GMAIL.COM', 'andy5@gmail.com', 'ANDY5@GMAIL.COM', false, 'AQAAAAIAAYagAAAAEEORPPf4XxMC1UhxehQ6daPjsr/TGIvcV4zf0FYau70L2boGSxx3bGN3C7gK6XqvIg==', 'KZBRSGBKSG5HPXPVI4ZQ6AH7JC4O4OO6', '2edd1bca-960a-447d-b08e-86c270a3cbe2', null, false, false, null, true, 0)
-- password: andy500
ON CONFLICT ("Id") DO NOTHING;
--endregion

-- Random GroupUsers links
INSERT INTO "GroupUsers" ("GroupId", "UserId") VALUES
(1, '94b0b023-915b-46e7-a551-f9fb1279b4dd'), -- levi in work
(1, '1be472f3-d625-4957-af2f-dfd54fd81e79'), -- alex in work
(2, '54c0a92c-3e61-4f79-ad73-a3cd61f9aec7'), -- luca in home
(2, '20d9536d-d46e-4494-a80d-c31b7e412da1'), -- andy in home
(3, '94b0b023-915b-46e7-a551-f9fb1279b4dd'), -- levi in hobby-ict
(3, '9c49f6b9-663c-4dbd-96a9-87f30c370fb8'), -- sami in hobby-ict
(4, '94b0b023-915b-46e7-a551-f9fb1279b4dd'), -- levi in other
(4, '1be472f3-d625-4957-af2f-dfd54fd81e79'), -- alex in other
(4, '20d9536d-d46e-4494-a80d-c31b7e412da1')  -- andy in other
ON CONFLICT ("GroupId", "UserId") DO NOTHING;

-- Random GroupOwnedItems
INSERT INTO "GroupOwnedItems" ("GroupId", "OwnedItemId") VALUES
(1, 1), (1, 2), (1, 5),
(2, 2), (2, 3), (2, 7),
(3, 1), (3, 4), (3, 6),
(4, 3), (4, 5), (4, 8)
ON CONFLICT ("GroupId", "OwnedItemId") DO NOTHING;

-- Random GroupWishedItems
INSERT INTO "GroupWishedItems" ("GroupId", "WishedItemId") VALUES
(1, 3), (1, 4),
(2, 1), (2, 5),
(3, 2), (3, 7),
(4, 1), (4, 6)
ON CONFLICT ("GroupId", "WishedItemId") DO NOTHING;

-- Random GroupProjects
INSERT INTO "GroupProjects" ("GroupId", "ProjectId") VALUES
(1, 1), (1, 3),
(2, 2), (2, 4),
(3, 1), (3, 2),
(4, 3), (4, 4)
ON CONFLICT ("GroupId", "ProjectId") DO NOTHING;

SET session_replication_role = DEFAULT; --enable constraints
