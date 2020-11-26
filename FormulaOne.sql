CREATE TABLE `Driver` (
  `driverNumber` int PRIMARY KEY,
  `driverName` varchar(255),
  `driverSurname` varchar(255),
  `teamCode` char,
  `countryCode` char,
  `winNumber` int,
  `worldChampionshipNumber` int,
  `img` varchar(255)
);

CREATE TABLE `Team` (
  `teamCode` char PRIMARY KEY,
  `teamFullName` varchar(255),
  `teamChief` varchar(255),
  `teamPowerUnit` varchar(255),
  `teamFirstEntryYear` int,
  `teamHQPlace` varchar(255),
  `nationCode` char,
  `logo` varchar(255),
  `img` varchar(255)
);

CREATE TABLE `Country` (
  `countryCode` char PRIMARY KEY,
  `countryName` varchar(255)
);

CREATE TABLE `Circuit` (
  `id` char PRIMARY KEY,
  `name` varchar(255),
  `country` char,
  `length` int,
  `laps_number` int,
  `turns_number` int,
  `first_race_year` char,
  `fastest_lap` varchar(255),
  `full_image` varchar(255),
  `small_image` varchar(255)
);

CREATE TABLE `Race` (
  `id` int PRIMARY KEY,
  `name` varchar(255),
  `circuit_id` char
);

ALTER TABLE `Driver` ADD FOREIGN KEY (`teamCode`) REFERENCES `Team` (`teamCode`);

ALTER TABLE `Driver` ADD FOREIGN KEY (`countryCode`) REFERENCES `Country` (`countryCode`);

ALTER TABLE `Race` ADD FOREIGN KEY (`circuit_id`) REFERENCES `Circuit` (`id`);

ALTER TABLE `Team` ADD FOREIGN KEY (`nationCode`) REFERENCES `Country` (`countryCode`);

ALTER TABLE `Circuit` ADD FOREIGN KEY (`country`) REFERENCES `Country` (`countryCode`);
