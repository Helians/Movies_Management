/*Tables*/

CREATE TABLE Actor(
ActorId INT IDENTITy(1000,1) PRIMARY KEY,
ActorName CHAR(50) NOT NULL,
ActorSex CHAR(1) NOT NULL,
ActorBio VARCHAR(200) NOT NULL,
ActorDOB DATE NOT NULL,
CHECK(ActorSex IN('M','F'))
)

CREATE TABLE Producer(
ProducerId INT IDENTITy(3000,1) PRIMARY KEY,
ProducerName CHAR(50) NOT NULL,
ProducerSex CHAR(1) NOT NULL,
ProducerBio VARCHAR(200) NOT NULL,
ProducerDOB DATE NOT NULL,
CHECK(ProducerSex IN('M','F'))
);

CREATE TABLE Movie(
MovieId INT IDENTITy(5000,1) PRIMARY KEY,
MovieName CHAR(50) NOT NULL,
MoviePoster VARCHAR(200) NOT NULL,
MoviePlot VARCHAR(MAX) NOT NULL,
MovieYearOfRelease INT NOT NULL,
ProducerId INT FOREIGN KEY REFERENCES Producer(ProducerId)
);

CREATE TABLE ActorMovie(
ActorId INT FOREIGN KEY REFERENCES Actor(ActorId),
MovieId INT FOREIGN KEY REFERENCES Movie(MovieId),
Primary Key (ActorId,MovieId)
);

/*Raw Data*/

INSERT INTO Actor VALUES('Sunil Shetty','M','I was a Body builder','12-23-1990');
INSERT INTO Actor VALUES('Priyanka Chopra','F','I am Beautiful','12-23-1998');
INSERT INTO Actor VALUES('Alia Bhatt','F','I am Dumb','11-9-1990');
INSERT INTO Actor VALUES('Akshay Kumar','M','Martial Art','10-20-1980');
INSERT INTO Actor VALUES('Salman Khan','M','I am a Body builder','12-23-1970');

INSERT INTO Producer VALUES('Sanjay Lila Bansali','M','Great Producer','12-23-1990');
INSERT INTO Producer VALUES('Mukesh Bhatt','M','Producer','12-23-1998');

INSERT INTO Movie VALUES('Race3','http://www.bollywoodlife.com/wp-content/uploads/2018/03/DZJwM-FXkAAv-ZL-768x1024.jpg','Thriller',1990,3000);
INSERT INTO Movie VALUES('Bajrangi Bhaijan','http://media.glamsham.com/download/poster/images/bajrang-bhaijaan/05-bajrang-bhaijaan.jpg','Emotional',2014,3001);

Select * from Actor
select * from Movie

INSERT INTO ActorMovie VALUES(1000,5001);
INSERT INTO ActorMovie VALUES(1001,5001);
INSERT INTO ActorMovie VALUES(1000,5002);
INSERT INTO ActorMovie VALUES(1002,5001);

