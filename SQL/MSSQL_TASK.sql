SELECT 
	p.name as ProductName,
	c.name as CategoryName 
FROM products p
LEFT JOIN categoriesToProducts cp on cp.product_pk = p.primarykey
LEFT JOIN categories c ON c.primarykey = cp.category_pk

-- Data for testing (Has been tested on https://sqliteonline.com/)
CREATE TABLE categories (
  primarykey INT PRIMARY KEY IDENTITY (1, 1),
  name VARCHAR(100) NOT NULL
);

INSERT INTO categories (name) VALUES
  ('Import production'),
  ('Suitable for pets'),
  ('Drinks');

CREATE TABLE products (
  primarykey INT PRIMARY KEY IDENTITY (1, 1),
  name VARCHAR(100) NOT NULL
);

INSERT INTO products (name) VALUES
  ('Whiskas'),
  ('Water Arkhyz'),
  ('Milk Domik v derevne'),
  ('Meow-vkusno'),
  ('Chips Russian potato'),
  ('Chips LAYS');
  
CREATE TABLE categoriesToProducts (
  category_pk INT,
  product_pk INT
);

INSERT INTO categoriesToProducts (category_pk, product_pk) VALUES
  (1, 1),
  (1, 6),
  (2, 1),
  (2, 2),
  (2, 4),
  (3, 2),
  (3, 3)