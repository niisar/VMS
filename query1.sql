select * from visitors order by VisitorID desc;
select * from inouts order by id desc;;


delete from inouts where id  between 32 and 900;
update InOuts set OutTime = null;

-- delete from Visitors where [vehicle] is null;