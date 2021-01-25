create or replace function update_note_mark_deleted(_note_id uuid)
  returns void as
  $body$
      begin
        update notes
          set is_deleted = true , modified_at = current_timestamp
          where notes.id = _note_id;
      end;
  $body$
  language 'plpgsql' volatile
  cost 100;
