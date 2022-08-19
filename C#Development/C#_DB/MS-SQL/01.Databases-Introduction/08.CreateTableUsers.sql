CREATE TABLE Users
(
    Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users 
(Username, [Password], ProfilePicture, LastLoginTime, isDeleted)
VALUES
('pl', 'parola', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '1/12/2021', 0),
('bo', 'paddrola', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '3/5/2021', 0),
('a', 'paroaala', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '1/12/2020', 1),
('v', 'parogbtfla', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '5/11/2021', 0),
('o', 'pardgdola', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '1/8/2021', 1)

ALTER TABLE Users 
DROP CONSTRAINT PK__Users__3214EC0706CF7621

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) > 5)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeast3Symbols CHECK (LEN(Username) > 3)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

