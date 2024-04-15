--Scaffold-DbConntext "Data Source=kidstrWebApiDB.mssql.somee.com;Initial Catalog=kidstrWebApiDB;Persist Security Info=True;User ID=chellil;Password=onushelnarassvete" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -DataAnnotations

DROP TABLE [Users];

DROP TABLE [Days];

DROP TABLE [AddServ_Ordr];

DROP TABLE [Ordr];

DROP TABLE [Status];

DROP TABLE [Price];

DROP TABLE [AddServ];

DROP TABLE [Guide];

DROP TABLE [Employee];

DROP TABLE [Service_Age];

DROP TABLE [Age];

DROP TABLE [Service];

DROP TABLE [Direction];

DROP TABLE [Types];

CREATE TABLE [Employee]
( 
	[id_emp]             nvarchar(15)  NOT NULL ,
	[name]               nvarchar(50)  NOT NULL ,
	[phone]              nvarchar(15)  NOT NULL ,
	PRIMARY KEY  ([id_emp])
);

INSERT INTO [Employee] VALUES
('1111 111111', 'Name1', '+7(911)1111111'),
('2222 222222', 'Name2', '+7(922)2222222'),
('3333 333333', 'Name3', '+7(933)3333333');

CREATE TABLE [Users]
( 
	[id_emp]             nvarchar(15)  NOT NULL ,
	[login]              nvarchar(20)  UNIQUE NOT NULL ,
	[password]          nvarchar(100)  NOT NULL ,
	[root]               bit  NOT NULL DEFAULT  0,
	PRIMARY KEY  ([id_emp]),
	 FOREIGN KEY ([id_emp]) REFERENCES [Employee]([id_emp])
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO [Users] VALUES
('1111 111111', 'Manager', 'dcccb657472b9f453acf0f7decdd5f8891d4eb997267de31b76bb02cd1bc4e17', 0), --Mpassword
('2222 222222', 'Admin', '9fff15cdec1f0b4f804c2217cce94ad7194ebc18744892bc7bb52be9fd7bb942', 1); --Apassword

CREATE TABLE [Types]
( 
	[id_type]            integer  IDENTITY  NOT NULL ,
	[name]               nvarchar(20)  NOT NULL ,
	[outdated]           bit  NOT NULL DEFAULT  0,
	PRIMARY KEY  ([id_type])
);

INSERT INTO [Types] ([name]) VALUES
(N'Экскурсия'),
(N'Мастер-класс'),
(N'Квест');

CREATE TABLE [Direction]
( 
	[id_dir]             integer  IDENTITY  NOT NULL ,
	[name]               nvarchar(20)  NOT NULL ,
	[outdated]           bit  NOT NULL DEFAULT  0,
	PRIMARY KEY  ([id_dir])
);
INSERT INTO [Direction] ([name]) VALUES
(N'Наука и техника'),
(N'Производство'),
(N'Культура и искусство'),
(N'Мастер-классы'),
(N'В природу'),
(N'Интерактив'),
(N'По городу'),
(N'Музеи'),
(N'Пригороды'),
(N'Живой урок'),
(N'Новый год'),
(N'Выпускной'),
(N'Война и Блокада'),
(N'Туры в Петербург');

CREATE TABLE [Service]
( 
	[id_serv]            integer  IDENTITY  NOT NULL ,
	[name]               nvarchar(50)  NOT NULL ,
	[duration]           nvarchar(20)  NOT NULL ,
	[descr]              nvarchar(max)  NULL ,
	[condit]             nvarchar(max)  NULL ,
	[id_type]            integer  NOT NULL ,
	[id_dir]             integer  NOT NULL ,
	[outdated]           bit  NOT NULL DEFAULT  0,
	PRIMARY KEY  ([id_serv]),
	 FOREIGN KEY ([id_type]) REFERENCES [Types]([id_type])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	 FOREIGN KEY ([id_dir]) REFERENCES [Direction]([id_dir])
		ON DELETE NO ACTION
		ON UPDATE CASCADE
);
INSERT INTO [Service] ([name],[duration],[descr],[condit],[id_type],[id_dir]) VALUES
(N'Экскурсия1', N'2 часа 30 минут', N'Описание1', N'Ограничения1', 1, 2),
(N'Мастер-класс1', N'2 часа 30 минут', N'Описание1', N'Ограничения1', 2, 2);

CREATE TABLE [Age]
( 
	[id_group]           integer IDENTITY NOT NULL ,
	[name]               nvarchar(15)  NOT NULL ,
	PRIMARY KEY  ([id_group])
);
INSERT INTO [Age] ([name]) VALUES
(N'5 лет'),
(N'6 лет'),
(N'1 класс'),
(N'2 класс'),
(N'3 класс'),
(N'4 класс'),
(N'5 класс'),
(N'6 класс'),
(N'7 класс'),
(N'8 класс'),
(N'9 класс'),
(N'10 класс'),
(N'11 класс'),
(N'Студенты'),
(N'Взрослые'),
(N'Смешан.');

CREATE TABLE [Service_Age]
( 
	[id_serv]            integer  NOT NULL ,
	[id_group]           integer  NOT NULL ,
	PRIMARY KEY  ([id_serv],[id_group]),
	 FOREIGN KEY ([id_serv]) REFERENCES [Service]([id_serv])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	 FOREIGN KEY ([id_group]) REFERENCES [Age]([id_group])
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
INSERT INTO [Service_Age] VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 4),
(2, 5);

CREATE TABLE [Guide]
( 
	[id_emp]             nvarchar(15)  NOT NULL ,
	[id_serv]            integer  NOT NULL ,
	PRIMARY KEY  ([id_emp],[id_serv]),
	 FOREIGN KEY ([id_emp]) REFERENCES [Employee]([id_emp])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	 FOREIGN KEY ([id_serv]) REFERENCES [Service]([id_serv])
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
INSERT INTO [Guide] VALUES
('3333 333333', 1),
('3333 333333', 2);

CREATE TABLE [Days]
( 
	[id_serv]            integer  NOT NULL ,
	[day_num]            integer  NOT NULL ,
	PRIMARY KEY  ([id_serv],[day_num]),
	 FOREIGN KEY ([id_serv]) REFERENCES [Service]([id_serv])
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
INSERT INTO [Days] VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 4),
(2, 5);

CREATE TABLE [AddServ]
( 
	[id_add]             integer  IDENTITY  NOT NULL ,
	[name]               nvarchar(50)  NOT NULL ,
	[cost]               float  NOT NULL DEFAULT  0,
	[outdated]           bit  NOT NULL DEFAULT  0,
	PRIMARY KEY  ([id_add])
);
INSERT INTO [AddServ] ([name], [cost]) VALUES
(N'Фотограф', 1000);

CREATE TABLE [Price]
( 
	[id_price]           integer  IDENTITY  NOT NULL ,
	[id_serv]            integer  NOT NULL ,
	[member_min]         integer  NOT NULL DEFAULT  0,
	[member_max]         integer  NULL ,
	[accom_count]        integer  NOT NULL DEFAULT  0,
	[condit]             nvarchar(max) ,
	[cost]               float  NOT NULL DEFAULT  0,
	[outdated]           bit  NOT NULL DEFAULT  0,
	PRIMARY KEY  ([id_price]),
	 FOREIGN KEY ([id_serv]) REFERENCES [Service]([id_serv])
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO [Price] ([id_serv], [member_min], [member_max], [accom_count], [cost]) VALUES
(1, 11, 15, 1, 31500),
(1, 16, 20, 2, 38500),
(1, 21, 30, 2, 40000),
(1, 31, 40, 2, 41500),
(1, 41, 45, 2, 43000),
(2, 11, 15, 1, 31500),
(2, 16, 20, 2, 38500),
(2, 21, 30, 2, 40000);


CREATE TABLE [Status]
( 
	[id_stat]            integer  IDENTITY  NOT NULL ,
	[name]               nvarchar(10)  NOT NULL ,
	PRIMARY KEY  ([id_stat])
);
INSERT INTO [Status] ([name]) VALUES
(N'Оформлен'),
(N'Оплачен'),
(N'Выполнен'),
(N'Отменен');

CREATE TABLE [Ordr]
( 
	[id_ordr]            integer  IDENTITY  NOT NULL ,
	[school]             nvarchar(50)  NOT NULL ,
	[id_group]           integer  NOT NULL ,
	[party_count]        integer  NOT NULL ,
	[accom_count]        integer  NOT NULL DEFAULT  0,
	[contact]            nvarchar(50)  NOT NULL ,
	[date_time]          datetime  NOT NULL ,
	[meet_point]         nvarchar(20)  NOT NULL ,
	[cost]               float  NULL ,
	[prepay]             float  NULL ,
	[id_price]           integer  NOT NULL ,
	[id_stat]            integer  NOT NULL ,
	[id_emp]             nvarchar(15)  NULL ,
	PRIMARY KEY  ([id_ordr]),
	 FOREIGN KEY ([id_price]) REFERENCES [Price]([id_price])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	 FOREIGN KEY ([id_group]) REFERENCES [Age]([id_group])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	 FOREIGN KEY ([id_stat]) REFERENCES [Status]([id_stat])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,		
	 FOREIGN KEY ([id_emp]) REFERENCES [Employee]([id_emp])
		ON DELETE SET NULL
		ON UPDATE CASCADE
);

CREATE TABLE [AddServ_Ordr]
( 
	[id_add]             integer  NOT NULL ,
	[id_ordr]            integer  NOT NULL ,
	[add_count]          integer  NOT NULL DEFAULT  1,
	PRIMARY KEY  ([id_add],[id_ordr]),
	 FOREIGN KEY ([id_add]) REFERENCES [AddServ]([id_add])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	 FOREIGN KEY ([id_ordr]) REFERENCES [Ordr]([id_ordr])
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
