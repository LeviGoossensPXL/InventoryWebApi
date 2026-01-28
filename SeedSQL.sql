-- =========================
-- ITEMS
-- =========================
INSERT INTO "Items" ("Id", "Name", "Image", "Brand", "Type", "Price")
VALUES
(1, '3d printer', 'https://localhost:7027/images/items/b95db868-ecb5-41f1-8f82-5a8bf520ad66.jpg', 'Prusa', 'CoreOne', 1500.00),
(2, 'repair toolkit', 'https://localhost:7027/images/items/c82af8a4-3662-4734-8453-a4e08197efc6.jpg', 'iFixIt', 'pro tech toolkit', 77.41),
(3, 'monitor arm', 'https://localhost:7027/images/items/45690b8f-3173-4e74-be8f-c773612046bb.jpg', 'Alberenz', 'single monitorarm Donkergrijs', 99.00)
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"Items"', 'Id'),
              (SELECT MAX("Id") FROM "Items"));

-- =========================
-- PROJECTS
-- =========================
INSERT INTO "Projects" ("Id", "Name", "Description")
VALUES
(1, 'led cube', 'leds in de vorm van een kubus om mooie effect te tonen door programmatie'),
(2, 'self balancing cube', 'een kubus die zich zelf kan balanceren op zijn punt')
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"Projects"', 'Id'),
              (SELECT MAX("Id") FROM "Projects"));

-- =========================
-- GROUPS
-- =========================
INSERT INTO "Groups" ("Id", "Name", "Description")
VALUES
(1, 'work', 'Items used for work, office tasks, or professional activities'),
(2, 'home', 'Everyday items used around the house'),
(3, 'food', 'Groceries, pantry items, and consumable food products'),
(4, 'electronics', 'Electronic devices, gadgets, and accessories'),
(5, 'other', 'Items that do not fit into any specific category')
ON CONFLICT ("Id") DO NOTHING;
SELECT setval(pg_get_serial_sequence('"Groups"', 'Id'),
                                            (SELECT MAX("Id") FROM "Groups"));
