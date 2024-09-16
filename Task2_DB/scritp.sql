-- Создаем таблицы
-- Таблица "Products" (Продукты):
CREATE TABLE public.products (
	product_id bigserial NOT NULL,
	product_name varchar(300) NOT NULL,
	description text NULL,
	price numeric DEFAULT 0 NOT NULL,
	quantity_in_stock int4 DEFAULT 0 NOT NULL,
	CONSTRAINT products_pk PRIMARY KEY (product_id)
);

-- Таблица "Users" (Пользователи):
CREATE TABLE public.users (
	user_id  bigserial NOT NULL,
	user_name varchar(500) NOT NULL,
	email varchar(100) NOT NULL,
	registration_date timestamptz DEFAULT now() NOT NULL,
	CONSTRAINT usesrs_pk PRIMARY KEY (user_id)
);

-- Таблица "Orders" (Заказы):
CREATE TABLE public.orders (
	order_id bigserial NOT NULL,
	user_id int8 NOT NULL,
	status int4 DEFAULT 0 NOT NULL,
	order_date timestamptz DEFAULT now() NOT NULL,
	CONSTRAINT orders_pk PRIMARY KEY (order_id)
);

-- Таблица "OrderDetails" (Детали заказа):
CREATE TABLE public.order_details (
	order_detail_id bigserial NOT NULL,
	order_id int8 NOT NULL,
	product_id int8 NOT NULL,
	quantity int4 DEFAULT 0 NOT NULL,
	total_cost numeric DEFAULT 0 NOT NULL,
	CONSTRAINT order_details_pk PRIMARY KEY (order_detail_id)
);

-- Связь между "Users" и "Orders"
ALTER TABLE public.orders ADD CONSTRAINT fk_orders_user_id_users_user_id FOREIGN KEY (user_id) REFERENCES public.users(user_id);

-- Связь между "Orders" и "OrderDetails"
ALTER TABLE public.order_details ADD CONSTRAINT fk_order_details_order_detail_id_orders_order_id FOREIGN KEY (order_id) REFERENCES public.orders(order_id);

-- Связь между "Products" и "OrderDetails"
ALTER TABLE public.order_details ADD CONSTRAINT fk_order_details_order_detail_id_products_product_id FOREIGN KEY (product_id) REFERENCES public.products(product_id);

-- Заполняем тестовыми данными
INSERT INTO public.products
(product_name, description, price, quantity_in_stock) VALUES
( 'Продукт  1', 'Описание продукта 1', 5, 15),
( 'Продукт  2', 'Описание продукта 2', 15, 10),
( 'Продукт  3', 'Описание продукта 3', 50, 8),
( 'Продукт  4', 'Описание продукта 4', 10, 1),
( 'Продукт  5', 'Описание продукта 5', 105, 25),
( 'Продукт  6', 'Описание продукта 6', 17, 35),
( 'Продукт  7', 'Описание продукта 7', 8, 45);


INSERT INTO public.users
(user_name, email, registration_date) VALUES
('Иванов Иван Иванович', 'ivanovii@example.com', now()),
('Петров Петр Петрович', 'petrovpp@example.com', now()),
('Сидоров Аркадий Харитонович', 'sidorovah@example.com', now());


INSERT INTO public.orders
(user_id, order_date, status)values
((select user_id from public.users where email like 'ivanov%'), '2024-09-01 09:30:25.988 +0300', 1),
((select user_id from public.users where email like 'ivanov%'), '2024-09-16 12:30:25.988 +0300', 0),
((select user_id from public.users where email like 'petrov%'), '2024-09-08 19:04:48.008 +0300', 1),
((select user_id from public.users where email like 'sidorov%'), '2024-09-14 23:48:55.012 +0300', 1);


INSERT INTO public.order_details
(order_id, product_id, quantity, total_cost)
values
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'ivanov%' and o.order_date::date = '2024-09-01'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  1'), 
2, 
(SELECT price*2 as price FROM public.products where product_name like 'Продукт  1')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'ivanov%' and o.order_date::date = '2024-09-01'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  2'), 
4, 
(SELECT price*4 as price FROM public.products where product_name like 'Продукт  2')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'ivanov%' and o.order_date::date = '2024-09-16'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  7'), 
10, 
(SELECT price*10 as price FROM public.products where product_name like 'Продукт  7')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'ivanov%' and o.order_date::date = '2024-09-16'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  4'), 
2, 
(SELECT price*2 as price FROM public.products where product_name like 'Продукт  4')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'ivanov%' and o.order_date::date = '2024-09-16'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  3'), 
1, 
(SELECT price*1 as price FROM public.products where product_name like 'Продукт  3')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'petrov%' and o.order_date::date = '2024-09-08'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  2'), 
3, 
(SELECT price*3 as price FROM public.products where product_name like 'Продукт  2')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'petrov%' and o.order_date::date = '2024-09-08'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  4'), 
3, 
(SELECT price*3 as price FROM public.products where product_name like 'Продукт  4')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'sidorov%' and o.order_date::date = '2024-09-14'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  6'), 
5, 
(SELECT price*5 as price FROM public.products where product_name like 'Продукт  6')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'sidorov%' and o.order_date::date = '2024-09-14'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  7'), 
1, 
(SELECT price*1 as price FROM public.products where product_name like 'Продукт  7')),
((SELECT order_id
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'sidorov%' and o.order_date::date = '2024-09-14'::date), 
(SELECT product_id FROM public.products where product_name like 'Продукт  5'), 
8, 
(SELECT price*8 as price FROM public.products where product_name like 'Продукт  5'))
;


-- SQL запросы

-- Добавление нового продукта
INSERT INTO public.products (product_name, description, price, quantity_in_stock) VALUES
( 'Продукт  8', 'Описание продукта 8', 0.5, 55);

-- Обновление цены продукта
UPDATE public.products SET price=1 WHERE product_name='Продукт  8';

-- Выбор всех заказов определенного пользователя
select u.user_name, o.order_id, o.order_date, o.status 
FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.user_name = 'Иванов Иван Иванович';

-- Расчет общей стоимости заказов
select u.user_name, o.order_date, otc.order_id, otc.total_cost from 
(SELECT od.order_id, sum(od.total_cost) as total_cost
FROM public.order_details od
group by od.order_id) otc
inner join public.orders o on o.order_id = otc.order_id 
inner join public.users u on o.user_id = u.user_id
order by o.order_date asc;

-- Расчет общей стоимости определенного заказа
select u.user_name, o.order_date, otc.order_id, otc.total_cost from 
(SELECT od.order_id, sum(od.total_cost) as total_cost
FROM public.order_details od
where od.order_id = (
SELECT order_id FROM public.orders o inner join public.users u on o.user_id = u.user_id 
where u.email like 'ivanov%' and o.order_date::date = '2024-09-01'::date)
group by od.order_id) otc
inner join public.orders o on o.order_id = otc.order_id 
inner join public.users u on o.user_id = u.user_id
order by o.order_date asc;

-- Подсчет количества товаров на складе
select sum(quantity_in_stock) as total_products_count FROM public.products;

-- Получение 5 самых дорогих товаров
SELECT * FROM public.products order by price desc limit 5;

-- Список товаров с низким запасом (менее 5 штук)
SELECT * FROM public.products where quantity_in_stock < 5;

