ALTER TABLE[dbo].[Race] WITH CHECK ADD CONSTRAINT[Race_Circuit] FOREIGN KEY([circuit_id]) REFERENCES[dbo].[Circuit]([circuitCode]);
ALTER TABLE[dbo].[Circuit] WITH CHECK ADD CONSTRAINT[Circuit_Country] FOREIGN KEY([country]) REFERENCES[dbo].[Country]([countryCode]);
ALTER TABLE[dbo].[Team] WITH CHECK ADD CONSTRAINT[Team_Country] FOREIGN KEY([nationCode]) REFERENCES[dbo].[Country]([countryCode]);
ALTER TABLE[dbo].[Driver] WITH CHECK ADD CONSTRAINT[Driver_Country] FOREIGN KEY([countryCode]) REFERENCES[dbo].[Country]([countryCode]);
ALTER TABLE[dbo].[Driver] WITH CHECK ADD CONSTRAINT[Driver_Team] FOREIGN KEY([teamCode]) REFERENCES[dbo].[Team]([teamCode]);



