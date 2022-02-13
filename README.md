### Skolan vill kunna ta fram en översikt över all personal där det framgår namn och vilka befattningar dem har samt hur många år de har arbetat på skolan. Administratören vill också ha möjlighet att spara ny personal.
SELECT Förnamn + ' ' + Efternamn as Namn, Befattning, DATEDIFF(Year,tblPersonal.AnställningsDatum,getdate()) as "Anställningstid i antal år"
FROM tblPersonal
inner join tblBefattning on tblBefattning.BefattningId = tblPersonal.PersonalId

INSERT INTO tblPersonal(Förnamn,Efternamn,BefattningId,Månadslön,AnställningsDatum)
VALUES ('Kenta','Agenta',1,20000,getdate())



### Vi vill spara elever och se vilken klass de läser i. Vi vill kunna spara betyg för en elev i varje kurs de läst och vi vill kunna se vilken lärare som satt betyget. Betyg ska också ha ett datum som de sats.
select tblElev.Förnamn +' '+ tblElev.Efternamn as Elev, tblKlass.KlassNamn as Klass, tblKurs.KursNamn,
tblElev_Kurs.BetygSiffra,
tblPersonal.Förnamn +' '+ tblPersonal.Efternamn as Lärare, tblElev_Kurs.DatumBetyg from tblElev_Kurs
inner join tblElev on tblElev.ElevId = tblElev_Kurs.ElevId
inner join tblKurs on tblKurs.KursId = tblElev_Kurs.KursId
inner join tblPersonal on tblPersonal.PersonalId = tblKurs.LärareId
inner join tblKlass on tblKlass.KlassId = tblElev.KlassId
order by tblElev.Förnamn


### Hur mycket betalar respektive avdelning ut i lön varje månad?
SELECT Befattning,
(SUM(Månadslön)) as 'Total Månadslön För Avdelning'
From tblPersonal
inner join tblBefattning on tblBefattning.BefattningId = tblPersonal.BefattningId
group by tblBefattning.Befattning


### Hur mycket är medellönen för de olika avdelningarna?
SELECT Befattning,
(SUM(Månadslön)/count(Månadslön)) as 'Medellönen För Avdelning'
From tblPersonal
inner join tblBefattning on tblBefattning.BefattningId = tblPersonal.BefattningId
group by tblBefattning.Befattning


### Skapa en Stored Procedure som tar emot en id och returnerar
viktig information om den eleven som är registrerad på det id.*/
CREATE PROCEDURE StudentInfo @ElevId int
AS
SELECT * FROM tblElev
Where ElevId = @ElevId
GO

EXEC StudentInfo @ElevId = 4

### Sätt betyg på en elev med att använda Transactions i fall något går fel */
BEGIN TRY
BEGIN TRANSACTION
INSERT INTO tblElev_Kurs(ElevId,KursId,DatumBetyg,Betyg)
VALUES('18','2',GETDATE(),'G')
COMMIT TRANSACTION
PRINT 'Transaction Commited'
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Transaction Rolled Back'
END CATCH

