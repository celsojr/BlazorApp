INSERT INTO Tags (Name) VALUES ('new') ON CONFLICT(Name) DO NOTHING;
INSERT INTO Tags (Name) VALUES ('popular') ON CONFLICT(Name) DO NOTHING;
INSERT INTO Tags (Name) VALUES ('sale') ON CONFLICT(Name) DO NOTHING;
INSERT INTO Tags (Name) VALUES ('limited edition') ON CONFLICT(Name) DO NOTHING;
