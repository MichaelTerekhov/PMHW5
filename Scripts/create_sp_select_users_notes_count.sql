create or replace function select_note(_note_id uuid)
returns table(id uuid, header varchar, body varchar, is_deleted boolean, last_modified timestamp with time zone, user_id int, first_name varchar, last_name varchar) as
    $$
        select notes.id,notes.header,notes.body,notes.is_deleted,notes.modified_at,notes.user_id,users.first_name,users.last_name
        from notes join users on notes.user_id = users.id
        where notes.id = _note_id;
    $$
language sql volatile ;