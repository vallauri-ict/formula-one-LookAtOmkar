ALTER TABLE[Circuit] ADD CONSTRAINT[Fk_Circuit_Race] FOREIGN KEY([id]) REFERENCES[Race]([circuit_id]);
ALTER TABLE[Circuit] ADD CONSTRAINT[Fk_Circuit_Country] FOREIGN KEY([country]) REFERENCES[Country]([countryCode]);
ALTER TABLE[Team] ADD CONSTRAINT[Fk_Team_Country] FOREIGN KEY([nationCode]) REFERENCES[Country]([countryCode]);
ALTER TABLE[Driver] ADD CONSTRAINT[Fk_Driver_Country] FOREIGN KEY([countryCode]) REFERENCES[Country]([countryCode]);
ALTER TABLE[Driver] ADD CONSTRAINT[Fk_Driver_Team] FOREIGN KEY([teamCode]) REFERENCES[Team]([teamCode]);



