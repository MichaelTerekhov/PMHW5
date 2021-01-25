create or replace function insert_user( _first_name_ varchar(128), _last_name_ varchar(128))
  returns void as
  $body$
      begin
        insert into users(first_name, last_name)
        values (_first_name_,_last_name_);
      end;
  $body$
  language 'plpgsql' volatile
  cost 100;