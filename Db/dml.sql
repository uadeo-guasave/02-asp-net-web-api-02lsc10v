-- ejecutar desde la terminal dentro de sqlite
insert into books (amazon_id,filename,image_url,title,author,category_id)
select amazon_id,filename,image_url,title,author,category_id
from libros;

insert into categories
select distinct category_id,category_name from libros;

select a.title,b.name
from books a
join categories b
on a.category_id = b.id
limit 10;