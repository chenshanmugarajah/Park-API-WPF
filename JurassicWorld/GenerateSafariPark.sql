use master

drop database if exists SafariParkDB

create database SafariParkDB
go

use SafariParkDB

create table Park (
	ParkId int not null identity(1,1) primary key,
	ParkName nvarchar(50),
	ParkDescription nvarchar(50),
	ParkLocation nvarchar(50),
	ParkCapacity int
)

insert into Park values ('Jurassic World', 'Theme park and luxury resort', 'Isla Nublar', 2000)
insert into Park values ('Jurassic Park', 'Original park', 'Isla Nublar', 500)
insert into Park values ('Paradise Wildlife Park', 'Exotic wildlife and animal experience park', 'Broxbourne', 400)

create table Animal (
	AnimalId int not null identity(1,1) primary key,
	AnimalName nvarchar(50),
	AnimalFact nvarchar(255),
	AnimalWeightTons decimal,
	AnimalDiet nvarchar(50),
	AnimalImage nvarchar(2083),
	ParkId int references Park(ParkId)
)

insert into Animal values ('Tyrannosaurus Rex', 'The Tyrannosaurus rex can bite with a force of 12,800 pounds.', 9,'Carnivore', 'https://vignette.wikia.nocookie.net/jurassicpark/images/f/f8/T-Rex.png/revision/latest?cb=20141128030334', 1)
insert into Animal values ('Triceratops', 'The skull of triceratops was one-third the length of its entire body', 12, 'Herbivore', 'https://vignette.wikia.nocookie.net/jurassicworld-evolution/images/9/96/Trikethumb.png/revision/latest?cb=20190817153424', 2)
insert into Animal values ('Tiger', 'Largest extant cat species and a memeber of the genus Panthera', 0.3, 'Carnivore', 'https://i.pinimg.com/originals/90/9a/43/909a4354eeb243a200772e0b0a841c50.png', 3)

