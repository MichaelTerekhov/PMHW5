create table users
(
    id serial primary key unique ,
    first_name varchar(128) not null,
    last_name  varchar(128) not null
);