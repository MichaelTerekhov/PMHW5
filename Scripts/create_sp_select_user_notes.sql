create or replace function select_users_notes(_user_id int)
returns table(id uuid, header varchar, body varchar, is_deleted boolean, user_id int ,last_modified timestamp with time zone)
as
    $$
        select *
        from notes
        where notes.user_id = _user_id and notes.is_deleted = false;
    $$
language sql volatile ;