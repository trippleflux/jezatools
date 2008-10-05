-- Insert Tasks
INSERT INTO [TravianBot].[dbo].[Tasks] ([TaskId], [TaskName]) VALUES (1, 'BuildResources')
INSERT INTO [TravianBot].[dbo].[Tasks] ([TaskId], [TaskName]) VALUES (2, 'BuildResourcesNoCrop')
INSERT INTO [TravianBot].[dbo].[Tasks] ([TaskId], [TaskName]) VALUES (3, 'WoodLand')
INSERT INTO [TravianBot].[dbo].[Tasks] ([TaskId], [TaskName]) VALUES (4, 'ClayPit')
INSERT INTO [TravianBot].[dbo].[Tasks] ([TaskId], [TaskName]) VALUES (5, 'IronMine')
INSERT INTO [TravianBot].[dbo].[Tasks] ([TaskId], [TaskName]) VALUES (6, 'CropLand')
INSERT INTO [TravianBot].[dbo].[Tasks] ([TaskId], [TaskName]) VALUES (7, 'BuildingId')
-- Insert Buildings GIDs
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Woodcutter', 1)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Clay Pit', 2)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Iron Mine', 3)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Cropland', 4)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Sawmill', 5)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Brickyard', 6)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Iron Foundry', 7)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Grain Mill', 8)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Bakery', 9)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Warehouse', 10)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Granary', 11)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Blacksmith', 12)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Armoury', 13)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Tournament Square', 14)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Main Building', 15)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Rally Point', 16)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Marketplace', 17)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Embassy', 18)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Barracks', 19)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Stable', 20)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Workshop', 21)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Academy', 22)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Cranny', 23)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Town Hall', 24)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Residence', 25)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Palace', 26)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Treasury', 27)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Trade Office', 28)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Great Barracks', 29)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Great Stable', 30)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('City Wall', 31)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Earth Wall', 32)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Palisade', 33)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Stonemason', 34)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Brewery', 35)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Trapper', 36)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Heros Mansion', 37)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Great Warehouse', 38)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Great Granary', 39)
INSERT INTO [TravianBot].[dbo].[BuildingsGIDs] ([BuildingsGIDName] ,[BuildingGIDId]) VALUES ('Wonder of the World', 40)
-- Insert Build IDs
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (1, 'build.php?id=1')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (2, 'build.php?id=2')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (3, 'build.php?id=3')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (4, 'build.php?id=4')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (5, 'build.php?id=5')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (6, 'build.php?id=6')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (7, 'build.php?id=7')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (8, 'build.php?id=8')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (9, 'build.php?id=9')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (10, 'build.php?id=10')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (11, 'build.php?id=11')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (12, 'build.php?id=12')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (13, 'build.php?id=13')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (14, 'build.php?id=14')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (15, 'build.php?id=15')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (16, 'build.php?id=16')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (17, 'build.php?id=17')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (18, 'build.php?id=18')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (19, 'build.php?id=19')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (20, 'build.php?id=20')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (21, 'build.php?id=21')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (22, 'build.php?id=22')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (23, 'build.php?id=23')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (24, 'build.php?id=24')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (25, 'build.php?id=25')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (26, 'build.php?id=26')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (27, 'build.php?id=27')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (28, 'build.php?id=28')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (29, 'build.php?id=29')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (30, 'build.php?id=30')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (31, 'build.php?id=31')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (32, 'build.php?id=32')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (33, 'build.php?id=33')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (34, 'build.php?id=34')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (35, 'build.php?id=35')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (36, 'build.php?id=36')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (37, 'build.php?id=37')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (38, 'build.php?id=38')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (39, 'build.php?id=39')
INSERT INTO [TravianBot].[dbo].[BuildIds] ([BuildId] ,[BuildIdName]) VALUES (40, 'build.php?id=40')
-- Insert Priority
INSERT INTO [TravianBot].[dbo].[Priority] ([PriorityName] ,[PriorityLevel]) VALUES ('Very High', 5)
INSERT INTO [TravianBot].[dbo].[Priority] ([PriorityName] ,[PriorityLevel]) VALUES ('High', 4)
INSERT INTO [TravianBot].[dbo].[Priority] ([PriorityName] ,[PriorityLevel]) VALUES ('Medium', 3)
INSERT INTO [TravianBot].[dbo].[Priority] ([PriorityName] ,[PriorityLevel]) VALUES ('Low', 2)
INSERT INTO [TravianBot].[dbo].[Priority] ([PriorityName] ,[PriorityLevel]) VALUES ('Very Low', 1)
-- Inser Tribes
INSERT INTO [TravianBot].[dbo].[Tribes] ([TribeId], [TribeName]) VALUES (1, 'Teutons')
INSERT INTO [TravianBot].[dbo].[Tribes] ([TribeId], [TribeName]) VALUES (2, 'Gauls')
INSERT INTO [TravianBot].[dbo].[Tribes] ([TribeId], [TribeName]) VALUES (3, 'Romans')
-- Insert Attack Types
INSERT INTO [TravianBot].[dbo].[AttackTypes] ([AttackId], [AttackName]) VALUES (2 ,'Reinforcement')
INSERT INTO [TravianBot].[dbo].[AttackTypes] ([AttackId], [AttackName]) VALUES (3 ,'Full Attack')
INSERT INTO [TravianBot].[dbo].[AttackTypes] ([AttackId], [AttackName]) VALUES (4 ,'Raid')
-- Insert TroopTypes
-- Teutons
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 1, 'Gorjačarjev')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 2, 'Suličarjev')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 3, 'Metalcev sekir')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 4, 'Skavtov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 5, 'Paladinov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 6, 'Tevtonskih vitezov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 7, 'Oblegovalnih ovnov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 8, 'Mangonelov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 9, 'Vodij')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (1, 10, 'Kolonistov')
-- Gauls
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 11, 'Falang')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 12, 'Mečevalcev')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 13, 'Stezosledcev')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 14, 'Theutatesovih Strel')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 15, 'Druidov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 16, 'Haeduanov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 17, 'Oblegovalnih ovnov')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 18, 'Trebušejev')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 19, 'Poglavarjev')
INSERT INTO [TravianBot].[dbo].[TroopTypes] ([TribeId], [TroopId], [TroopName]) VALUES (2, 20, 'Kolonistov')
-- Romans


