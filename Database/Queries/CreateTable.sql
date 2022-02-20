CREATE TABLE IF NOT EXISTS messages_tb (
	idMessage int AUTO_INCREMENT PRIMARY KEY, 
	message  varchar(255),
	idReference int,
	referenceDateTime DATETIME,
	createDateTime DATETIME,
	updateDateTime DATETIME
);