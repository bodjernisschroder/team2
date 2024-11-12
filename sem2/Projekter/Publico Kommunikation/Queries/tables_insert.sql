--Insert values 

INSERT INTO CLASSTEMPLATE (ClassTemplateId, RelatedId, Description)
VALUES
(1, 101, 'First class template'),
(2, 102, 'Second class template'),
(3, 103, 'Third class template');
GO

--Insert values for CATEGORY table 
INSERT INTO CATEGORY (CategoryId, CategoryName) VALUES ('Strategi');--1
INSERT INTO CATEGORY (CategoryId, CategoryName) VALUES ('Indhold');--2
INSERT INTO CATEGORY (CategoryId, CategoryName) VALUES ('Digital Marketing');--3
INSERT INTO CATEGORY (CategoryId, CategoryName) VALUES ('Film');--4
GO

--Insert values for PRODUCT table - Strategi
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('AI-workshop', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Analyse', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Befolkningsundersøgelser', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Brand-positionering', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Brugerundersøgelser', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('EB-sparring', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Employee advocacy', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Employer branding', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Employer branding-strategi', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('ESG-rapportering', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Implementering af EVP-koncept', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Interessentanalyse', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Interviews', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Issues management', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kendskabsundersøgelse', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kernefortælling', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Klippekort på sparring', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kommunebranding', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kommunikationsmåling', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kommunikationsplan', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kommunikationsrådgivning', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kommunikationsstrategi', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kriseberedskab', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Krisekommunikation', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kunderejse', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Marketingstrategi', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Medarbejderundersøgelser', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Omdømmeanalyse', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Personas', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Projektledelse', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('PR-indsats', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('PR-strategi', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Rekrutteringskampagne', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Rekrutteringskommunikation', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Retainer på strategi', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Strategisk rebranding', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Strategiworkshop', 1);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Tone of voice', 1);
GO

--Insert values for PRODUCT table - Indhold
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Adfærds- og holdningskampagner', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Adfærdsanalyse', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Adfærdsdesign', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Artikler', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Blogindlæg', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Brand-guide', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Budskabstræning', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Bæredygtighedskommunikation', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Content offer', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Content plan', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('CSR-rapporter', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Debatindlæg', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Indhold til sociale medier', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Informationskampagner', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kampagne-PR', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Klumme', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Medieovervågning', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Medietræning', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Nyt website', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Oversættelse af tekster', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Pressemeddelelser', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Proaktiv og reaktiv pressekontakt', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Projektledelse', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Retainer på content', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Thought leadership', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Udvikling af kreative koncepter', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Visuel identitet', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Webtekster', 2);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Årsrapporter', 2);
GO

--Insert values for PRODUCT table - Digital marketing
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Account Based Marketing', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Assistance til ActiveCampaign, Mailchimp osv.', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Digital strategi', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('E-mail kursus', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('E-mail marketing', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('E-mail marketnig audit', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Facebook-annoncering', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Google Ads-annoncering', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('HubSpot-assistance', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('HubSpot-onboarding', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Inbound marketing', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Instagram-annoncering', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Klippekort på teknisk support', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('LinkedIn-annoncering', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('LinkedIn-workshop', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Marketing automation', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Pinterest-annoncering', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Projektledelse', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Retainer på annoncering', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('SEO', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Snapchat-annoncering', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Social listening', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('SoMe-strategi', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('SoMe-workshop', 3);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Twitch-annoncering', 3);
GO

--Insert values for PRODUCT table - Film
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Animationsfilm', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Brandfilm', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Case-film', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('E-learning film', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Employer branding-film', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Filmoptagelser', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Interne film', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kampagnefilm', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Klipning', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Kursus i filmklip', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Manuskript', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Produktfilm', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Projektledelse', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Storyboard', 4);
INSERT INTO PRODUCT (ProductName, CategoryId) VALUES ('Webinarproduktion', 4);
GO