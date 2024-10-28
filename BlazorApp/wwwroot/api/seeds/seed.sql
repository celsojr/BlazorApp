-- --------------------------------------------------------
-- Host:                         $USERPROFILE\Downloads\Things.sqlite3
-- Server version:               3.39.4
-- Server OS:                    
-- HeidiSQL Version:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for things
-- CREATE DATABASE IF NOT EXISTS "things";

-- Dumping structure for table things.Categories
CREATE TABLE IF NOT EXISTS "Categories" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL
);

-- Dumping data for table things.Categories: 3 rows
/*!40000 ALTER TABLE "Categories" DISABLE KEYS */;
INSERT INTO "Categories" ("Id", "Name") VALUES
    (1, 'Electronics'),
    (2, 'Books'),
    (3, 'Clothing');
/*!40000 ALTER TABLE "Categories" ENABLE KEYS */;

-- Dumping structure for table things.Tags
CREATE TABLE IF NOT EXISTS "Tags" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Tags" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL UNIQUE
);

-- Dumping data for table things.Tags: 3 rows
/*!40000 ALTER TABLE "Tags" DISABLE KEYS */;
INSERT INTO "Tags" ("Id", "Name") VALUES
    (1, 'new'),
    (2, 'popular'),
    (3, 'sale'),
    (4, 'limited edition'),
    (5, 'wasm'),
    (6, 'blazor'),
    (7, 'sqlite');
/*!40000 ALTER TABLE "Tags" ENABLE KEYS */;

-- Dumping structure for table things.Things
CREATE TABLE IF NOT EXISTS "Things" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Things" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Description" TEXT NULL,
    "Price" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL,
    "CategoryId" INTEGER NOT NULL,
    "TagsString" TEXT NULL,
    CONSTRAINT "FK_Things_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE CASCADE
);

-- Dumping data for table things.Things: 4 rows
/*!40000 ALTER TABLE "Things" DISABLE KEYS */;
INSERT INTO "Things" ("Id", "Name", "Description", "Price", "CreatedDate", "CategoryId", "TagsString") VALUES
    (1, 'Smartphone', 'A smartphone with 5G capability', 699.99, CURRENT_TIMESTAMP, 1, 'new,popular'),
    (2, 'Novel', 'A mystery novel by a best-selling author', 14.99, CURRENT_TIMESTAMP, 2, 'sale'),
    (3, 'T-Shirt', 'A comfortable cotton t-shirt', 19.99, CURRENT_TIMESTAMP, 3, 'limited edition'),
    (4, 'Blazor Wasm', 'Blazor WebAssembly Experiments', 544.0, CURRENT_TIMESTAMP, 2, 'wasm,blazor,sqlite');
/*!40000 ALTER TABLE "Things" ENABLE KEYS */;

-- Dumping structure for table things.ThingTags
CREATE TABLE IF NOT EXISTS "ThingTags" (
    "ThingId" INTEGER NOT NULL,
    "TagId" INTEGER NOT NULL,
    CONSTRAINT "PK_ThingTags" PRIMARY KEY ("ThingId", "TagId"),
    CONSTRAINT "FK_ThingTags_Tags_TagId" FOREIGN KEY ("TagId") REFERENCES "Tags" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ThingTags_Things_ThingId" FOREIGN KEY ("ThingId") REFERENCES "Things" ("Id") ON DELETE CASCADE
);

-- Dumping data for table things.ThingTags: 3 rows
/*!40000 ALTER TABLE "ThingTags" DISABLE KEYS */;
INSERT INTO "ThingTags" ("ThingId", "TagId") VALUES
    (4, 5),
    (4, 6),
    (4, 7);
/*!40000 ALTER TABLE "ThingTags" ENABLE KEYS */;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
