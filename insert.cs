using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

await using var db = NpgsqlDataSource.Create(dbUri);


await using (var cmd = db.CreateCommand(@"
insert into customer (email, name, surname, phone_number, date_of_birth) values ('gevesque0@cocolog-nifty.com', 'Hejsan', 'Evesque', '+86 (202) 561-3911', '1998-07-14')")) ;

/*
insert into customer (email, name, surname, phone_number, date_of_birth) values ('gevesque0@cocolog-nifty.com', 'Gipsy', 'Evesque', '+86 (202) 561-3911', '1998-07-14');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('rpassmore1@tinypic.com', 'Ronald', 'Passmore', '+855 (222) 134-2219', '1956-12-10');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('mpakeman2@upenn.edu', 'Mallorie', 'Pakeman', '+7 (201) 491-4208', '1988-02-07');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('bbulfoy3@bizjournals.com', 'Benedicta', 'Bulfoy', '+86 (757) 835-3299', '1947-10-26');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('ocostard4@instagram.com', 'Ora', 'Costard', '+30 (517) 213-8096', '1970-09-08');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('fcorbyn5@springer.com', 'Frasquito', 'Corbyn', '+33 (319) 839-1449', '1977-08-06');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('mkilford6@stanford.edu', 'Maximilien', 'Kilford', '+86 (505) 258-9011', '1931-10-15');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('sbatman7@geocities.jp', 'Stearne', 'Batman', '+86 (456) 316-3227', '1998-02-14');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('hburnell8@cbc.ca', 'Haleigh', 'Burnell', '+504 (744) 682-8634', '1968-05-12');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('oyockley9@miibeian.gov.cn', 'Opaline', 'Yockley', '+58 (196) 572-7553', '1938-03-12');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('obezarraa@blog.com', 'Oralie', 'Bezarra', '+970 (191) 854-9994', '1950-08-24');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('hfilipputtib@51.la', 'Huey', 'Filipputti', '+55 (333) 161-7773', '1979-12-30');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('mdebrettc@networkadvertising.org', 'Melisse', 'De Brett', '+62 (470) 644-2641', '1946-11-01');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('glimprichtd@nydailynews.com', 'Garfield', 'Limpricht', '+62 (480) 385-8887', '1943-08-22');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('sruppe@bloomberg.com', 'Sol', 'Rupp', '+62 (113) 155-4284', '1931-05-25');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('kalveyf@fotki.com', 'Kalinda', 'Alvey', '+62 (984) 618-7395', '1942-05-29');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('chilaryg@gnu.org', 'Chev', 'Hilary', '+27 (322) 583-5586', '2003-12-23');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('cdevitth@vk.com', 'Conan', 'Devitt', '+7 (831) 971-0900', '1982-03-07');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('amelmorei@pbs.org', 'Amery', 'Melmore', '+48 (225) 190-1561', '1999-05-08');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('sgisckenj@sciencedirect.com', 'Selestina', 'Giscken', '+234 (341) 283-3513', '1983-01-02');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('cwhitebrookk@ed.gov', 'Corina', 'Whitebrook', '+63 (230) 283-9278', '1968-07-07');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('smartijnl@about.me', 'Selinda', 'Martijn', '+228 (788) 489-4884', '1962-02-09');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('zsleightholmm@purevolume.com', 'Zia', 'Sleightholm', '+46 (178) 973-1121', '1992-05-28');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('jsisleyn@tinyurl.com', 'Jami', 'Sisley', '+375 (634) 247-6172', '1974-10-03');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('ljacquemardo@infoseek.co.jp', 'Lazare', 'Jacquemard', '+47 (142) 520-6979', '1963-05-03');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('mvasiltsovp@sphinn.com', 'Michale', 'Vasiltsov', '+52 (230) 222-3022', '1967-12-20');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('loldfordq@mozilla.com', 'Lara', 'Oldford', '+86 (991) 644-8158', '1931-04-02');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('claurentinr@wp.com', 'Constantine', 'Laurentin', '+351 (395) 640-0788', '1940-06-08');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('ssandilandss@columbia.edu', 'Sam', 'Sandilands', '+351 (307) 459-3677', '1966-11-30');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('hreadert@redcross.org', 'Heath', 'Reader', '+62 (260) 658-7612', '1964-05-13');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('bleucharsu@wikia.com', 'Bobette', 'Leuchars', '+33 (411) 486-2492', '1998-09-12');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('btirrellv@gmpg.org', 'Bryna', 'Tirrell', '+46 (982) 741-6960', '1959-02-13');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('bashlingw@wiley.com', 'Bridget', 'Ashling', '+55 (943) 840-5460', '1966-12-19');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('smalamx@berkeley.edu', 'Stephi', 'Malam', '+93 (852) 177-9396', '1956-05-05');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('jsandfordy@blogger.com', 'Josey', 'Sandford', '+93 (619) 707-0009', '1945-10-28');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('bborrottz@fda.gov', 'Berky', 'Borrott', '+62 (858) 579-4617', '1981-08-16');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('kantliff10@adobe.com', 'Koral', 'Antliff', '+675 (167) 390-1279', '1986-12-09');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('whounsome11@google.co.uk', 'Whitman', 'Hounsome', '+86 (491) 340-6302', '1966-12-26');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('charroll12@weather.com', 'Cully', 'Harroll', '+1 (691) 479-3569', '1992-02-27');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('amcmickan13@bravesites.com', 'Agnesse', 'McMickan', '+95 (432) 510-1486', '1989-02-05');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('mworthy14@nyu.edu', 'Murdock', 'Worthy', '+62 (899) 825-5348', '1977-09-03');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('gcanham15@omniture.com', 'Grantham', 'Canham', '+7 (640) 694-8765', '1984-08-26');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('hsammars16@archive.org', 'Hugh', 'Sammars', '+63 (700) 868-0839', '1935-10-02');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('ccosin17@paypal.com', 'Cathyleen', 'Cosin', '+33 (903) 178-1958', '1943-02-10');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('llipyeat18@bloglovin.com', 'Livvyy', 'Lipyeat', '+33 (124) 622-8431', '1934-05-29');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('mtriplett19@nature.com', 'Marj', 'Triplett', '+55 (583) 111-4686', '1956-05-25');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('ashelborne1a@de.vu', 'Aila', 'Shelborne', '+48 (367) 307-3920', '1989-06-26');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('cmauger1b@quantcast.com', 'Chaddy', 'Mauger', '+62 (562) 122-1258', '2001-05-27');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('lgeorgiades1c@timesonline.co.uk', 'Leticia', 'Georgiades', '+30 (268) 302-7539', '1973-12-19');
insert into customer (email, name, surname, phone_number, date_of_birth) values ('lmaghull1d@cocolog-nifty.com', 'Lindsy', 'Maghull', '+1 (336) 240-4609', '1982-09-10');
*/