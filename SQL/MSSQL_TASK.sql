CREATE TABLE categories (
  primarykey INT PRIMARY KEY IDENTITY (1, 1),
  name VARCHAR(100) NOT NULL
);

INSERT INTO categories (name) VALUES ('Import production'), ('Suitable for pets'), ('Drinks');

CREATE TABLE products (
  primarykey INT PRIMARY KEY IDENTITY (1, 1),
  name VARCHAR(100) NOT NULL,
  category_pk INT
);

INSERT INTO products (name, category_pk) VALUES
  ('Whiskas', 1),
  ('Whiskas', 2),
  ('Water Arkhyz', 1),
  ('Water Arkhyz', 2),
  ('Water Arkhyz', 3),
  ('Milk Domik v derevne', 3),
  ('Meow-vkusno', 2),
  ('Chips Russian potato', null),
  ('Chips LAYS', 1);
  
SELECT 
	p.name as ProductName,
	c.name as CategoryName 
FROM products p
LEFT JOIN categories c ON c.primarykey = p.category_pk

-- Has been tested on https://sqliteonline.com/