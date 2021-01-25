create table notes
(
    id uuid primary key unique ,
    header varchar(128) not null,
    body varchar(1024) not null,
    is_deleted boolean not null default false,
    user_id int references users(id) not null,
    modified_at timestamp with time zone not null default current_timestamp
);

create index ind on notes (modified_at);