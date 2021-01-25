create or replace function insert_note(_id uuid, _header varchar(128), _body varchar(1024),_is_deleted_ boolean , _user_id int)
  returns void as
  $body$
      begin
        insert into notes(id, header, body, is_deleted, user_id)
        values (_id,_header,_body,_is_deleted_,_user_id);
      end;
  $body$
  language 'plpgsql' volatile
  cost 100;