CREATE TABLE [dbo].[admin]
(
	username varchar(50) primary key,password varchar(50)
)
insert into admin values('admin','admin');

CREATE TABLE [dbo].[student] (
    [Id]         INT          NOT NULL,
    [stu_name]   VARCHAR (40) NULL,
    [stu_batch]  VARCHAR (30) NULL,
    [stu_stream] VARCHAR (40) NULL,
    [stu_email]  VARCHAR (30) NULL,
    [stu_mno]    VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([stu_name]) REFERENCES [dbo].[student_register] ([username])
);


insert into student values(1,'parmod','2018','IT','parmod@gmail.com','67878787878');
insert into student values(2,'gurpreet','2018','IT','gurpreet@gmail.com','89878787878');


CREATE TABLE [dbo].[student_register] (
    [username] VARCHAR (40) NOT NULL,
    [password] VARCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([username] ASC)
);


insert into student_register values('parmod','123');
insert into student_register values('gurpreet','123');