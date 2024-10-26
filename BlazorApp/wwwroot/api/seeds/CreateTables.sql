-- Create the Categories table
CREATE TABLE IF NOT EXISTS Categories (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

-- Create the Tags table
CREATE TABLE IF NOT EXISTS Tags (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE
);

-- Create the Things table
CREATE TABLE IF NOT EXISTS Things (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Description TEXT,
    Price REAL,
    CreatedDate TEXT,
    CategoryId INTEGER,
    TagsString TEXT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Create the ThingTags join table
CREATE TABLE IF NOT EXISTS ThingTags (
    ThingId INTEGER,
    TagId INTEGER,
    PRIMARY KEY (ThingId, TagId),
    FOREIGN KEY (ThingId) REFERENCES Things(Id),
    FOREIGN KEY (TagId) REFERENCES Tags(Id)
);
