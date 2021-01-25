select * from notes;
select * from users;

select insert_user('Michael','Terekhov');
select insert_user('Dmitry','Maximov');

select * from users;

create extension if not exists "uuid-ossp"; --If we want to randomly generate even uuid

select insert_note('255a9bba-5e89-11eb-ae93-0242ac130002','test','This is test body',1);
select insert_note('255aa2a4-5e89-11eb-ae93-0242ac130002','test1','This is test1 body',1);
select insert_note('255aa420-5e89-11eb-ae93-0242ac130002','test2','This is test2 body',1);
select insert_note('255aa4f2-5e89-11eb-ae93-0242ac130002','test3','This is test3 body',2);
select insert_note('255aa5c4-5e89-11eb-ae93-0242ac130002','test','This is test body',2);

select * from notes;

select * from select_note('255a9bba-5e89-11eb-ae93-0242ac130002');
select * from select_note('255aa4f2-5e89-11eb-ae93-0242ac130002');

select update_note_mark_deleted('255a9bba-5e89-11eb-ae93-0242ac130002');
select update_note_mark_deleted('255aa4f2-5e89-11eb-ae93-0242ac130002');

select * from notes;

select * from select_users_notes_count()

select * from select_users_notes(1);
